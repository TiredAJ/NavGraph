using NavGraphTools;
using System.Text;
using WinForms.Tools;

namespace WinForms;

public partial class frm_Main : Form
{
    private void btn_CreateBlock_Click(object sender, EventArgs e)
    {
        if (NG.Blocks.ContainsKey(txt_New_BlockName.Text))
        { MessageBox.Show("Block wasn't saved, name already exists"); }
        else
        {
            NG.Blocks.Add
                (txt_New_BlockName.Text,
                ((int)nud_New_HighestFloor.Value, (int)nud_New_LowestFloor.Value));

            RefreshBlocksList();
            ClearBox(gbx_NewBlock);
        }

        RefreshNodesTree();

        Filer.SaveBackup(NG);
    }

    private void RefreshBlocksList()
    {
        lst_Blocks.Items.Clear();
        cmbx_BlockSelect.Items.Clear();
        FillBlocksControls();
    }

    private void FillBlocksControls()
    {
        lst_Blocks.Items.Clear();
        lst_Blocks.Items.AddRange(NG.Blocks.Keys.ToArray());
        lst_Blocks.Refresh();

        cmbx_BlockSelect.Items.Clear();
        cmbx_BlockSelect.Items.AddRange(NG.Blocks.Keys.ToArray());
        cmbx_BlockSelect.Refresh();
    }

    //Goddam, this does a lot of fairly heay stuff
    //could work out a way to cache <- low priority
    private void FillNodesTree()
    {
        TreeNode TN_Block = new TreeNode();
        TreeNode TN_Floor = new TreeNode();
        TreeNode TN_Node = new TreeNode();

        int FloorNodeCount = 0;

        foreach (var KVP in NG.Blocks)
        {
            TN_Block = trvw_Nodes.Nodes.Add(KVP.Key, KVP.Key);

            //TN_Block.Expand();

            for (int i = KVP.Value.Min; i <= KVP.Value.Max; i++)
            {
                FloorNodeCount = NG.GetFloorNodeCount(KVP.Key, i);

                if (FloorNodeCount == 0)
                { continue; }

                TN_Floor = TN_Block.Nodes.Add($"{KVP.Key}-{i}", $"Floor {i} ({FloorNodeCount} Nodes)");

                //TN_Floor.Expand();

                foreach (var N in NG.GetNodes(KVP.Key, i))
                {
                    StringBuilder SB_Name = new($"{N.Value.GetType().NodeTypeShort()}:{N.Key} \"{N.Value.InternalName}\"  [");

                    if (N.Value is IElevationFlow NE)
                    { SB_Name.Append($"E:{NE.ElvFlowDirection.ToArrow()}"); }

                    if (N.Value is IGatewayFlow NG)
                    { SB_Name.Append($"G:{NG.GatewayFlowDirection.ToArrow()}"); }

                    SB_Name.Append("]");

                    TN_Node = TN_Floor.Nodes
                        .Add($"{N.Key}", SB_Name.ToString());

                    if (N.Value is GatewayNode GN)
                    {
                        foreach (var CN in GN.GetConnectedNodes())
                        {
                            TN_Node.Nodes.Add
                            ($"{CN.Key}:".PadRight(6) + $" {CN.Value}]");
                        }
                        foreach (var CN in GN.GetConnectedGateways())
                        { TN_Node.Nodes.Add($"{CN.Key} -> {CN.Value}"); }
                    }
                    else
                    {
                        foreach (var CN in N.Value.GetConnectedNodes())
                        {
                            TN_Node.Nodes.Add
                            ($"{CN.Key}:".PadRight(6) + $" {CN.Value}");
                        }
                    }
                }
            }
        }

        trvw_Nodes.Refresh();

        foreach (TreeNode TN in trvw_Nodes.Nodes)
        { TN.Expand(); }
    }

    private void btn_SaveBlock_Click(object sender, EventArgs e)
    {
        if (SelectedBlock != txt_Edit_BlockName.Text)
        {
            if (NG.Blocks.ContainsKey(txt_Edit_BlockName.Text))
            { MessageBox.Show("Block wasn't saved, name exists"); }
            else
            {
                NG.Blocks.Remove(SelectedBlock);
                NG.Blocks.Add
                    (txt_Edit_BlockName.Text,
                    ((int)nud_New_HighestFloor.Value, (int)nud_New_LowestFloor.Value));
            }
        }
        else
        { NG.Blocks[SelectedBlock] = ((int)nud_Edit_HighestFloor.Value, (int)nud_Edit_LowestFloor.Value); }

        RefreshBlocksList();
        ClearBox(gbx_EditBlock);

        lst_Blocks.SelectedIndex = 1;
        SelectedBlock = lst_Blocks.SelectedItem.ToString();

        RefreshNodesTree();
    }

    private void btn_Delete_Click(object sender, EventArgs e)
    {
        NG.Blocks.Remove(SelectedBlock);
        lst_Blocks.Items.Remove(SelectedBlock);

        RefreshBlocksList();
        ClearBox(gbx_EditBlock);

        RefreshNodesTree();
    }

    private void lst_Blocks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lst_Blocks.SelectedIndex > -1)
        {
            SelectedBlock = (string)lst_Blocks.SelectedItem;

            txt_Edit_BlockName.Text = SelectedBlock;
            nud_Edit_HighestFloor.Value = NG.Blocks[SelectedBlock].Max;
            nud_Edit_LowestFloor.Value = NG.Blocks[SelectedBlock].Min;
        }
    }
}
