namespace WinForms
{
    partial class frm_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tbctrl_MainTabs = new TabControl();
            tbpg_Nodes = new TabPage();
            gbx_Node = new GroupBox();
            btn_SaveBackup = new Button();
            label10 = new Label();
            cmbx_GWFlow = new ComboBox();
            label9 = new Label();
            cmbx_ElvFlow = new ComboBox();
            btn_Node_Delete = new Button();
            btn_Node_Save = new Button();
            btn_Node_Create = new Button();
            txt_InternalName = new TextBox();
            label5 = new Label();
            txt_PublicName = new TextBox();
            label4 = new Label();
            nud_Node_Floor = new NumericUpDown();
            label3 = new Label();
            cmbx_NodeType = new ComboBox();
            label2 = new Label();
            cmbx_BlockSelect = new ComboBox();
            label1 = new Label();
            pnl_NormalNodes = new Panel();
            dgv_NodeConnections = new DataGridView();
            label7 = new Label();
            txt_Node_Tags = new TextBox();
            pnl_GW = new Panel();
            label8 = new Label();
            cmbx_GW_AvailableNodes = new ComboBox();
            label6 = new Label();
            cmbx_GW_Direction = new ComboBox();
            dgv_GatewayConnections = new DataGridView();
            dgvcmbx_GW_AvailableNodes = new DataGridViewComboBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            trvw_Nodes = new TreeView();
            tbpg_Blocks = new TabPage();
            pnl_Right_Blocks = new Panel();
            gbx_EditBlock = new GroupBox();
            nud_Edit_HighestFloor = new NumericUpDown();
            btn_Delete = new Button();
            lbl_Edit_HighestFloor = new Label();
            btn_SaveBlock = new Button();
            nud_Edit_LowestFloor = new NumericUpDown();
            lbl_Edit_BlockName = new Label();
            lbl_Edit_LowestFloor = new Label();
            txt_Edit_BlockName = new TextBox();
            gbx_NewBlock = new GroupBox();
            btn_CreateBlock = new Button();
            nud_New_HighestFloor = new NumericUpDown();
            lbl_New_HighestFloor = new Label();
            nud_New_LowestFloor = new NumericUpDown();
            lbl_New_LowestFloor = new Label();
            lbl_New_BlockName = new Label();
            txt_New_BlockName = new TextBox();
            lst_Blocks = new ListBox();
            tbpg_Export = new TabPage();
            panel2 = new Panel();
            btn_Import = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            rbtn_Export_FARapp = new RadioButton();
            radioButton2 = new RadioButton();
            rbtn_Export_Both = new RadioButton();
            btn_Export = new Button();
            tbpg_Combine = new TabPage();
            textBox1 = new TextBox();
            tbpg_Settings = new TabPage();
            txt_set_Layout = new TextBox();
            btn_set_SaveSettings = new Button();
            panel4 = new Panel();
            label16 = new Label();
            txt_set_Prefix = new TextBox();
            groupBox1 = new GroupBox();
            txt_set_id_Corridor = new TextBox();
            label15 = new Label();
            txt_set_id_Room = new TextBox();
            label14 = new Label();
            txt_set_id_GW = new TextBox();
            label13 = new Label();
            txt_set_id_Elv = new TextBox();
            lbl_set_id_Elv = new Label();
            label12 = new Label();
            txt_set_Separator = new TextBox();
            label11 = new Label();
            lbl_NameTemplate = new Label();
            clm_NodeDirection = new DataGridViewTextBoxColumn();
            clm_AvailNodes = new DataGridViewComboBoxColumn();
            clm_SelectNode = new DataGridViewButtonColumn();
            clm_OneWay = new DataGridViewCheckBoxColumn();
            tbctrl_MainTabs.SuspendLayout();
            tbpg_Nodes.SuspendLayout();
            gbx_Node.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).BeginInit();
            pnl_NormalNodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_NodeConnections).BeginInit();
            pnl_GW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_GatewayConnections).BeginInit();
            tbpg_Blocks.SuspendLayout();
            pnl_Right_Blocks.SuspendLayout();
            gbx_EditBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_HighestFloor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_LowestFloor).BeginInit();
            gbx_NewBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_New_HighestFloor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_New_LowestFloor).BeginInit();
            tbpg_Export.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tbpg_Combine.SuspendLayout();
            tbpg_Settings.SuspendLayout();
            panel4.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tbctrl_MainTabs
            // 
            tbctrl_MainTabs.Controls.Add(tbpg_Nodes);
            tbctrl_MainTabs.Controls.Add(tbpg_Blocks);
            tbctrl_MainTabs.Controls.Add(tbpg_Export);
            tbctrl_MainTabs.Controls.Add(tbpg_Combine);
            tbctrl_MainTabs.Controls.Add(tbpg_Settings);
            tbctrl_MainTabs.Dock = DockStyle.Fill;
            tbctrl_MainTabs.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbctrl_MainTabs.HotTrack = true;
            tbctrl_MainTabs.Location = new Point(0, 0);
            tbctrl_MainTabs.Multiline = true;
            tbctrl_MainTabs.Name = "tbctrl_MainTabs";
            tbctrl_MainTabs.SelectedIndex = 0;
            tbctrl_MainTabs.Size = new Size(1023, 620);
            tbctrl_MainTabs.TabIndex = 0;
            tbctrl_MainTabs.TabStop = false;
            // 
            // tbpg_Nodes
            // 
            tbpg_Nodes.Controls.Add(gbx_Node);
            tbpg_Nodes.Controls.Add(trvw_Nodes);
            tbpg_Nodes.Location = new Point(4, 34);
            tbpg_Nodes.Name = "tbpg_Nodes";
            tbpg_Nodes.Padding = new Padding(3);
            tbpg_Nodes.Size = new Size(1015, 582);
            tbpg_Nodes.TabIndex = 0;
            tbpg_Nodes.Text = "Nodes";
            tbpg_Nodes.UseVisualStyleBackColor = true;
            // 
            // gbx_Node
            // 
            gbx_Node.Controls.Add(btn_SaveBackup);
            gbx_Node.Controls.Add(label10);
            gbx_Node.Controls.Add(cmbx_GWFlow);
            gbx_Node.Controls.Add(label9);
            gbx_Node.Controls.Add(cmbx_ElvFlow);
            gbx_Node.Controls.Add(btn_Node_Delete);
            gbx_Node.Controls.Add(btn_Node_Save);
            gbx_Node.Controls.Add(btn_Node_Create);
            gbx_Node.Controls.Add(txt_InternalName);
            gbx_Node.Controls.Add(label5);
            gbx_Node.Controls.Add(txt_PublicName);
            gbx_Node.Controls.Add(label4);
            gbx_Node.Controls.Add(nud_Node_Floor);
            gbx_Node.Controls.Add(label3);
            gbx_Node.Controls.Add(cmbx_NodeType);
            gbx_Node.Controls.Add(label2);
            gbx_Node.Controls.Add(cmbx_BlockSelect);
            gbx_Node.Controls.Add(label1);
            gbx_Node.Controls.Add(pnl_NormalNodes);
            gbx_Node.Controls.Add(pnl_GW);
            gbx_Node.Dock = DockStyle.Fill;
            gbx_Node.Location = new Point(460, 3);
            gbx_Node.Name = "gbx_Node";
            gbx_Node.Padding = new Padding(5);
            gbx_Node.Size = new Size(552, 576);
            gbx_Node.TabIndex = 0;
            gbx_Node.TabStop = false;
            gbx_Node.Text = "Create/Edit Node";
            // 
            // btn_SaveBackup
            // 
            btn_SaveBackup.Location = new Point(417, 538);
            btn_SaveBackup.Name = "btn_SaveBackup";
            btn_SaveBackup.Size = new Size(132, 33);
            btn_SaveBackup.TabIndex = 19;
            btn_SaveBackup.Text = "Save Backup";
            btn_SaveBackup.UseVisualStyleBackColor = true;
            btn_SaveBackup.Click += btn_SaveBackup_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(198, 158);
            label10.Name = "label10";
            label10.Size = new Size(128, 25);
            label10.TabIndex = 18;
            label10.Text = "Gateway Flow";
            // 
            // cmbx_GWFlow
            // 
            cmbx_GWFlow.FormattingEnabled = true;
            cmbx_GWFlow.Items.AddRange(new object[] { "North", "East", "South", "West" });
            cmbx_GWFlow.Location = new Point(197, 186);
            cmbx_GWFlow.Name = "cmbx_GWFlow";
            cmbx_GWFlow.Size = new Size(187, 33);
            cmbx_GWFlow.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 158);
            label9.Name = "label9";
            label9.Size = new Size(124, 25);
            label9.TabIndex = 16;
            label9.Text = "Elevator Flow";
            // 
            // cmbx_ElvFlow
            // 
            cmbx_ElvFlow.FormattingEnabled = true;
            cmbx_ElvFlow.Items.AddRange(new object[] { "North", "East", "South", "West" });
            cmbx_ElvFlow.Location = new Point(8, 186);
            cmbx_ElvFlow.Name = "cmbx_ElvFlow";
            cmbx_ElvFlow.Size = new Size(183, 33);
            cmbx_ElvFlow.TabIndex = 15;
            // 
            // btn_Node_Delete
            // 
            btn_Node_Delete.Location = new Point(298, 538);
            btn_Node_Delete.Name = "btn_Node_Delete";
            btn_Node_Delete.Size = new Size(95, 33);
            btn_Node_Delete.TabIndex = 9;
            btn_Node_Delete.Text = "Delete";
            btn_Node_Delete.UseVisualStyleBackColor = true;
            btn_Node_Delete.Click += btn_Node_Delete_Click;
            // 
            // btn_Node_Save
            // 
            btn_Node_Save.Enabled = false;
            btn_Node_Save.Location = new Point(161, 538);
            btn_Node_Save.Name = "btn_Node_Save";
            btn_Node_Save.Size = new Size(95, 33);
            btn_Node_Save.TabIndex = 8;
            btn_Node_Save.Text = "Save";
            btn_Node_Save.UseVisualStyleBackColor = true;
            btn_Node_Save.Click += btn_Node_Save_Click;
            // 
            // btn_Node_Create
            // 
            btn_Node_Create.Location = new Point(8, 538);
            btn_Node_Create.Name = "btn_Node_Create";
            btn_Node_Create.Size = new Size(95, 33);
            btn_Node_Create.TabIndex = 7;
            btn_Node_Create.Text = "Create";
            btn_Node_Create.UseVisualStyleBackColor = true;
            btn_Node_Create.Click += btn_Node_Create_Click;
            // 
            // txt_InternalName
            // 
            txt_InternalName.Location = new Point(197, 122);
            txt_InternalName.Name = "txt_InternalName";
            txt_InternalName.Size = new Size(185, 33);
            txt_InternalName.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(200, 94);
            label5.Name = "label5";
            label5.Size = new Size(132, 25);
            label5.TabIndex = 7;
            label5.Text = "Internal Name";
            // 
            // txt_PublicName
            // 
            txt_PublicName.Location = new Point(6, 122);
            txt_PublicName.Name = "txt_PublicName";
            txt_PublicName.Size = new Size(185, 33);
            txt_PublicName.TabIndex = 3;
            txt_PublicName.Tag = "ClearMe";
            txt_PublicName.TextChanged += txt_PublicName_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 94);
            label4.Name = "label4";
            label4.Size = new Size(119, 25);
            label4.TabIndex = 5;
            label4.Text = "Public Name";
            // 
            // nud_Node_Floor
            // 
            nud_Node_Floor.Location = new Point(389, 53);
            nud_Node_Floor.Name = "nud_Node_Floor";
            nud_Node_Floor.Size = new Size(158, 33);
            nud_Node_Floor.TabIndex = 2;
            nud_Node_Floor.ValueChanged += nud_Node_Floor_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(390, 24);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 3;
            label3.Text = "Floor";
            // 
            // cmbx_NodeType
            // 
            cmbx_NodeType.AutoCompleteMode = AutoCompleteMode.Append;
            cmbx_NodeType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_NodeType.FormattingEnabled = true;
            cmbx_NodeType.Items.AddRange(new object[] { "Corridor", "Room", "Elevation", "Gateway" });
            cmbx_NodeType.Location = new Point(6, 53);
            cmbx_NodeType.Name = "cmbx_NodeType";
            cmbx_NodeType.Size = new Size(185, 33);
            cmbx_NodeType.TabIndex = 0;
            cmbx_NodeType.SelectedIndexChanged += cmbx_NodeType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 25);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 2;
            label2.Text = "Node Type";
            // 
            // cmbx_BlockSelect
            // 
            cmbx_BlockSelect.AutoCompleteMode = AutoCompleteMode.Append;
            cmbx_BlockSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_BlockSelect.FormattingEnabled = true;
            cmbx_BlockSelect.Location = new Point(197, 53);
            cmbx_BlockSelect.Name = "cmbx_BlockSelect";
            cmbx_BlockSelect.Size = new Size(185, 33);
            cmbx_BlockSelect.TabIndex = 1;
            cmbx_BlockSelect.SelectedIndexChanged += cmbx_BlockSelect_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(199, 23);
            label1.Name = "label1";
            label1.Size = new Size(57, 25);
            label1.TabIndex = 0;
            label1.Text = "Block";
            // 
            // pnl_NormalNodes
            // 
            pnl_NormalNodes.BackColor = SystemColors.ControlLight;
            pnl_NormalNodes.Controls.Add(dgv_NodeConnections);
            pnl_NormalNodes.Controls.Add(label7);
            pnl_NormalNodes.Controls.Add(txt_Node_Tags);
            pnl_NormalNodes.Location = new Point(2, 230);
            pnl_NormalNodes.Margin = new Padding(3, 4, 3, 4);
            pnl_NormalNodes.Name = "pnl_NormalNodes";
            pnl_NormalNodes.Size = new Size(546, 301);
            pnl_NormalNodes.TabIndex = 1;
            // 
            // dgv_NodeConnections
            // 
            dgv_NodeConnections.AllowUserToAddRows = false;
            dgv_NodeConnections.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_NodeConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_NodeConnections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_NodeConnections.Columns.AddRange(new DataGridViewColumn[] { clm_NodeDirection, clm_AvailNodes, clm_SelectNode, clm_OneWay });
            dgv_NodeConnections.Dock = DockStyle.Top;
            dgv_NodeConnections.Location = new Point(0, 0);
            dgv_NodeConnections.Name = "dgv_NodeConnections";
            dgv_NodeConnections.RowHeadersWidth = 51;
            dgv_NodeConnections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_NodeConnections.Size = new Size(546, 207);
            dgv_NodeConnections.TabIndex = 5;
            dgv_NodeConnections.TabStop = false;
            dgv_NodeConnections.CellMouseEnter += dgv_NodeConnections_CellClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 209);
            label7.Name = "label7";
            label7.Size = new Size(216, 25);
            label7.TabIndex = 12;
            label7.Text = "Tags (comma separated)";
            // 
            // txt_Node_Tags
            // 
            txt_Node_Tags.Enabled = false;
            txt_Node_Tags.Location = new Point(6, 229);
            txt_Node_Tags.Multiline = true;
            txt_Node_Tags.Name = "txt_Node_Tags";
            txt_Node_Tags.Size = new Size(537, 53);
            txt_Node_Tags.TabIndex = 6;
            // 
            // pnl_GW
            // 
            pnl_GW.BackColor = SystemColors.ControlLight;
            pnl_GW.Controls.Add(label8);
            pnl_GW.Controls.Add(cmbx_GW_AvailableNodes);
            pnl_GW.Controls.Add(label6);
            pnl_GW.Controls.Add(cmbx_GW_Direction);
            pnl_GW.Controls.Add(dgv_GatewayConnections);
            pnl_GW.Location = new Point(2, 230);
            pnl_GW.Margin = new Padding(3, 4, 3, 4);
            pnl_GW.Name = "pnl_GW";
            pnl_GW.Size = new Size(546, 301);
            pnl_GW.TabIndex = 14;
            pnl_GW.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(159, 9);
            label8.Name = "label8";
            label8.Size = new Size(148, 25);
            label8.TabIndex = 17;
            label8.Text = "Available Nodes";
            // 
            // cmbx_GW_AvailableNodes
            // 
            cmbx_GW_AvailableNodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbx_GW_AvailableNodes.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_GW_AvailableNodes.FormattingEnabled = true;
            cmbx_GW_AvailableNodes.Location = new Point(159, 38);
            cmbx_GW_AvailableNodes.Margin = new Padding(3, 4, 3, 4);
            cmbx_GW_AvailableNodes.Name = "cmbx_GW_AvailableNodes";
            cmbx_GW_AvailableNodes.Size = new Size(231, 33);
            cmbx_GW_AvailableNodes.TabIndex = 16;
            cmbx_GW_AvailableNodes.TabStop = false;
            cmbx_GW_AvailableNodes.Tag = "ClearMe";
            cmbx_GW_AvailableNodes.MouseEnter += cmbx_GW_AvailableNodes_MouseEnter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 9);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 15;
            label6.Text = "Direction";
            // 
            // cmbx_GW_Direction
            // 
            cmbx_GW_Direction.FormattingEnabled = true;
            cmbx_GW_Direction.Items.AddRange(new object[] { "North", "South", "East", "West" });
            cmbx_GW_Direction.Location = new Point(7, 38);
            cmbx_GW_Direction.Margin = new Padding(3, 4, 3, 4);
            cmbx_GW_Direction.Name = "cmbx_GW_Direction";
            cmbx_GW_Direction.Size = new Size(138, 33);
            cmbx_GW_Direction.TabIndex = 14;
            cmbx_GW_Direction.TabStop = false;
            cmbx_GW_Direction.Tag = "ClearMe";
            // 
            // dgv_GatewayConnections
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_GatewayConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_GatewayConnections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_GatewayConnections.Columns.AddRange(new DataGridViewColumn[] { dgvcmbx_GW_AvailableNodes, dataGridViewCheckBoxColumn1 });
            dgv_GatewayConnections.Dock = DockStyle.Bottom;
            dgv_GatewayConnections.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_GatewayConnections.Location = new Point(0, 78);
            dgv_GatewayConnections.MultiSelect = false;
            dgv_GatewayConnections.Name = "dgv_GatewayConnections";
            dgv_GatewayConnections.RowHeadersWidth = 51;
            dgv_GatewayConnections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_GatewayConnections.Size = new Size(546, 223);
            dgv_GatewayConnections.TabIndex = 13;
            dgv_GatewayConnections.TabStop = false;
            dgv_GatewayConnections.CellClick += dgv_GatewayConnections_CellClick;
            // 
            // dgvcmbx_GW_AvailableNodes
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcmbx_GW_AvailableNodes.DefaultCellStyle = dataGridViewCellStyle5;
            dgvcmbx_GW_AvailableNodes.Frozen = true;
            dgvcmbx_GW_AvailableNodes.HeaderText = "Available Nodes";
            dgvcmbx_GW_AvailableNodes.MinimumWidth = 250;
            dgvcmbx_GW_AvailableNodes.Name = "dgvcmbx_GW_AvailableNodes";
            dgvcmbx_GW_AvailableNodes.Resizable = DataGridViewTriState.True;
            dgvcmbx_GW_AvailableNodes.Width = 250;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.Frozen = true;
            dataGridViewCheckBoxColumn1.HeaderText = "Is one way?";
            dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewCheckBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewCheckBoxColumn1.Width = 80;
            // 
            // trvw_Nodes
            // 
            trvw_Nodes.Dock = DockStyle.Left;
            trvw_Nodes.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            trvw_Nodes.FullRowSelect = true;
            trvw_Nodes.HideSelection = false;
            trvw_Nodes.Indent = 10;
            trvw_Nodes.Location = new Point(3, 3);
            trvw_Nodes.Name = "trvw_Nodes";
            trvw_Nodes.Size = new Size(457, 576);
            trvw_Nodes.TabIndex = 200;
            trvw_Nodes.AfterSelect += trvw_Nodes_AfterSelect;
            // 
            // tbpg_Blocks
            // 
            tbpg_Blocks.Controls.Add(pnl_Right_Blocks);
            tbpg_Blocks.Controls.Add(lst_Blocks);
            tbpg_Blocks.Location = new Point(4, 34);
            tbpg_Blocks.Name = "tbpg_Blocks";
            tbpg_Blocks.Padding = new Padding(3);
            tbpg_Blocks.Size = new Size(1015, 582);
            tbpg_Blocks.TabIndex = 1;
            tbpg_Blocks.Text = "Blocks";
            tbpg_Blocks.UseVisualStyleBackColor = true;
            // 
            // pnl_Right_Blocks
            // 
            pnl_Right_Blocks.Controls.Add(gbx_EditBlock);
            pnl_Right_Blocks.Controls.Add(gbx_NewBlock);
            pnl_Right_Blocks.Dock = DockStyle.Fill;
            pnl_Right_Blocks.Location = new Point(292, 3);
            pnl_Right_Blocks.Name = "pnl_Right_Blocks";
            pnl_Right_Blocks.Padding = new Padding(5);
            pnl_Right_Blocks.Size = new Size(720, 576);
            pnl_Right_Blocks.TabIndex = 5;
            // 
            // gbx_EditBlock
            // 
            gbx_EditBlock.Controls.Add(nud_Edit_HighestFloor);
            gbx_EditBlock.Controls.Add(btn_Delete);
            gbx_EditBlock.Controls.Add(lbl_Edit_HighestFloor);
            gbx_EditBlock.Controls.Add(btn_SaveBlock);
            gbx_EditBlock.Controls.Add(nud_Edit_LowestFloor);
            gbx_EditBlock.Controls.Add(lbl_Edit_BlockName);
            gbx_EditBlock.Controls.Add(lbl_Edit_LowestFloor);
            gbx_EditBlock.Controls.Add(txt_Edit_BlockName);
            gbx_EditBlock.Dock = DockStyle.Fill;
            gbx_EditBlock.Location = new Point(5, 232);
            gbx_EditBlock.Name = "gbx_EditBlock";
            gbx_EditBlock.Size = new Size(710, 339);
            gbx_EditBlock.TabIndex = 3;
            gbx_EditBlock.TabStop = false;
            gbx_EditBlock.Text = "Edit Block";
            // 
            // nud_Edit_HighestFloor
            // 
            nud_Edit_HighestFloor.Location = new Point(120, 132);
            nud_Edit_HighestFloor.Name = "nud_Edit_HighestFloor";
            nud_Edit_HighestFloor.Size = new Size(98, 33);
            nud_Edit_HighestFloor.TabIndex = 7;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(6, 212);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(111, 39);
            btn_Delete.TabIndex = 8;
            btn_Delete.Text = "Delete";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // lbl_Edit_HighestFloor
            // 
            lbl_Edit_HighestFloor.AutoSize = true;
            lbl_Edit_HighestFloor.Location = new Point(120, 109);
            lbl_Edit_HighestFloor.Name = "lbl_Edit_HighestFloor";
            lbl_Edit_HighestFloor.Size = new Size(124, 25);
            lbl_Edit_HighestFloor.TabIndex = 12;
            lbl_Edit_HighestFloor.Text = "Highest Floor";
            // 
            // btn_SaveBlock
            // 
            btn_SaveBlock.Location = new Point(138, 212);
            btn_SaveBlock.Name = "btn_SaveBlock";
            btn_SaveBlock.Size = new Size(111, 39);
            btn_SaveBlock.TabIndex = 9;
            btn_SaveBlock.Text = "Save";
            btn_SaveBlock.UseVisualStyleBackColor = true;
            btn_SaveBlock.Click += btn_SaveBlock_Click;
            // 
            // nud_Edit_LowestFloor
            // 
            nud_Edit_LowestFloor.Location = new Point(6, 132);
            nud_Edit_LowestFloor.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            nud_Edit_LowestFloor.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_Edit_LowestFloor.Name = "nud_Edit_LowestFloor";
            nud_Edit_LowestFloor.Size = new Size(89, 33);
            nud_Edit_LowestFloor.TabIndex = 6;
            // 
            // lbl_Edit_BlockName
            // 
            lbl_Edit_BlockName.AutoSize = true;
            lbl_Edit_BlockName.Location = new Point(6, 39);
            lbl_Edit_BlockName.Name = "lbl_Edit_BlockName";
            lbl_Edit_BlockName.Size = new Size(112, 25);
            lbl_Edit_BlockName.TabIndex = 9;
            lbl_Edit_BlockName.Text = "Block Name";
            // 
            // lbl_Edit_LowestFloor
            // 
            lbl_Edit_LowestFloor.AutoSize = true;
            lbl_Edit_LowestFloor.Location = new Point(6, 109);
            lbl_Edit_LowestFloor.Name = "lbl_Edit_LowestFloor";
            lbl_Edit_LowestFloor.Size = new Size(118, 25);
            lbl_Edit_LowestFloor.TabIndex = 10;
            lbl_Edit_LowestFloor.Text = "Lowest Floor";
            // 
            // txt_Edit_BlockName
            // 
            txt_Edit_BlockName.Font = new Font("Segoe UI", 12F);
            txt_Edit_BlockName.Location = new Point(6, 61);
            txt_Edit_BlockName.Name = "txt_Edit_BlockName";
            txt_Edit_BlockName.Size = new Size(212, 29);
            txt_Edit_BlockName.TabIndex = 5;
            // 
            // gbx_NewBlock
            // 
            gbx_NewBlock.Controls.Add(btn_CreateBlock);
            gbx_NewBlock.Controls.Add(nud_New_HighestFloor);
            gbx_NewBlock.Controls.Add(lbl_New_HighestFloor);
            gbx_NewBlock.Controls.Add(nud_New_LowestFloor);
            gbx_NewBlock.Controls.Add(lbl_New_LowestFloor);
            gbx_NewBlock.Controls.Add(lbl_New_BlockName);
            gbx_NewBlock.Controls.Add(txt_New_BlockName);
            gbx_NewBlock.Dock = DockStyle.Top;
            gbx_NewBlock.Location = new Point(5, 5);
            gbx_NewBlock.Name = "gbx_NewBlock";
            gbx_NewBlock.Size = new Size(710, 227);
            gbx_NewBlock.TabIndex = 2;
            gbx_NewBlock.TabStop = false;
            gbx_NewBlock.Text = "New Block";
            // 
            // btn_CreateBlock
            // 
            btn_CreateBlock.Location = new Point(6, 181);
            btn_CreateBlock.Name = "btn_CreateBlock";
            btn_CreateBlock.Size = new Size(111, 39);
            btn_CreateBlock.TabIndex = 4;
            btn_CreateBlock.Text = "Create";
            btn_CreateBlock.UseVisualStyleBackColor = true;
            btn_CreateBlock.Click += btn_CreateBlock_Click;
            // 
            // nud_New_HighestFloor
            // 
            nud_New_HighestFloor.Location = new Point(123, 129);
            nud_New_HighestFloor.Name = "nud_New_HighestFloor";
            nud_New_HighestFloor.Size = new Size(98, 33);
            nud_New_HighestFloor.TabIndex = 3;
            // 
            // lbl_New_HighestFloor
            // 
            lbl_New_HighestFloor.AutoSize = true;
            lbl_New_HighestFloor.Location = new Point(123, 101);
            lbl_New_HighestFloor.Name = "lbl_New_HighestFloor";
            lbl_New_HighestFloor.Size = new Size(124, 25);
            lbl_New_HighestFloor.TabIndex = 6;
            lbl_New_HighestFloor.Text = "Highest Floor";
            // 
            // nud_New_LowestFloor
            // 
            nud_New_LowestFloor.Location = new Point(10, 129);
            nud_New_LowestFloor.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            nud_New_LowestFloor.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_New_LowestFloor.Name = "nud_New_LowestFloor";
            nud_New_LowestFloor.Size = new Size(89, 33);
            nud_New_LowestFloor.TabIndex = 2;
            // 
            // lbl_New_LowestFloor
            // 
            lbl_New_LowestFloor.AutoSize = true;
            lbl_New_LowestFloor.Location = new Point(10, 101);
            lbl_New_LowestFloor.Name = "lbl_New_LowestFloor";
            lbl_New_LowestFloor.Size = new Size(118, 25);
            lbl_New_LowestFloor.TabIndex = 4;
            lbl_New_LowestFloor.Text = "Lowest Floor";
            // 
            // lbl_New_BlockName
            // 
            lbl_New_BlockName.AutoSize = true;
            lbl_New_BlockName.Location = new Point(10, 36);
            lbl_New_BlockName.Name = "lbl_New_BlockName";
            lbl_New_BlockName.Size = new Size(112, 25);
            lbl_New_BlockName.TabIndex = 2;
            lbl_New_BlockName.Text = "Block Name";
            // 
            // txt_New_BlockName
            // 
            txt_New_BlockName.Font = new Font("Segoe UI", 12F);
            txt_New_BlockName.Location = new Point(10, 59);
            txt_New_BlockName.Name = "txt_New_BlockName";
            txt_New_BlockName.Size = new Size(212, 29);
            txt_New_BlockName.TabIndex = 1;
            // 
            // lst_Blocks
            // 
            lst_Blocks.Dock = DockStyle.Left;
            lst_Blocks.FormattingEnabled = true;
            lst_Blocks.ItemHeight = 25;
            lst_Blocks.Location = new Point(3, 3);
            lst_Blocks.Name = "lst_Blocks";
            lst_Blocks.Size = new Size(289, 576);
            lst_Blocks.TabIndex = 200;
            lst_Blocks.SelectedIndexChanged += lst_Blocks_SelectedIndexChanged;
            // 
            // tbpg_Export
            // 
            tbpg_Export.Controls.Add(panel2);
            tbpg_Export.Controls.Add(panel1);
            tbpg_Export.Location = new Point(4, 34);
            tbpg_Export.Name = "tbpg_Export";
            tbpg_Export.Padding = new Padding(6, 5, 6, 5);
            tbpg_Export.Size = new Size(1015, 582);
            tbpg_Export.TabIndex = 2;
            tbpg_Export.Text = "Export/Import";
            tbpg_Export.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btn_Import);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(6, 428);
            panel2.Margin = new Padding(9);
            panel2.Name = "panel2";
            panel2.Size = new Size(1003, 149);
            panel2.TabIndex = 12;
            // 
            // btn_Import
            // 
            btn_Import.Dock = DockStyle.Bottom;
            btn_Import.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btn_Import.Location = new Point(0, 64);
            btn_Import.Margin = new Padding(0, 3, 0, 3);
            btn_Import.Name = "btn_Import";
            btn_Import.Size = new Size(1001, 83);
            btn_Import.TabIndex = 9;
            btn_Import.Text = "Import";
            btn_Import.UseVisualStyleBackColor = true;
            btn_Import.Click += btn_Import_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(btn_Export);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(6, 5);
            panel1.Margin = new Padding(9);
            panel1.Name = "panel1";
            panel1.Size = new Size(1003, 293);
            panel1.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Controls.Add(rbtn_Export_FARapp);
            panel3.Controls.Add(radioButton2);
            panel3.Controls.Add(rbtn_Export_Both);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1001, 189);
            panel3.TabIndex = 10;
            // 
            // rbtn_Export_FARapp
            // 
            rbtn_Export_FARapp.AutoSize = true;
            rbtn_Export_FARapp.Font = new Font("Segoe UI", 18F);
            rbtn_Export_FARapp.Location = new Point(9, 3);
            rbtn_Export_FARapp.Name = "rbtn_Export_FARapp";
            rbtn_Export_FARapp.Size = new Size(195, 36);
            rbtn_Export_FARapp.TabIndex = 5;
            rbtn_Export_FARapp.Tag = "1";
            rbtn_Export_FARapp.Text = "Export for FARa";
            rbtn_Export_FARapp.UseVisualStyleBackColor = true;
            rbtn_Export_FARapp.CheckedChanged += rbtn_Export_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 18F);
            radioButton2.Location = new Point(9, 53);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(209, 36);
            radioButton2.TabIndex = 6;
            radioButton2.Tag = "0";
            radioButton2.Text = "Export for FARap";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += rbtn_Export_CheckedChanged;
            // 
            // rbtn_Export_Both
            // 
            rbtn_Export_Both.AutoSize = true;
            rbtn_Export_Both.Font = new Font("Segoe UI", 18F);
            rbtn_Export_Both.Location = new Point(9, 105);
            rbtn_Export_Both.Name = "rbtn_Export_Both";
            rbtn_Export_Both.Size = new Size(178, 36);
            rbtn_Export_Both.TabIndex = 7;
            rbtn_Export_Both.Tag = "2";
            rbtn_Export_Both.Text = "Both (Zipped)";
            rbtn_Export_Both.UseVisualStyleBackColor = true;
            rbtn_Export_Both.CheckedChanged += rbtn_Export_CheckedChanged;
            // 
            // btn_Export
            // 
            btn_Export.Dock = DockStyle.Bottom;
            btn_Export.Enabled = false;
            btn_Export.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btn_Export.Location = new Point(0, 208);
            btn_Export.Margin = new Padding(0, 3, 0, 3);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new Size(1001, 83);
            btn_Export.TabIndex = 9;
            btn_Export.Text = "Export";
            btn_Export.UseVisualStyleBackColor = true;
            btn_Export.Click += btn_Export_Click;
            // 
            // tbpg_Combine
            // 
            tbpg_Combine.Controls.Add(textBox1);
            tbpg_Combine.Location = new Point(4, 34);
            tbpg_Combine.Name = "tbpg_Combine";
            tbpg_Combine.Padding = new Padding(3);
            tbpg_Combine.Size = new Size(1015, 582);
            tbpg_Combine.TabIndex = 3;
            tbpg_Combine.Text = "Combine";
            tbpg_Combine.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(58, 60);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(604, 279);
            textBox1.TabIndex = 0;
            textBox1.Text = "So this page will allow the user to combine two .apjson files into 1. \r\nThis allows a .apjson per floor per block. Genius right? doubt it.\r\n\r\nAnyway, think about UID clashes and shit.";
            // 
            // tbpg_Settings
            // 
            tbpg_Settings.Controls.Add(txt_set_Layout);
            tbpg_Settings.Controls.Add(btn_set_SaveSettings);
            tbpg_Settings.Controls.Add(panel4);
            tbpg_Settings.Controls.Add(label11);
            tbpg_Settings.Controls.Add(lbl_NameTemplate);
            tbpg_Settings.Location = new Point(4, 34);
            tbpg_Settings.Name = "tbpg_Settings";
            tbpg_Settings.Size = new Size(1015, 582);
            tbpg_Settings.TabIndex = 4;
            tbpg_Settings.Text = "Settings";
            tbpg_Settings.UseVisualStyleBackColor = true;
            tbpg_Settings.Click += tbpg_Settings_Click;
            // 
            // txt_set_Layout
            // 
            txt_set_Layout.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_set_Layout.Location = new Point(3, 42);
            txt_set_Layout.Name = "txt_set_Layout";
            txt_set_Layout.Size = new Size(307, 35);
            txt_set_Layout.TabIndex = 5;
            txt_set_Layout.Text = "{P}{b}{-}{F}{-}{I}{-}";
            txt_set_Layout.KeyDown += txt_set_Layout_KeyDown;
            // 
            // btn_set_SaveSettings
            // 
            btn_set_SaveSettings.Location = new Point(8, 329);
            btn_set_SaveSettings.Name = "btn_set_SaveSettings";
            btn_set_SaveSettings.Size = new Size(177, 67);
            btn_set_SaveSettings.TabIndex = 4;
            btn_set_SaveSettings.Text = "Save";
            btn_set_SaveSettings.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(label16);
            panel4.Controls.Add(txt_set_Prefix);
            panel4.Controls.Add(groupBox1);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(txt_set_Separator);
            panel4.Location = new Point(520, 3);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(1);
            panel4.Size = new Size(384, 180);
            panel4.TabIndex = 3;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(104, 7);
            label16.Name = "label16";
            label16.Size = new Size(60, 25);
            label16.TabIndex = 4;
            label16.Text = "Prefix";
            // 
            // txt_set_Prefix
            // 
            txt_set_Prefix.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_set_Prefix.Location = new Point(103, 34);
            txt_set_Prefix.MaxLength = 4;
            txt_set_Prefix.Name = "txt_set_Prefix";
            txt_set_Prefix.Size = new Size(94, 35);
            txt_set_Prefix.TabIndex = 3;
            txt_set_Prefix.Text = "TR";
            txt_set_Prefix.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_set_id_Corridor);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txt_set_id_Room);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(txt_set_id_GW);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(txt_set_id_Elv);
            groupBox1.Controls.Add(lbl_set_id_Elv);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(1, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 101);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Identifiers";
            // 
            // txt_set_id_Corridor
            // 
            txt_set_id_Corridor.Location = new Point(288, 62);
            txt_set_id_Corridor.MaxLength = 3;
            txt_set_id_Corridor.Name = "txt_set_id_Corridor";
            txt_set_id_Corridor.Size = new Size(89, 33);
            txt_set_id_Corridor.TabIndex = 7;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(288, 34);
            label15.Name = "label15";
            label15.Size = new Size(83, 25);
            label15.TabIndex = 6;
            label15.Text = "Corridor";
            // 
            // txt_set_id_Room
            // 
            txt_set_id_Room.Location = new Point(193, 62);
            txt_set_id_Room.MaxLength = 3;
            txt_set_id_Room.Name = "txt_set_id_Room";
            txt_set_id_Room.Size = new Size(89, 33);
            txt_set_id_Room.TabIndex = 5;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(193, 34);
            label14.Name = "label14";
            label14.Size = new Size(60, 25);
            label14.TabIndex = 4;
            label14.Text = "Room";
            // 
            // txt_set_id_GW
            // 
            txt_set_id_GW.Location = new Point(98, 62);
            txt_set_id_GW.MaxLength = 3;
            txt_set_id_GW.Name = "txt_set_id_GW";
            txt_set_id_GW.Size = new Size(89, 33);
            txt_set_id_GW.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(98, 34);
            label13.Name = "label13";
            label13.Size = new Size(84, 25);
            label13.TabIndex = 2;
            label13.Text = "Gateway";
            // 
            // txt_set_id_Elv
            // 
            txt_set_id_Elv.Location = new Point(3, 62);
            txt_set_id_Elv.MaxLength = 3;
            txt_set_id_Elv.Name = "txt_set_id_Elv";
            txt_set_id_Elv.Size = new Size(89, 33);
            txt_set_id_Elv.TabIndex = 1;
            // 
            // lbl_set_id_Elv
            // 
            lbl_set_id_Elv.AutoSize = true;
            lbl_set_id_Elv.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_set_id_Elv.Location = new Point(3, 34);
            lbl_set_id_Elv.Name = "lbl_set_id_Elv";
            lbl_set_id_Elv.Size = new Size(89, 25);
            lbl_set_id_Elv.TabIndex = 0;
            lbl_set_id_Elv.Text = "Elevation";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(4, 7);
            label12.Name = "label12";
            label12.Size = new Size(94, 25);
            label12.TabIndex = 1;
            label12.Text = "Separator";
            // 
            // txt_set_Separator
            // 
            txt_set_Separator.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_set_Separator.Location = new Point(3, 34);
            txt_set_Separator.MaxLength = 1;
            txt_set_Separator.Name = "txt_set_Separator";
            txt_set_Separator.Size = new Size(94, 39);
            txt_set_Separator.TabIndex = 0;
            txt_set_Separator.Text = "-";
            txt_set_Separator.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(8, 92);
            label11.Name = "label11";
            label11.Size = new Size(296, 150);
            label11.TabIndex = 2;
            label11.Text = "{B} - Block name\r\n{b} - First character of block name\r\n{F} - Floor number\r\n{-} - Separator\r\n{I} - Node Identifier\r\n{P} - Prefix";
            // 
            // lbl_NameTemplate
            // 
            lbl_NameTemplate.AutoSize = true;
            lbl_NameTemplate.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_NameTemplate.Location = new Point(3, 9);
            lbl_NameTemplate.Name = "lbl_NameTemplate";
            lbl_NameTemplate.Size = new Size(261, 30);
            lbl_NameTemplate.TabIndex = 1;
            lbl_NameTemplate.Text = "Node internal name layout";
            // 
            // clm_NodeDirection
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clm_NodeDirection.DefaultCellStyle = dataGridViewCellStyle2;
            clm_NodeDirection.Frozen = true;
            clm_NodeDirection.HeaderText = "Direction";
            clm_NodeDirection.MinimumWidth = 6;
            clm_NodeDirection.Name = "clm_NodeDirection";
            clm_NodeDirection.ReadOnly = true;
            clm_NodeDirection.Width = 90;
            // 
            // clm_AvailNodes
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clm_AvailNodes.DefaultCellStyle = dataGridViewCellStyle3;
            clm_AvailNodes.Frozen = true;
            clm_AvailNodes.HeaderText = "Available Nodes";
            clm_AvailNodes.MaxDropDownItems = 20;
            clm_AvailNodes.MinimumWidth = 200;
            clm_AvailNodes.Name = "clm_AvailNodes";
            clm_AvailNodes.Resizable = DataGridViewTriState.True;
            clm_AvailNodes.Width = 200;
            // 
            // clm_SelectNode
            // 
            clm_SelectNode.Frozen = true;
            clm_SelectNode.HeaderText = "Select Node";
            clm_SelectNode.Name = "clm_SelectNode";
            clm_SelectNode.ReadOnly = true;
            clm_SelectNode.Resizable = DataGridViewTriState.True;
            clm_SelectNode.SortMode = DataGridViewColumnSortMode.Automatic;
            clm_SelectNode.Text = "Select a node...";
            // 
            // clm_OneWay
            // 
            clm_OneWay.Frozen = true;
            clm_OneWay.HeaderText = "Is one way?";
            clm_OneWay.MinimumWidth = 6;
            clm_OneWay.Name = "clm_OneWay";
            clm_OneWay.Resizable = DataGridViewTriState.True;
            clm_OneWay.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 620);
            Controls.Add(tbctrl_MainTabs);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frm_Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            FormClosing += frm_Main_FormClosing;
            Load += frm_Main_Load;
            tbctrl_MainTabs.ResumeLayout(false);
            tbpg_Nodes.ResumeLayout(false);
            gbx_Node.ResumeLayout(false);
            gbx_Node.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).EndInit();
            pnl_NormalNodes.ResumeLayout(false);
            pnl_NormalNodes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_NodeConnections).EndInit();
            pnl_GW.ResumeLayout(false);
            pnl_GW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_GatewayConnections).EndInit();
            tbpg_Blocks.ResumeLayout(false);
            pnl_Right_Blocks.ResumeLayout(false);
            gbx_EditBlock.ResumeLayout(false);
            gbx_EditBlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_HighestFloor).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_LowestFloor).EndInit();
            gbx_NewBlock.ResumeLayout(false);
            gbx_NewBlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_New_HighestFloor).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_New_LowestFloor).EndInit();
            tbpg_Export.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tbpg_Combine.ResumeLayout(false);
            tbpg_Combine.PerformLayout();
            tbpg_Settings.ResumeLayout(false);
            tbpg_Settings.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbctrl_MainTabs;
        private TabPage tbpg_Nodes;
        private GroupBox gbx_EditNode;
        private TabPage tbpg_Blocks;
        private GroupBox gbx_EditBlock;
        private NumericUpDown nud_Edit_HighestFloor;
        private Button btn_Delete;
        private Label lbl_Edit_HighestFloor;
        private Button btn_SaveBlock;
        private NumericUpDown nud_Edit_LowestFloor;
        private Label lbl_Edit_BlockName;
        private Label lbl_Edit_LowestFloor;
        private TextBox txt_Edit_BlockName;
        private GroupBox gbx_NewBlock;
        private Button btn_CreateBlock;
        private NumericUpDown nud_New_HighestFloor;
        private Label lbl_New_HighestFloor;
        private NumericUpDown nud_New_LowestFloor;
        private Label lbl_New_LowestFloor;
        private Label lbl_New_BlockName;
        private TextBox txt_New_BlockName;
        private Panel pnl_Right_Nodes;
        private TreeView trvw_Nodes;
        private Panel pnl_Right_Blocks;
        private ListBox lst_Blocks;
        private TabPage tbpg_Export;
        private RadioButton rbtn_Export_Both;
        private RadioButton radioButton2;
        private RadioButton rbtn_Export_FARapp;
        private Button btn_Export;
        private Panel panel3;
        private Panel panel1;
        private Panel panel2;
        private Button btn_Import;
        private TabPage tbpg_Combine;
        private TextBox textBox1;
        private GroupBox gbx_Node;
        private Panel pnl_NormalNodes;
        private DataGridView dgv_NodeConnections;
        private Label label7;
        private TextBox txt_Node_Tags;
        private Button btn_Node_Delete;
        private Button btn_Node_Save;
        private Button btn_Node_Create;
        private TextBox txt_InternalName;
        private Label label5;
        private TextBox txt_PublicName;
        private Label label4;
        private NumericUpDown nud_Node_Floor;
        private Label label3;
        private ComboBox cmbx_NodeType;
        private Label label2;
        private ComboBox cmbx_BlockSelect;
        private Label label1;
        private Panel pnl_GW;
        private Label label8;
        private ComboBox cmbx_GW_AvailableNodes;
        private Label label6;
        private ComboBox cmbx_GW_Direction;
        private DataGridView dgv_GatewayConnections;
        private Label label10;
        private ComboBox cmbx_GWFlow;
        private Label label9;
        private ComboBox cmbx_ElvFlow;
        private Button btn_SaveBackup;
        private TabPage tbpg_Settings;
        private Label lbl_NameTemplate;
        private Panel panel4;
        private Label label12;
        private TextBox txt_set_Separator;
        private Label label11;
        private Button btn_set_SaveSettings;
        private GroupBox groupBox1;
        private TextBox txt_set_id_Corridor;
        private Label label15;
        private TextBox txt_set_id_Room;
        private Label label14;
        private TextBox txt_set_id_GW;
        private Label label13;
        private TextBox txt_set_id_Elv;
        private Label lbl_set_id_Elv;
        private TextBox txt_set_Layout;
        private Label label16;
        private TextBox txt_set_Prefix;
        private DataGridViewComboBoxColumn dgvcmbx_GW_AvailableNodes;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn clm_NodeDirection;
        private DataGridViewComboBoxColumn clm_AvailNodes;
        private DataGridViewButtonColumn clm_SelectNode;
        private DataGridViewCheckBoxColumn clm_OneWay;
    }
}
