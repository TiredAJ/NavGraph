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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            tbctrl_MainTabs = new TabControl();
            tbpg_Nodes = new TabPage();
            gbx_Node = new GroupBox();
            pnl_NormalNodes = new Panel();
            dgv_NodeConnections = new DataGridView();
            clm_NodeDirection = new DataGridViewTextBoxColumn();
            clm_AvailNodes = new DataGridViewComboBoxColumn();
            clm_OneWay = new DataGridViewCheckBoxColumn();
            label7 = new Label();
            txt_Node_Tags = new TextBox();
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
            pnl_GW = new Panel();
            label8 = new Label();
            cmbx_GW_AvailableNodes = new ComboBox();
            label6 = new Label();
            cmbx_GW_Direction = new ComboBox();
            dgv_GatewayConnections = new DataGridView();
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
            dgvcmbx_GW_AvailableNodes = new DataGridViewComboBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            tbctrl_MainTabs.SuspendLayout();
            tbpg_Nodes.SuspendLayout();
            gbx_Node.SuspendLayout();
            pnl_NormalNodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_NodeConnections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).BeginInit();
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
            SuspendLayout();
            // 
            // tbctrl_MainTabs
            // 
            tbctrl_MainTabs.Controls.Add(tbpg_Nodes);
            tbctrl_MainTabs.Controls.Add(tbpg_Blocks);
            tbctrl_MainTabs.Controls.Add(tbpg_Export);
            tbctrl_MainTabs.Controls.Add(tbpg_Combine);
            tbctrl_MainTabs.Dock = DockStyle.Fill;
            tbctrl_MainTabs.HotTrack = true;
            tbctrl_MainTabs.Location = new Point(0, 0);
            tbctrl_MainTabs.Margin = new Padding(3, 2, 3, 2);
            tbctrl_MainTabs.Multiline = true;
            tbctrl_MainTabs.Name = "tbctrl_MainTabs";
            tbctrl_MainTabs.SelectedIndex = 0;
            tbctrl_MainTabs.Size = new Size(673, 399);
            tbctrl_MainTabs.TabIndex = 0;
            tbctrl_MainTabs.TabStop = false;
            // 
            // tbpg_Nodes
            // 
            tbpg_Nodes.Controls.Add(gbx_Node);
            tbpg_Nodes.Controls.Add(trvw_Nodes);
            tbpg_Nodes.Location = new Point(4, 24);
            tbpg_Nodes.Margin = new Padding(3, 2, 3, 2);
            tbpg_Nodes.Name = "tbpg_Nodes";
            tbpg_Nodes.Padding = new Padding(3, 2, 3, 2);
            tbpg_Nodes.Size = new Size(665, 371);
            tbpg_Nodes.TabIndex = 0;
            tbpg_Nodes.Text = "Nodes";
            tbpg_Nodes.UseVisualStyleBackColor = true;
            // 
            // gbx_Node
            // 
            gbx_Node.Controls.Add(pnl_NormalNodes);
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
            gbx_Node.Controls.Add(pnl_GW);
            gbx_Node.Dock = DockStyle.Fill;
            gbx_Node.Location = new Point(307, 2);
            gbx_Node.Margin = new Padding(3, 2, 3, 2);
            gbx_Node.Name = "gbx_Node";
            gbx_Node.Padding = new Padding(4);
            gbx_Node.Size = new Size(355, 367);
            gbx_Node.TabIndex = 0;
            gbx_Node.TabStop = false;
            gbx_Node.Text = "Create/Edit Node";
            // 
            // pnl_NormalNodes
            // 
            pnl_NormalNodes.BackColor = SystemColors.ControlLight;
            pnl_NormalNodes.Controls.Add(dgv_NodeConnections);
            pnl_NormalNodes.Controls.Add(label7);
            pnl_NormalNodes.Controls.Add(txt_Node_Tags);
            pnl_NormalNodes.Location = new Point(0, 137);
            pnl_NormalNodes.Name = "pnl_NormalNodes";
            pnl_NormalNodes.Size = new Size(351, 184);
            pnl_NormalNodes.TabIndex = 1;
            // 
            // dgv_NodeConnections
            // 
            dgv_NodeConnections.AllowUserToAddRows = false;
            dgv_NodeConnections.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_NodeConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_NodeConnections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_NodeConnections.Columns.AddRange(new DataGridViewColumn[] { clm_NodeDirection, clm_AvailNodes, clm_OneWay });
            dgv_NodeConnections.Dock = DockStyle.Top;
            dgv_NodeConnections.Location = new Point(0, 0);
            dgv_NodeConnections.Margin = new Padding(3, 2, 3, 2);
            dgv_NodeConnections.Name = "dgv_NodeConnections";
            dgv_NodeConnections.RowHeadersWidth = 51;
            dgv_NodeConnections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_NodeConnections.Size = new Size(351, 140);
            dgv_NodeConnections.TabIndex = 5;
            dgv_NodeConnections.TabStop = false;
            dgv_NodeConnections.CellClick += dgv_NodeConnections_CellClick;
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
            clm_AvailNodes.MinimumWidth = 6;
            clm_AvailNodes.Name = "clm_AvailNodes";
            clm_AvailNodes.Resizable = DataGridViewTriState.True;
            clm_AvailNodes.Width = 125;
            // 
            // clm_OneWay
            // 
            clm_OneWay.Frozen = true;
            clm_OneWay.HeaderText = "Is one way?";
            clm_OneWay.MinimumWidth = 6;
            clm_OneWay.Name = "clm_OneWay";
            clm_OneWay.Resizable = DataGridViewTriState.True;
            clm_OneWay.SortMode = DataGridViewColumnSortMode.Automatic;
            clm_OneWay.Width = 80;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 142);
            label7.Name = "label7";
            label7.Size = new Size(136, 15);
            label7.TabIndex = 12;
            label7.Text = "Tags (comma separated)";
            // 
            // txt_Node_Tags
            // 
            txt_Node_Tags.Enabled = false;
            txt_Node_Tags.Location = new Point(2, 157);
            txt_Node_Tags.Margin = new Padding(3, 2, 3, 2);
            txt_Node_Tags.Name = "txt_Node_Tags";
            txt_Node_Tags.Size = new Size(346, 23);
            txt_Node_Tags.TabIndex = 6;
            // 
            // btn_Node_Delete
            // 
            btn_Node_Delete.Enabled = false;
            btn_Node_Delete.Location = new Point(259, 332);
            btn_Node_Delete.Margin = new Padding(3, 2, 3, 2);
            btn_Node_Delete.Name = "btn_Node_Delete";
            btn_Node_Delete.Size = new Size(83, 25);
            btn_Node_Delete.TabIndex = 9;
            btn_Node_Delete.Text = "Delete";
            btn_Node_Delete.UseVisualStyleBackColor = true;
            btn_Node_Delete.Click += btn_Node_Delete_Click;
            // 
            // btn_Node_Save
            // 
            btn_Node_Save.Enabled = false;
            btn_Node_Save.Location = new Point(139, 332);
            btn_Node_Save.Margin = new Padding(3, 2, 3, 2);
            btn_Node_Save.Name = "btn_Node_Save";
            btn_Node_Save.Size = new Size(83, 25);
            btn_Node_Save.TabIndex = 8;
            btn_Node_Save.Text = "Save";
            btn_Node_Save.UseVisualStyleBackColor = true;
            btn_Node_Save.Click += btn_Node_Save_Click;
            // 
            // btn_Node_Create
            // 
            btn_Node_Create.Location = new Point(5, 332);
            btn_Node_Create.Margin = new Padding(3, 2, 3, 2);
            btn_Node_Create.Name = "btn_Node_Create";
            btn_Node_Create.Size = new Size(83, 25);
            btn_Node_Create.TabIndex = 7;
            btn_Node_Create.Text = "Create";
            btn_Node_Create.UseVisualStyleBackColor = true;
            btn_Node_Create.Click += btn_Node_Create_Click;
            // 
            // txt_InternalName
            // 
            txt_InternalName.Location = new Point(181, 112);
            txt_InternalName.Margin = new Padding(3, 2, 3, 2);
            txt_InternalName.Name = "txt_InternalName";
            txt_InternalName.Size = new Size(162, 23);
            txt_InternalName.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(183, 97);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 7;
            label5.Text = "Internal Name";
            // 
            // txt_PublicName
            // 
            txt_PublicName.Location = new Point(5, 112);
            txt_PublicName.Margin = new Padding(3, 2, 3, 2);
            txt_PublicName.Name = "txt_PublicName";
            txt_PublicName.Size = new Size(162, 23);
            txt_PublicName.TabIndex = 3;
            txt_PublicName.TextChanged += txt_PublicName_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 97);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 5;
            label4.Text = "Public Name";
            // 
            // nud_Node_Floor
            // 
            nud_Node_Floor.Location = new Point(183, 74);
            nud_Node_Floor.Margin = new Padding(3, 2, 3, 2);
            nud_Node_Floor.Name = "nud_Node_Floor";
            nud_Node_Floor.Size = new Size(127, 23);
            nud_Node_Floor.TabIndex = 2;
            nud_Node_Floor.ValueChanged += nud_Node_Floor_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(185, 58);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 3;
            label3.Text = "Floor";
            // 
            // cmbx_NodeType
            // 
            cmbx_NodeType.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_NodeType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_NodeType.FormattingEnabled = true;
            cmbx_NodeType.Items.AddRange(new object[] { "Corridor", "Room", "Elevation", "Gateway" });
            cmbx_NodeType.Location = new Point(5, 34);
            cmbx_NodeType.Margin = new Padding(3, 2, 3, 2);
            cmbx_NodeType.Name = "cmbx_NodeType";
            cmbx_NodeType.Size = new Size(162, 23);
            cmbx_NodeType.TabIndex = 0;
            cmbx_NodeType.SelectedIndexChanged += cmbx_NodeType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 19);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Node Type";
            // 
            // cmbx_BlockSelect
            // 
            cmbx_BlockSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_BlockSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_BlockSelect.FormattingEnabled = true;
            cmbx_BlockSelect.Location = new Point(5, 74);
            cmbx_BlockSelect.Margin = new Padding(3, 2, 3, 2);
            cmbx_BlockSelect.Name = "cmbx_BlockSelect";
            cmbx_BlockSelect.Size = new Size(162, 23);
            cmbx_BlockSelect.TabIndex = 1;
            cmbx_BlockSelect.SelectedIndexChanged += cmbx_BlockSelect_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 58);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Block";
            // 
            // pnl_GW
            // 
            pnl_GW.BackColor = SystemColors.ControlLight;
            pnl_GW.Controls.Add(label8);
            pnl_GW.Controls.Add(cmbx_GW_AvailableNodes);
            pnl_GW.Controls.Add(label6);
            pnl_GW.Controls.Add(cmbx_GW_Direction);
            pnl_GW.Controls.Add(dgv_GatewayConnections);
            pnl_GW.Location = new Point(0, 137);
            pnl_GW.Name = "pnl_GW";
            pnl_GW.Size = new Size(351, 184);
            pnl_GW.TabIndex = 14;
            pnl_GW.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(139, 16);
            label8.Name = "label8";
            label8.Size = new Size(92, 15);
            label8.TabIndex = 17;
            label8.Text = "Available Nodes";
            // 
            // cmbx_GW_AvailableNodes
            // 
            cmbx_GW_AvailableNodes.FormattingEnabled = true;
            cmbx_GW_AvailableNodes.Location = new Point(139, 34);
            cmbx_GW_AvailableNodes.Name = "cmbx_GW_AvailableNodes";
            cmbx_GW_AvailableNodes.Size = new Size(203, 23);
            cmbx_GW_AvailableNodes.TabIndex = 16;
            cmbx_GW_AvailableNodes.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 16);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 15;
            label6.Text = "Direction";
            // 
            // cmbx_GW_Direction
            // 
            cmbx_GW_Direction.FormattingEnabled = true;
            cmbx_GW_Direction.Items.AddRange(new object[] { "North", "South", "East", "West" });
            cmbx_GW_Direction.Location = new Point(6, 34);
            cmbx_GW_Direction.Name = "cmbx_GW_Direction";
            cmbx_GW_Direction.Size = new Size(121, 23);
            cmbx_GW_Direction.TabIndex = 14;
            cmbx_GW_Direction.TabStop = false;
            // 
            // dgv_GatewayConnections
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_GatewayConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_GatewayConnections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_GatewayConnections.Columns.AddRange(new DataGridViewColumn[] { dgvcmbx_GW_AvailableNodes, dataGridViewCheckBoxColumn1 });
            dgv_GatewayConnections.Dock = DockStyle.Bottom;
            dgv_GatewayConnections.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_GatewayConnections.Location = new Point(0, 73);
            dgv_GatewayConnections.Margin = new Padding(3, 2, 3, 2);
            dgv_GatewayConnections.MultiSelect = false;
            dgv_GatewayConnections.Name = "dgv_GatewayConnections";
            dgv_GatewayConnections.RowHeadersWidth = 51;
            dgv_GatewayConnections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_GatewayConnections.Size = new Size(351, 111);
            dgv_GatewayConnections.TabIndex = 13;
            dgv_GatewayConnections.TabStop = false;
            dgv_GatewayConnections.CellClick += dgv_GatewayConnections_CellClick;
            // 
            // trvw_Nodes
            // 
            trvw_Nodes.Dock = DockStyle.Left;
            trvw_Nodes.Font = new Font("Cascadia Mono", 9F, FontStyle.Bold);
            trvw_Nodes.FullRowSelect = true;
            trvw_Nodes.HideSelection = false;
            trvw_Nodes.Location = new Point(3, 2);
            trvw_Nodes.Margin = new Padding(3, 2, 3, 2);
            trvw_Nodes.Name = "trvw_Nodes";
            trvw_Nodes.Size = new Size(304, 367);
            trvw_Nodes.TabIndex = 200;
            trvw_Nodes.AfterSelect += trvw_Nodes_AfterSelect;
            // 
            // tbpg_Blocks
            // 
            tbpg_Blocks.Controls.Add(pnl_Right_Blocks);
            tbpg_Blocks.Controls.Add(lst_Blocks);
            tbpg_Blocks.Location = new Point(4, 24);
            tbpg_Blocks.Margin = new Padding(3, 2, 3, 2);
            tbpg_Blocks.Name = "tbpg_Blocks";
            tbpg_Blocks.Padding = new Padding(3, 2, 3, 2);
            tbpg_Blocks.Size = new Size(665, 371);
            tbpg_Blocks.TabIndex = 1;
            tbpg_Blocks.Text = "Blocks";
            tbpg_Blocks.UseVisualStyleBackColor = true;
            // 
            // pnl_Right_Blocks
            // 
            pnl_Right_Blocks.Controls.Add(gbx_EditBlock);
            pnl_Right_Blocks.Controls.Add(gbx_NewBlock);
            pnl_Right_Blocks.Dock = DockStyle.Fill;
            pnl_Right_Blocks.Location = new Point(256, 2);
            pnl_Right_Blocks.Margin = new Padding(3, 2, 3, 2);
            pnl_Right_Blocks.Name = "pnl_Right_Blocks";
            pnl_Right_Blocks.Padding = new Padding(4);
            pnl_Right_Blocks.Size = new Size(406, 367);
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
            gbx_EditBlock.Location = new Point(4, 174);
            gbx_EditBlock.Margin = new Padding(3, 2, 3, 2);
            gbx_EditBlock.Name = "gbx_EditBlock";
            gbx_EditBlock.Padding = new Padding(3, 2, 3, 2);
            gbx_EditBlock.Size = new Size(398, 189);
            gbx_EditBlock.TabIndex = 3;
            gbx_EditBlock.TabStop = false;
            gbx_EditBlock.Text = "Edit Block";
            // 
            // nud_Edit_HighestFloor
            // 
            nud_Edit_HighestFloor.Location = new Point(105, 99);
            nud_Edit_HighestFloor.Margin = new Padding(3, 2, 3, 2);
            nud_Edit_HighestFloor.Name = "nud_Edit_HighestFloor";
            nud_Edit_HighestFloor.Size = new Size(86, 23);
            nud_Edit_HighestFloor.TabIndex = 7;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(5, 159);
            btn_Delete.Margin = new Padding(3, 2, 3, 2);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(97, 29);
            btn_Delete.TabIndex = 8;
            btn_Delete.Text = "Delete";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // lbl_Edit_HighestFloor
            // 
            lbl_Edit_HighestFloor.AutoSize = true;
            lbl_Edit_HighestFloor.Location = new Point(105, 82);
            lbl_Edit_HighestFloor.Name = "lbl_Edit_HighestFloor";
            lbl_Edit_HighestFloor.Size = new Size(78, 15);
            lbl_Edit_HighestFloor.TabIndex = 12;
            lbl_Edit_HighestFloor.Text = "Highest Floor";
            // 
            // btn_SaveBlock
            // 
            btn_SaveBlock.Location = new Point(121, 159);
            btn_SaveBlock.Margin = new Padding(3, 2, 3, 2);
            btn_SaveBlock.Name = "btn_SaveBlock";
            btn_SaveBlock.Size = new Size(97, 29);
            btn_SaveBlock.TabIndex = 9;
            btn_SaveBlock.Text = "Save";
            btn_SaveBlock.UseVisualStyleBackColor = true;
            btn_SaveBlock.Click += btn_SaveBlock_Click;
            // 
            // nud_Edit_LowestFloor
            // 
            nud_Edit_LowestFloor.Location = new Point(5, 99);
            nud_Edit_LowestFloor.Margin = new Padding(3, 2, 3, 2);
            nud_Edit_LowestFloor.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            nud_Edit_LowestFloor.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_Edit_LowestFloor.Name = "nud_Edit_LowestFloor";
            nud_Edit_LowestFloor.Size = new Size(78, 23);
            nud_Edit_LowestFloor.TabIndex = 6;
            // 
            // lbl_Edit_BlockName
            // 
            lbl_Edit_BlockName.AutoSize = true;
            lbl_Edit_BlockName.Location = new Point(5, 29);
            lbl_Edit_BlockName.Name = "lbl_Edit_BlockName";
            lbl_Edit_BlockName.Size = new Size(71, 15);
            lbl_Edit_BlockName.TabIndex = 9;
            lbl_Edit_BlockName.Text = "Block Name";
            // 
            // lbl_Edit_LowestFloor
            // 
            lbl_Edit_LowestFloor.AutoSize = true;
            lbl_Edit_LowestFloor.Location = new Point(5, 82);
            lbl_Edit_LowestFloor.Name = "lbl_Edit_LowestFloor";
            lbl_Edit_LowestFloor.Size = new Size(74, 15);
            lbl_Edit_LowestFloor.TabIndex = 10;
            lbl_Edit_LowestFloor.Text = "Lowest Floor";
            // 
            // txt_Edit_BlockName
            // 
            txt_Edit_BlockName.Font = new Font("Segoe UI", 12F);
            txt_Edit_BlockName.Location = new Point(5, 46);
            txt_Edit_BlockName.Margin = new Padding(3, 2, 3, 2);
            txt_Edit_BlockName.Name = "txt_Edit_BlockName";
            txt_Edit_BlockName.Size = new Size(186, 29);
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
            gbx_NewBlock.Location = new Point(4, 4);
            gbx_NewBlock.Margin = new Padding(3, 2, 3, 2);
            gbx_NewBlock.Name = "gbx_NewBlock";
            gbx_NewBlock.Padding = new Padding(3, 2, 3, 2);
            gbx_NewBlock.Size = new Size(398, 170);
            gbx_NewBlock.TabIndex = 2;
            gbx_NewBlock.TabStop = false;
            gbx_NewBlock.Text = "New Block";
            // 
            // btn_CreateBlock
            // 
            btn_CreateBlock.Location = new Point(5, 136);
            btn_CreateBlock.Margin = new Padding(3, 2, 3, 2);
            btn_CreateBlock.Name = "btn_CreateBlock";
            btn_CreateBlock.Size = new Size(97, 29);
            btn_CreateBlock.TabIndex = 4;
            btn_CreateBlock.Text = "Create";
            btn_CreateBlock.UseVisualStyleBackColor = true;
            btn_CreateBlock.Click += btn_CreateBlock_Click;
            // 
            // nud_New_HighestFloor
            // 
            nud_New_HighestFloor.Location = new Point(108, 97);
            nud_New_HighestFloor.Margin = new Padding(3, 2, 3, 2);
            nud_New_HighestFloor.Name = "nud_New_HighestFloor";
            nud_New_HighestFloor.Size = new Size(86, 23);
            nud_New_HighestFloor.TabIndex = 3;
            // 
            // lbl_New_HighestFloor
            // 
            lbl_New_HighestFloor.AutoSize = true;
            lbl_New_HighestFloor.Location = new Point(108, 80);
            lbl_New_HighestFloor.Name = "lbl_New_HighestFloor";
            lbl_New_HighestFloor.Size = new Size(78, 15);
            lbl_New_HighestFloor.TabIndex = 6;
            lbl_New_HighestFloor.Text = "Highest Floor";
            // 
            // nud_New_LowestFloor
            // 
            nud_New_LowestFloor.Location = new Point(9, 97);
            nud_New_LowestFloor.Margin = new Padding(3, 2, 3, 2);
            nud_New_LowestFloor.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            nud_New_LowestFloor.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_New_LowestFloor.Name = "nud_New_LowestFloor";
            nud_New_LowestFloor.Size = new Size(78, 23);
            nud_New_LowestFloor.TabIndex = 2;
            // 
            // lbl_New_LowestFloor
            // 
            lbl_New_LowestFloor.AutoSize = true;
            lbl_New_LowestFloor.Location = new Point(9, 80);
            lbl_New_LowestFloor.Name = "lbl_New_LowestFloor";
            lbl_New_LowestFloor.Size = new Size(74, 15);
            lbl_New_LowestFloor.TabIndex = 4;
            lbl_New_LowestFloor.Text = "Lowest Floor";
            // 
            // lbl_New_BlockName
            // 
            lbl_New_BlockName.AutoSize = true;
            lbl_New_BlockName.Location = new Point(9, 27);
            lbl_New_BlockName.Name = "lbl_New_BlockName";
            lbl_New_BlockName.Size = new Size(71, 15);
            lbl_New_BlockName.TabIndex = 2;
            lbl_New_BlockName.Text = "Block Name";
            // 
            // txt_New_BlockName
            // 
            txt_New_BlockName.Font = new Font("Segoe UI", 12F);
            txt_New_BlockName.Location = new Point(9, 44);
            txt_New_BlockName.Margin = new Padding(3, 2, 3, 2);
            txt_New_BlockName.Name = "txt_New_BlockName";
            txt_New_BlockName.Size = new Size(186, 29);
            txt_New_BlockName.TabIndex = 1;
            // 
            // lst_Blocks
            // 
            lst_Blocks.Dock = DockStyle.Left;
            lst_Blocks.FormattingEnabled = true;
            lst_Blocks.ItemHeight = 15;
            lst_Blocks.Location = new Point(3, 2);
            lst_Blocks.Margin = new Padding(3, 2, 3, 2);
            lst_Blocks.Name = "lst_Blocks";
            lst_Blocks.Size = new Size(253, 367);
            lst_Blocks.TabIndex = 200;
            lst_Blocks.SelectedIndexChanged += lst_Blocks_SelectedIndexChanged;
            // 
            // tbpg_Export
            // 
            tbpg_Export.Controls.Add(panel2);
            tbpg_Export.Controls.Add(panel1);
            tbpg_Export.Location = new Point(4, 24);
            tbpg_Export.Margin = new Padding(3, 2, 3, 2);
            tbpg_Export.Name = "tbpg_Export";
            tbpg_Export.Padding = new Padding(5, 4, 5, 4);
            tbpg_Export.Size = new Size(665, 371);
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
            panel2.Location = new Point(5, 255);
            panel2.Margin = new Padding(8, 7, 8, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(655, 112);
            panel2.TabIndex = 12;
            // 
            // btn_Import
            // 
            btn_Import.Dock = DockStyle.Bottom;
            btn_Import.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btn_Import.Location = new Point(0, 48);
            btn_Import.Margin = new Padding(0, 2, 0, 2);
            btn_Import.Name = "btn_Import";
            btn_Import.Size = new Size(653, 62);
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
            panel1.Location = new Point(5, 4);
            panel1.Margin = new Padding(8, 7, 8, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(655, 220);
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
            panel3.Size = new Size(653, 142);
            panel3.TabIndex = 10;
            // 
            // rbtn_Export_FARapp
            // 
            rbtn_Export_FARapp.AutoSize = true;
            rbtn_Export_FARapp.Font = new Font("Segoe UI", 18F);
            rbtn_Export_FARapp.Location = new Point(8, 2);
            rbtn_Export_FARapp.Margin = new Padding(3, 2, 3, 2);
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
            radioButton2.Location = new Point(8, 40);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
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
            rbtn_Export_Both.Location = new Point(8, 79);
            rbtn_Export_Both.Margin = new Padding(3, 2, 3, 2);
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
            btn_Export.Location = new Point(0, 156);
            btn_Export.Margin = new Padding(0, 2, 0, 2);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new Size(653, 62);
            btn_Export.TabIndex = 9;
            btn_Export.Text = "Export";
            btn_Export.UseVisualStyleBackColor = true;
            btn_Export.Click += btn_Export_Click;
            // 
            // tbpg_Combine
            // 
            tbpg_Combine.Controls.Add(textBox1);
            tbpg_Combine.Location = new Point(4, 24);
            tbpg_Combine.Margin = new Padding(3, 2, 3, 2);
            tbpg_Combine.Name = "tbpg_Combine";
            tbpg_Combine.Padding = new Padding(3, 2, 3, 2);
            tbpg_Combine.Size = new Size(665, 371);
            tbpg_Combine.TabIndex = 3;
            tbpg_Combine.Text = "Combine";
            tbpg_Combine.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(51, 45);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(529, 210);
            textBox1.TabIndex = 0;
            textBox1.Text = "So this page will allow the user to combine two .apjson files into 1. \r\nThis allows a .apjson per floor per block. Genius right? doubt it.\r\n\r\nAnyway, think about UID clashes and shit.";
            // 
            // dgvcmbx_GW_AvailableNodes
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcmbx_GW_AvailableNodes.DefaultCellStyle = dataGridViewCellStyle5;
            dgvcmbx_GW_AvailableNodes.Frozen = true;
            dgvcmbx_GW_AvailableNodes.HeaderText = "Available Nodes";
            dgvcmbx_GW_AvailableNodes.MinimumWidth = 6;
            dgvcmbx_GW_AvailableNodes.Name = "dgvcmbx_GW_AvailableNodes";
            dgvcmbx_GW_AvailableNodes.Resizable = DataGridViewTriState.True;
            dgvcmbx_GW_AvailableNodes.Width = 125;
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
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 399);
            Controls.Add(tbctrl_MainTabs);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frm_Main";
            Text = "Main";
            FormClosing += frm_Main_FormClosing;
            tbctrl_MainTabs.ResumeLayout(false);
            tbpg_Nodes.ResumeLayout(false);
            gbx_Node.ResumeLayout(false);
            gbx_Node.PerformLayout();
            pnl_NormalNodes.ResumeLayout(false);
            pnl_NormalNodes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_NodeConnections).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).EndInit();
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
        private DataGridViewTextBoxColumn clm_NodeDirection;
        private DataGridViewComboBoxColumn clm_AvailNodes;
        private DataGridViewCheckBoxColumn clm_OneWay;
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
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        public DataGridViewComboBoxColumn dgvcmbx_GW_AvailableNodes;
    }
}
