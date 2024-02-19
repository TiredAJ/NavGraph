// Ignore Spelling: Nav Dest

namespace NavGraphTools.Navigation;

public class Navigator
{
    Queue<UserDirections> Path_Dir = new Queue<UserDirections>();
    Stack<int> Path_Nodes = new Stack<int>();
    Stack<int> Pre_PathNodes = new Stack<int>();

    public void StartNavigation()
    {
    }
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
