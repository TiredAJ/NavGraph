using NavGraphTools;

namespace WinForms;

public partial class frm_Main
{
    public void EditLoad(int _UID)
    {
        NavNode? T = NG[_UID];

        if (T == null)
        {
            MessageBox.Show("Node was null?");
            tbctrl_MainTabs.SelectTab(tbpg_Nodes);
            return;
        }

        cmbx_edit_Block.Items.AddRange
            (NG.Blocks
                    .Select(X => X.Key)
                    .ToArray());

        cmbx_edit_Block.SelectedItem = T.BlockName;

        //.Select(X => $"{X.Key} \"{X.Value.InternalName}\"")

        var Connections = T.GetConnectedNodes();

        foreach (var KVP in Connections)
        {

        }

    }

    private void cmbx_edit_Block_SelectionChangeCommitted(object sender, EventArgs e)
    {
        (int Max, int Min) BlockFloors;

        BlockFloors = NG.Blocks[cmbx_edit_Block.Text];

        nud_edit_Floor.Value = 0;
        nud_edit_Floor.Maximum = BlockFloors.Max;
        nud_edit_Floor.Minimum = BlockFloors.Min;
    }

}
