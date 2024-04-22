using System.Diagnostics;

namespace NavGraphTools.Utilities;

public class Path_er
{
    private ReadonlyNavGraph NG = null;
    private NavNode Origin, Destination, Current, Temporary;
    private Path_erStages _Stage = Path_erStages.None;
    private List<(NodeDirection, int)> Path = new();
    private GatewayNode DestGW;

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
        Dictionary<NodeDirection, ISpecialFlow> ISFs;

        ISFs = GetISF(Origin);

        if (ISFs.First().Key == 0)
        {//Origin is alread an ISF

        }
        else
        {

        }




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

    private void DauBwyntB()
    {
        var BlockGWs = NG
                                            .GetBlock(Origin.BlockName)
                                            .Where(X => X is GatewayNode)
                                            .Select(X => X)

        if (true)
        {

        }
    }

    private void DauBwyntBUn(IEnumerable<NavNode> _GWs)
    {

    }
    #endregion

    #region Tri
    private void Tri()
    {
        if (Current.Floor == Destination.Floor)
        { Pedwar(); return; }
        else
        { TriBwyntA(); return; }
    }

    private void TriBwyntA()
    {
        //gets all the ENGroupIDs on the floor the gateway current will enter through
        List<int> DestGWFloorENs = NG.GetFloor(Destination.BlockName, DestGW.Floor)
                                        .Select(X => (X.Value as ElevationNode).ENGroupID)
                                        .ToList();

        //gets all the ENGroupIDs on the floor of the destination node
        List<int> DestFloorENs = NG.GetFloor(Destination.BlockName, Destination.Floor)
                                        .Select(X => (X.Value as ElevationNode).ENGroupID)
                                        .ToList();

        //Finds common ENGroupIDs
        List<int> SuitableENGroups = DestFloorENs.Intersect(DestGWFloorENs).ToList();

        //gets the ENs on C's floor that are in the suitability list
        DestGWFloorENs = DestGWFloorENs
                            .Where(X => SuitableENGroups
                                .Contains((NG[X] as ElevationNode).ENGroupID))
                            .ToList();

        var ISF = GetISF(DestGW)
                                                    .Select(X => (X.Key, X.Value))
                                                    .First();

        var ChosenEN = ISF.Value.GetElevationNodes()
                        .ToDictionary(X => X.Key,
                                        Y => Y.Value
                            .ToDictionary(X => NG[X.Key], Y => Y.Value)
                            .OrderBy(X => X.Value)
                            .Select(X => (X.Key, X.Value))
                            .First())
                        .OrderBy(X => X.Value.Value)
                        .Select(X => (X.Key, X.Value.Key, X.Value.Value))
                        .First();
    }

    private void TriBwyntB()
    { }

    private void TriBwyntC()
    { }
    #endregion

    #region Pedwar
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
    #endregion

    #region Misc
    private int Negotiate(ISpecialFlow _A, ISpecialFlow _B)
    { throw new NotImplementedException(); }

    private Dictionary<NodeDirection, ISpecialFlow>? GetISF(int _UID, int? _Floor = null, string? _Block = null)
    {
        NavNode? N;

        return NG.TryGetNode(_UID, out N) ? GetISF(N, _Floor, _Block) : null;
    }

    private Dictionary<NodeDirection, ISpecialFlow>? GetISF(NavNode? _N, int? _Floor = null, string? _Block = null)
    {
        if (_N is null)
        { return null; }
        else if (_N is ISpecialFlow ISF)
        { return new Dictionary<NodeDirection, ISpecialFlow>() { { 0, ISF } }; }
        else
        {
            var Conns = NG
                        .GetConnectedNodes(_N, true)
                        .Where(X => X.Value is ISpecialFlow);

            if (_Floor is not null)
            { Conns = Conns.Where(X => X.Value.Floor == _Floor); }

            if (_Block is not null)
            { Conns = Conns.Where(X => X.Value.BlockName == _Block); }

            return Conns.ToDictionary(X => X.Key, Y => Y.Value as ISpecialFlow);
        }
    }
    #endregion
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