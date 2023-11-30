using NavGraphTools;

namespace WinForms
{
    public partial class frm_Main : Form
    {
        private void btn_CreateBlock_Click(object sender, EventArgs e)
        {
            if (NG.Blocks.ContainsKey(txt_New_BlockName.Text))
            { MessageBox.Show("Block wasn't saved, name exists"); }
            else
            {
                NG.Blocks.Add
                    (txt_New_BlockName.Text,
                    ((int)nud_New_HighestFloor.Value, (int)nud_New_LowestFloor.Value));

                RefreshBlocksList();
                ClearBox(gbx_NewBlock);
            }
        }

        private void RefreshBlocksList()
        {
            lst_Blocks.Items.Clear();
            cmbx_BlockSelect.Items.Clear();
            FillBlocksControls();
        }

        private void FillBlocksControls()
        {
            lst_Blocks.Items.AddRange(NG.Blocks.Keys.ToArray());
            lst_Blocks.Refresh();

            cmbx_BlockSelect.Items.AddRange(NG.Blocks.Keys.ToArray());
            cmbx_BlockSelect.Refresh();
        }

        private void FillNodesTree()
        {
            TreeNode Current = new TreeNode();

            foreach (var N in NG.GetAllNodes())
            {
                Current = trvw_Nodes.Nodes.Add($"{N.Key} \"{N.Value.InternalName}\"");

                if (N.Value is GatewayNode GN)
                {
                    foreach (var CN in GN.GetConnectedNodes())
                    {
                        Current.Nodes.Add
                        ($"{CN.Key}:".PadRight(6) + $" {CN.Value} \"{GetNodeName(CN.Value)}\"");
                    }
                    foreach (var CN in GN.GetConnectedGateways())
                    { Current.Nodes.Add($"{CN.Key} -> {CN.Value} \"{GetNodeName(CN.Key)}\""); }
                }
                else
                {
                    foreach (var CN in N.Value.GetConnectedNodes())
                    {
                        Current.Nodes.Add
                        ($"{CN.Key}:".PadRight(6) + $" {CN.Value} \"{GetNodeName(CN.Value)}\"");
                    }
                }
            }

            trvw_Nodes.Refresh();
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
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            NG.Blocks.Remove(SelectedBlock);
            lst_Blocks.Items.Remove(SelectedBlock);

            RefreshBlocksList();
            ClearBox(gbx_EditBlock);
        }

        private void lst_Blocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedBlock = (string)lst_Blocks.SelectedItem;

            txt_Edit_BlockName.Text = SelectedBlock;
            nud_Edit_HighestFloor.Value = NG.Blocks[SelectedBlock].Max;
            nud_Edit_LowestFloor.Value = NG.Blocks[SelectedBlock].Min;
        }
    }
}
