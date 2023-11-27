// Ignore Spelling: frm

using NavGraphTools;

namespace WinForms
{
    public partial class frm_Main : Form
    {
        private int CurNodeUID = 0;
        private int CurFloor;
        private NodeDirection CurDir;
        private string SelectedBlock = string.Empty;
        private string CurBlock;
        private NavGraph NG = new NavGraph(true);

        public frm_Main()
        {
            InitializeComponent();

            dgv_NodeConnections.Rows.Add("North", null, false);
            dgv_NodeConnections.Rows.Add("East", null, false);
            dgv_NodeConnections.Rows.Add("South", null, false);
            dgv_NodeConnections.Rows.Add("West", null, false);

            dgv_NodeConnections.Rows[0].Tag = NodeDirection.North;
            dgv_NodeConnections.Rows[1].Tag = NodeDirection.East;
            dgv_NodeConnections.Rows[2].Tag = NodeDirection.South;
            dgv_NodeConnections.Rows[3].Tag = NodeDirection.West;

            dgv_NodeConnections.ClearSelection();

            NG.Blocks.Add("Johnstone", (4, 0));
            RefreshBlocksList();
        }

        private void ClearBox(GroupBox _GBX)
        {
            CurNodeUID = 0;

            foreach (Control C in _GBX.Controls)
            {
                if (C is TextBox TXT)
                { TXT.Text = ""; }
                /*else if (C is NumericUpDown NUD)
                { NUD.Value = 0; }*/
                /*else if (C is ComboBox CMBX)
                { CMBX.SelectedItem = -1; }*/
                else if (C is CheckBox CHKBX)
                { CHKBX.Checked = false; }

                C.Refresh();
            }
        }

        private void btn_SetSaveLocation_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();


        }
    }
}
