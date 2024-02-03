using System.Diagnostics;

namespace NavGraphTools.Navigation;

public class Pather
{
    #region Variables
    private NavNode? Origin { get; set; } = null;
    private NavNode? Destination { get; set; } = null;
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
        NG = NG;
        Destination = _D;
        Origin = _O;
    }

    public NavigatorErrors Start()
    {
        if (!Initialised)
        { return NavigatorErrors.NotInitialised; }
        else if (Origin == null || Destination == null)
        { return NavigatorErrors.NullNodes; }

        if (Origin.BlockName != Destination.BlockName)
        { NavigateToGateway(Origin); }
        else if (Origin.Floor != Destination.Floor)
        { NavigateToElevation(Origin); }

        throw new NotImplementedException();
    }

    private bool NavigateToGateway(NavNode _SubOrigin)
    {
        if (_SubOrigin is IGatewayFlow IGF && IGF.GatewayFlowDirection == null)
        { /*check neighbours*/ }
        else if (_SubOrigin is IGatewayFlow)
        { SlideUntil(X => X is GatewayNode, _SubOrigin, false, 10000); }

        throw new NotImplementedException();
    }

    private bool NavigateToElevation(NavNode _SubOrigin)
    {
        if (_SubOrigin is IElevationFlow IEF && IEF.ElvFlowDirection == null)
        { /*check neighbours*/ }
        else if (_SubOrigin is IElevationFlow)
        { SlideUntil(X => X is GatewayNode, _SubOrigin, false, 10000); }

        throw new NotImplementedException();
    }

    /// <summary>
    /// Follows the flow until something
    /// </summary>
    /// <param name="Predicate">The 'something' that stops the flow</param>
    /// <param name="_SubOrigin">The starting point</param>
    /// <param name="_ElvFlow">Whether to follow Elevation flow (true) or Gateway flow (false)</param>
    /// <param name="_MillisecondTimeout">NOT IMPLEMENTED - how long until it just gives up</param>
    /// <returns></returns>
    private List<int> SlideUntil
        (Predicate<NavNode> Predicate, NavNode _SubOrigin,
        bool _ElvFlow, long _MillisecondTimeout)
    {
        Stopwatch SW = new Stopwatch();
        NavNode Position = _SubOrigin;
        List<int> SubPath = new List<int>();
        int PosUID = 0;
        bool Reached = false;

        while (SW.ElapsedMilliseconds < _MillisecondTimeout && !Reached)
        {
            if (_ElvFlow && Position is IElevationFlow IEF && IEF.ElvFlowDirection != null)
            { PosUID = Position.GetNode((NodeDirection)IEF.ElvFlowDirection); }
            else if (!_ElvFlow && Position is IGatewayFlow IGF && IGF.GatewayFlowDirection != null)
            { PosUID = Position.GetNode((NodeDirection)IGF.GatewayFlowDirection); }

            if (Predicate(NG.TryGetNode(PosUID)))
            {
                SubPath.Add(PosUID);
                return SubPath;
            }
            else
            {
                Position = NG.TryGetNode(PosUID);

                if (Position == null)
                { throw new Exception("NodeWasNull?"); }
            }
        }

        return SubPath;
    }

    public enum NavigatorErrors
    {
        None = 0,
        NullNodes = 1,
        NotInitialised = 2,

    }
}
