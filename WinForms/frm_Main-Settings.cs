namespace WinForms;

public partial class frm_Main : Form
{
    private Layout Layouter;

    private void tbpg_Settings_Click(object sender, EventArgs e)
    { }

    private void txt_set_Layout_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        { Layouter.SetLayout(txt_set_Layout.Text); }
    }
}
