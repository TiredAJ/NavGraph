namespace NavGraphTools.Utilities;

public class Path_er
{
    private ReadonlyNavGraph NG = null;
    private NavNode Origin, Destination, Current, Temporary;
    private Path_erStages _Stage = Path_erStages.None;
    private List<(NodeDirection, NavNode)> Path = new();
    private GatewayNode DestGW;
    private ElevationNode DestEN;

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
        Stage = Path_erStages.Un;

        Temporary = Destination;

        Path.Add((0, Origin));

        Current = Origin;

        //Dau
        Stage = Path_erStages.Dau;

        if (Origin.BlockName == Destination.BlockName)
        { Tri(); return; }
        else
        { DauBwyntA(); return; }
    }

    #region Dau
    private void DauBwyntA()
    {
        NavNode? Skip;

        var Temp = GetFlows(Current, out Skip);

        if (Skip is not null)
        { Path.Add(((NodeDirection)Temp.Value.Dir, Skip)); }

        Current = Skip;

        Dictionary<NodeDirection, (int UID, int Distance)> ReducedISFs = new();

        foreach (var KVP in Temp.Value.Flow.Where(X => X.Value.Any(X => NG[X.Key] is GatewayNode GW && GW.IsConnected(Destination.BlockName))))
        { ReducedISFs.Add(KVP.Key, KVP.Value.OrderBy(X => X.Value.Distance).Select(X => (X.Key, X.Value.Distance)).First()); }

        (NodeDirection Dir, int UID) ChosenGW = ReducedISFs.OrderBy(X => X.Value.Distance).Select(X => (X.Key, X.Value.UID)).First();

        DauBwyntAUn(ChosenGW);
        return;
    }

    private void DauBwyntAUn((NodeDirection Dir, int UID) _GW)
    {
        NavNode LocalCurrent;
        NodeDirection CurDir = 0;

        if (!NG.TryGetNode(Current.GetNode(_GW.Dir), out LocalCurrent))
        { throw new Exception("Node returned null!"); }

        ISpecialFlow LocalCISF = LocalCurrent as ISpecialFlow;

        Path.Add((_GW.Dir, LocalCurrent));

        while (LocalCurrent.UID != _GW.UID)
        {
            CurDir = (NodeDirection)LocalCISF.GetDirection(_GW.UID);

            if (!NG.TryGetNode(LocalCurrent.GetNode(CurDir), out LocalCurrent))
            { throw new Exception("Node returned null!"); }

            LocalCISF = LocalCurrent as ISpecialFlow;

            //Console.WriteLine($"LocalCurrent: {LocalCurrent}");

            Path.Add((CurDir, LocalCurrent));
        }

        Console.WriteLine(LocalCurrent);

        //2.A.2
        DestGW = NG[(LocalCurrent as GatewayNode).Connections[Destination.BlockName].First()] as GatewayNode;

        Current = DestGW;

        Path.Add((0, Current));

        Tri(); return;
    }

    private void DauBwyntB()
    {
        var BlockGWs = NG
                                    .GetBlock(Origin.BlockName)
                                    .Where(X => X.Value is GatewayNode GW &&
                                        GW.IsConnected(Destination.BlockName))
                                    .Select(X => X.Value as GatewayNode);

        if (BlockGWs is not null && BlockGWs.Count() < 1)
        { throw new Exception("No viable exits from Block!"); }
        else
        { DauBwyntBUn(BlockGWs); return; }
    }

    private void DauBwyntBUn(IEnumerable<GatewayNode?> _GWs)
    {

    }
    #endregion

    #region Tri
    private void Tri()
    {
        Stage = Path_erStages.Tri;

        if (Current.Floor == Destination.Floor)
        { Pedwar(); return; }
        else
        { TriBwyntA(); return; }
    }

    private void TriBwyntA()
    {
        FlowToEN(Current, Destination);
        Pedwar(); return;
    }

    private void TriBwyntB()
    { }

    private void TriBwyntC()
    { }
    #endregion

    #region Pedwar
    private void Pedwar()
    {
        Stage = Path_erStages.Pedwar;

        if (Current is not ISpecialNode)
        { PedwarBwyntA(); return; }
        else
        { PumpBwyntA(); return; }
    }

    private void PedwarBwyntA()
    { }
    #endregion

    #region Pump
    private void PumpBwyntA()
    {
        Stage = Path_erStages.Pump;

        //var ISF = GetFlows(Destination);
    }

    private void PumpBwyntB()
    { }
    #endregion

    #region Flow
    /// <summary>
    /// Will flow from the start to the Target, traversing floors (adding to Path).
    /// </summary>
    /// <param name="_Start">Node to start from</param>
    /// <param name="_Target">Node target to flow to</param>
    private void FlowToEN(NavNode _Start, NavNode _Target)
    {
        NodeDirection ElvDir = _Start.Floor < _Target.Floor ? NodeDirection.Up : NodeDirection.Down;
        NodeDirection CurDir = 0;
        NodeDirection SSkip, TSkip;

        NavNode LocalCurrent = _Start;
        NavNode? StartSkip, TargetSkip;

        var StartENGroups = GetFlows(_Start, out StartSkip).Value;

        SSkip = (NodeDirection)StartENGroups.Dir;

        var TargetENGroups = GetFlows(_Target, out TargetSkip).Value;

        TSkip = (NodeDirection)TargetENGroups.Dir;

        #region big lad
        //gets the common Elevation node
        List<int> Common = StartENGroups
                                    .Flow.Values
                                    .SelectMany(X => X)
                                    .OrderBy(X => X.Value.Distance)
                                    .Where(X => X.Value.IsEN)
                                    .Select(X => (NG[X.Key] as ElevationNode).ENGroupID)
                                    .Intersect
                                    (
                                        TargetENGroups.Flow.Values
                                        .SelectMany(X => X)
                                        .OrderBy(X => X.Value.Distance)
                                        .Where(X => X.Value.IsEN)
                                        .Select(X => (NG[X.Key] as ElevationNode).ENGroupID)
                                    )
                                    .ToList();
        #endregion

        Dictionary<NodeDirection, (int UID, int Distance)> ReducedISFs = new();

        foreach (var KVP in StartENGroups.Flow.Where(X => X.Value.Any(X => NG[X.Key] is ElevationNode EN && Common.Contains(EN.ENGroupID))))
        { ReducedISFs.Add(KVP.Key, KVP.Value.OrderBy(X => X.Value.Distance).Select(X => (X.Key, X.Value.Distance)).First()); }

        (NodeDirection Dir, int UID) ChosenEN = ReducedISFs.OrderBy(X => X.Value.Distance).Select(X => (X.Key, X.Value.UID)).First();

        if (!NG.TryGetNode(Current.GetNode(ChosenEN.Dir), out LocalCurrent))
        { throw new Exception("Node returned null!"); }

        ISpecialFlow LocalCISF = LocalCurrent as ISpecialFlow;

        Path.Add((ChosenEN.Dir, LocalCurrent));

        while (LocalCurrent.UID != ChosenEN.UID) //check UID not node
        {
            CurDir = (NodeDirection)LocalCISF.GetDirection(ChosenEN.UID);

            if (!NG.TryGetNode(LocalCurrent.GetNode(CurDir), out LocalCurrent))
            { throw new Exception("Node returned null!"); }

            LocalCISF = LocalCurrent as ISpecialFlow;

            Path.Add((CurDir, LocalCurrent));
        }

        Console.WriteLine($"Current: {Current}");

        //DestEN = NG[(Current as ElevationNode).Nodes[Destination.BlockName].First()] as GatewayNode;

        //Current = DestGW;

        //Path.Add((0, Current));

        //throw new NotImplementedException();
    }

    private void FlowToGW()
    {
        //think this might be handy, also maybe these should return the last node?
    }

    #endregion

    #region Misc
    private int Negotiate(ISpecialFlow _A, ISpecialFlow _B)
    { throw new NotImplementedException(); }

    /// <summary>
    /// Gets the next best ISF from the current node.
    /// </summary>
    /// <param name="_UID">The node UID to get an ISF from</param>
    /// <returns>A tuple of node direction (Dir) and Flow. Dir will be null if the current node is an ISF, otherwise it'll contain the direction to get to the ISF from the inputted node</returns>
    private (NodeDirection?, Dictionary<NodeDirection, Dictionary<int, (int Distance, bool IsEN)>>)? GetFlows(int _UID, out NavNode? _Skip)
    {
        NavNode? N;

        _Skip = null;

        return NG.TryGetNode(_UID, out N) ? GetFlows(N, out _Skip) : null;
    }

    /// <summary>
    /// Gets the next best ISF from the current node.
    /// </summary>
    /// <param name="_N">The node to get an ISF from</param>
    /// <param name="_Skip">If _N isn't an ISF, _Skip is the first connecting ISF node</param>
    /// <returns>A tuple of node direction (Dir) and Flow. Dir will be null if the current node is an ISF, otherwise it'll contain the direction to get to the ISF from the inputted node</returns>
    private (NodeDirection? Dir, Dictionary<NodeDirection, Dictionary<int, (int Distance, bool IsEN)>> Flow)? GetFlows(NavNode? _N, out NavNode? _Skip)
    {
        _Skip = null;

        if (_N is null)
        { return null; }
        else if (_N is ISpecialFlow ISF)
        { return (null, ISF.Flow); }
        else
        {
            var Conn = NG
                        .GetConnectedNodes(_N, true)
                        .Where(X => X.Value is ISpecialFlow)
                        .First();

            //connected ISF node to _N
            _Skip = Conn.Value;

            return (Conn.Key, (Conn.Value as ISpecialFlow).Flow);
        }
    }

    /// <summary>
    /// Gets the flow direction for a specified UID
    /// </summary>
    /// <param name="_N">Node (ISF)</param>
    /// <param name="_UID"></param>
    /// <returns></returns>
    private NodeDirection? GetDirection(NavNode? _N, int _UID)
    {
        if (_N is ISpecialFlow ISF)
        { return GetDirection(ISF, _UID); }
        else
        { return null; }
    }

    private NodeDirection? GetDirection(ISpecialFlow? _ISF, int _UID)
    {
        if (_ISF is ISpecialFlow ISF)
        { return ISF.GetDirection(_UID); }
        else
        { return null; }
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