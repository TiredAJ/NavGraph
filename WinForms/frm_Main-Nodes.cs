using NavGraphTools;
using WinForms.Tools;

namespace WinForms;

public partial class frm_Main : Form
{
    private HashSet<int> AlreadyConnectedNodes = new();

    private void btn_Node_Create_Click(object sender, EventArgs e)
    {
        int Result = -1;

        if (cmbx_nodes_NodeType.SelectedItem.ToString() == "Elevation")
        { Result = Create_Elevation(); }
        else if (cmbx_nodes_NodeType.SelectedItem.ToString() == "Room")
        { Result = Create_Room(); }
        else if (cmbx_nodes_NodeType.SelectedItem.ToString() == "Corridor")
        { Result = Create_Corridor(); }
        else if (cmbx_nodes_NodeType.SelectedItem.ToString() == "Gateway")
        { Result = Create_Gateway(); }

        if (Result == -1)
        { return; }

        RefreshNodesTree();
        ClearBox(gbx_Node);
        ClearBox(pnl_GW);
        ClearDGV(pnl_GW);

        txt_nodes_Tags.Clear();
        cmbx_tag_Tags.Text = string.Empty;

        CurNodeUID = 0;

        ResetConnPnl();

        Filer.SaveBackup(NG);

        GenerateInternalName();
    }

    private void btn_Node_Delete_Click(object sender, EventArgs e)
    {
        if (trvw_Nodes.SelectedNode.Level == 0)
        {
            foreach (TreeNode T in trvw_Nodes.SelectedNode.Nodes)
            { DeleteFloor(T.Name, trvw_Nodes.SelectedNode.Name); }
        }
        else if (trvw_Nodes.SelectedNode.Level == 1)
        {//delete all nodes in floor
            DeleteFloor(trvw_Nodes.SelectedNode.Name,
                trvw_Nodes.SelectedNode.Parent.Name);
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

    private void DeleteFloor(string _Key, string _ParentKey)
    {
        TreeNode T = trvw_Nodes.Nodes[_ParentKey].Nodes[_Key];

        if (T != null)
        {
            foreach (TreeNode TN in T.Nodes)
            { DeleteNode(TN.Text.SplitNodeID()); }
        }
    }

    private void DeleteNode(int _UID)
    {
        NG.RemoveNode(_UID);
        trvw_Nodes.Nodes.RemoveByKey(_UID.ToString());

        btn_nodes_Edit.Enabled = false;
        //btn_nodes_Delete.Enabled = false;
    }

    private void btn_Node_Save_Click(object sender, EventArgs e)
    { tbctrl_MainTabs.SelectTab(tbpg_EditNode); }

    private void nud_Node_Floor_ValueChanged(object sender, EventArgs e)
    {
        CurFloor = (int)nud_nodes_Floor.Value;
        GenerateInternalName();
    }

    private void cmbx_BlockSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        var Floor = NG.Blocks[cmbx_nodes_BlockSelect.SelectedItem.ToString()];

        nud_nodes_Floor.Maximum = Floor.Max;
        nud_nodes_Floor.Minimum = Floor.Min;

        CurBlock = cmbx_nodes_BlockSelect.SelectedItem.ToString();

        GenerateInternalName();
    }

    private void cmbx_NodeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ckbx_IsElevator.Enabled = false;

        if (cmbx_nodes_NodeType.SelectedIndex >= 0)
        { pnl_NormalNodes.Enabled = true; }
        else
        { pnl_NormalNodes.Enabled = false; }

        if (cmbx_nodes_NodeType.Text == "Elevation")
        {
            pnl_conn_Down.Enabled = true;
            pnl_conn_Up.Enabled = true;

            txt_nodes_PublicName.Enabled = false;

            ckbx_IsElevator.Enabled = true;
        }
        else
        {
            pnl_conn_Down.Enabled = false;
            pnl_conn_Up.Enabled = false;
        }

        if (cmbx_nodes_NodeType.SelectedItem.ToString() == "Room")
        {
            txt_nodes_Tags.Enabled = true;
            txt_nodes_PublicName.Enabled = true;
            btn_nodes_PublicNmCpy.Enabled = true;
        }
        else
        {
            txt_nodes_Tags.Enabled = false;
            txt_nodes_PublicName.Enabled = false;
            btn_nodes_PublicNmCpy.Enabled = false;
        }

        if (cmbx_nodes_NodeType.SelectedItem.ToString() == "Gateway")
        { SetupGW(); }
        else
        {
            pnl_NormalNodes.BringToFront();
            pnl_GW.Visible = false;
            cmbx_GW_AvailableNodes.Items.Clear();
            cmbx_GW_Direction.Text = string.Empty;
        }

        GenerateInternalName();
    }

