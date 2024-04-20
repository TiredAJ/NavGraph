using System.Diagnostics;

namespace NavGraphTools.Utilities;

public class Path_er
{
    private ReadonlyNavGraph NG = null;
    private NavNode Origin, Destination, Current, Temporary;
    private Path_erStages _Stage = Path_erStages.None;
    private List<(NodeDirection, int)> Path = new();

    public Path_erStages Stage
    {
        get => _Stage;
        internal set
        {
            Progress?.Invoke(this, new PatherProgressEvent
                (value));
        }
    }

    public event EventHandler<PatherProgressEvent> Progress;

    public Path_er(ref ReadonlyNavGraph _NG)
    { NG = _NG; }

    public void Start(NavNode _Origin, NavNode _Destination)
    {
        if (!NG.DoesNodeExist(_Origin) || !NG.DoesNodeExist(_Destination))
        { throw new Exception("Either _Origin or _Destination does not exist!"); }

        Origin = _Origin;
        Destination = _Destination;

        _Start();
    }

    public void Start(int _OriginUID, int _DestinationUID)
    {
        NavNode? TO, TD;

        if (!NG.DoesNodeExist(_OriginUID, out TO) || !NG.DoesNodeExist(_DestinationUID, out TD))
        { throw new Exception("Either _OriginUID or _DestinationUID does not exist!"); }

        Origin = TO;
        Destination = TD;

        _Start();
    }

    private void _Start()
    {
        Stage = Path_erStages.Started;

        Temporary = Destination;

        Stage = Path_erStages.Dau;

        //Dau
        if (Origin.BlockName == Destination.BlockName)
        { Current = Origin; Tri(); return; }
        else
        { DauBwynt(); return; }
    }

    #region Dau
    private void DauBwynt()
    {
        ISpecialFlow P;

        IEnumerable<int> GWs_UIDS;
        List<NavNode> GWs_Nodes = new();

        if (Origin is ISpecialFlow ISF && ISF.Connected_GW(out GWs_UIDS))
        {
            GWs_Nodes = GWs_UIDS
                        .Select(X => NG[X])
                        .Where(X => X is not null && X.BlockName == Destination.BlockName)
                        .ToList();

            Debug.WriteLine(GWs_Nodes.First().InternalName);
        }

        //gets the ISFs connected to Origin?
        var ISFNodes = NG.GetNodes<ISpecialFlow>(Origin.Nodes.Values);

        if (ISFNodes.Count() > 0 && ISFNodes.Any(X => X.Connected_GW(out GWs_UIDS)))
        {
        }


        var Block = NG
                                        .GetNodes(Origin.BlockName)
                                        .Select(X => X.Value);

        var Floor = Block
                                        .Where(X => X.Floor == Origin.Floor);

        if (Floor.Any(X => X is GatewayNode GN &&
                GN.IsConnected(Destination.BlockName)))
        {//DauBwyntA
            DauBwyntAUn(Floor.Where(X => X is GatewayNode GN &&
                            GN.IsConnected(Destination.BlockName)));
        }
        else if (Block.Any(X => X is GatewayNode GN &&
                    GN.IsConnected(Destination.BlockName)))
        {//DayBwyntB
            DauBwyntBUn(Block.Where(X => X is GatewayNode GN &&
                            GN.IsConnected(Destination.BlockName)));
        }
        else
        { throw new Exception("Can't escape block!"); }
    }

    private void DauBwyntAUn(IEnumerable<NavNode> _GWs)
    {

    }

    private void DauBwyntBUn(IEnumerable<NavNode> _GWs)
    {

    }
    #endregion

    private void Tri()
    {
        if (Current.Floor == Destination.Floor)
        { Pedwar(); return; }


    }

    private void TriBwyntA()
    { }

    private void TriBwyntB()
    { }

    private void TriBwyntC()
    { }

    private void Pedwar()
    {
        if (Current is not ISpecialNode)
        { PedwarBwyntA(); return; }

    }

    private void PedwarBwyntA()
    { }

    private void PumpBwyntA()
    { }

    private void PumpBwyntB()
    { }

    private int Negotiate(ISpecialFlow _A, ISpecialFlow _B)
    { throw new NotImplementedException(); }

    private ISpecialFlow? GetISF(int _UID, int? Floor = null, string? Block = null)
    {
        NavNode? N;

        return NG.TryGetNode(_UID, out N) ? GetISF(N) : null;
    }

    private ISpecialFlow? GetISF(NavNode? _N, int? Floor = null, string? Block = null)
    {
        if (_N is null)
        { return null; }

        ISpecialFlow ISf;

        if (_N is not ISpecialFlow)
        {
            var Conss = NG
                        .GetConnectedNodes(_N, true)
                        .Where(X => X.Value is ISpecialFlow)
                        .ToDictionary(X => X.Key, Y => (ISpecialFlow)Y.Value);


        }

        if (_N is ISpecialFlow ISF && ISF.Connected_GW(out IEnumerable<int> GWs_UIDS))
        {
            List<NavNode> GWs_Nodes = GWs_UIDS
                                        .Select(X => NG[X])
                                        .Where(X => X is not null && X.BlockName == Destination.BlockName)
                                        .ToList();

            Debug.WriteLine(GWs_Nodes.First().InternalName);
        }
    }
}
public class PatherProgressEvent : EventArgs
{
    public Path_erStages Current = Path_erStages.None, Previous;
    public bool Completed = false;

    public PatherProgressEvent() { }

    public PatherProgressEvent(Path_erStages _Stage)
    {
        Previous = Current;
        Current = _Stage;
    }
    public PatherProgressEvent(bool _Complete)
    {
        Previous = Current;
        Current = _Complete ? Path_erStages.Completed : Path_erStages.Started;

        Completed = _Complete;
    }
}

public enum Path_erStages
{
    None,
    Started,
    Un,
    Dau,
    Tri,
    Pedwar,
    Pump,
    Completed,
    Searching
}