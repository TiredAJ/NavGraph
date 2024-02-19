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
        ClearBox(pnl_GW);

        txt_tag_Tags.Clear();
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

        btn_node_Edit.Enabled = false;
        //btn_Node_Delete.Enabled = false;
    }

    private void btn_Node_Save_Click(object sender, EventArgs e)
    { tbctrl_MainTabs.SelectTab(tbpg_EditNode); }

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
        ckbx_IsElevator.Enabled = false;

        if (cmbx_NodeType.SelectedIndex >= 0)
        { pnl_NormalNodes.Enabled = true; }
        else
        { pnl_NormalNodes.Enabled = false; }

        if (cmbx_NodeType.Text == "Elevation")
        {
            pnl_conn_Down.Enabled = true;
            pnl_conn_Up.Enabled = true;

            cmbx_ElvFlow.Enabled = false;

            txt_PublicName.Enabled = false;

            ckbx_IsElevator.Enabled = true;

            cmbx_GWFlow.Items.AddRange(new string[] { "Up", "Down" });
            cmbx_ElvFlow.Items.AddRange(new string[] { "Up", "Down" });
        }
        else
        {
            cmbx_ElvFlow.Items.Remove("Up");
            cmbx_ElvFlow.Items.Remove("Down");
            cmbx_GWFlow.Items.Remove("Up");
            cmbx_GWFlow.Items.Remove("Down");

            pnl_conn_Down.Enabled = false;
            pnl_conn_Up.Enabled = false;
        }

        if (cmbx_NodeType.SelectedItem.ToString() == "Room")
        {
            txt_tag_Tags.Enabled = true;
            txt_PublicName.Enabled = true;
            cmbx_GWFlow.Enabled = false;
            cmbx_ElvFlow.Enabled = false;
        }
        else
        {
            txt_tag_Tags.Enabled = false;
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

        foreach (string S in lst_node_GW.Items)
        {
            var T = S.Split(" - ");

            EN.GateFlow.Add(int.Parse(T[1]), (NodeDirection)T[0].ToDirection());
        }

        CurNodeUID = NG.AddNode(EN);

        foreach (Control C in pnl_NormalNodes.Controls.OfType<Panel>())
        {
            if (C is Panel PNL)
            {
                ComboBox CMBX = PNL.Controls.OfType<ComboBox>().First();
                CheckBox? CKBX = PNL.Controls.OfType<CheckBox>().FirstOrDefault();

                if (CMBX.Text == string.Empty)
                { continue; }

                if ((NodeDirection)PNL.Tag == NodeDirection.Up || (NodeDirection)PNL.Tag == NodeDirection.Down)
                { NG.ConnectElevationNodes(CurNodeUID, CMBX.SelectedItem.ToString().SplitNodeID(), (NodeDirection)PNL.Tag); }
                else
                { NG.ConnectElevationNodes(CurNodeUID, CMBX.SelectedItem.ToString().SplitNodeID(), (NodeDirection)PNL.Tag, CKBX.Checked); }
            }
        }

        EN.IsElevator = ckbx_IsElevator.Checked;

        //foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
        //{
        //    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
        //    {
        //        if ((NodeDirection)Row.Tag == NodeDirection.Up || (NodeDirection)Row.Tag == NodeDirection.Down)
        //        { NG.ConnectElevationNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag); }
        //        else
        //        { NG.ConnectElevationNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
        //    }
        //}

        return 0;
    }

    private int Create_Room()
    {
        RoomNode RN = new RoomNode();

        RN.BlockName = cmbx_BlockSelect.Text;
        RN.Floor = (int)nud_Node_Floor.Value;
        RN.InternalName = txt_InternalName.Text.Trim();
        RN.RoomName = txt_PublicName.Text.Trim();
        RN.Tags = txt_tag_Tags.Text
                        .Split(new[] { ',' })
                        .Select(X => X.Trim())
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


        //foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
        //{
        //    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
        //    { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
        //}

        return 0;
    }

    private int Create_Corridor()
    {
        CorridorNode CN = new CorridorNode();

        CN.BlockName = cmbx_BlockSelect.Text;
        CN.Floor = (int)nud_Node_Floor.Value;
        CN.InternalName = txt_InternalName.Text.Trim();

        foreach (string S in lst_node_Elevation.Items)
        {
            var T = S.Split(" - ");

            CN.ElvFlow.Add(int.Parse(T[1]), (NodeDirection)T[0].ToDirection());
        }

        foreach (string S in lst_node_GW.Items)
        {
            var T = S.Split(" - ");

            CN.GateFlow.Add(int.Parse(T[1]), (NodeDirection)T[0].ToDirection());
        }

        CurNodeUID = NG.AddNode(CN);

        foreach (Control C in pnl_NormalNodes.Controls.OfType<Panel>())
        {
            if (C is Panel PNL)
            {
                ComboBox CMBX = PNL.Controls.OfType<ComboBox>().First();
                CheckBox? CKBX = PNL.Controls.OfType<CheckBox>().FirstOrDefault();

                if (CMBX.Text == string.Empty)
                { continue; }

                NG.ConnectNodes(CurNodeUID, CMBX.SelectedItem.ToString().SplitNodeID(), (NodeDirection)PNL.Tag, CKBX.Checked);
            }
        }

        //foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
        //{
        //    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
        //    { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
        //}

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

        foreach (string S in lst_node_Elevation.Items)
        {
            var T = S.Split(" - ");

            GN.ElvFlow.Add(int.Parse(T[1]), (NodeDirection)T[0].ToDirection());
        }

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

        Layouter.IsElevator = ckbx_IsElevator.Checked;

        txt_InternalName.Text = Layouter.GetName();
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

        string Required = cmbx_NodeType.Text;
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
    { txt_tag_Tags.AppendText($"{cmbx_tag_Tags.Text}, "); }

    private void btn_tag_AddNewTag_Click(object sender, EventArgs e)
    {
        if (cmbx_tag_Tags.Text == string.Empty)
        { return; }

        string NewTag = cmbx_tag_Tags.Text;

        if (NG.GetTags().Contains(NewTag))
        { txt_tag_Tags.AppendText($"{cmbx_tag_Tags.Text}, "); }

        cmbx_tag_Tags.Text = string.Empty;

        txt_tag_Tags.AppendText($"{NewTag}, ");
        cmbx_tag_Tags.Items.Add(NewTag);

        cmbx_tag_Tags.Refresh();
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
    { txt_tag_Tags.Text = string.Empty; }

    private void lst_node_ElvGW_DeleteKey(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && sender is ListBox LST && LST.SelectedIndex >= 0)
        {
            LST.Items.RemoveAt(LST.SelectedIndex);
            LST.SelectedIndex = -1;
            LST.Refresh();
        }
    }

    private void btn_node_ElvGWAddConn_Click(object sender, EventArgs e)
    {
        var BTN = sender as Button;

        if (BTN.Tag.ToString() == "E")
        {
            //(cmbx_GWFlow.SelectedItem as string).ToDirection();

            lst_node_Elevation.Items.Add
                ($"{cmbx_node_ElvDir.SelectedItem.ToString().ToArrow()} - " +
                $"{cmbx_node_ElevationNode.SelectedItem.ToString().SplitNodeID()}");
        }
        else if (BTN.Tag.ToString() == "G")
        {
            lst_node_GW.Items.Add
                ($"{cmbx_node_GWDir.SelectedItem.ToString().ToArrow()} - " +
                $"{cmbx_node_GWNode.SelectedItem.ToString().SplitNodeID()}");
        }
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
