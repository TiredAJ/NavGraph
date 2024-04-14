using NavGraphTools;

namespace WinForms.Back;

class Stats_er
{
    private NavGraph NG = null;

    public Stats_er(ref NavGraph _NG)
    { NG = _NG; }

    public async Task<Stats> GetStats()
    {
        Stats Sts = new();

        Sts.AllNodes = await CountAllNodes();
        Sts.CN = await CountSpecificNodes<CorridorNode>();
        Sts.EN = await CountSpecificNodes<ElevationNode>();
        Sts.RN = await CountSpecificNodes<RoomNode>();
        Sts.GW = await CountSpecificNodes<GatewayNode>();

        Sts.Tags = NG.Tags;

        Sts.AverageENDistance = await AverageDistanceFromEN();
        Sts.AverageGWDistance = await AverageDistanceFromGW();

        Sts.Connections = await CountConnections();

        Sts.IsolatedNodes = await IsolatedNodeCount();

        Sts.Flows = await CountFlows();

        return Sts;
    }

    private async Task<int> CountAllNodes()
    { return NG.CountNodes(); }

    private async Task<int> CountSpecificNodes<T>() where T : NavNode
    {
        return await Task.Run(int () =>
        {
            return NG
                    .GetAllNodes()
                    .Where(X => X.Value is T)
                    .Count();
        });
    }

    private async Task<int> CountConnections()
    {
        return await Task.Run(int () =>
        {
            int Count = 0;

            foreach (var N in NG.GetAllNodes().Values)
            { Count += N.ConnectedNodesCount; }

            return Count;
        });
    }

    private async Task<int> CountConnections<T>() where T : NavNode
    {
        return await Task.Run(int () =>
        {
            int Count = 0;
            IEnumerable<NavNode> Nodes = NG.GetAllNodes()
                                            .Select(X => X.Value)
                                            .Where(X => X is T);

            foreach (var N in Nodes)
            { Count += N.ConnectedNodesCount; }

            return Count;
        });
    }

    private async Task<(int Count, IEnumerable<NavNode>? Nodes)> IsolatedNodeCount()
    {
        return await Task.Run((int Count, IEnumerable<NavNode>? Nodes) () =>
        {
            List<NavNode> IsolatedNodes = new();

            foreach (var N in NG.GetAllNodes().Values)
            {
                if (N.ConnectedNodesCount == 0)
                { IsolatedNodes.Add(N); }
            }

            if (IsolatedNodes.Count == 0)
            { return (0, null); }
            else
            { return (IsolatedNodes.Count, IsolatedNodes); }
        });
    }

    private async Task<double> AverageDistanceFromEN()
    {
        return await Task.Run(double () =>
        {
            List<int> Distances = new();

            foreach (var N in NG.GetAllNodes().Values)
            {
                if (N is not ISpecialFlow ISF || ISF.Flow is null)
                { continue; }

                foreach (var L in (N as ISpecialFlow).Flow.Values)
                {
                    if (L is null)
                    { continue; }
                    else
                    {
                        foreach (var T in L.Values)
                        {
                            if (T.IsEN)
                            { Distances.Add(T.Distance); }
                        }
                    }
                }
            }

            return Distances.Average();
        });
    }

    private async Task<double> AverageDistanceFromGW()
    {
        return await Task.Run(double () =>
        {
            List<int> Distances = new();

            foreach (var N in NG.GetAllNodes().Values)
            {
                if (N is not ISpecialFlow ISF || ISF.Flow is null)
                { continue; }

                foreach (var L in (N as ISpecialFlow).Flow.Values)
                {
                    if (L is null)
                    { continue; }
                    else
                    {
                        foreach (var T in L.Values)
                        {
                            if (!T.IsEN)
                            { Distances.Add(T.Distance); }
                        }
                    }
                }
            }

            return Distances.Average();
        });
    }

    private async Task<int> CountFlows()
    {
        int Count = 0;

        var ISFs = NG
                                    .GetAllNodes()
                                    .Select(X => X.Value)
                                    .Where(X => X is ISpecialFlow ISF && 
                                        ISF.Flow is not null)
                                    .Cast<ISpecialFlow>();

        foreach (var I in ISFs)
        {
            foreach (var KVP in I.Flow)
            { Count += KVP.Value.Count(); }
        }

        return Count;
    }
}

public struct Stats
{
    public int AllNodes, RN, EN, GW, CN;
    public int Connections, Flows;
    public Dictionary<string, int> Tags;
    public (int Count, IEnumerable<NavNode>? Nodes) IsolatedNodes;
    public double AverageENDistance, AverageGWDistance;
}