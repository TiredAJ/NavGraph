﻿// Ignore Spelling: Nav Dest

namespace NavGraphTools.Navigation;

public class Navigator
{
}

public enum UserDirections
{
    TurnLeft,       //turn left in a corridor
    TurnRight,      //turn right in a corridor
    GoForward,      //just go forward
    TurnLeftJunc,   //at a junction, turn left
    TurnRightJunc,  //at a junction, turn right
    GoStraightJunc, //at a junction, go forward
    GoUpFloor,      //go up stairs/elevator
    GoDownFloor     //go down stairs/elevator
}

/*
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

        if (Origin.BlockName != Destination.BlockName)
        { NavigateToGateway(Origin); }
        else if (Origin.Floor != Destination.Floor)
        { NavigateToElevation(Origin); }
        else
        {

        }

        return NavigatorErrors.None;

        //throw new NotImplementedException();
    }

    private bool NavigateToGateway(NavNode _SubOrigin)
    {
        if (_SubOrigin is IGatewayFlow IGF && IGF.GatewayFlowDirection == null)
        { /*check neighbours }
        else if (_SubOrigin is IGatewayFlow)
        { SlideUntil(X => X is GatewayNode, _SubOrigin, false, 10000); }

        throw new NotImplementedException();
    }

    private bool NavigateToElevation(NavNode _SubOrigin)
    {
        if (_SubOrigin is IElevationFlow IEF && IEF.ElvFlowDirection == null)
        { /*check neighbours }
        else if (_SubOrigin is RoomNode)
        {
            var SB_Conn = _SubOrigin
                .GetConnectedNodes();

            int SB_UID = SB_Conn.First().Value;

            if (!NG.TryGetNode((int)SB_UID, out _SubOrigin)
                && _SubOrigin == null && _SubOrigin is not CorridorNode)
            { throw new NullReferenceException("Node was null?"); }

            SlideUntil(X => X is ElevationNode, _SubOrigin, true, 10000);
        }
        else if (_SubOrigin is IElevationFlow)
        { SlideUntil(X => X is ElevationNode, _SubOrigin, true, 10000); }

        return true;

        //throw new NotImplementedException();
    }

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

        while (/*SW.ElapsedMilliseconds < _MillisecondTimeout && !Reached)
        {
            if (_ElvFlow && Position is IElevationFlow IEF && IEF.ElvFlowDirection != null)
            { PosUID = Position.GetNode((NodeDirection)IEF.ElvFlowDirection); }
            else if (!_ElvFlow && Position is IGatewayFlow IGF && IGF.GatewayFlowDirection != null)
            { PosUID = Position.GetNode((NodeDirection)IGF.GatewayFlowDirection); }

#if DEBUG
            Console.WriteLine($"{Position.InternalName} {(Position as IElevationFlow).ElvFlowDirection.ToArrow()}");
#endif

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

*/