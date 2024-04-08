namespace NavGraphTools.Utilities;

public class Path_er
{
    private NavGraph NG = null;
    private NavNode Origin, Destination, Current, Temporary;
    private Path_erStages _Stage = Path_erStages.None;
    private List<int> Path = new();

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

    public Path_er(ref NavGraph _NG)
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

        if (Origin.BlockName == Destination.BlockName)
        { Tri(); return; }
        else
        { DauBwyntA(); return; }
    }

    private void DauBwyntA()
    {
        var Floor = NG.GetNodes(Origin.BlockName, Origin.Floor);

        if (Floor.Any(X => X.Value is GatewayNode))
        { /*travel to different floor*/ }

        //var Gateways = Floor
        //        .Where(X => X.Value is GatewayNode GN &&
        //            NG.);


    }



    private void DauBwyntB()
    { }

    private void Tri()
    { }

    private void TriBwyntA()
    { }

    private void TriBwyntB()
    { }

    private void TriBwyntC()
    { }

    private void Pedwar()
    { }

    private void PedwarBwyntA()
    { }

    private void PumpBwyntA()
    { }

    private void PumpBwyntB()
    { }

    private int Negotiate(ISpecialFlow _A, ISpecialFlow _B)
    { throw new NotImplementedException(); }
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