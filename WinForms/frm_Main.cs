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
                    SFD.FileName = "A-NavGraph";
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
                    SFD.FileName = "AP-NavGraph";
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
                { ExportToAdmin(FileSaveS); break; }
                default:
                case ExportType.FARa:
                { ExportToApp(FileSaveS); break; }
                case ExportType.Zipped:
                { ExportToZipped(FileSaveS); break; }
            }
        }

        private void ExportToApp(Stream _DataStream)
        { NG.Serialise(_DataStream, NGSerialiseOptions.SerialiseForApp); }

        private void ExportToAdmin(Stream _DataStream)
        { }

        private void ExportToZipped(Stream _DataStream)
        {
            //maybe use 7zip?
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

            switch (Path.GetExtension(OFD.FileName))
            {
                case ".apjson":
                { ImportFromAdmin(OFD.OpenFile()); break; }
                case ".zip":
                { ImportFromZipped(OFD.OpenFile()); break; }
                default:
                { MessageBox.Show("IDKHOW, but that's not the right file?"); break; }
            }
        }

        private void ImportFromAdmin(Stream _File)
        {
            NG.Deserialise(_File);

        }

        private void ImportFromZipped(Stream _File)
        {
            using (FileStream F = _File as FileStream)
            {
                if (!F.Name.Contains(".ajson.zip"))
                {
                    MessageBox.Show("Wrong kinda zip file buddy");
                    return;
                }
            }

            //ImportFromAdmin();
        }
    }

    public enum ExportType : int
    {
        FARap = 0,
        FARa = 1,
        Zipped = 2
    }

}
