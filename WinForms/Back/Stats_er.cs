using NavGraphTools;

namespace WinForms.Back;

class Stats_er
{
    private NavGraph NG = null;

    public Stats_er(ref NavGraph _NG)
    { NG = _NG; }

    public async Task<int> CountAllNodes()
    { return NG.CountNodes(); }

    public async Task<int> CountSpecificNodes<T>()
    {
        return NG
                .GetAllNodes()
                .Where(X => X.Value is T)
                .Count();
    }

    public async Task<int> CountConnections()
    {
        int Count = 0;

        foreach (var N in NG.GetAllNodes().Values)
        { Count += N.ConnectedNodesCount; }

        return Count;
    }

    public async Task<int> CountConnections<T>() where T : NavNode
    {
        int Count = 0;
        IEnumerable<NavNode> Nodes = NG.GetAllNodes()
                                        .Select(X => X.Value)
                                        .Where(X => X is T);

        foreach (var N in Nodes)
        { Count += N.ConnectedNodesCount; }

        return Count;
    }

    public async Task<List<string>> CommonTags()
    {
        return NG.Tags.OrderByDescending(X => X.Value)
                        .Take(5)
                        .Select(X => X.Key)
                        .ToList();
    }

    public async Task<(int Count, IEnumerable<NavNode>? Nodes)> IsolatedNodeCount()
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
    }

    public async Task<double> AverageDistanceFromEN()
    {
        List<int> Distances = new();

        foreach (var N in NG.GetAllNodes().Values)
        {
            if (N is not ISpecialFlow)
            { continue; }

            foreach (var L in (N as ISpecialFlow).Flow.Values)
            {
                if (L is null)
                { continue; }
                else
                {
                    foreach (var T in L)
                    {
                        if (T.IsEN)
                        { Distances.Add(T.Distance); }
                    }
                }
            }
        }

        return Distances.Average();
    }

    public async Task<double> AverageDistanceFromGW()
    {
        List<int> Distances = new();

        foreach (var N in NG.GetAllNodes().Values)
        {
            if (N is not ISpecialFlow)
            { continue; }

            foreach (var L in (N as ISpecialFlow).Flow.Values)
            {
                if (L is null)
                { continue; }
                else
                {
                    foreach (var T in L)
                    {
                        if (!T.IsEN)
                        { Distances.Add(T.Distance); }
                    }
                }
            }
        }

        return Distances.Average();
    }
}