    private void trvw_Nodes_Click(object sender, EventArgs e)
    {
        TreeNode TN = trvw_Nodes.SelectedNode;

        if (TN == null || TN.Level != 2)
        { return; }

        CurNodeUID = TN.Text.SplitNodeID();
    }

    private void trvw_Nodes_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node == null || e.Node.Level != 2)
        { return; }

        CurNodeUID = e.Node.Text.SplitNodeID();
    }

    private void ResetConnPnl()
    {
        foreach (Control C in pnl_NormalNodes.Controls.OfType<Panel>())
        {
            if (C is Panel PNL)
            {
                ComboBox CMBX = PNL.Controls.OfType<ComboBox>().First();
                CMBX.SelectedItem = null;
                CMBX.Items.Clear();
            }
        }
    }

    private void dgv_GatewayConnections_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex >= 0)
        {
            Task.Run(() =>
            {
                var AvailableNodes = NG.GetAllNodes()
                    .AsParallel()
                    .Where(X => X.Value is GatewayNode GN &&
                            !AlreadyConnectedNodes.Contains(X.Key))
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();

                dgv_GatewayConnections.Invoke(() =>
                {
                    var CMBX = dgv_GatewayConnections
                                                    .Rows[e.RowIndex]
                                                    .Cells[e.ColumnIndex]
                                                    as DataGridViewComboBoxCell;

                    if (CMBX is null)
                    { throw new Exception("CMBX was null!"); }

                    if (CMBX.Items.Count > 0)
                    { CMBX.Items.Clear(); }

                    CMBX.Items.AddRange(AvailableNodes);

                    dgv_GatewayConnections.Refresh();
                });
            });
        }
    }

    private int Create_Elevation()
    {
        ElevationNode EN = new ElevationNode();

        EN.BlockName = cmbx_nodes_BlockSelect.Text;
        EN.Floor = (int)nud_nodes_Floor.Value;
        EN.InternalName = txt_nodes_InternalName.Text;

        CurNodeUID = NG.AddNode(EN);

        foreach (Control C in pnl_NormalNodes.Controls.OfType<Panel>())
        {
            if (C is Panel PNL)
            {
                ComboBox CMBX = PNL.Controls.OfType<ComboBox>().First();
                CheckBox? CKBX = PNL.Controls.OfType<CheckBox>().FirstOrDefault();

                if (CMBX.Text == string.Empty)
                { continue; }

                //if ((NodeDirection)PNL.Tag == NodeDirection.Up || (NodeDirection)PNL.Tag == NodeDirection.Down)
                if ((NodeDirection)PNL.Tag is (NodeDirection.Up or NodeDirection.Down))
                { NG.ConnectElevationNodes(CurNodeUID, CMBX.Text.SplitNodeID(), (NodeDirection)PNL.Tag); }
                else
                { NG.ConnectElevationNodes(CurNodeUID, CMBX.Text.SplitNodeID(), (NodeDirection)PNL.Tag, CKBX.Checked); }
            }
        }

        NG.AssignENGroupID(CurNodeUID);

        EN.IsElevator = ckbx_IsElevator.Checked;

        return 0;
    }

    private int Create_Room()
    {
        RoomNode RN = new RoomNode();

        RN.BlockName = cmbx_nodes_BlockSelect.Text;
        RN.Floor = (int)nud_nodes_Floor.Value;
        RN.InternalName = txt_nodes_InternalName.Text.Trim();
        RN.RoomName = txt_nodes_PublicName.Text.Trim();
        RN.Tags = txt_nodes_Tags.Text
                        .Split(new[] { ',' })
                        .Select(X => X.Trim())
                        .Where(X => X != string.Empty)
                        .ToList();

        CurNodeUID = NG.AddNode(RN);

        foreach (Control C in pnl_NormalNodes.Controls.OfType<Panel>())
        {
            if (C is Panel PNL)
            {
                ComboBox CMBX = PNL.Controls.OfType<ComboBox>().First();
                CheckBox? CKBX = PNL.Controls.OfType<CheckBox>().FirstOrDefault();

                if (CMBX.Text == string.Empty)
                { continue; }

                NG.ConnectNodes(CurNodeUID, CMBX.Text.SplitNodeID(), (NodeDirection)PNL.Tag, CKBX.Checked);
            }
        }

        return 0;
    }

    private int Create_Corridor()
    {
        CorridorNode CN = new CorridorNode();

        CN.BlockName = cmbx_nodes_BlockSelect.Text;
        CN.Floor = (int)nud_nodes_Floor.Value;
        CN.InternalName = txt_nodes_InternalName.Text.Trim();

        CurNodeUID = NG.AddNode(CN);

        foreach (Control C in pnl_NormalNodes.Controls.OfType<Panel>())
        {
            if (C is Panel PNL)
            {
                ComboBox CMBX = PNL.Controls.OfType<ComboBox>().First();
                CheckBox? CKBX = PNL.Controls.OfType<CheckBox>().FirstOrDefault();

                if (CMBX.Text == string.Empty)
                { continue; }

                int BUID = CMBX.Text.SplitNodeID();

                if (NG.TryGetNode(BUID) is ElevationNode)
                { NG.ConnectElevationNodes(CurNodeUID, BUID, (NodeDirection)PNL.Tag, CKBX.Checked); }
                else
                { NG.ConnectNodes(CurNodeUID, BUID, (NodeDirection)PNL.Tag, CKBX.Checked); }
            }
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

        GN.BlockName = cmbx_nodes_BlockSelect.Text;
        GN.Floor = (int)nud_nodes_Floor.Value;
        GN.InternalName = txt_nodes_InternalName.Text.Trim();

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
        FillBlocksControls();
    }

    private void btn_SaveBackup_Click(object sender, EventArgs e)
    { Filer.SaveBackup(NG); }

    private void GenerateInternalName()
    {
        string TypeStr = "";

        if (cmbx_nodes_NodeType.Text != "" && cmbx_nodes_BlockSelect.Text != "")
        {
            Layouter._Blockname = cmbx_nodes_BlockSelect.Text;
            Layouter._Floor = (int)nud_nodes_Floor.Value;
            TypeStr = cmbx_nodes_NodeType.Text;
            Layouter._Separator = txt_set_Separator.Text.First();
            Layouter._Prefix = txt_set_Prefix.Text;
        }
        else
        {
            Layouter._Blockname = cmbx_nodes_BlockSelect.Items[0].ToString();
            Layouter._Floor = 0;
            TypeStr = cmbx_nodes_NodeType.Items[0] as string;
            Layouter._Separator = txt_set_Separator.Text.First();
            Layouter._Prefix = txt_set_Prefix.Text;
        }

        txt_nodes_InternalName.Text = Layouter.GetName(TypeStr, ckbx_IsElevator.Checked);
    }

    private async void cmbx_GW_AvailableNodes_MouseEnter(object sender, EventArgs e)
    {
        if (cmbx_GW_Direction.SelectedItem != null)
        { CurDir = (NodeDirection)cmbx_GW_Direction.SelectedItem.ToDirection(); }

        await Task.Run(async () =>
        {
            var AvailableNodes = await GetAvailableNodes(CurNodeUID, CurBlock, CurFloor, CurDir);

            cmbx_GW_AvailableNodes.Invoke(() =>
            {
                cmbx_GW_AvailableNodes.Items.Clear();
                cmbx_GW_AvailableNodes.Items.AddRange(AvailableNodes);

                cmbx_GW_AvailableNodes.Refresh();
            });
        });
    }

    private async Task<string[]> GetAvailableNodes(int _CurUID, string _CurBlock, int _CurFloor, NodeDirection _CurDir)
    {
        return await Task.Run(() =>
        {
            return NG.GetAllNodes()
                    .AsParallel()
                    .Where(X => X.Key != _CurUID)
                    .Where
                    (
                        X => X.Value.BlockName == _CurBlock
                        && X.Value.Floor == _CurFloor
                        && X.Value.IsAvailable((NodeDirection)((int)_CurDir * -1))
                    )
                    .OrderByDescending(X => X.Key)
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();
        });
    }

    private Task<string[]> GetAvailable<T>(int _CurUID, string _CurBlock, int _CurFloor, NodeDirection _CurDir) where T : NavNode
    {
        return Task.Run(() =>
        {
            return NG.GetAllNodes()
                    .AsParallel()
                    .Where(X => X.Key != _CurUID)
                    .Where
                    (
                        X => X.Value.BlockName == _CurBlock
                        && X.Value.Floor == _CurFloor
                        && X.Value.IsAvailable((NodeDirection)((int)_CurDir * -1))
                    )
                    .Where(X => X.Value is T)
                    .OrderByDescending(X => X.Key)
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();
        });
    }

    private void dgv_GatewayConnections_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
        {
            AlreadyConnectedNodes.AddIfNotNull(dgv_GatewayConnections
                                                .Rows[e.RowIndex]
                                                .Cells[e.ColumnIndex]
                                                .Value.ToString()
                                                .SplitNodeID());
        }
    }

    private Task<string[]> GetAvailableElevation(int _CurUID, string _CurBlock, int _CurFloor, NodeDirection _CurDir, bool _IsEE)
    {
        return Task.Run(() =>
        {
            int Offset = 0;

            if (_CurDir == NodeDirection.Down)
            { Offset = -1; }
            else if (CurDir == NodeDirection.Up)
            { Offset = 1; }
            else
            { throw new Exception("Don't use this to find nodes for up/down direction!"); }

            (int Max, int Min) = NG.Blocks[_CurBlock];

            if (!((_CurFloor + Offset) <= Max && (_CurFloor + Offset) >= Min))
            { return new string[0]; }

            return NG.GetAllNodes()
                    .AsParallel()
                    .Where(X => X.Key != _CurUID)
                    .Where(X => X.Value is ElevationNode)
                    .Where
                    (
                        X => X.Value.BlockName == _CurBlock
                        && X.Value.IsAvailable((NodeDirection)((int)_CurDir * -1)) &&
                        X.Value.Floor == _CurFloor + Offset &&
                        (X.Value as ElevationNode).IsElevator == _IsEE
                    )
                    .OrderByDescending(X => X.Key)
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();
        });
    }

    private void cmbx_conn_GetNodes(object _Sender, EventArgs e)
    {
        ComboBox? CMBX = _Sender as ComboBox;

        if (CMBX == null)
        { return; }

        CurDir = (NodeDirection)CMBX.Tag;

        string Required = cmbx_nodes_NodeType.Text;
        bool IsEE = ckbx_IsElevator.Checked;

        Task.Run(async () =>
        {
            string[] AvailableNodes;

            switch (Required)
            {
                case "Elevation" when Math.Abs((int)CurDir) < 3:
                { AvailableNodes = await GetAvailableNodes(CurNodeUID, CurBlock, CurFloor, CurDir); break; }
                case "Elevation":
                { AvailableNodes = await GetAvailableElevation(CurNodeUID, CurBlock, CurFloor, CurDir, IsEE); break; }
                case "Room":
                { AvailableNodes = await GetAvailable<CorridorNode>(CurNodeUID, CurBlock, CurFloor, CurDir); break; }
                default:
                { AvailableNodes = await GetAvailableNodes(CurNodeUID, CurBlock, CurFloor, CurDir); break; }
            }

            CMBX.Invoke(() =>
            {
                CMBX.Items.Clear();
                CMBX.Items.AddRange(AvailableNodes);

                CMBX.Refresh();
            });
        });
    }

    private void cbmx_conn_ContentsCheck(object _Sender, EventArgs e)
    {
        ComboBox? CMBX = _Sender as ComboBox;

        if (CMBX == null)
        { return; }

        if ((!CMBX.Items.Contains(CMBX.Text)) && CMBX.Text != string.Empty)
        {
            MessageBox.Show("Please only enter nodes in comboboxes");
            CMBX.Text = "";
            CMBX.SelectedItem = -1;
            CMBX.Refresh();
        }
    }

    private void ckbx_IsElevator_CheckedChanged(object sender, EventArgs e)
    { GenerateInternalName(); }

    private void btn_tag_AddTag_Click(object sender, EventArgs e)
    {
        if (cmbx_tag_Tags.Text == string.Empty)
        { return; }

        string NewTag = cmbx_tag_Tags.Text;

        if (!NG.GetTags().Contains(NewTag))
        {
            cmbx_tag_Tags.Items.Add(NewTag);

            cmbx_tag_Tags.Refresh();
        }

        if (txt_nodes_Tags.Text == string.Empty)
        { txt_nodes_Tags.AppendText($"{cmbx_tag_Tags.Text}"); }
        else
        { txt_nodes_Tags.AppendText($", {cmbx_tag_Tags.Text}"); }
    }

    private void btn_tree_Search_Click(object sender, EventArgs e)
    {
        SearchNodes();
        //trvw_Nodes.Focus();
    }

    private void txt_tree_SearchBox_TextChanged(object sender, EventArgs e)
    {
        SearchNodes();
        txt_tree_SearchBox.Focus();
    }

    private void SearchNodes()
    {
        trvw_Nodes.SelectedNode = null;

        if (txt_tree_SearchBox.Text == string.Empty)
        { return; }

        string SearchQ = txt_tree_SearchBox.Text.ToLower();

        foreach (TreeNode TN in trvw_Nodes.Nodes)
        {
            if (TN.Text.ToLower().Contains(SearchQ))
            { trvw_Nodes.SelectedNode = TN; break; }
            else
            {
                foreach (TreeNode TN2 in TN.Nodes)
                {
                    if (TN2.Text.ToLower().Contains(SearchQ))
                    { trvw_Nodes.SelectedNode = TN2; break; }
                    else
                    {
                        foreach (TreeNode TN3 in TN2.Nodes)
                        {
                            if (TN3.Text.ToLower().Contains(SearchQ))
                            { trvw_Nodes.SelectedNode = TN3; break; }
                        }

                        if (trvw_Nodes.SelectedNode != null)
                        { break; }
                    }
                }
                if (trvw_Nodes.SelectedNode != null)
                { break; }
            }
        }

        if (trvw_Nodes.SelectedNode != null)
        {
            trvw_Nodes.SelectedNode.EnsureVisible();
            trvw_Nodes.Focus();
        }
    }

    private void btn_Clear_Click(object sender, EventArgs e)
    { txt_nodes_Tags.Text = string.Empty; }

    private void lst_node_ElvGW_DeleteKey(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && sender is ListBox LST && LST.SelectedIndex >= 0)
        {
            LST.Items.RemoveAt(LST.SelectedIndex);
            LST.SelectedIndex = -1;
            LST.Refresh();
        }
    }
    private void btn_PublicNmCpy_Click(object sender, EventArgs e)
    { txt_nodes_InternalName.Text = txt_nodes_PublicName.Text; }
}
