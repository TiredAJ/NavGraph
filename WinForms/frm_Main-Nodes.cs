using NavGraphTools;
using System.Diagnostics;
using WinForms.Tools;

namespace WinForms;

public partial class frm_Main : Form
{
    private void txt_PublicName_TextChanged(object sender, EventArgs e)
    { txt_InternalName.Text = txt_PublicName.Text.Trim(); }

    private void btn_Node_Create_Click(object sender, EventArgs e)
    {
        int Result = -1;

        if (cmbx_NodeType.SelectedItem.ToString() == "Elevation")
        { Result = Create_Elevation(); }
        else if (cmbx_NodeType.SelectedItem.ToString() == "Room")
        { Result = Create_Room(); }
        else if (cmbx_NodeType.SelectedItem.ToString() == "Corridor")
        { Result = Create_Corridor(); }
        else if (cmbx_NodeType.SelectedItem.ToString() == "Gateway")
        { Result = Create_Gateway(); }

        if (Result == -1)
        { return; }

        RefreshNodesTree();
        ClearBox(gbx_Node);

        CurNodeUID = 0;

        ResetNC_DGV();

        Filer.SaveBackup(NG);

        GenerateInternalName();
    }

    private void btn_Node_Delete_Click(object sender, EventArgs e)
    {
        if (trvw_Nodes.SelectedNode.Level == 1)
        {//delete all nodes in floor

            foreach (TreeNode TN in trvw_Nodes.SelectedNode.Nodes)
            { DeleteNode(TN.Text.SplitNodeID()); }

        }
        else if (trvw_Nodes.SelectedNode.Level == 2)
        {
            //null node UID check
            if (CurNodeUID == 0)
            { return; }

            DeleteNode(CurNodeUID);

            CurNodeUID = 0;
        }

        RefreshNodesTree();
    }

    private void DeleteNode(int _UID)
    {
        NG.RemoveNode(_UID);
        trvw_Nodes.Nodes.RemoveByKey(_UID.ToString());

        btn_Node_Save.Enabled = false;
        btn_Node_Delete.Enabled = false;

        dgv_NodeConnections.ClearSelection();
    }

