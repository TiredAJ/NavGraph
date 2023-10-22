using NavGraphTools;

namespace WinForms
{
    public partial class frm_Main : Form
    {
        public NavGraph NG = new NavGraph(true);

        private string SelectedBlock = string.Empty;

        private int CurNodeUID = 0;
        private NodeDirection CurDir;

        private Dictionary<NodeDirection, int> TempNodeConnections = new Dictionary<NodeDirection, int>();

        public frm_Main()
        { InitializeComponent(); }

        #region Blocks
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
            }
        }

        private void RefreshBlocksList()
        {
            lst_Blocks.Items.Clear();
            cmbx_BlockSelect.Items.Clear();
            FillBlocksControls();
        }

        private void RefreshNodesTree()
        {
            trvw_Nodes.Nodes.Clear();
            FillNodesTree();
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
                Current = trvw_Nodes.Nodes.Add(N.Key.ToString());

                if (!(N.Value is GatewayNode))
                {
                    foreach (var CN in N.Value.GetConnectedNodes())
                    { Current.Nodes.Add(CN.Value.ToString()); }
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
                        (txt_New_BlockName.Text,
                        ((int)nud_New_HighestFloor.Value, (int)nud_New_LowestFloor.Value));


                }
            }
        }

        private void lst_Blocks_SelectedIndexChanged(object sender, EventArgs e)
        { SelectedBlock = (string)lst_Blocks.SelectedItem; }
        #endregion

        #region Nodes
        private void cmbx_BlockSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Floor = NG.Blocks[cmbx_BlockSelect.SelectedItem.ToString()];

            nud_Node_Floor.Maximum = Floor.Max;
            nud_Node_Floor.Minimum = Floor.Min;
        }

        private void cmbx_NodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbx_NodeType.SelectedIndex >= 0)
            { gbx_Node_Connections.Enabled = true; }
            else
            { gbx_Node_Connections.Enabled = false; }

            if (cmbx_NodeType.SelectedItem.ToString() == "Elevation")
            {
                cmbx_NodeDirection.Items.AddRange(new[] { "Up", "Down" });
                txt_PublicName.Enabled = false;
            }
            else
            {
                cmbx_NodeDirection.Items.Remove("Up");
                cmbx_NodeDirection.Items.Remove("Down");
                txt_PublicName.Enabled = true;
            }

            if (cmbx_NodeType.SelectedItem.ToString() == "Room")
            { txt_Node_Tags.Enabled = true; }
            else
            { txt_Node_Tags.Enabled = false; }
        }
        private void cmbx_NodeDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbx_NodeDirection.SelectedItem.ToString())
            {
                default:
                { throw new Exception($"wtf: {cmbx_NodeDirection.SelectedItem}"); }
                case "North":
                { CurDir = NodeDirection.North; break; }
                case "East":
                { CurDir = NodeDirection.East; break; }
                case "South":
                { CurDir = NodeDirection.South; break; }
                case "West":
                { CurDir = NodeDirection.West; break; }
                case "Up":
                { CurDir = NodeDirection.Up; break; }
                case "Down":
                { CurDir = NodeDirection.Down; break; }
            }

            Task.Run(() =>
            {
                //Filters through all nodes to find ones that aren't connected on the
                //selected direction (and isn't the current node)
                var AvailableNodes = NG.GetAllNodes()
                    .Where
                     (
                        X => X.Key != CurNodeUID &&
                        X.Value.IsAvailable(CurDir)
                     )
                    .Select(X => (object)X.Key)
                    .ToArray();

                lstbx_AvailableNodes.Invoke(() =>
                { lstbx_AvailableNodes.Items.AddRange(AvailableNodes); });
            });
        }

        #endregion

        private void trvw_Nodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CurNodeUID = int.Parse(trvw_Nodes.SelectedNode.Text);
            TempNodeConnections.Clear();
        }

        private void btn_Node_Create_Click(object sender, EventArgs e)
        {
            if (cmbx_NodeType.SelectedItem.ToString() == "Elevation")
            { Create_Elevation(); }
            else if (cmbx_NodeType.SelectedItem.ToString() == "Room")
            { Create_Room(); }
            else if (cmbx_NodeType.SelectedItem.ToString() == "Corridor")
            { Create_Corridor(); }
            else if (cmbx_NodeType.SelectedItem.ToString() == "Gateway")
            { Create_Gateway(); }
        }

        private void lstbx_AvailableNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Temp = int.Parse(lstbx_AvailableNodes.SelectedItem.ToString());

            if (TempNodeConnections.ContainsKey(CurDir))
            {TempNodeConnections[CurDir] = Temp;}
            else
            {TempNodeConnections.Add(CurDir, Temp);}
        }

        private void Create_Elevation()
        {
            ElevationNode EN = new ElevationNode();

            EN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            EN.Floor = (int)nud_Node_Floor.Value;
            EN.InternalName = txt_InternalName.Text;

            foreach (var CNN in TempNodeConnections)
            {EN.AddConnectedNode(CNN.Value, CNN.Key);}

            NG.AddNode(EN);
        }

        private void Create_Room()
        {
            RoomNode RN = new RoomNode();

            RN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            RN.Floor = (int)nud_Node_Floor.Value;
            RN.InternalName = txt_InternalName.Text;
            RN.RoomName = txt_PublicName.Text;
            RN.Tags = txt_Node_Tags.Text.Split([',']).ToList();

            foreach (var CNN in TempNodeConnections)
            { RN.AddConnectedNode(CNN.Value, CNN.Key); }

            NG.AddNode(RN);
        }

        private void Create_Corridor()
        {
            CorridorNode CN = new CorridorNode();


            NG.AddNode(CN);
        }

        private void Create_Gateway()
        {
            GatewayNode GN = new GatewayNode();

            NG.AddNode(GN);
        }
    }
}
