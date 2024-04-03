﻿using NavGraphTools;
using NavGraphTools.Utilities;
using System.Diagnostics;

namespace WinForms.Tools;
/*
 * Uh, this might move to just NavGraph, really doesn't belong here
 */

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
    private Queue<int> SpecialNodes = new();
    private HashSet<int> ExclusionSet = new();
    private IEnumerable<int> SpecialNodesPerm;
    private Dictionary<NodeDirection, int> ConnNodes = null;
    private NavNode CurrentNode = null, PrevNode = null, ISP_Node = null;
    private NodeDirection BackDir;
    private int Distance = 0, IsEN = 0, ISP_UID = 0;
    //                          ^ T
    private ISpecialFlow FlowNode = null;

    public event EventHandler<ProgressEvent> Progress;

    #endregion

    #region Constructors
    public Flow_er(ref NavGraph _NG)
    { NG = _NG; }

    public Flow_er() { }

    #endregion


    //
    // Function names beyond this point aren't gonna mean much without
    // referring to Flower_er-Labelled.jpg in the repo
    //

    public void GenerateFlows()
    {
        if (NG is null)
        { throw new NullReferenceException("NG was null!"); }

        SpecialNodes = new Queue<int>(NG.GetAllNodes()
            .Select(X => X.Value)
            .Where(X => X is ISpecialNode)
            .Select(X => X.UID));

        SpecialNodesPerm = SpecialNodes.ToArray();

        Progress?.Invoke(this,
                    new ProgressEvent(SpecialNodesPerm.Count(), 0, 0));

        Task.Run(() =>
        {
            try
            { DauBwyntB(); }
            catch (Exception EXC)
            { MessageBox.Show($"uh oh: {EXC.Message}"); }
        });
    }

    //(1)
    private void Un()
    {
        //(2.A)
        if (!NG.DoesNodeExist(ISP_UID) || NG[ISP_UID].NoUpDownCount() == 0)
        { DauBwyntB(); }

        ISP_Node = NG[ISP_UID];

        //(1)
        //This is used for the index of ISpecialFlow.Flow[]
        IsEN = ISP_Node is ElevationNode ? 0 : 1;

        Flow(ISP_UID);
    }

    //(2.B)
    private void DauBwyntB()
    {
        ExclusionSet.Clear();

        if (SpecialNodes.Count == 0)
        {
            Debug.WriteLine("Done!");

            Progress?.Invoke(this, new ProgressEvent(true));

            return;
        }

        ISP_UID = SpecialNodes.Dequeue();

        ExclusionSet = new HashSet<int>(SpecialNodesPerm);
        Distance = 0;

        Un();

        _ProgressUpdate++;
    }

    private void Flow(int _SP_UID)
    {
        //(3)
        if (ISP_Node.NoUpDownCount() > 1)
        {
            //(4.B)
            foreach (var KVP in GetFlowNodes(ISP_Node).NoUpDownSkip(1))
            { Backlog.Enqueue((KVP.Key, KVP.Value, Distance)); }
        }

        //(4.A)
        var CN = GetFlowNodes(ISP_Node).NoUpDownFirst();

        if (!NG.DoesNodeExist(CN.Value) || NG[CN.Value] is not ISpecialFlow)
        { PopBacklog(); return; }

        CurrentNode = NG[CN.Value];

        Distance++;
        BackDir = CN.Key.Inverse();
        FlowNode = CurrentNode as ISpecialFlow;
        FlowNode.Add(IsEN, BackDir, ISP_UID, Distance);

        ExclusionSet.Add(CN.Value);

        Pump();
    }

    //(5)
    private void Pump()
    {
        if (GetFlowNodes(CurrentNode).ExclusionCount(ExclusionSet) >= 1)
        { Wyth(); }
        else
        { PopBacklog(); }
    }

    private void Wyth()
    {
        PrevNode = CurrentNode;

        var CN = GetFlowNodes(PrevNode)
                                            .First(ExclusionSet);

        if (!NG.DoesNodeExist(CN.Value) || NG[CN.Value] is not ISpecialFlow)
        { throw new Exception("not sure what to do from here"); }

        CurrentNode = NG[CN.Value];
        BackDir = CN.Key.Inverse();
        Distance++;

        FlowNode = CurrentNode as ISpecialFlow;
        FlowNode.Add(IsEN, BackDir, ISP_UID, Distance);

        /*
         * Issue here, because current node is added to the exclusion list,
         * then PrevNode is checked for non-excluded nodes.
         * In Flow_er-Test.png, this happens when travelling south from 817.
         * 821 is connected to 819 (prev-prev), 822 (current) and 826 (untouched)
         * Because 822 gets added to ExclusionSet, when checked, 821 only has 1
         * unexcluded node, so it gets skipped and ignored. Thinking we add
         * CurrentNode to the ExclusionSet *after* checking connection count
         * just before Naw() is called.
         */


        //ExclusionSet.Add(CN.Value);

        if (GetFlowNodes(PrevNode).ExclusionCount(ExclusionSet) > 1)
        {
            ExclusionSet.Add(CN.Value);
            Naw();
            return;
        }
        else
        {
            ExclusionSet.Add(CN.Value);
            Pump();
            return;
        }
    }

    public void Naw()
    {
        foreach (var KVP in
                            GetFlowNodes(PrevNode)
                                .Skip(ExclusionSet, 1))
        {
            if (!NG.DoesNodeExist(KVP.Value) || NG[KVP.Value] is not ISpecialFlow)
            { continue; }

            Backlog.Enqueue((KVP.Key, KVP.Value, Distance));
        }

        /*if (CurrentNode.ExclusionCount(ExclusionSet) == 0)
        { PopBacklog(); }
        else
        {*/
        Pump(); /*}*/
    }

    private void PopBacklog()
    {
        //(6)
        if (Backlog.Count == 0)
        {
            DauBwyntB();
            return;
        }

        //(7)
        var Tn = Backlog.Dequeue();

        if (!NG.DoesNodeExist(Tn.UID) || NG[Tn.UID] is not ISpecialFlow)
        { PopBacklog(); return; }

        CurrentNode = NG[Tn.UID];
        BackDir = (NodeDirection)((int)Tn.Dir * -1);
        Distance = Tn.Distance;
        FlowNode = CurrentNode as ISpecialFlow;
        FlowNode.Add(IsEN, BackDir, ISP_UID, Distance);

        ExclusionSet.Add(Tn.UID);

        Pump();
    }

    private IEnumerable<KeyValuePair<NodeDirection, int>> GetFlowNodes(NavNode _N)
    { return _N.GetConnectedNodes().Where(X => NG.TryGetNode(X.Value) is ISpecialFlow); }
}

public class ProgressEvent : EventArgs
{
    public int Max, Min, Current;
    public bool InitEvent, Done = false;

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

    public ProgressEvent(bool _Done)
    { Done = _Done; }
}
