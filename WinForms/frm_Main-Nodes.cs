using NavGraphTools;
using System.Diagnostics;

namespace WinForms
{
    public partial class frm_Main : Form
    {
        private void txt_PublicName_TextChanged(object sender, EventArgs e)
        { txt_InternalName.Text = txt_PublicName.Text.Trim(); }

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

            ResetNC_DGV();
        }

        private void btn_Node_Delete_Click(object sender, EventArgs e)
        {
            NG.RemoveNode(CurNodeUID);
            trvw_Nodes.Nodes.Remove(trvw_Nodes.SelectedNode);

            trvw_Nodes.Refresh();
            btn_Node_Save.Enabled = false;
            btn_Node_Delete.Enabled = false;

            dgv_NodeConnections.ClearSelection();
        }

        private void btn_Node_Save_Click(object sender, EventArgs e)
        {
            NavNode? TempNode = NG.TryGetNode(CurNodeUID);

            if (TempNode == null)
            { MessageBox.Show("There was an error getting the object to edit"); }

            TempNode.InternalName = txt_InternalName.Text.Trim();

            if (cmbx_BlockSelect.SelectedItem != null)
            { TempNode.BlockName = cmbx_BlockSelect.SelectedItem.ToString(); }

            TempNode.Floor = (int)nud_Node_Floor.Value;

            if (TempNode is CorridorNode CN)
            {
                foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
                {
                    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                    { NG.ConnectNodes(CurNodeUID, int.Parse((Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString()), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
                }
            }
            else if (TempNode is RoomNode RN)
            {
                RN.RoomName = txt_PublicName.Text.Trim();
                RN.Tags = txt_Node_Tags.Text.Split(new[] { ',' }).ToList();

                foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
                {
                    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                    { NG.ConnectNodes(CurNodeUID, int.Parse((Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString()), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
                }
            }
            else if (TempNode is GatewayNode GN)
            {
                //do later, am eeeepy
                //wtf was I supposed to do?
                foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
                {
                    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                    { NG.ConnectGatewayNodes(CurNodeUID, int.Parse((Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString())); }
                }
            }
            else if (TempNode is ElevationNode EN)
            {
                foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
                {
                    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                    { NG.ConnectElevationNodes(CurNodeUID, int.Parse((Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString()), (NodeDirection)Row.Tag); }
                }
            }

            NG.SetNode(CurNodeUID, TempNode);

            btn_Node_Save.Enabled = false;
            btn_Node_Delete.Enabled = false;
        }

        private void nud_Node_Floor_ValueChanged(object sender, EventArgs e)
        { CurFloor = (int)nud_Node_Floor.Value; }

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
            { dgv_NodeConnections.Enabled = true; }
            else
            { dgv_NodeConnections.Enabled = false; }

            if (cmbx_NodeType.SelectedItem.ToString() == "Elevation")
            {
                dgv_NodeConnections.Rows
                    [dgv_NodeConnections.Rows.Add("Up", null, false)]
                    .Tag = NodeDirection.Up;

                dgv_NodeConnections.Rows
                    [dgv_NodeConnections.Rows.Add("Down", null, false)]
                    .Tag = NodeDirection.Down;

                dgv_NodeConnections.Columns[2].Visible = false;

                txt_PublicName.Enabled = false;
            }
            else
            {
                List<int> RowsToRemove = new List<int>();

                foreach (DataGridViewRow R in dgv_NodeConnections.Rows)
                {
                    if (((NodeDirection)R.Tag == NodeDirection.Up || (NodeDirection)R.Tag == NodeDirection.Down))
                    { RowsToRemove.Add(R.Index); }
                }

                RowsToRemove.Reverse();

                foreach (var I in RowsToRemove)
                { dgv_NodeConnections.Rows.RemoveAt(I); }

                dgv_NodeConnections.Columns[2].Visible = true;

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

            if (cmbx_NodeType.SelectedItem.ToString() == "Gateway")
            {/*extra bits*/}
        }

        private void trvw_Nodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NavNode Temp;
            CurNodeUID = trvw_Nodes.SelectedNode.Text.SplitNodeID();

            //if (trvw_Nodes.SelectedNode.Text.Contains(':'))
            //{  }
            //else
            //{ CurNodeUID = SplitNodeID(trvw_Nodes.SelectedNode.Text); }

            Temp = NG.TryGetNode(CurNodeUID);

            txt_InternalName.Text = Temp.InternalName;

            if (Temp is CorridorNode)
            { cmbx_NodeType.SelectedItem = "Corridor"; }
            else if (Temp is RoomNode)
            { cmbx_NodeType.SelectedItem = "Room"; }
            else if (Temp is ElevationNode)
            { cmbx_NodeType.SelectedItem = "Elevation"; }
            else if (Temp is GatewayNode)
            { cmbx_NodeType.SelectedItem = "Gateway"; }

            gbx_Node.Text = $"Create/Edit Node: {CurNodeUID}";

            btn_Node_Save.Enabled = true;
            btn_Node_Delete.Enabled = true;
        }

        private void dgv_NodeConnections_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Stopwatch SW = new Stopwatch();

            /*
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

                    if (NodeEditMode)
                    { lstbx_AvailableNodes.SelectedItem = NG.TryGetNode(CurNodeUID).Nodes[CurDir]; }
                });
            });
             */

            int SelectedIndex = dgv_NodeConnections.SelectedRows[0].Index;

            if (dgv_NodeConnections.Rows[SelectedIndex].Tag != null)
            { CurDir = (NodeDirection)dgv_NodeConnections.Rows[SelectedIndex].Tag; }

            if (e.ColumnIndex == 1)
            {
                SW.Start();

                Task.Run(() =>
                {
                    var AvailableNodes = NG.GetAllNodes()
                        .AsParallel()
                        .Where(X => X.Key != CurNodeUID)
                        .Where
                        (
                            X => X.Value.BlockName == CurBlock
                            && X.Value.Floor == CurFloor
                            && X.Value.IsAvailable(CurDir)
                        )
                        .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                        .ToArray();

                    dgv_NodeConnections.Invoke(() =>
                    {
                        var CMBX = (dgv_NodeConnections.Rows[SelectedIndex].Cells[1] as DataGridViewComboBoxCell);

                        if (CMBX != null)
                        {
                            CMBX.Items.Clear();
                            CMBX.Items.AddRange(AvailableNodes);
                        }

                        dgv_NodeConnections.Refresh();
                    });
                });

                SW.Stop();
                Debug.WriteLine($"Retrieving Nodes took {SW.ElapsedMilliseconds}ms");
            }

        }

        private void ResetNC_DGV()
        {
            dgv_NodeConnections.ClearSelection();

            foreach (DataGridViewRow R in dgv_NodeConnections.Rows)
            {
                var DGVCBX = R.Cells[1] as DataGridViewComboBoxCell;

                DGVCBX.Items.Clear();
                DGVCBX.Value = null;
            }
        }

        private void dgv_GatewayConnections_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Create_Elevation()
        {
            ElevationNode EN = new ElevationNode();

            EN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            EN.Floor = (int)nud_Node_Floor.Value;
            EN.InternalName = txt_InternalName.Text;

            CurNodeUID = NG.AddNode(EN);

            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectElevationNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag); }
            }
        }

        private void Create_Room()
        {
            RoomNode RN = new RoomNode();

            RN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            RN.Floor = (int)nud_Node_Floor.Value;
            RN.InternalName = txt_InternalName.Text.Trim();
            RN.RoomName = txt_PublicName.Text.Trim();
            RN.Tags = txt_Node_Tags.Text.Split(new[] { ',' }).ToList();

            CurNodeUID = NG.AddNode(RN);

            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
            }

            //foreach (var CNN in TempNodeConnections)
            //{ NG.ConnectNodes(CurNodeUID, CNN.Value.UID, CNN.Key, CNN.Value.Oneway); }
        }

        private void Create_Corridor()
        {
            CorridorNode CN = new CorridorNode();

            CN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            CN.Floor = (int)nud_Node_Floor.Value;
            CN.InternalName = txt_InternalName.Text.Trim();

            CurNodeUID = NG.AddNode(CN);

            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
            }
        }

        private void Create_Gateway()
        {
            GatewayNode GN = new GatewayNode();

            GN.BlockName = cmbx_BlockSelect.SelectedItem.ToString();
            GN.Floor = (int)nud_Node_Floor.Value;
            GN.InternalName = txt_InternalName.Text.Trim();

            CurNodeUID = NG.AddNode(GN);

            foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
            {
                if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                { NG.ConnectGatewayNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID()); }
            }
        }

        private string GetNodeName(int _UID)
        { return NG.TryGetNode(_UID).InternalName; }
    }

    public static class Extensions
    {
        /// <summary>
        /// Takes a string and extracts the UID from it
        /// </summary>
        /// <returns>int extracted from input</returns>
        public static int SplitNodeID(this string _In)
        { return int.Parse(_In.Split(" ").First()); }
    }
}
