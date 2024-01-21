// Ignore Spelling: frm

using NavGraphTools;
using WinForms.Tools;

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
        private string FileLoc = "";
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

            dgv_GatewayConnections.Rows.Add();

            Layouter = new();

            cmbx_BlockSelect.SelectedIndex = 0;
            cmbx_NodeType.SelectedIndex = 0;
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

        private void rbtn_Export_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton SE)
            {
                ExportOptions = (ExportType)int.Parse(SE.Tag.ToString());

                btn_Export.Enabled = true;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            Stream? FileSaveS = null;
            SaveFileDialog SFD = new SaveFileDialog();

            SFD = new SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                CheckWriteAccess = true,
                CreatePrompt = false,
                RestoreDirectory = true,
                OkRequiresInteraction = true,
            };

            if (DefaultFileLoc == null)
            { SFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }
            else
            { SFD.InitialDirectory = DefaultFileLoc; }

            switch (ExportOptions)
            {
                case ExportType.FARa:
                {
                    SFD.DefaultExt = "ajson";
                    SFD.FileName = "App-NavGraph";
                    SFD.Filter = "Application NavGraph JSON file (*.ajson)|*.ajson";
                    break;
                }
                case ExportType.Zipped:
                {
                    SFD.DefaultExt = "ajson.zip";
                    SFD.FileName = "NavGraph";
                    SFD.Filter = "NavGraph Zipped JSON file (*.ajson.zip)|*.ajson.zip";
                    break;
                }
                case ExportType.FARap:
                default:
                {
                    SFD.DefaultExt = "apjson";
                    SFD.FileName = "Admin-NavGraph";
                    SFD.Filter = "Admin Panel NavGraph JSON file (*.apjson)|*.apjson";
                    break;
                }
            }

            switch (SFD.ShowDialog())
            {
                case DialogResult.Cancel:
                case DialogResult.Abort:
                case DialogResult.No:
                { return; }
            }

            FileSaveS = SFD.OpenFile();

            switch (ExportOptions)
            {
                case ExportType.FARap:
                { Filer.ExportToAdmin(FileSaveS, NG); break; }
                case ExportType.Zipped:
                { Filer.ExportToZipped(FileSaveS, NG); break; }
                default:
                case ExportType.FARa:
                { Filer.ExportToApp(FileSaveS, NG); break; }
            }
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog()
            {
                Filter = "NavGraph JSON files (*.apjson;*.ajson.zip)|*.apjson;*.ajson.zip",
                Title = "Choose NavGraph JSON file to import",
                SupportMultiDottedExtensions = true,
                RestoreDirectory = true,
                Multiselect = false,
                OkRequiresInteraction = true,
                CheckPathExists = true,
            };

            if (DefaultFileLoc == null)
            { OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }
            else
            { OFD.InitialDirectory = DefaultFileLoc; }

            switch (OFD.ShowDialog())
            {
                case DialogResult.None:
                case DialogResult.Cancel:
                case DialogResult.Abort:
                case DialogResult.Ignore:
                case DialogResult.No:
                { return; }
            }

            switch (Path.GetExtension(OFD.FileName))
            {
                case ".apjson":
                { Filer.ImportFromAdmin(OFD.OpenFile(), NG); break; }
                case ".zip":
                { Filer.ImportFromZipped(OFD.OpenFile(), NG); break; }
                default:
                { MessageBox.Show("IDKHOW, but that ain't the right file."); return; }
            }

            RefreshNodesTree();
            RefreshBlocksList();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        { Filer.CloseLocalFolders(); }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            if (Filer.CheckBackup())
            {
                var R = MessageBox.Show
                    ("Would you like to load the backup?", "Backup found!", MessageBoxButtons.YesNo);

                switch (R)
                {
                    case DialogResult.None:
                    case DialogResult.Cancel:
                    case DialogResult.Abort:
                    case DialogResult.Ignore:
                    case DialogResult.No:
                    {
                        Filer.DeleteBackup();
                        return;
                    }
                    case DialogResult.OK:
                    case DialogResult.Yes:
                    case DialogResult.Continue:
                    default:
                    {
                        Filer.LoadBackup(NG);

                        RefreshNodesTree();

                        break;
                    }
                }
            }
        }

        private void btn_CreateBlock_Click(object sender, EventArgs e)
        {

        }
    }

    public enum ExportType : int
    {
        FARap = 0,
        FARa = 1,
        Zipped = 2
    }
}
