using WinForms.Tools;

namespace WinForms;

public partial class frm_Main : Form
{
    private LayoutHelper Layouter;

    private void tbpg_Settings_Click(object sender, EventArgs e)
    { }

    private void btn_set_SaveSettings_Click(object sender, EventArgs e)
    {
        LayoutHelper.NodeIdentifiers["EN0"] = txt_set_id_ElvES.Text;
        LayoutHelper.NodeIdentifiers["EN1"] = txt_set_id_ElvEE.Text;
        LayoutHelper.NodeIdentifiers["CN"] = txt_set_id_Corridor.Text;
        LayoutHelper.NodeIdentifiers["GW"] = txt_set_id_GW.Text;
        LayoutHelper.NodeIdentifiers["RN"] = txt_set_id_Room.Text;

        Layouter.SetLayout(txt_set_Layout.Text);
    }
}
