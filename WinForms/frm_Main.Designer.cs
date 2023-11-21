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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tbctrl_MainTabs = new TabControl();
            tbpg_Nodes = new TabPage();
            gbx_Node = new GroupBox();
            dgv_Connections = new DataGridView();
            clm_NodeDirection = new DataGridViewTextBoxColumn();
            clm_AvailNodes = new DataGridViewComboBoxColumn();
            clm_OneWay = new DataGridViewCheckBoxColumn();
            btn_Node_Delete = new Button();
            btn_Node_Save = new Button();
            btn_Node_Create = new Button();
            txt_Node_Tags = new TextBox();
            label7 = new Label();
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
            btn_SetSaveLocation = new Button();
            textBox1 = new TextBox();
            panel1 = new Panel();
            btn_AdminPanelExport = new Button();
            btn_ExportBoth = new Button();
            btn_AppExport = new Button();
            tbctrl_MainTabs.SuspendLayout();
            tbpg_Nodes.SuspendLayout();
            gbx_Node.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Connections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).BeginInit();
            tbpg_Blocks.SuspendLayout();
            pnl_Right_Blocks.SuspendLayout();
            gbx_EditBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_HighestFloor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_LowestFloor).BeginInit();
            gbx_NewBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_New_HighestFloor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_New_LowestFloor).BeginInit();
            tbpg_Export.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbctrl_MainTabs
            // 
            tbctrl_MainTabs.Controls.Add(tbpg_Nodes);
            tbctrl_MainTabs.Controls.Add(tbpg_Blocks);
            tbctrl_MainTabs.Controls.Add(tbpg_Export);
            tbctrl_MainTabs.Dock = DockStyle.Fill;
            tbctrl_MainTabs.Location = new Point(0, 0);
            tbctrl_MainTabs.Name = "tbctrl_MainTabs";
            tbctrl_MainTabs.SelectedIndex = 0;
            tbctrl_MainTabs.Size = new Size(659, 532);
            tbctrl_MainTabs.TabIndex = 0;
            // 
            // tbpg_Nodes
            // 
            tbpg_Nodes.Controls.Add(gbx_Node);
            tbpg_Nodes.Controls.Add(trvw_Nodes);
            tbpg_Nodes.Location = new Point(4, 29);
            tbpg_Nodes.Name = "tbpg_Nodes";
            tbpg_Nodes.Padding = new Padding(3);
            tbpg_Nodes.Size = new Size(651, 499);
            tbpg_Nodes.TabIndex = 0;
            tbpg_Nodes.Text = "Nodes";
            tbpg_Nodes.UseVisualStyleBackColor = true;
            // 
            // gbx_Node
            // 
            gbx_Node.Controls.Add(dgv_Connections);
            gbx_Node.Controls.Add(btn_Node_Delete);
            gbx_Node.Controls.Add(btn_Node_Save);
            gbx_Node.Controls.Add(btn_Node_Create);
            gbx_Node.Controls.Add(txt_Node_Tags);
            gbx_Node.Controls.Add(label7);
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
            gbx_Node.Dock = DockStyle.Fill;
            gbx_Node.Location = new Point(249, 3);
            gbx_Node.Name = "gbx_Node";
            gbx_Node.Padding = new Padding(5);
            gbx_Node.Size = new Size(399, 493);
            gbx_Node.TabIndex = 0;
            gbx_Node.TabStop = false;
            gbx_Node.Text = "Create/Edit Node";
            // 
            // dgv_Connections
            // 
            dgv_Connections.AllowUserToAddRows = false;
            dgv_Connections.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_Connections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_Connections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Connections.Columns.AddRange(new DataGridViewColumn[] { clm_NodeDirection, clm_AvailNodes, clm_OneWay });
            dgv_Connections.Location = new Point(0, 183);
            dgv_Connections.Name = "dgv_Connections";
            dgv_Connections.RowHeadersWidth = 51;
            dgv_Connections.RowTemplate.Height = 29;
            dgv_Connections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Connections.Size = new Size(402, 181);
            dgv_Connections.TabIndex = 5;
            dgv_Connections.CellClick += dgv_Connections_CellClick;
            // 
            // clm_NodeDirection
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clm_NodeDirection.DefaultCellStyle = dataGridViewCellStyle5;
            clm_NodeDirection.Frozen = true;
            clm_NodeDirection.HeaderText = "Direction";
            clm_NodeDirection.MinimumWidth = 6;
            clm_NodeDirection.Name = "clm_NodeDirection";
            clm_NodeDirection.ReadOnly = true;
            clm_NodeDirection.Width = 125;
            // 
            // clm_AvailNodes
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clm_AvailNodes.DefaultCellStyle = dataGridViewCellStyle6;
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
            // btn_Node_Delete
            // 
            btn_Node_Delete.Enabled = false;
            btn_Node_Delete.Location = new Point(296, 443);
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
            btn_Node_Save.Location = new Point(159, 443);
            btn_Node_Save.Name = "btn_Node_Save";
            btn_Node_Save.Size = new Size(95, 33);
            btn_Node_Save.TabIndex = 8;
            btn_Node_Save.Text = "Save";
            btn_Node_Save.UseVisualStyleBackColor = true;
            btn_Node_Save.Click += btn_Node_Save_Click;
            // 
            // btn_Node_Create
            // 
            btn_Node_Create.Location = new Point(6, 443);
            btn_Node_Create.Name = "btn_Node_Create";
            btn_Node_Create.Size = new Size(95, 33);
            btn_Node_Create.TabIndex = 7;
            btn_Node_Create.Text = "Create";
            btn_Node_Create.UseVisualStyleBackColor = true;
            btn_Node_Create.Click += btn_Node_Create_Click;
            // 
            // txt_Node_Tags
            // 
            txt_Node_Tags.Enabled = false;
            txt_Node_Tags.Location = new Point(4, 398);
            txt_Node_Tags.Name = "txt_Node_Tags";
            txt_Node_Tags.Size = new Size(387, 27);
            txt_Node_Tags.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 377);
            label7.Name = "label7";
            label7.Size = new Size(172, 20);
            label7.TabIndex = 12;
            label7.Text = "Tags (comma separated)";
            // 
            // txt_InternalName
            // 
            txt_InternalName.Location = new Point(207, 150);
            txt_InternalName.Name = "txt_InternalName";
            txt_InternalName.Size = new Size(185, 27);
            txt_InternalName.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(209, 129);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 7;
            label5.Text = "Internal Name";
            // 
            // txt_PublicName
            // 
            txt_PublicName.Location = new Point(6, 150);
            txt_PublicName.Name = "txt_PublicName";
            txt_PublicName.Size = new Size(185, 27);
            txt_PublicName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 129);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 5;
            label4.Text = "Public Name";
            // 
            // nud_Node_Floor
            // 
            nud_Node_Floor.Location = new Point(209, 99);
            nud_Node_Floor.Name = "nud_Node_Floor";
            nud_Node_Floor.Size = new Size(145, 27);
            nud_Node_Floor.TabIndex = 2;
            nud_Node_Floor.ValueChanged += nud_Node_Floor_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(211, 78);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 3;
            label3.Text = "Floor";
            // 
            // cmbx_NodeType
            // 
            cmbx_NodeType.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_NodeType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_NodeType.FormattingEnabled = true;
            cmbx_NodeType.Items.AddRange(new object[] { "Corridor", "Room", "Elevation", "Gateway" });
            cmbx_NodeType.Location = new Point(6, 46);
            cmbx_NodeType.Name = "cmbx_NodeType";
            cmbx_NodeType.Size = new Size(185, 28);
            cmbx_NodeType.TabIndex = 0;
            cmbx_NodeType.SelectedIndexChanged += cmbx_NodeType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 25);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 2;
            label2.Text = "Node Type";
            // 
            // cmbx_BlockSelect
            // 
            cmbx_BlockSelect.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_BlockSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_BlockSelect.FormattingEnabled = true;
            cmbx_BlockSelect.Location = new Point(6, 98);
            cmbx_BlockSelect.Name = "cmbx_BlockSelect";
            cmbx_BlockSelect.Size = new Size(185, 28);
            cmbx_BlockSelect.TabIndex = 1;
            cmbx_BlockSelect.SelectedIndexChanged += cmbx_BlockSelect_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 77);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "Block";
            // 
            // trvw_Nodes
            // 
            trvw_Nodes.Dock = DockStyle.Left;
            trvw_Nodes.FullRowSelect = true;
            trvw_Nodes.HideSelection = false;
            trvw_Nodes.Location = new Point(3, 3);
            trvw_Nodes.Name = "trvw_Nodes";
            trvw_Nodes.Size = new Size(246, 493);
            trvw_Nodes.TabIndex = 200;
            trvw_Nodes.AfterSelect += trvw_Nodes_AfterSelect;
            // 
            // tbpg_Blocks
            // 
            tbpg_Blocks.Controls.Add(pnl_Right_Blocks);
            tbpg_Blocks.Controls.Add(lst_Blocks);
            tbpg_Blocks.Location = new Point(4, 29);
            tbpg_Blocks.Name = "tbpg_Blocks";
            tbpg_Blocks.Padding = new Padding(3);
            tbpg_Blocks.Size = new Size(651, 499);
            tbpg_Blocks.TabIndex = 1;
            tbpg_Blocks.Text = "Blocks";
            tbpg_Blocks.UseVisualStyleBackColor = true;
            // 
            // pnl_Right_Blocks
            // 
            pnl_Right_Blocks.Controls.Add(gbx_EditBlock);
            pnl_Right_Blocks.Controls.Add(gbx_NewBlock);
            pnl_Right_Blocks.Dock = DockStyle.Fill;
            pnl_Right_Blocks.Location = new Point(237, 3);
            pnl_Right_Blocks.Name = "pnl_Right_Blocks";
            pnl_Right_Blocks.Padding = new Padding(5);
            pnl_Right_Blocks.Size = new Size(411, 493);
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
            gbx_EditBlock.Location = new Point(5, 231);
            gbx_EditBlock.Name = "gbx_EditBlock";
            gbx_EditBlock.Size = new Size(401, 257);
            gbx_EditBlock.TabIndex = 3;
            gbx_EditBlock.TabStop = false;
            gbx_EditBlock.Text = "Edit Block";
            // 
            // nud_Edit_HighestFloor
            // 
            nud_Edit_HighestFloor.Location = new Point(120, 132);
            nud_Edit_HighestFloor.Name = "nud_Edit_HighestFloor";
            nud_Edit_HighestFloor.Size = new Size(98, 27);
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
            lbl_Edit_HighestFloor.Size = new Size(98, 20);
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
            nud_Edit_LowestFloor.Size = new Size(89, 27);
            nud_Edit_LowestFloor.TabIndex = 6;
            // 
            // lbl_Edit_BlockName
            // 
            lbl_Edit_BlockName.AutoSize = true;
            lbl_Edit_BlockName.Location = new Point(6, 39);
            lbl_Edit_BlockName.Name = "lbl_Edit_BlockName";
            lbl_Edit_BlockName.Size = new Size(89, 20);
            lbl_Edit_BlockName.TabIndex = 9;
            lbl_Edit_BlockName.Text = "Block Name";
            // 
            // lbl_Edit_LowestFloor
            // 
            lbl_Edit_LowestFloor.AutoSize = true;
            lbl_Edit_LowestFloor.Location = new Point(6, 109);
            lbl_Edit_LowestFloor.Name = "lbl_Edit_LowestFloor";
            lbl_Edit_LowestFloor.Size = new Size(93, 20);
            lbl_Edit_LowestFloor.TabIndex = 10;
            lbl_Edit_LowestFloor.Text = "Lowest Floor";
            // 
            // txt_Edit_BlockName
            // 
            txt_Edit_BlockName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Edit_BlockName.Location = new Point(6, 62);
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
            gbx_NewBlock.Size = new Size(401, 226);
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
            nud_New_HighestFloor.Location = new Point(124, 129);
            nud_New_HighestFloor.Name = "nud_New_HighestFloor";
            nud_New_HighestFloor.Size = new Size(98, 27);
            nud_New_HighestFloor.TabIndex = 3;
            // 
            // lbl_New_HighestFloor
            // 
            lbl_New_HighestFloor.AutoSize = true;
            lbl_New_HighestFloor.Location = new Point(124, 106);
            lbl_New_HighestFloor.Name = "lbl_New_HighestFloor";
            lbl_New_HighestFloor.Size = new Size(98, 20);
            lbl_New_HighestFloor.TabIndex = 6;
            lbl_New_HighestFloor.Text = "Highest Floor";
            // 
            // nud_New_LowestFloor
            // 
            nud_New_LowestFloor.Location = new Point(10, 129);
            nud_New_LowestFloor.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            nud_New_LowestFloor.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_New_LowestFloor.Name = "nud_New_LowestFloor";
            nud_New_LowestFloor.Size = new Size(89, 27);
            nud_New_LowestFloor.TabIndex = 2;
            // 
            // lbl_New_LowestFloor
            // 
            lbl_New_LowestFloor.AutoSize = true;
            lbl_New_LowestFloor.Location = new Point(10, 106);
            lbl_New_LowestFloor.Name = "lbl_New_LowestFloor";
            lbl_New_LowestFloor.Size = new Size(93, 20);
            lbl_New_LowestFloor.TabIndex = 4;
            lbl_New_LowestFloor.Text = "Lowest Floor";
            // 
            // lbl_New_BlockName
            // 
            lbl_New_BlockName.AutoSize = true;
            lbl_New_BlockName.Location = new Point(10, 36);
            lbl_New_BlockName.Name = "lbl_New_BlockName";
            lbl_New_BlockName.Size = new Size(89, 20);
            lbl_New_BlockName.TabIndex = 2;
            lbl_New_BlockName.Text = "Block Name";
            // 
            // txt_New_BlockName
            // 
            txt_New_BlockName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_New_BlockName.Location = new Point(10, 59);
            txt_New_BlockName.Name = "txt_New_BlockName";
            txt_New_BlockName.Size = new Size(212, 29);
            txt_New_BlockName.TabIndex = 1;
            // 
            // lst_Blocks
            // 
            lst_Blocks.Dock = DockStyle.Left;
            lst_Blocks.FormattingEnabled = true;
            lst_Blocks.ItemHeight = 20;
            lst_Blocks.Location = new Point(3, 3);
            lst_Blocks.Name = "lst_Blocks";
            lst_Blocks.Size = new Size(234, 493);
            lst_Blocks.TabIndex = 200;
            lst_Blocks.SelectedIndexChanged += lst_Blocks_SelectedIndexChanged;
            // 
            // tbpg_Export
            // 
            tbpg_Export.Controls.Add(btn_SetSaveLocation);
            tbpg_Export.Controls.Add(textBox1);
            tbpg_Export.Controls.Add(panel1);
            tbpg_Export.Location = new Point(4, 29);
            tbpg_Export.Name = "tbpg_Export";
            tbpg_Export.Padding = new Padding(3);
            tbpg_Export.Size = new Size(651, 499);
            tbpg_Export.TabIndex = 2;
            tbpg_Export.Text = "Export";
            tbpg_Export.UseVisualStyleBackColor = true;
            // 
            // btn_SetSaveLocation
            // 
            btn_SetSaveLocation.Location = new Point(247, 49);
            btn_SetSaveLocation.Name = "btn_SetSaveLocation";
            btn_SetSaveLocation.Size = new Size(151, 27);
            btn_SetSaveLocation.TabIndex = 1;
            btn_SetSaveLocation.Text = "Choose save location";
            btn_SetSaveLocation.UseVisualStyleBackColor = true;
            btn_SetSaveLocation.Click += btn_SetSaveLocation_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(8, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(635, 33);
            textBox1.TabIndex = 0;
            textBox1.WordWrap = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_AdminPanelExport);
            panel1.Controls.Add(btn_ExportBoth);
            panel1.Controls.Add(btn_AppExport);
            panel1.Location = new Point(0, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(651, 317);
            panel1.TabIndex = 3;
            // 
            // btn_AdminPanelExport
            // 
            btn_AdminPanelExport.Location = new Point(121, 129);
            btn_AdminPanelExport.Name = "btn_AdminPanelExport";
            btn_AdminPanelExport.Size = new Size(399, 53);
            btn_AdminPanelExport.TabIndex = 3;
            btn_AdminPanelExport.Text = "Export for FARap";
            btn_AdminPanelExport.UseVisualStyleBackColor = true;
            // 
            // btn_ExportBoth
            // 
            btn_ExportBoth.Location = new Point(121, 213);
            btn_ExportBoth.Name = "btn_ExportBoth";
            btn_ExportBoth.Size = new Size(399, 53);
            btn_ExportBoth.TabIndex = 4;
            btn_ExportBoth.Text = "Export for Both";
            btn_ExportBoth.UseVisualStyleBackColor = true;
            // 
            // btn_AppExport
            // 
            btn_AppExport.Location = new Point(121, 48);
            btn_AppExport.Name = "btn_AppExport";
            btn_AppExport.Size = new Size(399, 53);
            btn_AppExport.TabIndex = 2;
            btn_AppExport.Text = "Export for FARa";
            btn_AppExport.UseVisualStyleBackColor = true;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 532);
            Controls.Add(tbctrl_MainTabs);
            Name = "frm_Main";
            Text = "Main";
            tbctrl_MainTabs.ResumeLayout(false);
            tbpg_Nodes.ResumeLayout(false);
            gbx_Node.ResumeLayout(false);
            gbx_Node.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Connections).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).EndInit();
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
            tbpg_Export.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbctrl_MainTabs;
        private TabPage tbpg_Nodes;
        private GroupBox gbx_EditNode;
        private GroupBox gbx_Node;
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
        private Label label1;
        private ComboBox cmbx_BlockSelect;
        private ComboBox cmbx_NodeType;
        private Label label2;
        private NumericUpDown nud_Node_Floor;
        private Label label3;
        private TextBox txt_InternalName;
        private Label label5;
        private TextBox txt_PublicName;
        private Label label4;
        private Button btn_Node_Delete;
        private Button btn_Node_Save;
        private Button btn_Node_Create;
        private TextBox txt_Node_Tags;
        private Label label7;
        private DataGridView dgv_Connections;
        private DataGridViewTextBoxColumn clm_NodeDirection;
        private DataGridViewComboBoxColumn clm_AvailNodes;
        private DataGridViewCheckBoxColumn clm_OneWay;
        private TabPage tbpg_Export;
        private Button btn_SetSaveLocation;
        private TextBox textBox1;
        private Panel panel1;
        private Button btn_AdminPanelExport;
        private Button btn_ExportBoth;
        private Button btn_AppExport;
    }
}