    private void btn_Node_Save_Click(object sender, EventArgs e)
    {
        NavNode? TempNode = NG.TryGetNode(CurNodeUID);

        if (TempNode == null)
        { MessageBox.Show("There was an error getting the object to edit"); }

        TempNode.InternalName = txt_InternalName.Text.Trim();

        if (cmbx_BlockSelect.SelectedItem != null)
        { TempNode.BlockName = cmbx_BlockSelect.SelectedItem.ToString(); }

        TempNode.Floor = (int)nud_Node_Floor.Value;

        if (TempNode is CorridorNode CN)
        {
            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
            }
        }
        else if (TempNode is RoomNode RN)
        {
            RN.RoomName = txt_PublicName.Text.Trim();
            RN.Tags = txt_Node_Tags.Text.Split(new[] { ',' }).ToList();

            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
            }
        }
        else if (TempNode is GatewayNode GN)
        {
            //do later, am eeeepy
            //wtf was I supposed to do?
            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectGatewayNodes(CurNodeUID, int.Parse((Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString())); }
            }
        }
        else if (TempNode is ElevationNode EN)
        {
            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectElevationNodes(CurNodeUID, int.Parse((Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString()), (NodeDirection)Row.Tag); }
            }
        }

        NG.SetNode(CurNodeUID, TempNode);

        btn_Node_Save.Enabled = false;
        btn_Node_Delete.Enabled = false;

        RefreshNodesTree();
    }

    private void nud_Node_Floor_ValueChanged(object sender, EventArgs e)
    {
        CurFloor = (int)nud_Node_Floor.Value;
        GenerateInternalName();
    }

    private void cmbx_BlockSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        var Floor = NG.Blocks[cmbx_BlockSelect.SelectedItem.ToString()];

        nud_Node_Floor.Maximum = Floor.Max;
        nud_Node_Floor.Minimum = Floor.Min;

        CurBlock = cmbx_BlockSelect.SelectedItem.ToString();

        GenerateInternalName();
    }

    private void cmbx_NodeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmbx_ElvFlow.Enabled = true;
        cmbx_GWFlow.Enabled = true;

        DGV_ElvDelete();

        if (cmbx_NodeType.SelectedIndex >= 0)
        { dgv_NodeConnections.Enabled = true; }
        else
        { dgv_NodeConnections.Enabled = false; }

        if (cmbx_NodeType.SelectedItem.ToString() == "Elevation")
        {
            dgv_NodeConnections.Rows
                [dgv_NodeConnections.Rows.Add("Up", null, false)]
                .Tag = NodeDirection.Up;

            dgv_NodeConnections.Rows
                [dgv_NodeConnections.Rows.Add("Down", null, false)]
                .Tag = NodeDirection.Down;

            dgv_NodeConnections.Columns[2].Visible = false;

            cmbx_ElvFlow.Enabled = false;

            txt_PublicName.Enabled = false;
        }
        else
        {
            //List<int> RowsToRemove = new List<int>();
            //
            //foreach (DataGridViewRow R in dgv_NodeConnections.Rows)
            //{
            //    if (((NodeDirection)R.Tag == NodeDirection.Up || (NodeDirection)R.Tag == NodeDirection.Down))
            //    { RowsToRemove.Add(R.Index); }
            //}
            //
            //RowsToRemove.Reverse();
            //
            //foreach (var I in RowsToRemove)
            //{ dgv_NodeConnections.Rows.RemoveAt(I); }

            dgv_NodeConnections.Columns[2].Visible = true;

            txt_PublicName.Enabled = true;
        }

        if (cmbx_NodeType.SelectedItem.ToString() == "Room")
        {
            txt_Node_Tags.Enabled = true;
            txt_PublicName.Enabled = true;
            cmbx_GWFlow.Enabled = false;
            cmbx_ElvFlow.Enabled = false;
        }
        else
        {
            txt_Node_Tags.Enabled = false;
            txt_PublicName.Enabled = false;
        }

        if (cmbx_NodeType.SelectedItem.ToString() == "Gateway")
        {
            SetupGW();
            cmbx_GWFlow.Enabled = false;
        }
        else
        {
            pnl_NormalNodes.BringToFront();
            pnl_GW.Visible = false;
        }

        GenerateInternalName();
    }

    private void trvw_Nodes_AfterSelect(object sender, TreeViewEventArgs e)
    {
        NavNode? Temp;

        if (e.Node == null || e.Node.Level != 2)
        { return; }

        CurNodeUID = e.Node.Text.SplitNodeID();

        btn_Delete.Enabled = true;

        //Temp = NG.TryGetNode(CurNodeUID);

        //if (Temp == null)
        //{s
        //    MessageBox.Show("Node returned null!");
        //    return;
        //}

        //txt_InternalName.Text = Temp.InternalName;

        //if (Temp is GatewayNode GN)
        //{
        //    cmbx_NodeType.SelectedItem = "Gateway";

        //    pnl_GW.BringToFront();
        //    pnl_GW.Visible = true;

        //    cmbx_GW_AvailableNodes.Text = GN.GetConnectedNodes().First().Value.ToString();
        //    cmbx_GW_Direction.Text = GN.GetConnectedNodes().First().Key.ToString();

        //    dgv_GatewayConnections.Rows.Clear();

        //    foreach (var KVP in GN.GetConnectedGateways())
        //    { dgv_GatewayConnections.Rows.Add(KVP.Key); }
        //}
        //else
        //{
        //    pnl_NormalNodes.BringToFront();
        //    pnl_GW.Visible = false;
        //}

        //if (Temp is ElevationNode EN)
        //{
        //    cmbx_NodeType.SelectedItem = "Elevation";

        //    foreach (var KVP in EN.GetConnectedNodes())
        //    { dgv_NodeConnections.Rows.Add(KVP.Key, KVP.Value); }
        //}
        //else
        //{
        //    if (Temp is CorridorNode)
        //    { cmbx_NodeType.SelectedItem = "Corridor"; }
        //    else if (Temp is RoomNode RN)
        //    {
        //        cmbx_NodeType.SelectedItem = "Room";
        //        txt_PublicName.Text = RN.RoomName;
        //        txt_Node_Tags.Text = RN.Tags.ElementString();
        //    }

        //    //fix this \/
        //    //still on todo

        //    var NodeConnections = Temp.GetConnectedNodes();

        //    foreach (DataGridViewRow? R in dgv_NodeConnections.Rows)
        //    {
        //        if (R == null)
        //        { continue; }

        //        NodeDirection CellDirection = (NodeDirection)R.Cells[0].Value;

        //        if (NodeConnections.ContainsKey(CellDirection))
        //        {
        //            var DGVCMBX = R.Cells[1] as DataGridViewComboBoxCell;



        //            R.Cells[1].Value = NodeConnections[CellDirection];

        //            if (NodeConnections[CellDirection] < 1)
        //            {
        //                R.Cells[2].Value =
        //            }

        //        }
        //    }


        //    foreach (var KVP in Temp.GetConnectedNodes())
        //    { dgv_NodeConnections.Rows.Add(KVP.Key, new DataGridViewComboBoxCell().Items.Add(KVP.Value)); }

        //    dgv_NodeConnections.Refresh();
        //}

        //gbx_Node.Text = $"Create/Edit Node: {CurNodeUID}";

        //btn_Node_Save.Enabled = true;
        //btn_Node_Delete.Enabled = true;
    }

    private void dgv_NodeConnections_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        Stopwatch SW = new Stopwatch();

        /*
        Task.Run(() =>
        {
            //Filters through all nodes to find ones that aren't connected on the
            //selected direction (and isn't the current GN)
            var AvailableNodes = NG.GetAllNodes()
                .Where
                 (
                    X => X.Value.BlockName == CurBlock
                    && X.Value.Floor == CurFloor
                 )
                .Where
                 (
                    X => X.Key != CurNodeUID &&
                    X.Value.IsAvailable(CurDir)
                 )
                .Select(X => (object)X.Key)
                .ToArray();

            lstbx_AvailableNodes.Invoke(() =>
            {
                lstbx_AvailableNodes.Items.Clear();
                lstbx_AvailableNodes.Items.AddRange(AvailableNodes);
                lstbx_AvailableNodes.Refresh();

                if (NodeEditMode)
                { lstbx_AvailableNodes.SelectedItem = NG.TryGetNode(CurNodeUID).Nodes[CurDir]; }
            });
        });
         */

        //int SelectedIndex = dgv_NodeConnections.SelectedRows[0].Index;

        if (e.RowIndex < 0)
        { return; }

        if (dgv_NodeConnections.Rows[e.RowIndex].Tag != null)
        { CurDir = (NodeDirection)dgv_NodeConnections.Rows[e.RowIndex].Tag; }

        if (e.ColumnIndex == 1)
        {
            SW.Start();

            Task.Run(() =>
            {
                var AvailableNodes = NG.GetAllNodes()
                    .AsParallel()
                    .Where(X => X.Key != CurNodeUID)
                    .Where
                    (
                        X => X.Value.BlockName == CurBlock
                        && X.Value.Floor == CurFloor
                        && X.Value.IsAvailable((NodeDirection)((int)CurDir * -1))
                    )
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();

                dgv_NodeConnections.Invoke(() =>
                {
                    var CMBX = (dgv_NodeConnections.Rows[e.RowIndex]
                                                        .Cells[1]
                                                        as DataGridViewComboBoxCell);

                    if (CMBX != null)
                    {
                        CMBX.Items.Clear();
                        CMBX.Items.AddRange(AvailableNodes);
                    }

                    dgv_NodeConnections.Refresh();
                });
            });

            SW.Stop();
            Debug.WriteLine($"Retrieving Nodes took {SW.ElapsedMilliseconds}ms");
        }
    }

    private void ResetNC_DGV()
    {
        dgv_NodeConnections.ClearSelection();

        foreach (DataGridViewRow R in dgv_NodeConnections.Rows)
        {
            var DGVCBX = R.Cells[1] as DataGridViewComboBoxCell;

            DGVCBX.Items.Clear();
            DGVCBX.Value = null;
        }
    }

    private void dgv_GatewayConnections_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        Stopwatch SW = new Stopwatch();

        if (e.ColumnIndex == 0)
        {
            SW.Start();

            Task.Run(() =>
            {
                var AvailableNodes = NG.GetAllNodes()
                    .AsParallel()
                    .Where(X => X.Key != CurNodeUID)
                    .Where
                    (
                        X => X.Value is GatewayNode GN
                        && !GN.IsConnected(CurNodeUID)
                    )
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();

                dgv_NodeConnections.Invoke(() =>
                {
                    var CMBX = (dgv_GatewayConnections.Rows[e.RowIndex]
                                                                    .Cells[e.ColumnIndex]
                                                                    as DataGridViewComboBoxCell);

                    if (CMBX != null)
                    {
                        CMBX.Items.Clear();
                        CMBX.Items.AddRange(AvailableNodes);
                    }

                    dgv_GatewayConnections.Refresh();
                });
            });

            SW.Stop();
            Debug.WriteLine($"Retrieving Nodes took {SW.ElapsedMilliseconds}ms");
        }
    }

    private int Create_Elevation()
    {
        ElevationNode EN = new ElevationNode();

        EN.BlockName = cmbx_BlockSelect.Text;
        EN.Floor = (int)nud_Node_Floor.Value;
        EN.InternalName = txt_InternalName.Text;
        EN.GatewayFlowDirection = (cmbx_GWFlow.SelectedItem as string).ToDirection();

        CurNodeUID = NG.AddNode(EN);

        foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
        {
            if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
            { NG.ConnectElevationNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag); }
        }

        return 0;
    }

    private int Create_Room()
    {
        RoomNode RN = new RoomNode();

        RN.BlockName = cmbx_BlockSelect.Text;
        RN.Floor = (int)nud_Node_Floor.Value;
        RN.InternalName = txt_InternalName.Text.Trim();
        RN.RoomName = txt_PublicName.Text.Trim();
        RN.Tags = txt_Node_Tags.Text.Split(new[] { ',' }).ToList();

        CurNodeUID = NG.AddNode(RN);

        foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
        {
            if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
            { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
        }

        return 0;
    }

    private int Create_Corridor()
    {
        CorridorNode CN = new CorridorNode();

        CN.BlockName = cmbx_BlockSelect.Text;
        CN.Floor = (int)nud_Node_Floor.Value;
        CN.InternalName = txt_InternalName.Text.Trim();
        CN.GatewayFlowDirection = (cmbx_GWFlow.SelectedItem as string).ToDirection();
        CN.ElvFlowDirection = (cmbx_ElvFlow.SelectedItem as string).ToDirection();

        CurNodeUID = NG.AddNode(CN);

        foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
        {
            if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
            { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
        }

        return 0;
    }

    private int Create_Gateway()
    {
        if (cmbx_GW_Direction.SelectedItem == null ||
            cmbx_GW_AvailableNodes.SelectedItem == null)
        {
            MessageBox.Show("Please select a gateway direction/connecting node", "Issue!");
            return -1;
        }

        GatewayNode GN = new GatewayNode();

        GN.BlockName = cmbx_BlockSelect.Text;
        GN.Floor = (int)nud_Node_Floor.Value;
        GN.InternalName = txt_InternalName.Text.Trim();
        GN.ElvFlowDirection = (cmbx_ElvFlow.SelectedItem as string).ToDirection();

        CurNodeUID = NG.AddNode(GN);

        if (cmbx_GW_AvailableNodes.Text != string.Empty)
        { NG.ConnectGatewayNode(CurNodeUID, cmbx_GW_AvailableNodes.Text.SplitNodeID(), (NodeDirection)cmbx_GW_Direction.Text.ToDirection()); }

        foreach (DataGridViewRow Row in dgv_GatewayConnections.Rows)
        {
            if (Row.Cells[0] is DataGridViewComboBoxCell DGVCBX && DGVCBX.Value != null)
            { NG.ConnectGatewayNodes(CurNodeUID, (Row.Cells[0] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID()); }
        }

        return 0;
    }

    private string GetNodeName(int _UID)
    { return NG.TryGetNode(_UID).InternalName; }

    private void SetupGW()
    {
        pnl_GW.BringToFront();
        pnl_GW.Visible = true;

        NodeDirection ND = (NodeDirection)((int)cmbx_GW_Direction.SelectedText.ToDirection() * -1);

        Task.Run(() =>
        {
            var AvailableNodes = NG.GetAllNodes()
                .AsParallel()
                .Where(X => X.Value is not GatewayNode)
                .Where(X => X.Value.IsAvailable(ND))
                .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                .ToArray();

            cmbx_GW_AvailableNodes.Invoke(() =>
            {
                cmbx_GW_AvailableNodes.Items.Clear();
                cmbx_GW_AvailableNodes.Items.AddRange(AvailableNodes);

                cmbx_GW_AvailableNodes.Refresh();
            });
        });
    }

    private void RefreshNodesTree()
    {
        trvw_Nodes.Nodes.Clear();
        FillNodesTree();
    }

    private void DGV_ElvDelete()
    {
        try
        {
            List<DataGridViewRow> RowsForDel = new();

            foreach (DataGridViewRow? R in dgv_NodeConnections.Rows)
            {
                if (R == null)
                { continue; }

                switch (((NodeDirection?)R.Tag))
                {
                    default:
                    case null:
                    { continue; }
                    case NodeDirection.Up:
                    case NodeDirection.Down:
                    {
                        //dgv_NodeConnections.Rows.Remove(R);
                        RowsForDel.Add(R);
                        break;
                    }
                }
            }

            foreach (var R in RowsForDel)
            { dgv_NodeConnections.Rows.Remove(R); }
        }
        catch (Exception EXC)
        {
            MessageBox.Show(EXC.Message, "Error!");
            throw;
        }
    }

    private void btn_SaveBackup_Click(object sender, EventArgs e)
    { Filer.SaveBackup(NG); }

    private void GenerateInternalName()
    {
        if (cmbx_NodeType.Text != "" && cmbx_BlockSelect.Text != "")
        {
            Layouter._Blockname = cmbx_BlockSelect.Text;
            Layouter._Floor = (int)nud_Node_Floor.Value;
            Layouter._Type = cmbx_NodeType.Text;
            Layouter._Separator = txt_set_Separator.Text.First();
            Layouter._Prefix = txt_set_Prefix.Text;
        }
        else
        {
            Layouter._Blockname = cmbx_BlockSelect.Items[0].ToString();
            Layouter._Floor = 0;
            Layouter._Type = cmbx_NodeType.Items[0] as string;
            Layouter._Separator = txt_set_Separator.Text.First();
            Layouter._Prefix = txt_set_Prefix.Text;
        }

        txt_InternalName.Text = Layouter.GetName();
    }
}

public class TempNode
{
    public static int? UID, Floor;
    //Both used by all nodes

    public static string?
        PublicName = "", InternalName = "", BlockName = "";
    //   ^Room nodes                         ^used by all nodes
    //                    ^Used by all nodes

    public static Dictionary<NodeDirection, int>? NodeConnections = new();
    //Used by all nodes (with slight differences)

    public static Dictionary<int, string>? GatewayConnections = new();
    //Gateway nodes

    public static List<string>? Tags = new();
    //Room nodes

    public NodeDirection? ElvNodeDirection, GWNodeDirection;
    //All nodes bar GW and Elv for obvious reasons

}
