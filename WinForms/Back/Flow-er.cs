using NavGraphTools;

namespace WinForms.Tools;

class Flow_er
{
    private NavGraph? NG = null;

    private int _Progress = 0;

    //probably doesn't work great, but it's not critical so oh well
    private int _ProgressUpdate
    {
        get => _Progress;
        set
        {
            Interlocked.Increment(ref _Progress);
            Progress?.Invoke(this, new ProgressEvent(_Progress));
        }
    }

    public event EventHandler<ProgressEvent> Progress;


    public Flow_er(ref NavGraph _NG)
    { NG = _NG; }

    public Flow_er() { }

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

    private void Flow(int _UID)
    {
        //SpecialNode UID
        int SN_UID = _UID, CurrentUID = 0, VisitedUIDs = 0, Distance = 0;
        int IsEN = NG[_UID] is ElevationNode ? 0 : 1;
        NodeDirection BackDir;
        bool Done = false; ;

        Queue<(NodeDirection Dir, int UID, int Distance)> NodesToReturnTo = new Queue<(NodeDirection Dir, int UID, int Distance)>();
        Dictionary<NodeDirection, int> ConnNodes = null;

        NavNode CurNode = NG[SN_UID];

        while (!Done)
        {
            ConnNodes = CurNode.GetConnectedNodes()
                .Where(X => (VisitedUIDs & X.Value) != X.Value)
                .Where(X => NG[X.Value] is ISpecialFlow)
                .ToDictionary(X => X.Key, Y => Y.Value);

            if (ConnNodes.Count() == 0 && NodesToReturnTo.Count == 0)
            { Done = true; break; }
            else if (ConnNodes.Count() >= 1)
            {
                if (!ConnNodes.First().Value.IsValidUID())
                { break; }

                CurNode = NG[ConnNodes.First().Value];
                BackDir = (NodeDirection)((int)ConnNodes.First().Key * -1);

                ISpecialFlow ISF_CurNode = (ISpecialFlow)CurNode;

                Distance++;

                if (ISF_CurNode.Flow[IsEN].ContainsKey(BackDir))
                { ISF_CurNode.Flow[IsEN][BackDir].Add((SN_UID, Distance)); }
                else
                { ISF_CurNode.Flow[IsEN].Add(BackDir, new() { (SN_UID, Distance) }); }

                VisitedUIDs = VisitedUIDs | CurNode.UID;

                if (ConnNodes.Count == 1)
                {
                    //If there's only 1 connection, what do?
                    //EN-Main connects to CN-01, what do now?

                    //CurNode = NG[ConnNodes.First().Value];
                }
                else
                {
                    foreach (var R_Node in ConnNodes.Where(X => X.Value != CurNode.UID && X.Value.IsValidUID()))
                    { NodesToReturnTo.Enqueue((R_Node.Key, R_Node.Value, Distance)); }
                }
            }
            else if (NodesToReturnTo.Count > 1)
            {
                if (!NodesToReturnTo.Peek().UID.IsValidUID())
                { break; }

                (NodeDirection Dir, int UID, int Distance) T = NodesToReturnTo.Dequeue();

                CurNode = NG[T.UID];
                BackDir = (NodeDirection)((int)T.Dir * -1);
            }
        }

        _ProgressUpdate++;
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
