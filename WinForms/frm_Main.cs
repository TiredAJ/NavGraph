using NavGraphTools;

namespace WinForms
{
    public partial class frm_Main : Form
    {
        public NavGraph NG = new NavGraph(true);
        private string SelectedBlock = string.Empty;
        private int CurNodeUID = 0;
        private NodeDirection CurDir;
        private string CurBlock;
        private int CurFloor;
        private Dictionary<NodeDirection, (int UID, bool Oneway)> TempNodeConnections = new Dictionary<NodeDirection, (int UID, bool Oneway)>();

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
                ClearBox(gbx_NewBlock);
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
                    { Current.Nodes.Add($"{CN.Key}:{CN.Value}"); }
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
            lstbx_AvailableNodes.Items.Remove(SelectedBlock);

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
        #endregion

        #region Nodes
        private void cmbx_BlockSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Floor = NG.Blocks[cmbx_BlockSelect.SelectedItem.ToString()];

            nud_Node_Floor.Maximum = Floor.Max;
            nud_Node_Floor.Minimum = Floor.Min;

            CurBlock = cmbx_BlockSelect.SelectedItem.ToString();
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
            {
                txt_Node_Tags.Enabled = true;
                txt_PublicName.Enabled = true;
            }
            else
            {
                txt_Node_Tags.Enabled = false;
                txt_PublicName.Enabled = false;
            }
        }

        private void nud_Node_Floor_ValueChanged(object sender, EventArgs e)
        { CurFloor = (int)nud_Node_Floor.Value; }

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
                        X => X.Value.BlockName == CurBlock
                        && X.Value.Floor == CurFloor
                     )
                    .Where
                     (
                        X => X.Key != CurNodeUID &&
                        X.Value.IsAvailable(CurDir)
                     )
                    .Select(X => (object)X.Key)
                    .ToArray();

                lstbx_AvailableNodes.Invoke(() =>
                {
                    lstbx_AvailableNodes.Items.Clear();
                    lstbx_AvailableNodes.Items.AddRange(AvailableNodes);
                    lstbx_AvailableNodes.Refresh();
                });
            });
        }

        private void trvw_Nodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvw_Nodes.SelectedNode.Text.Contains(':'))
            {CurNodeUID = int.Parse(trvw_Nodes.SelectedNode.Text.Split([':'])[1]);}
            else
            {CurNodeUID = int.Parse(trvw_Nodes.SelectedNode.Text);}

            TempNodeConnections.Clear();

            gbx_Node.Text = $"Create/Edit Node: {CurNodeUID}";
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

            RefreshNodesTree();
            ClearBox(gbx_Node);
        }

        private void lstbx_AvailableNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Temp = int.Parse(lstbx_AvailableNodes.SelectedItem.ToString());
            bool IsOneWay = chkbx_OneWay.Checked;

            if (TempNodeConnections.ContainsKey(CurDir))
            { TempNodeConnections[CurDir] = (Temp, IsOneWay); }
            else
            { TempNodeConnections.Add(CurDir, (Temp, IsOneWay)); }
        }

        private void Create_Elevation()
        {
            ElevationNode EN = new ElevationNode();

            EN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            EN.Floor = (int)nud_Node_Floor.Value;
            EN.InternalName = txt_InternalName.Text;

            CurNodeUID = NG.AddNode(EN);

            foreach (var CNN in TempNodeConnections)
            { NG.ConnectElevationNodes(CurNodeUID, CNN.Value.UID, CNN.Key); }
        }

        private void Create_Room()
        {
            RoomNode RN = new RoomNode();

            RN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            RN.Floor = (int)nud_Node_Floor.Value;
            RN.InternalName = txt_InternalName.Text;
            RN.RoomName = txt_PublicName.Text;
            RN.Tags = txt_Node_Tags.Text.Split([',']).ToList();

            CurNodeUID = NG.AddNode(RN);

            foreach (var CNN in TempNodeConnections)
            { NG.ConnectNodes(CurNodeUID, CNN.Value.UID, CNN.Key, CNN.Value.Oneway); }
        }

        private void Create_Corridor()
        {
            CorridorNode CN = new CorridorNode();

            CN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            CN.Floor = (int)nud_Node_Floor.Value;
            CN.InternalName = txt_InternalName.Text;

            CurNodeUID = NG.AddNode(CN);

            foreach (var CNN in TempNodeConnections)
            { NG.ConnectNodes(CurNodeUID, CNN.Value.UID, CNN.Key, CNN.Value.Oneway); }
        }

        private void Create_Gateway()
        {
            GatewayNode GN = new GatewayNode();

            GN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            GN.Floor = (int)nud_Node_Floor.Value;
            GN.InternalName = txt_InternalName.Text;

            CurNodeUID = NG.AddNode(GN);

            foreach (var CNN in TempNodeConnections)
            { NG.ConnectGatewayNodes(CurNodeUID, CNN.Value.UID); }
        }

        private void btn_Node_Delete_Click(object sender, EventArgs e)
        {
            NG.RemoveNode(CurNodeUID);
            trvw_Nodes.Nodes.Remove(trvw_Nodes.SelectedNode);

            trvw_Nodes.Refresh();
        }

        private void btn_Node_Save_Click(object sender, EventArgs e)
        {
            NavNode? TempNode = NG.TryGetNode(CurNodeUID);

            if (TempNode == null)
            { MessageBox.Show("There was an error getting the object to edit"); }

            TempNode.InternalName = txt_InternalName.Text;
            TempNode.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            TempNode.Floor = (int)nud_Node_Floor.Value;

            if (TempNode is CorridorNode CN)
            {
                foreach (var CNN in TempNodeConnections)
                { NG.ConnectNodes(CurNodeUID, CNN.Value.UID, CNN.Key, CNN.Value.Oneway); }
            }
            else if (TempNode is RoomNode RN)
            {
                RN.RoomName = txt_PublicName.Text;
                RN.Tags = txt_Node_Tags.Text.Split([',']).ToList();

                foreach (var CNN in TempNodeConnections)
                { NG.ConnectNodes(CurNodeUID, CNN.Value.UID, CNN.Key, CNN.Value.Oneway); }
            }
            else if (TempNode is GatewayNode GN)
            {
                //do later, am eeeepy
                foreach (var CNN in TempNodeConnections)
                { NG.ConnectGatewayNodes(CurNodeUID, CNN.Value.UID); }
            }
            else if (TempNode is ElevationNode EN)
            {
                foreach (var CNN in TempNodeConnections)
                { NG.ConnectElevationNodes(CurNodeUID, CNN.Value.UID, CNN.Key); }
            }

            NG.SetNode(CurNodeUID, TempNode);
        }
        #endregion

        #region Misc
        private void ClearBox(GroupBox _GBX)
        {
            CurNodeUID = 0;

            foreach (Control C in _GBX.Controls)
            {
                if (C is TextBox TXT)
                { TXT.Text = ""; }
                else if (C is NumericUpDown NUD)
                { NUD.Value = 0; }
                else if (C is ComboBox CMBX)
                { CMBX.SelectedItem = -1; }
                else if (C is CheckBox CHKBX)
                { CHKBX.Checked = false; }

                C.Refresh();
            }
        }
        #endregion
    }
}
