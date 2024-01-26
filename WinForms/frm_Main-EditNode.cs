using NavGraphTools;

namespace WinForms;

public partial class frm_Main
{
    public void EditLoad()
    {
        NavNode? T = NG[CurNodeUID];

        if (T == null)
        {
            MessageBox.Show("Node was null?");
            tbctrl_MainTabs.SelectTab(tbpg_Nodes);
            return;
        }

        txt_edit_Block.Text = T.BlockName;

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

        txt_edit_NodeType.Text = T.GetType().NodeTypeLong();

        txt_edit_Floor.Text = T.Floor.ToString();

        txt_edit_IntName.Text = T.InternalName;

        if (T is RoomNode RN)
        {
            txt_edit_PubName.Enabled = true;
            txt_edit_PubName.Text = RN.RoomName;
            txt_edit_tags_Tags.Text = RN.Tags.unTagList();
        }
        else
        { txt_edit_PubName.Enabled = false; }

        if (T is IGatewayFlow GWF)
        {
            cmbx_edit_GWFlow.Enabled = true;
            cmbx_edit_GWFlow.Text = GWF.GatewayFlowDirection.ToStr();
        }
        else
        { cmbx_edit_GWFlow.Enabled = false; }

        if (T is IElevationFlow ElvF)
        {
            cmbx_edit_ElvFlow.Enabled = true;
            cmbx_edit_ElvFlow.Text = ElvF.ElvFlowDirection.ToStr();
        }
        else
        { cmbx_edit_ElvFlow.Enabled = false; }

        if (T is ElevationNode EN)
        { ckbx_edit_IsElevator.Checked = EN.IsElevator; }
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

        if (T is IGatewayFlow GWF)
        { GWF.GatewayFlowDirection = cmbx_edit_GWFlow.Text.ToDirection(); }

        if (T is IElevationFlow ElvF)
        { ElvF.ElvFlowDirection = cmbx_edit_ElvFlow.Text.ToDirection(); }

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
}
