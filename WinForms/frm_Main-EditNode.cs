// Ignore Spelling: frm

using NavGraphTools;

namespace WinForms;

public partial class frm_Main
{
    List<int> edit_GWTempNodes = new List<int>();

    public void EditLoad()
    {
        Task.Run(() =>
        {
            pbx_Decor.Invoke(() =>
            {
                if (DateTime.Now.Ticks % 2 == 0)
                { pbx_Decor.Image = Properties.Resources.Blehh; }
                else
                { pbx_Decor.Image = Properties.Resources.Seagull; }
            });
        });

        NavNode? T = NG[CurNodeUID];

        if (T == null)
        {
            MessageBox.Show("Node was null?");
            tbctrl_MainTabs.SelectTab(tbpg_Nodes);
            return;
        }

        cmbx_edit_gw_ConnBlock.Items.Clear();
        cmbx_edit_gw_ConnBlock.Items.AddRange(NG.Blocks.Keys.ToArray());

        txt_edit_Block.Text = T.BlockName;
        txt_edit_NodeType.Text = T.GetType().NodeTypeLong();
        txt_edit_Floor.Text = T.Floor.ToString();
        txt_edit_IntName.Text = T.InternalName;

        txt_edit_PubName.Enabled = false;

        if (T is GatewayNode GN)
        {
            //throw new NotImplementedException();

            pnl_edit_GWNodeConnections.BringToFront();

            foreach (var GW in GN.GetConnectedGateways())
            {
                string BlockName = GW.Key;

                foreach (var UID in GW.Value)
                {
                    GatewayNode? TNode = NG.TryGetNode(UID) as GatewayNode;

                    dgv_edit_gw_Connections.Rows
                        .Add(BlockName, $"{TNode.UID} \"{TNode.InternalName}\"");
                }

                //    GatewayNode? GNt = NG.TryGetNode<GatewayNode>(GW.Key);

                //    if (GNt == null)
                //    { continue; }

                //    //.Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                //    dgv_edit_gw_Connections.Rows
                //        .Add($"{GW.Value} \"{GNt.InternalName}\"", GW.Key);
            }

            if (dgv_edit_gw_Connections.Rows.Count > 0)
            { dgv_edit_BlockList(0); }
        }
        else
        { pnl_edit_GWNodeConnections.SendToBack(); }

        if (T is ElevationNode EN)
        { ckbx_edit_IsElevator.Checked = EN.IsElevator; }
        else if (T is not ElevationNode & T is not GatewayNode)
        {
            var Connections = T.GetConnectedNodes();

            Dictionary<NodeDirection, CheckBox> CKBXs = new();
            Dictionary<NodeDirection, ComboBox> CMBXs = new();

            foreach (Control C in pnl_edit_NodeConns.Controls)
            {
                if (C is Panel PNL && PNL.Tag != null)
                {
                    if ((NodeDirection)PNL.Tag != NodeDirection.Down && (NodeDirection)PNL.Tag != NodeDirection.Up)
                    { CKBXs.Add((NodeDirection)PNL.Tag, PNL.Controls.OfType<CheckBox>().First()); }

                    CMBXs.Add((NodeDirection)PNL.Tag, PNL.Controls.OfType<ComboBox>().First());
                }
            }

            //.Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
            foreach (var KVP in Connections)
            {
                NavNode? Temp = NG[KVP.Value];

                if (Temp != null)
                {
                    CMBXs[KVP.Key].Text = $"{KVP.Value} \"{Temp.InternalName}\"";

                    if (KVP.Key != NodeDirection.Down && KVP.Key != NodeDirection.Up)
                    {
                        //MINIMUM_UID is converted to negative because we're checking
                        //if the UID is one-way: less than -25
                        CKBXs[KVP.Key].Checked = KVP.Value < (NavGraph.MINIMUM_UID * -1);
                    }
                }
            }

            CKBXs = null;
            CMBXs = null;

            if (T is RoomNode RN)
            {
                txt_edit_PubName.Enabled = true;
                txt_edit_PubName.Text = RN.RoomName;
                txt_edit_tags_Tags.Text = RN.Tags.unTagList();
            }
        }
    }

