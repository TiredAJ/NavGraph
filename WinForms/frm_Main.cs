// Ignore Spelling: frm

using NavGraphTools;
using NavGraphTools.Utilities;
using WinForms.Back;
using WinForms.Tools;

namespace WinForms;

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
    private ExportType ExportOptions = ExportType.FARap;
    #endregion
    #endregion

    public frm_Main()
    {
        InitializeComponent();

        NG.Blocks.Add("Johnstone", (4, 0));
        RefreshBlocksList();

        pnl_conn_Down.Tag = NodeDirection.Down;
        pnl_conn_Up.Tag = NodeDirection.Up;
        pnl_conn_North.Tag = NodeDirection.North;
        pnl_conn_East.Tag = NodeDirection.East;
        pnl_conn_South.Tag = NodeDirection.South;
        pnl_conn_West.Tag = NodeDirection.West;

        cmbx_conn_Down.Tag = NodeDirection.Down;
        cmbx_conn_Up.Tag = NodeDirection.Up;
        cmbx_conn_North.Tag = NodeDirection.North;
        cmbx_conn_East.Tag = NodeDirection.East;
        cmbx_conn_South.Tag = NodeDirection.South;
        cmbx_conn_West.Tag = NodeDirection.West;

        pnl_edit_conn_Down.Tag = NodeDirection.Down;
        pnl_edit_conn_Up.Tag = NodeDirection.Up;
        pnl_edit_conn_North.Tag = NodeDirection.North;
        pnl_edit_conn_East.Tag = NodeDirection.East;
        pnl_edit_conn_South.Tag = NodeDirection.South;
        pnl_edit_conn_West.Tag = NodeDirection.West;

        //dgv_GatewayConnections.Rows.Add();

        Layouter = new();

        cmbx_BlockSelect.SelectedIndex = 0;
        cmbx_NodeType.SelectedIndex = 0;
    }

    private void ClearBox(Control _BX)
    {
        if (_BX is not GroupBox & _BX is not Panel)
        { return; }

        CurNodeUID = 0;

        foreach (Control C in _BX.Controls)
        {
            if (C.Tag != null && C.Tag.ToString().Contains("ClearMe"))
            {
                if (C is TextBox TXT)
                { TXT.Text = ""; }
                else if (C is CheckBox CHKBX)
                { CHKBX.Checked = false; }

                C.Refresh();
            }
        }
    }

    private void rbtn_Export_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is RadioButton SE)
        { ExportOptions = (ExportType)int.Parse(SE.Tag.ToString()); }
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

        //if (DefaultFileLoc == null)
        //{ SFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }
        //else
        //{ SFD.InitialDirectory = DefaultFileLoc; }

        if (Directory.Exists("E:\\GitHub\\_Individual Project\\NavGraph\\NavGraph\\Notes"))
        { SFD.InitialDirectory = "E:\\GitHub\\_Individual Project\\NavGraph\\NavGraph\\Notes"; }


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
            AddToRecent = true
        };

        if (Directory.Exists("E:\\GitHub\\_Individual Project\\NavGraph\\NavGraph\\Notes"))
        { OFD.InitialDirectory = "E:\\GitHub\\_Individual Project\\NavGraph\\NavGraph\\Notes"; }

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

        foreach (TreeNode TN in trvw_Nodes.Nodes)
        {
            TN.Expand();

            foreach (TreeNode TN2 in TN.Nodes)
            { TN2.Expand(); }
        }

        cmbx_tag_Tags.Items.AddRange(NG.GetTags().ToArray());
    }

    private void tbctrl_MainTabs_Selected(object sender, TabControlEventArgs e)
    {
        if (e.TabPage == tbpg_Settings)
        {
            txt_set_id_ElvES.Text = LayoutHelper.NodeIdentifiers["EN0"];
            txt_set_id_ElvEE.Text = LayoutHelper.NodeIdentifiers["EN1"];
            txt_set_id_Corridor.Text = LayoutHelper.NodeIdentifiers["CN"];
            txt_set_id_GW.Text = LayoutHelper.NodeIdentifiers["GW"];
            txt_set_id_Room.Text = LayoutHelper.NodeIdentifiers["RN"];
        }
        else if (e.TabPage == tbpg_Stats)
        { LoadStats(); }
    }

    private void tbctrl_MainTabs_Selecting(object sender, TabControlCancelEventArgs e)
    {
        if (e.TabPage == tbpg_EditNode && CurNodeUID == 0)
        { e.Cancel = true; }
        else if (e.TabPage == tbpg_EditNode)
        { EditLoad(); }
        else if (e.TabPage == tbpg_Stats && NG.NodeCount == 0)
        { e.Cancel = true; }
    }

    private Task<string[]> GetAvailableElvGW<T>(string _CurBlock, int _CurFloor, List<int> _CurrentConn) where T : ISpecialNode
    {
        return Task.Run(() =>
        {
            return NG.GetAllNodes()
                    .AsParallel()
                    .Where
                    (
                        X => X.Value.BlockName == _CurBlock
                        && X.Value.Floor == _CurFloor
                    )
                    .Where(X => X.Value is T)
                    .OrderByDescending(X => X.Key)
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();
        });
    }

    private void btn_Nodes_GenDirection_Click(object sender, EventArgs e)
    {
        tbctrl_MainTabs.Enabled = false;

        Flow_er F = new Flow_er(ref NG);

        var Result = MessageBox.Show("Would you like to clear existing flows?", "Flow purge confirmation", MessageBoxButtons.YesNoCancel);

        F.Progress += ((object _S, ProgressEvent e) => Task.Run(() =>
        {
            if (e.Done)
            {
                MessageBox.Show("Flow_er complete!");

                trvw_Nodes.Invoke(() =>
                { RefreshNodesTree(); });

                return;
            }

            pbr_Nodes_FlowGenProgress.Invoke(() =>
            {
                if (e.InitEvent)
                {
                    pbr_Nodes_FlowGenProgress.Maximum = e.Max;
                    pbr_Nodes_FlowGenProgress.Minimum = e.Min;
                }

                pbr_Nodes_FlowGenProgress.Value = e.Current;
                pbr_Nodes_FlowGenProgress.Refresh();

            });
        }));

        switch (Result)
        {
            default:
            case DialogResult.Cancel:
            { return; }
            case DialogResult.Yes:
            { F.GenerateFlows(true); break; }
            case DialogResult.No:
            { F.GenerateFlows(false); break; }
        }

        tbctrl_MainTabs.Enabled = true;
    }

    public async void LoadStats()
    {
        Stats_er S = new Stats_er(ref NG);

        Stats Result = await S.GetStats();

        tbpg_Stats.Invoke(() =>
        {
            txt_stats_TotalNodeCount.Text = Result.AllNodes.ToString();
            txt_stats_nodes_CNCount.Text = Result.CN.ToString();
            txt_stats_nodes_ENCount.Text = Result.EN.ToString();
            txt_stats_nodes_GWCount.Text = Result.GW.ToString();
            txt_stats_nodes_RNCount.Text = Result.RN.ToString();

            txt_stats_dist_ENDist.Text = Result.AverageENDistance.ToString("N2");
            txt_stats_dist_GWDist.Text = Result.AverageGWDistance.ToString("N2");

            txt_stats_nodes_Connections.Text = Result.Connections.ToString();

            foreach (var KVP in Result.Tags.OrderByDescending(X => X.Value))
            { lstbx_stats_misc_Tags.Items.Add($"{KVP.Value}: {KVP.Key}"); }

            txt_stats_misc_TagsCount.Text = $"{Result.Tags.Count} tags";

            foreach (var N in Result.IsolatedNodes.Nodes)
            {
                lstbx_stats_misc_IsolatedNodes.Items
                    .Add($"{N.UID}: {N.InternalName}");
            }

            txt_stats_misc_IsoNodesCount.Text = $"{Result.IsolatedNodes.Count} nodes";
        });
    }
}

public enum ExportType : int
{
    FARap = 0,
    FARa = 1,
    Zipped = 2
}
