// Ignore Spelling: frm

using NavGraphTools;

namespace WinForms
{
    public partial class frm_Main : Form
    {
        #region Member Variables
        #region Nodes
        private int CurNodeUID = 0;
        private int CurFloor;
        private NodeDirection CurDir;
        private string SelectedBlock = string.Empty;
        private string CurBlock;
        private NavGraph NG = new NavGraph(true);
        #endregion

        #region Exporting
        private string? DefaultFileLoc = null;
        private SaveFileDialog SFD = new SaveFileDialog();
        private Stream? FileSaveS = null;
        private bool Both = false;
        private ExportType ExportOptions = ExportType.FARap;
        #endregion
        #endregion

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
            SFD = new SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                CheckWriteAccess = true,
                DefaultExt = "apjson",
                CreatePrompt = false,
                Filter = "Admin Panel NavGraph JSON file (*.apjson)|*.apjson",
                FileName = "AP-Map"
            };

            if (DefaultFileLoc == null)
            { SFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }
            else
            { SFD.InitialDirectory = DefaultFileLoc; }

            switch (SFD.ShowDialog())
            {
                case DialogResult.None:
                break;
                case DialogResult.Cancel:
                case DialogResult.Abort:
                case DialogResult.No:
                break;
                case DialogResult.Ignore:
                break;
                case DialogResult.Retry:
                case DialogResult.TryAgain:
                break;
                case DialogResult.OK:
                case DialogResult.Yes:
                case DialogResult.Continue:
                default:
                break;
            }

            FileSaveS = SFD.OpenFile();

            using (StreamWriter Writer = new StreamWriter(FileSaveS))
            { txt_SaveLocation.Text = ((FileStream)(Writer.BaseStream)).Name; }
        }

        private void rbtn_Export_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton SE && SE.Tag.ToString() != "Both")
            {
                SFD.DefaultExt = $".{SE.Tag.ToString()}";

                if (SE.Tag.ToString() == "ajson")
                { SFD.Filter = "Admin Panel NavGraph JSON file (*.ajson)|*.ajson"; }
                else
                { SFD.Filter = "Application NavGraph JSON file (*.apjson)|*.apjson"; }



                pnl_ZipOptions.Enabled = false;
            }
            else
            {
                Both = true;

                pnl_ZipOptions.Enabled = true;
            }
        }
    }

    public enum ExportType : int
    {
        FARap,
        FARa,
        Both
    }

}
