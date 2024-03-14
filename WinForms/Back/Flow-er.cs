using NavGraphTools;

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

    private Queue<(NodeDirection Dir, int UID, int Distance)> NodesToReturnTo = new Queue<(NodeDirection Dir, int UID, int Distance)>();
    private Dictionary<NodeDirection, int> ConnNodes = null;

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
        int SN_UID = _SP_UID, CurrentUID = 0, VisitedUIDs = 0, Distance = 0;
        int IsEN = NG[_SP_UID] is ElevationNode ? 0 : 1;
        NodeDirection BackDir;
        bool Done = false;

        while (!Done)
        {
            if (Init(SN_UID) == -1)
            { Done = true; }


        }

        _ProgressUpdate++;
    }

    //
    // Function names beyond this point relate to steps in the accompanying flowchart
    // (Which'll be added once it's cleaned up)
    //

    private int Init(int _ISP_UID)
    {
        if (NG.GetConnectedNodes<ISpecialNode>(_ISP_UID).Count > 0)
        {
            
        }

        throw new NotImplementedException();
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
