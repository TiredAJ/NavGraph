﻿using NavGraphTools;
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
                    { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
                }
            }
            else if (TempNode is RoomNode RN)
            {
                RN.RoomName = txt_PublicName.Text.Trim();
                RN.Tags = txt_Node_Tags.Text.Split(new[] { ',' }).ToList();

                foreach (DataGridViewRow Row in dgv_NodeConnections.Rows)
                {
                    if ((Row.Cells[1] as DataGridViewComboBoxCell).Value != null)
                    { NG.ConnectNodes(CurNodeUID, (Row.Cells[1] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID(), (NodeDirection)Row.Tag, (bool)Row.Cells[2].Value); }
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

            RefreshNodesTree();
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
            { SetupGW(); }
            else
            {
                pnl_NormalNodes.BringToFront();
                pnl_GW.Visible = false;
            }
        }

        private void trvw_Nodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NavNode? Temp;

            if (e.Node == null || e.Node.Level > 0)
            { return; }

            CurNodeUID = e.Node.Text.SplitNodeID();

            Temp = NG.TryGetNode(CurNodeUID);

            if (Temp == null)
            {
                MessageBox.Show("Node returned null!");
                return;
            }

            txt_InternalName.Text = Temp.InternalName;

            if (Temp is GatewayNode GN)
            {
                cmbx_NodeType.SelectedItem = "Gateway";

                pnl_GW.BringToFront();
                pnl_GW.Visible = true;

                cmbx_GW_AvailableNodes.Text = GN.GetConnectedNodes().First().Value.ToString();
                cmbx_GW_Direction.Text = GN.GetConnectedNodes().First().Key.ToString();

                dgv_GatewayConnections.Rows.Clear();

                foreach (var KVP in GN.GetConnectedGateways())
                { dgv_GatewayConnections.Rows.Add(KVP.Key); }
            }
            else
            {
                pnl_NormalNodes.BringToFront();
                pnl_GW.Visible = false;
            }

            if (Temp is ElevationNode EN)
            {
                cmbx_NodeType.SelectedItem = "Elevation";

                foreach (var KVP in EN.GetConnectedNodes())
                { dgv_NodeConnections.Rows.Add(KVP.Key, KVP.Value); }
            }
            else
            {
                if (Temp is CorridorNode)
                { cmbx_NodeType.SelectedItem = "Corridor"; }
                else if (Temp is RoomNode RN)
                {
                    cmbx_NodeType.SelectedItem = "Room";
                    txt_PublicName.Text = RN.RoomName;
                    txt_Node_Tags.Text = RN.Tags.ElementString();
                }

                //fix this \/

                foreach (var KVP in Temp.GetConnectedNodes())
                { dgv_NodeConnections.Rows.Add(KVP.Key, new DataGridViewComboBoxCell().Items.Add(KVP.Value)); }

                dgv_NodeConnections.Refresh();
            }

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
                //selected direction (and isn't the current GN)
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

            //int SelectedIndex = dgv_NodeConnections.SelectedRows[0].Index;

            if (e.RowIndex < 0)
            { return; }

            if (dgv_NodeConnections.Rows[e.RowIndex].Tag != null)
            { CurDir = (NodeDirection)dgv_NodeConnections.Rows[e.RowIndex].Tag; }

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
                            && X.Value.IsAvailable((NodeDirection)((int)CurDir * -1))
                        )
                        .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                        .ToArray();

                    dgv_NodeConnections.Invoke(() =>
                    {
                        var CMBX = (dgv_NodeConnections.Rows[e.RowIndex]
                                                            .Cells[1]
                                                            as DataGridViewComboBoxCell);

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
            Stopwatch SW = new Stopwatch();

            if (e.ColumnIndex == 0)
            {
                SW.Start();

                Task.Run(() =>
                {
                    var AvailableNodes = NG.GetAllNodes()
                        .AsParallel()
                        .Where(X => X.Key != CurNodeUID)
                        .Where
                        (
                            X => X.Value is GatewayNode GN
                            && !GN.IsConnected(CurNodeUID)
                        )
                        .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                        .ToArray();

                    dgv_NodeConnections.Invoke(() =>
                    {
                        var CMBX = (dgv_GatewayConnections.Rows[e.RowIndex]
                                                                        .Cells[e.ColumnIndex]
                                                                        as DataGridViewComboBoxCell);

                        if (CMBX != null)
                        {
                            CMBX.Items.Clear();
                            CMBX.Items.AddRange(AvailableNodes);
                        }

                        dgv_GatewayConnections.Refresh();
                    });
                });

                SW.Stop();
                Debug.WriteLine($"Retrieving Nodes took {SW.ElapsedMilliseconds}ms");
            }
        }

        private void Create_Elevation()
        {
            ElevationNode EN = new ElevationNode();

            EN.BlockName = cmbx_BlockSelect.Text;
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

            RN.BlockName = cmbx_BlockSelect.Text;
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

            CN.BlockName = cmbx_BlockSelect.Text;
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

            GN.BlockName = cmbx_BlockSelect.Text;
            GN.Floor = (int)nud_Node_Floor.Value;
            GN.InternalName = txt_InternalName.Text.Trim();

            CurNodeUID = NG.AddNode(GN);

            if (cmbx_GW_AvailableNodes.Text != string.Empty)
            { NG.ConnectGatewayNode(CurNodeUID, cmbx_GW_AvailableNodes.Text.SplitNodeID(), cmbx_GW_Direction.Text.ToDirection()); }


            foreach (DataGridViewRow Row in dgv_GatewayConnections.Rows)
            {
                if (Row.Cells[0] is DataGridViewComboBoxCell DGVCBX && DGVCBX.Value != null)
                { NG.ConnectGatewayNodes(CurNodeUID, (Row.Cells[0] as DataGridViewComboBoxCell).Value.ToString().SplitNodeID()); }
            }
        }

        private string GetNodeName(int _UID)
        { return NG.TryGetNode(_UID).InternalName; }

        private void SetupGW()
        {
            pnl_GW.BringToFront();
            pnl_GW.Visible = true;

            NodeDirection ND = (NodeDirection)((int)cmbx_GW_Direction.SelectedText.ToDirection() * -1);

            Task.Run(() =>
            {
                var AvailableNodes = NG.GetAllNodes()
                    .AsParallel()
                    .Where(X => X.Value is not GatewayNode)
                    .Where(X => X.Value.IsAvailable(ND))
                    .Select(X => $"{X.Key} \"{X.Value.InternalName}\"")
                    .ToArray();

                cmbx_GW_AvailableNodes.Invoke(() =>
                {
                    cmbx_GW_AvailableNodes.Items.Clear();
                    cmbx_GW_AvailableNodes.Items.AddRange(AvailableNodes);

                    cmbx_GW_AvailableNodes.Refresh();
                });
            });
        }

        private void RefreshNodesTree()
        {
            trvw_Nodes.Nodes.Clear();
            FillNodesTree();
        }
    }

    public class TempNode
    {
        public static int? UID, Floor;
        //Both used by all nodes

        public static string?
            PublicName = "", InternalName = "", BlockName = "";
        //   ^Room nodes                         ^used by all nodes
        //                    ^Used by all nodes

        public static Dictionary<NodeDirection, int>? NodeConnections = new();
        //Used by all nodes (with slight differences)

        public static Dictionary<int, string>? GatewayConnections = new();
        //Gateway nodes

        public static List<string>? Tags = new();
        //Room nodes

        public NodeDirection? ElvNodeDirection, GWNodeDirection;
        //All nodes bar GW and Elv for obvious reasons

    }
}
