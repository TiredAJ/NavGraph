using NavGraphTools;
using Windows.ApplicationModel.Store;

namespace WinForms.Tools;

class Flow_er
{
    #region Member Variables
    private NavGraph? NG = null;

    private int _Progress = 0;

    //probably doesn't work great, but it's not critical so oh well
    private int _ProgressUpdate
    {
        get => _Progress;
        set
        {
            Progress?.Invoke(this, new ProgressEvent
                (Interlocked.Increment(ref _Progress)));
        }
    }

    private Queue<(NodeDirection Dir, int UID, int Distance)> Backlog = new();
    private Dictionary<NodeDirection, int> ConnNodes = null;
    private NavNode CurrentNode = null, PrevNode = null;
    private NodeDirection BackDir;
    private int Distance = 0, IsEN = 0, ISP_UID = 0;
    private ISpecialFlow FlowNode = null;

    public event EventHandler<ProgressEvent> Progress;

    #endregion

    #region Constructors
    public Flow_er(ref NavGraph _NG)
    { NG = _NG; }

    public Flow_er() { }

    #endregion

    public void GenerateFlows()
    {
        if (NG is null)
        { throw new NullReferenceException("NG was null!"); }

        List<int> SpecialNodes = NG.GetAllNodes()
            .Select(X => X.Value)
            .Where(X => X is ISpecialNode)
            .Select(X => X.UID)
            .ToList();

        Progress?.Invoke(this, new ProgressEvent(NG.NodeCount, 0, 0));

        Task.Run(() =>
        {
            foreach (var UID in SpecialNodes)
            { Flow(UID); }
        });
    }

    private void Flow(int _SP_UID)
    {
        //SpecialNode UID
        bool Done = false;

        //This is used for the index of ISpecialFlow.Flow[]
        IsEN = NG[_SP_UID] is ElevationNode ? 0 : 1;

        while (!Done)
        {
            //if (Init(SN_UID) == -1)
            //{ Done = true; }


        }

        _ProgressUpdate++;
    }

    //
    // Function names beyond this point relate to steps in the accompanying flowchart
    // (Which'll be added once it's cleaned up)
    //

    private int Init(int _ISP_UID)
    {
        //if (NG.GetConnectedNodes<CorridorNode>(_ISP_UID).Count > 0)
        //{
//
        //}

        throw new NotImplementedException();
    }

    private void PopBacklog()
    {
        var Tn = Backlog.Dequeue();

        CurrentNode = NG[Tn.UID];
        BackDir = (NodeDirection)((int)Tn.Dir * -1);
        Distance = ++Tn.Distance;
        FlowNode = CurrentNode as ISpecialFlow;
        FlowNode.Add(IsEN, BackDir, ISP_UID, Distance);
    }

}

public class ProgressEvent : EventArgs
{
    public int Max, Min, Current;
    public bool InitEvent;

    public ProgressEvent() { }

    public ProgressEvent(int _Max, int _Min, int _StartVal)
    {
        Max = _Max;
        Min = _Min;
        Current = _StartVal;
        InitEvent = true;
    }

    public ProgressEvent(int _Current)
    {
        InitEvent = false;
        Current = _Current;
    }
}