    private void btn_edit_SaveAndReturn_Click(object sender, EventArgs e)
    {
        NavNode? T = NG[CurNodeUID];

        if (T == null)
        {
            MessageBox.Show("Node became null?");
            ReturnAndTidy();
            return;
        }

        if (T is RoomNode RN)
        {
            RN.RoomName = txt_edit_PubName.Text;
            RN.Tags = txt_edit_tags_Tags.Text.TagList();
        }

        T.InternalName = txt_edit_IntName.Text;

        foreach (Panel PNL in pnl_edit_NodeConns.Controls.OfType<Panel>())
        {
            ComboBox CMBX = PNL.Controls.OfType<ComboBox>().First();
            CheckBox? CKBX = PNL.Controls.OfType<CheckBox>().FirstOrDefault();

            if (CMBX.Text == string.Empty)
            { continue; }

            if (T is ElevationNode)
            {
                if ((NodeDirection)PNL.Tag == NodeDirection.Up || (NodeDirection)PNL.Tag == NodeDirection.Down)
                { NG.ConnectElevationNodes(CurNodeUID, CMBX.Text.SplitNodeID(), (NodeDirection)PNL.Tag); }
                else if (CKBX != null)
                { NG.ConnectElevationNodes(CurNodeUID, CMBX.Text.SplitNodeID(), (NodeDirection)PNL.Tag, CKBX.Checked); }
            }
            else if (T is GatewayNode)
            {
                //do later, am eepy
            }
            else if (CKBX != null)
            { NG.ConnectNodes(CurNodeUID, CMBX.Text.SplitNodeID(), (NodeDirection)PNL.Tag, CKBX.Checked); }
        }
    }

    private void btn_edit_ReturnNoSave_Click(object sender, EventArgs e)
    { ReturnAndTidy(); }

    private void ReturnAndTidy()
    {
        CurNodeUID = 0;
        tbctrl_MainTabs.SelectTab(tbpg_Nodes);
        ClearBox(pnl_edit_Main);
    }

    private void dgv_edit_BlockList(int _Row)
    {
        var DGVCMBX =
        (dgv_edit_gw_Connections.Rows[_Row].Cells[0] as DataGridViewComboBoxCell);

        DGVCMBX.Items.Clear();
        DGVCMBX.Items.AddRange(NG.Blocks.Keys.ToArray());
        DGVCMBX.Value = DGVCMBX.Items[0];
    }

    private void dgv_edit_gw_Connections_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        cmbx_edit_gw_ConnBlock.Text = string.Empty;

        if (e.RowIndex <= -1 || e.ColumnIndex <= -1)
        { return; }

        DataGridViewRow DGVR = dgv_edit_gw_Connections.Rows[e.RowIndex];

        if (DGVR.Cells[0].Value != null && DGVR.Cells[1].Value != null)
        {
            cmbx_edit_gw_ConnBlock.Text = DGVR.Cells[0].Value.ToString();
            cmbx_edit_gw_ConnNode.Text = DGVR.Cells[1].Value.ToString();
        }

        btn_edit_gw_AddConn.Enabled = false;
    }

    private void btn_edit_gw_AddConn_Click(object sender, EventArgs e)
    {
        if (cmbx_edit_gw_ConnBlock.Text == string.Empty ||
            cmbx_edit_gw_ConnNode.Text == string.Empty)
        {
            MessageBox.Show("Please don't leave comboboxes empty");
            return;
        }

        dgv_edit_gw_Connections.Rows.Add
        (
            cmbx_edit_gw_ConnBlock.Text,
            cmbx_edit_gw_ConnNode.Text
        );

        edit_GWTempNodes.Add(cmbx_edit_gw_ConnNode.Text.SplitNodeID());

        cmbx_edit_gw_ConnNode.Text = string.Empty;

        cmbx_edit_gw_ConnNode_Load();
    }

    private void cmbx_edit_gw_ConnNode_MouseEnter(object sender, EventArgs e)
    { cmbx_edit_gw_ConnNode_Load(); }

    private async Task cmbx_edit_gw_ConnNode_Load()
    {
        if (cmbx_edit_gw_ConnBlock.SelectedIndex < 0)
        { return; }

        string Block = cmbx_edit_gw_ConnBlock.Text;
        string IntName = txt_edit_IntName.Text;
        int UID = CurNodeUID;

        await Task.Run(() =>
        {
            cmbx_edit_gw_ConnNode.Invoke(() =>
            {
                cmbx_edit_gw_ConnNode.Items.Clear();

                cmbx_edit_gw_ConnNode.Items.AddRange
                (
                NG.GetAllNodes()
                        .AsParallel()
                        .Select(X => X.Value)
                        .Select(X => X as GatewayNode)
                        .Where(X => X != null)
                        .Where(X => !edit_GWTempNodes.Contains(X.UID))
                        .Where(X => X.BlockName == Block)
                        .Where(X => X.InternalName != IntName)
                        .Where(X => !X.IsConnected(UID))
                        .Select(X => $"{X.UID} \"{X.InternalName}\"")
                        .ToArray()
                );
            });
        });
    }

    private void dgv_edit_gw_Connections_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
    {
        int? UID = e.Row.Cells[1].Value.ToString().SplitNodeID();

        if (UID != null)
        { edit_GWTempNodes.Remove((int)UID); }

        cmbx_edit_gw_ConnNode.Text = string.Empty;

        cmbx_edit_gw_ConnNode_Load();
    }

    private void cmbx_edit_gw_ConnNode_SelectionChangeCommitted(object sender, EventArgs e)
    { btn_edit_gw_AddConn.Enabled = true; }
}
