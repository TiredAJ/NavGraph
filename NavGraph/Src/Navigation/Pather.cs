using NavGraphTools.Utilities;
using System.Diagnostics;

namespace NavGraphTools.Navigation;

public class Pather
{
    #region Variables
    private NavNode? _Origin = null, _Destination = null;

    private NavNode? Origin
    {
        get => _Origin;
        set
        {
            _Origin = value;

            Initialised = IsInitialised();
        }
    }
    private NavNode? Destination
    {
        get => _Destination;
        set
        {
            _Destination = value;

            Initialised = IsInitialised();
        }
    }
    private NavNode? CurrentLocation = null;
    private ReadonlyNavGraph NG;
    private bool Initialised = false;

    //states
    //private bool IsSFloor = false;
    //private bool IsSBlock = false;
    //private bool IsSGFloor = false;
    #endregion

    public Pather
        (ref ReadonlyNavGraph _NG, NavNode _D, NavNode _O)
    {
        NG = _NG;
        Destination = _D;
        Origin = _O;

        Initialised = true;
    }

    public Pather
        (ref ReadonlyNavGraph _NG, int _D, int _O)
    {
        NG = _NG;

        if (!NG.TryGetNode(_D, out _Destination))
        { throw new NullReferenceException("Node was null!"); }

        if (!NG.TryGetNode(_O, out _Origin))
        { throw new NullReferenceException("Node was null!"); }

        Destination = NG.TryGetNode(_D);
        Origin = NG.TryGetNode(_O);

        Initialised = true;
    }

    public Pather(ref ReadonlyNavGraph _NG)
    { NG = _NG; }

    public NavigatorErrors Start()
    {
        if (!Initialised)
        { return NavigatorErrors.NotInitialised; }
        else if (Origin == null || Destination == null)
        { return NavigatorErrors.NullNodes; }

        throw new NotImplementedException();
    }

    private bool NavigateToGateway(NavNode _SubOrigin)
    { throw new NotImplementedException(); }

    private bool NavigateToElevation(NavNode _SubOrigin)
    { throw new NotImplementedException(); }

    public bool IsInitialised()
    {
        if (_Origin != null && _Destination != null)
        { return true; }
        else
        { return false; }
    }

    /// <summary>
    /// Follows the flow until something
    /// </summary>
    /// <param name="Predicate">The 'something' that stops the flow</param>
    /// <param name="_SubOrigin">The starting point</param>
    /// <param name="_ElvFlow">Whether to follow Elevation flow (true) or Gateway flow (false)</param>
    /// <param name="_MillisecondTimeout">NOT IMPLEMENTED - how long until it just gives up</param>
    /// <returns></returns>
    public List<int> SlideUntil
        (Predicate<NavNode> Predicate, NavNode _SubOrigin,
        bool _ElvFlow, long _MillisecondTimeout)
    {
        Stopwatch SW = new Stopwatch();
        NavNode Position = _SubOrigin;
        List<int> SubPath = new List<int>();
        int PosUID = 0;
        bool Reached = false;

        throw new NotImplementedException();
        return SubPath;
    }

    public enum NavigatorErrors
    {
        None = 0,
        NullNodes = 1,
        NotInitialised = 2,
    }
}
