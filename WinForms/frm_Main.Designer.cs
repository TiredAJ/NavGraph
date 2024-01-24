
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
            tbctrl_MainTabs = new TabControl();
            tbpg_Nodes = new TabPage();
            gbx_Node = new GroupBox();
            ckbx_IsElevator = new CheckBox();
            btn_SaveBackup = new Button();
            cmbx_GWFlow = new ComboBox();
            cmbx_ElvFlow = new ComboBox();
            btn_Node_Delete = new Button();
            btn_Node_Save = new Button();
            btn_Node_Create = new Button();
            txt_InternalName = new TextBox();
            txt_PublicName = new TextBox();
            nud_Node_Floor = new NumericUpDown();
            cmbx_NodeType = new ComboBox();
            cmbx_BlockSelect = new ComboBox();
            pnl_NormalNodes = new Panel();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            pnl_conn_North = new Panel();
            ckbx_conn_North = new CheckBox();
            cmbx_conn_North = new ComboBox();
            label17 = new Label();
            txt_Node_Tags = new TextBox();
            pnl_conn_East = new Panel();
            ckbx_conn_East = new CheckBox();
            cmbx_conn_East = new ComboBox();
            label21 = new Label();
            pnl_conn_South = new Panel();
            ckbx_conn_South = new CheckBox();
            cmbx_conn_South = new ComboBox();
            label22 = new Label();
            pnl_conn_West = new Panel();
            ckbx_conn_West = new CheckBox();
            cmbx_conn_West = new ComboBox();
            label23 = new Label();
            pnl_conn_Up = new Panel();
            cmbx_conn_Up = new ComboBox();
            label24 = new Label();
            pnl_conn_Down = new Panel();
            cmbx_conn_Down = new ComboBox();
            label25 = new Label();
            label7 = new Label();
            pnl_GW = new Panel();
            label8 = new Label();
            cmbx_GW_AvailableNodes = new ComboBox();
            label6 = new Label();
            cmbx_GW_Direction = new ComboBox();
            dgv_GatewayConnections = new DataGridView();
            dgvcmbx_GW_AvailableNodes = new DataGridViewComboBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            label10 = new Label();
            label9 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
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
            txt_New_BlockName = new TextBox();
            lbl_New_BlockName = new Label();
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
            txt_set_id_ElvEE = new TextBox();
            label26 = new Label();
            txt_set_id_Corridor = new TextBox();
            txt_set_id_Room = new TextBox();
            txt_set_id_GW = new TextBox();
            txt_set_id_ElvES = new TextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            lbl_set_id_Elv = new Label();
            label12 = new Label();
            txt_set_Separator = new TextBox();
            label11 = new Label();
            lbl_NameTemplate = new Label();
            tbctrl_MainTabs.SuspendLayout();
            tbpg_Nodes.SuspendLayout();
            gbx_Node.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).BeginInit();
            pnl_NormalNodes.SuspendLayout();
            pnl_conn_North.SuspendLayout();
            pnl_conn_East.SuspendLayout();
            pnl_conn_South.SuspendLayout();
            pnl_conn_West.SuspendLayout();
            pnl_conn_Up.SuspendLayout();
            pnl_conn_Down.SuspendLayout();
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
            tbctrl_MainTabs.Size = new Size(1069, 679);
            tbctrl_MainTabs.TabIndex = 0;
            tbctrl_MainTabs.TabStop = false;
            tbctrl_MainTabs.Selected += tbctrl_MainTabs_Selected;
            // 
            // tbpg_Nodes
            // 
            tbpg_Nodes.Controls.Add(gbx_Node);
            tbpg_Nodes.Controls.Add(trvw_Nodes);
            tbpg_Nodes.Location = new Point(4, 34);
            tbpg_Nodes.Name = "tbpg_Nodes";
            tbpg_Nodes.Padding = new Padding(3);
            tbpg_Nodes.Size = new Size(1061, 641);
            tbpg_Nodes.TabIndex = 0;
            tbpg_Nodes.Text = "Nodes";
            tbpg_Nodes.UseVisualStyleBackColor = true;
            // 
            // gbx_Node
            // 
            gbx_Node.Controls.Add(ckbx_IsElevator);
            gbx_Node.Controls.Add(btn_SaveBackup);
            gbx_Node.Controls.Add(cmbx_GWFlow);
            gbx_Node.Controls.Add(cmbx_ElvFlow);
            gbx_Node.Controls.Add(btn_Node_Delete);
            gbx_Node.Controls.Add(btn_Node_Save);
            gbx_Node.Controls.Add(btn_Node_Create);
            gbx_Node.Controls.Add(txt_InternalName);
            gbx_Node.Controls.Add(txt_PublicName);
            gbx_Node.Controls.Add(nud_Node_Floor);
            gbx_Node.Controls.Add(cmbx_NodeType);
            gbx_Node.Controls.Add(cmbx_BlockSelect);
            gbx_Node.Controls.Add(pnl_NormalNodes);
            gbx_Node.Controls.Add(pnl_GW);
            gbx_Node.Controls.Add(label10);
            gbx_Node.Controls.Add(label9);
            gbx_Node.Controls.Add(label5);
            gbx_Node.Controls.Add(label4);
            gbx_Node.Controls.Add(label3);
            gbx_Node.Controls.Add(label2);
            gbx_Node.Controls.Add(label1);
            gbx_Node.Dock = DockStyle.Fill;
            gbx_Node.Location = new Point(460, 3);
            gbx_Node.Name = "gbx_Node";
            gbx_Node.Padding = new Padding(5);
            gbx_Node.Size = new Size(598, 635);
            gbx_Node.TabIndex = 0;
            gbx_Node.TabStop = false;
            gbx_Node.Text = "Create/Edit Node";
            // 
            // ckbx_IsElevator
            // 
            ckbx_IsElevator.AutoSize = true;
            ckbx_IsElevator.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckbx_IsElevator.Location = new Point(414, 120);
            ckbx_IsElevator.Name = "ckbx_IsElevator";
            ckbx_IsElevator.Size = new Size(100, 25);
            ckbx_IsElevator.TabIndex = 20;
            ckbx_IsElevator.Text = "Is Elevator";
            ckbx_IsElevator.UseVisualStyleBackColor = true;
            ckbx_IsElevator.CheckedChanged += ckbx_IsElevator_CheckedChanged;
            // 
            // btn_SaveBackup
            // 
            btn_SaveBackup.Font = new Font("Segoe UI", 12F);
            btn_SaveBackup.Location = new Point(387, 581);
            btn_SaveBackup.Name = "btn_SaveBackup";
            btn_SaveBackup.Size = new Size(160, 37);
            btn_SaveBackup.TabIndex = 19;
            btn_SaveBackup.Text = "Save Backup";
            btn_SaveBackup.TextAlign = ContentAlignment.TopCenter;
            btn_SaveBackup.UseVisualStyleBackColor = true;
            btn_SaveBackup.Click += btn_SaveBackup_Click;
            // 
            // cmbx_GWFlow
            // 
            cmbx_GWFlow.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbx_GWFlow.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_GWFlow.Font = new Font("Segoe UI", 12F);
            cmbx_GWFlow.FormattingEnabled = true;
            cmbx_GWFlow.Items.AddRange(new object[] { "North", "East", "South", "West" });
            cmbx_GWFlow.Location = new Point(195, 181);
            cmbx_GWFlow.Name = "cmbx_GWFlow";
            cmbx_GWFlow.Size = new Size(187, 29);
            cmbx_GWFlow.TabIndex = 17;
            // 
            // cmbx_ElvFlow
            // 
            cmbx_ElvFlow.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbx_ElvFlow.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_ElvFlow.Font = new Font("Segoe UI", 12F);
            cmbx_ElvFlow.FormattingEnabled = true;
            cmbx_ElvFlow.Items.AddRange(new object[] { "North", "East", "South", "West" });
            cmbx_ElvFlow.Location = new Point(6, 181);
            cmbx_ElvFlow.Name = "cmbx_ElvFlow";
            cmbx_ElvFlow.Size = new Size(183, 29);
            cmbx_ElvFlow.TabIndex = 15;
            // 
            // btn_Node_Delete
            // 
            btn_Node_Delete.Font = new Font("Segoe UI", 12F);
            btn_Node_Delete.Location = new Point(271, 581);
            btn_Node_Delete.Name = "btn_Node_Delete";
            btn_Node_Delete.Size = new Size(95, 37);
            btn_Node_Delete.TabIndex = 9;
            btn_Node_Delete.Text = "Delete";
            btn_Node_Delete.TextAlign = ContentAlignment.TopCenter;
            btn_Node_Delete.UseVisualStyleBackColor = true;
            btn_Node_Delete.Click += btn_Node_Delete_Click;
            // 
            // btn_Node_Save
            // 
            btn_Node_Save.Enabled = false;
            btn_Node_Save.Font = new Font("Segoe UI", 12F);
            btn_Node_Save.Location = new Point(134, 581);
            btn_Node_Save.Name = "btn_Node_Save";
            btn_Node_Save.Size = new Size(95, 37);
            btn_Node_Save.TabIndex = 8;
            btn_Node_Save.Text = "Save";
            btn_Node_Save.TextAlign = ContentAlignment.TopCenter;
            btn_Node_Save.UseVisualStyleBackColor = true;
            btn_Node_Save.Click += btn_Node_Save_Click;
            // 
            // btn_Node_Create
            // 
            btn_Node_Create.Font = new Font("Segoe UI", 12F);
            btn_Node_Create.Location = new Point(6, 581);
            btn_Node_Create.Name = "btn_Node_Create";
            btn_Node_Create.Size = new Size(95, 37);
            btn_Node_Create.TabIndex = 7;
            btn_Node_Create.Text = "Create";
            btn_Node_Create.TextAlign = ContentAlignment.TopCenter;
            btn_Node_Create.UseVisualStyleBackColor = true;
            btn_Node_Create.Click += btn_Node_Create_Click;
            // 
            // txt_InternalName
            // 
            txt_InternalName.Font = new Font("Segoe UI", 12F);
            txt_InternalName.Location = new Point(197, 117);
            txt_InternalName.Name = "txt_InternalName";
            txt_InternalName.Size = new Size(185, 29);
            txt_InternalName.TabIndex = 4;
            // 
            // txt_PublicName
            // 
            txt_PublicName.Font = new Font("Segoe UI", 12F);
            txt_PublicName.Location = new Point(6, 117);
            txt_PublicName.Name = "txt_PublicName";
            txt_PublicName.Size = new Size(185, 29);
            txt_PublicName.TabIndex = 3;
            txt_PublicName.Tag = "ClearMe";
            txt_PublicName.TextChanged += txt_PublicName_TextChanged;
            // 
            // nud_Node_Floor
            // 
            nud_Node_Floor.Font = new Font("Segoe UI", 12F);
            nud_Node_Floor.Location = new Point(390, 53);
            nud_Node_Floor.Name = "nud_Node_Floor";
            nud_Node_Floor.Size = new Size(138, 29);
            nud_Node_Floor.TabIndex = 2;
            nud_Node_Floor.ValueChanged += nud_Node_Floor_ValueChanged;
            // 
            // cmbx_NodeType
            // 
            cmbx_NodeType.AutoCompleteMode = AutoCompleteMode.Append;
            cmbx_NodeType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_NodeType.Font = new Font("Segoe UI", 12F);
            cmbx_NodeType.FormattingEnabled = true;
            cmbx_NodeType.Items.AddRange(new object[] { "Corridor", "Room", "Elevation", "Gateway" });
            cmbx_NodeType.Location = new Point(6, 53);
            cmbx_NodeType.Name = "cmbx_NodeType";
            cmbx_NodeType.Size = new Size(185, 29);
            cmbx_NodeType.TabIndex = 0;
            cmbx_NodeType.SelectedIndexChanged += cmbx_NodeType_SelectedIndexChanged;
            // 
            // cmbx_BlockSelect
            // 
            cmbx_BlockSelect.AutoCompleteMode = AutoCompleteMode.Append;
            cmbx_BlockSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_BlockSelect.Font = new Font("Segoe UI", 12F);
            cmbx_BlockSelect.FormattingEnabled = true;
            cmbx_BlockSelect.Location = new Point(197, 53);
            cmbx_BlockSelect.Name = "cmbx_BlockSelect";
            cmbx_BlockSelect.Size = new Size(185, 29);
            cmbx_BlockSelect.TabIndex = 1;
            cmbx_BlockSelect.SelectedIndexChanged += cmbx_BlockSelect_SelectedIndexChanged;
            // 
            // pnl_NormalNodes
            // 
            pnl_NormalNodes.BackColor = SystemColors.ControlLight;
            pnl_NormalNodes.Controls.Add(label20);
            pnl_NormalNodes.Controls.Add(label19);
            pnl_NormalNodes.Controls.Add(label18);
            pnl_NormalNodes.Controls.Add(pnl_conn_North);
            pnl_NormalNodes.Controls.Add(txt_Node_Tags);
            pnl_NormalNodes.Controls.Add(pnl_conn_East);
            pnl_NormalNodes.Controls.Add(pnl_conn_South);
            pnl_NormalNodes.Controls.Add(pnl_conn_West);
            pnl_NormalNodes.Controls.Add(pnl_conn_Up);
            pnl_NormalNodes.Controls.Add(pnl_conn_Down);
            pnl_NormalNodes.Controls.Add(label7);
            pnl_NormalNodes.Location = new Point(2, 221);
            pnl_NormalNodes.Margin = new Padding(3, 4, 3, 4);
            pnl_NormalNodes.Name = "pnl_NormalNodes";
            pnl_NormalNodes.Size = new Size(546, 353);
            pnl_NormalNodes.TabIndex = 1;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(447, 1);
            label20.Name = "label20";
            label20.Size = new Size(95, 25);
            label20.TabIndex = 16;
            label20.Text = "Is oneway";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(105, 1);
            label19.Name = "label19";
            label19.Size = new Size(148, 25);
            label19.TabIndex = 15;
            label19.Text = "Available Nodes";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(3, 1);
            label18.Name = "label18";
            label18.Size = new Size(89, 25);
            label18.TabIndex = 14;
            label18.Text = "Direction";
            // 
            // pnl_conn_North
            // 
            pnl_conn_North.Controls.Add(ckbx_conn_North);
            pnl_conn_North.Controls.Add(cmbx_conn_North);
            pnl_conn_North.Controls.Add(label17);
            pnl_conn_North.Location = new Point(0, 32);
            pnl_conn_North.Name = "pnl_conn_North";
            pnl_conn_North.Size = new Size(553, 41);
            pnl_conn_North.TabIndex = 13;
            // 
            // ckbx_conn_North
            // 
            ckbx_conn_North.AutoSize = true;
            ckbx_conn_North.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckbx_conn_North.Location = new Point(490, 8);
            ckbx_conn_North.Name = "ckbx_conn_North";
            ckbx_conn_North.Size = new Size(15, 14);
            ckbx_conn_North.TabIndex = 3;
            ckbx_conn_North.UseVisualStyleBackColor = true;
            // 
            // cmbx_conn_North
            // 
            cmbx_conn_North.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_conn_North.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_conn_North.FormattingEnabled = true;
            cmbx_conn_North.Location = new Point(105, -1);
            cmbx_conn_North.Name = "cmbx_conn_North";
            cmbx_conn_North.Size = new Size(338, 33);
            cmbx_conn_North.TabIndex = 1;
            cmbx_conn_North.Leave += cbmx_conn_ContentsCheck;
            cmbx_conn_North.MouseEnter += cmbx_conn_GetNodes;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(5, 3);
            label17.Margin = new Padding(3);
            label17.Name = "label17";
            label17.Size = new Size(61, 25);
            label17.TabIndex = 0;
            label17.Text = "North";
            // 
            // txt_Node_Tags
            // 
            txt_Node_Tags.Dock = DockStyle.Bottom;
            txt_Node_Tags.Enabled = false;
            txt_Node_Tags.Location = new Point(0, 300);
            txt_Node_Tags.Multiline = true;
            txt_Node_Tags.Name = "txt_Node_Tags";
            txt_Node_Tags.Size = new Size(546, 53);
            txt_Node_Tags.TabIndex = 6;
            // 
            // pnl_conn_East
            // 
            pnl_conn_East.Controls.Add(ckbx_conn_East);
            pnl_conn_East.Controls.Add(cmbx_conn_East);
            pnl_conn_East.Controls.Add(label21);
            pnl_conn_East.Location = new Point(0, 69);
            pnl_conn_East.Name = "pnl_conn_East";
            pnl_conn_East.Size = new Size(553, 41);
            pnl_conn_East.TabIndex = 14;
            // 
            // ckbx_conn_East
            // 
            ckbx_conn_East.AutoSize = true;
            ckbx_conn_East.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckbx_conn_East.Location = new Point(490, 8);
            ckbx_conn_East.Name = "ckbx_conn_East";
            ckbx_conn_East.Size = new Size(15, 14);
            ckbx_conn_East.TabIndex = 3;
            ckbx_conn_East.UseVisualStyleBackColor = true;
            // 
            // cmbx_conn_East
            // 
            cmbx_conn_East.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_conn_East.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_conn_East.FormattingEnabled = true;
            cmbx_conn_East.Location = new Point(105, -1);
            cmbx_conn_East.Name = "cmbx_conn_East";
            cmbx_conn_East.Size = new Size(338, 33);
            cmbx_conn_East.TabIndex = 1;
            cmbx_conn_East.Leave += cbmx_conn_ContentsCheck;
            cmbx_conn_East.MouseEnter += cmbx_conn_GetNodes;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(5, 3);
            label21.Margin = new Padding(3);
            label21.Name = "label21";
            label21.Size = new Size(46, 25);
            label21.TabIndex = 0;
            label21.Text = "East";
            // 
            // pnl_conn_South
            // 
            pnl_conn_South.Controls.Add(ckbx_conn_South);
            pnl_conn_South.Controls.Add(cmbx_conn_South);
            pnl_conn_South.Controls.Add(label22);
            pnl_conn_South.Location = new Point(0, 107);
            pnl_conn_South.Name = "pnl_conn_South";
            pnl_conn_South.Size = new Size(553, 41);
            pnl_conn_South.TabIndex = 17;
            // 
            // ckbx_conn_South
            // 
            ckbx_conn_South.AutoSize = true;
            ckbx_conn_South.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckbx_conn_South.Location = new Point(490, 8);
            ckbx_conn_South.Name = "ckbx_conn_South";
            ckbx_conn_South.Size = new Size(15, 14);
            ckbx_conn_South.TabIndex = 3;
            ckbx_conn_South.UseVisualStyleBackColor = true;
            // 
            // cmbx_conn_South
            // 
            cmbx_conn_South.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_conn_South.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_conn_South.FormattingEnabled = true;
            cmbx_conn_South.Location = new Point(105, -1);
            cmbx_conn_South.Name = "cmbx_conn_South";
            cmbx_conn_South.Size = new Size(338, 33);
            cmbx_conn_South.TabIndex = 1;
            cmbx_conn_South.Leave += cbmx_conn_ContentsCheck;
            cmbx_conn_South.MouseEnter += cmbx_conn_GetNodes;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(5, 3);
            label22.Margin = new Padding(3);
            label22.Name = "label22";
            label22.Size = new Size(61, 25);
            label22.TabIndex = 0;
            label22.Text = "South";
            // 
            // pnl_conn_West
            // 
            pnl_conn_West.Controls.Add(ckbx_conn_West);
            pnl_conn_West.Controls.Add(cmbx_conn_West);
            pnl_conn_West.Controls.Add(label23);
            pnl_conn_West.Location = new Point(0, 144);
            pnl_conn_West.Name = "pnl_conn_West";
            pnl_conn_West.Size = new Size(553, 41);
            pnl_conn_West.TabIndex = 18;
            // 
            // ckbx_conn_West
            // 
            ckbx_conn_West.AutoSize = true;
            ckbx_conn_West.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckbx_conn_West.Location = new Point(490, 8);
            ckbx_conn_West.Name = "ckbx_conn_West";
            ckbx_conn_West.Size = new Size(15, 14);
            ckbx_conn_West.TabIndex = 3;
            ckbx_conn_West.UseVisualStyleBackColor = true;
            // 
            // cmbx_conn_West
            // 
            cmbx_conn_West.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_conn_West.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_conn_West.FormattingEnabled = true;
            cmbx_conn_West.Location = new Point(105, -1);
            cmbx_conn_West.Name = "cmbx_conn_West";
            cmbx_conn_West.Size = new Size(338, 33);
            cmbx_conn_West.TabIndex = 1;
            cmbx_conn_West.Leave += cbmx_conn_ContentsCheck;
            cmbx_conn_West.MouseEnter += cmbx_conn_GetNodes;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(5, 3);
            label23.Margin = new Padding(3);
            label23.Name = "label23";
            label23.Size = new Size(53, 25);
            label23.TabIndex = 0;
            label23.Text = "West";
            // 
            // pnl_conn_Up
            // 
            pnl_conn_Up.Controls.Add(cmbx_conn_Up);
            pnl_conn_Up.Controls.Add(label24);
            pnl_conn_Up.Enabled = false;
            pnl_conn_Up.Location = new Point(0, 180);
            pnl_conn_Up.Name = "pnl_conn_Up";
            pnl_conn_Up.Size = new Size(553, 41);
            pnl_conn_Up.TabIndex = 19;
            // 
            // cmbx_conn_Up
            // 
            cmbx_conn_Up.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_conn_Up.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_conn_Up.FormattingEnabled = true;
            cmbx_conn_Up.Location = new Point(105, -1);
            cmbx_conn_Up.Name = "cmbx_conn_Up";
            cmbx_conn_Up.Size = new Size(338, 33);
            cmbx_conn_Up.TabIndex = 1;
            cmbx_conn_Up.Leave += cbmx_conn_ContentsCheck;
            cmbx_conn_Up.MouseEnter += cmbx_conn_GetNodes;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(5, 3);
            label24.Margin = new Padding(3);
            label24.Name = "label24";
            label24.Size = new Size(36, 25);
            label24.TabIndex = 0;
            label24.Text = "Up";
            // 
            // pnl_conn_Down
            // 
            pnl_conn_Down.Controls.Add(cmbx_conn_Down);
            pnl_conn_Down.Controls.Add(label25);
            pnl_conn_Down.Enabled = false;
            pnl_conn_Down.Location = new Point(0, 219);
            pnl_conn_Down.Name = "pnl_conn_Down";
            pnl_conn_Down.Size = new Size(553, 41);
            pnl_conn_Down.TabIndex = 19;
            // 
            // cmbx_conn_Down
            // 
            cmbx_conn_Down.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbx_conn_Down.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbx_conn_Down.FormattingEnabled = true;
            cmbx_conn_Down.Location = new Point(105, -1);
            cmbx_conn_Down.Name = "cmbx_conn_Down";
            cmbx_conn_Down.Size = new Size(338, 33);
            cmbx_conn_Down.TabIndex = 1;
            cmbx_conn_Down.Leave += cbmx_conn_ContentsCheck;
            cmbx_conn_Down.MouseEnter += cmbx_conn_GetNodes;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(5, 3);
            label25.Margin = new Padding(3);
            label25.Name = "label25";
            label25.Size = new Size(61, 25);
            label25.TabIndex = 0;
            label25.Text = "Down";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 268);
            label7.Name = "label7";
            label7.Size = new Size(216, 25);
            label7.TabIndex = 12;
            label7.Text = "Tags (comma separated)";
            // 
            // pnl_GW
            // 
            pnl_GW.BackColor = SystemColors.ControlLight;
            pnl_GW.Controls.Add(label8);
            pnl_GW.Controls.Add(cmbx_GW_AvailableNodes);
            pnl_GW.Controls.Add(label6);
            pnl_GW.Controls.Add(cmbx_GW_Direction);
            pnl_GW.Controls.Add(dgv_GatewayConnections);
            pnl_GW.Location = new Point(2, 229);
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
            cmbx_GW_AvailableNodes.Location = new Point(159, 37);
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
            cmbx_GW_Direction.Location = new Point(7, 37);
            cmbx_GW_Direction.Margin = new Padding(3, 4, 3, 4);
            cmbx_GW_Direction.Name = "cmbx_GW_Direction";
            cmbx_GW_Direction.Size = new Size(138, 33);
            cmbx_GW_Direction.TabIndex = 14;
            cmbx_GW_Direction.TabStop = false;
            cmbx_GW_Direction.Tag = "ClearMe";
            // 
            // dgv_GatewayConnections
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_GatewayConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvcmbx_GW_AvailableNodes.DefaultCellStyle = dataGridViewCellStyle2;
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(198, 153);
            label10.Name = "label10";
            label10.Size = new Size(128, 25);
            label10.TabIndex = 18;
            label10.Text = "Gateway Flow";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 153);
            label9.Name = "label9";
            label9.Size = new Size(124, 25);
            label9.TabIndex = 16;
            label9.Text = "Elevator Flow";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(200, 89);
            label5.Name = "label5";
            label5.Size = new Size(132, 25);
            label5.TabIndex = 7;
            label5.Text = "Internal Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 89);
            label4.Name = "label4";
            label4.Size = new Size(119, 25);
            label4.TabIndex = 5;
            label4.Text = "Public Name";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 25);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 2;
            label2.Text = "Node Type";
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
            // trvw_Nodes
            // 
            trvw_Nodes.Dock = DockStyle.Left;
            trvw_Nodes.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            trvw_Nodes.FullRowSelect = true;
            trvw_Nodes.HideSelection = false;
            trvw_Nodes.Indent = 10;
            trvw_Nodes.Location = new Point(3, 3);
            trvw_Nodes.Name = "trvw_Nodes";
            trvw_Nodes.Size = new Size(457, 635);
            trvw_Nodes.TabIndex = 200;
            trvw_Nodes.AfterSelect += trvw_Nodes_AfterSelect;
            trvw_Nodes.Click += trvw_Nodes_Click;
            // 
            // tbpg_Blocks
            // 
            tbpg_Blocks.Controls.Add(pnl_Right_Blocks);
            tbpg_Blocks.Controls.Add(lst_Blocks);
            tbpg_Blocks.Location = new Point(4, 34);
            tbpg_Blocks.Name = "tbpg_Blocks";
            tbpg_Blocks.Padding = new Padding(3);
            tbpg_Blocks.Size = new Size(1061, 641);
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
            pnl_Right_Blocks.Size = new Size(766, 635);
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
            gbx_EditBlock.Location = new Point(5, 268);
            gbx_EditBlock.Name = "gbx_EditBlock";
            gbx_EditBlock.Size = new Size(756, 362);
            gbx_EditBlock.TabIndex = 3;
            gbx_EditBlock.TabStop = false;
            gbx_EditBlock.Text = "Edit Block";
            // 
            // nud_Edit_HighestFloor
            // 
            nud_Edit_HighestFloor.Location = new Point(125, 145);
            nud_Edit_HighestFloor.Name = "nud_Edit_HighestFloor";
            nud_Edit_HighestFloor.Size = new Size(98, 33);
            nud_Edit_HighestFloor.TabIndex = 7;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(10, 225);
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
            btn_SaveBlock.Location = new Point(143, 225);
            btn_SaveBlock.Name = "btn_SaveBlock";
            btn_SaveBlock.Size = new Size(111, 39);
            btn_SaveBlock.TabIndex = 9;
            btn_SaveBlock.Text = "Save";
            btn_SaveBlock.UseVisualStyleBackColor = true;
            btn_SaveBlock.Click += btn_SaveBlock_Click;
            // 
            // nud_Edit_LowestFloor
            // 
            nud_Edit_LowestFloor.Location = new Point(10, 145);
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
            gbx_NewBlock.Controls.Add(txt_New_BlockName);
            gbx_NewBlock.Controls.Add(lbl_New_BlockName);
            gbx_NewBlock.Dock = DockStyle.Top;
            gbx_NewBlock.Location = new Point(5, 5);
            gbx_NewBlock.Name = "gbx_NewBlock";
            gbx_NewBlock.Size = new Size(756, 263);
            gbx_NewBlock.TabIndex = 2;
            gbx_NewBlock.TabStop = false;
            gbx_NewBlock.Text = "New Block";
            // 
            // btn_CreateBlock
            // 
            btn_CreateBlock.Location = new Point(6, 199);
            btn_CreateBlock.Name = "btn_CreateBlock";
            btn_CreateBlock.Size = new Size(111, 39);
            btn_CreateBlock.TabIndex = 4;
            btn_CreateBlock.Text = "Create";
            btn_CreateBlock.UseVisualStyleBackColor = true;
            btn_CreateBlock.Click += btn_CreateBlock_Click;
            // 
            // nud_New_HighestFloor
            // 
            nud_New_HighestFloor.Location = new Point(143, 149);
            nud_New_HighestFloor.Name = "nud_New_HighestFloor";
            nud_New_HighestFloor.Size = new Size(98, 33);
            nud_New_HighestFloor.TabIndex = 3;
            // 
            // lbl_New_HighestFloor
            // 
            lbl_New_HighestFloor.AutoSize = true;
            lbl_New_HighestFloor.Location = new Point(143, 113);
            lbl_New_HighestFloor.Name = "lbl_New_HighestFloor";
            lbl_New_HighestFloor.Size = new Size(124, 25);
            lbl_New_HighestFloor.TabIndex = 6;
            lbl_New_HighestFloor.Text = "Highest Floor";
            // 
            // nud_New_LowestFloor
            // 
            nud_New_LowestFloor.Location = new Point(7, 149);
            nud_New_LowestFloor.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            nud_New_LowestFloor.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_New_LowestFloor.Name = "nud_New_LowestFloor";
            nud_New_LowestFloor.Size = new Size(89, 33);
            nud_New_LowestFloor.TabIndex = 2;
            // 
            // lbl_New_LowestFloor
            // 
            lbl_New_LowestFloor.AutoSize = true;
            lbl_New_LowestFloor.Location = new Point(7, 113);
            lbl_New_LowestFloor.Name = "lbl_New_LowestFloor";
            lbl_New_LowestFloor.Size = new Size(118, 25);
            lbl_New_LowestFloor.TabIndex = 4;
            lbl_New_LowestFloor.Text = "Lowest Floor";
            // 
            // txt_New_BlockName
            // 
            txt_New_BlockName.Font = new Font("Segoe UI", 12F);
            txt_New_BlockName.Location = new Point(7, 72);
            txt_New_BlockName.Name = "txt_New_BlockName";
            txt_New_BlockName.Size = new Size(212, 29);
            txt_New_BlockName.TabIndex = 1;
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
            // lst_Blocks
            // 
            lst_Blocks.Dock = DockStyle.Left;
            lst_Blocks.FormattingEnabled = true;
            lst_Blocks.ItemHeight = 25;
            lst_Blocks.Location = new Point(3, 3);
            lst_Blocks.Name = "lst_Blocks";
            lst_Blocks.Size = new Size(289, 635);
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
            tbpg_Export.Size = new Size(1061, 641);
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
            panel2.Location = new Point(6, 487);
            panel2.Margin = new Padding(9);
            panel2.Name = "panel2";
            panel2.Size = new Size(1049, 149);
            panel2.TabIndex = 12;
            // 
            // btn_Import
            // 
            btn_Import.Dock = DockStyle.Bottom;
            btn_Import.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btn_Import.Location = new Point(0, 64);
            btn_Import.Margin = new Padding(0, 3, 0, 3);
            btn_Import.Name = "btn_Import";
            btn_Import.Size = new Size(1047, 83);
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
            panel1.Size = new Size(1049, 293);
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
            panel3.Size = new Size(1047, 189);
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
            radioButton2.Checked = true;
            radioButton2.Font = new Font("Segoe UI", 18F);
            radioButton2.Location = new Point(9, 53);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(209, 36);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
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
            btn_Export.Size = new Size(1047, 83);
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
            tbpg_Combine.Size = new Size(1061, 641);
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
            tbpg_Settings.Size = new Size(1061, 641);
            tbpg_Settings.TabIndex = 4;
            tbpg_Settings.Text = "Settings";
            tbpg_Settings.UseVisualStyleBackColor = true;
            tbpg_Settings.Click += tbpg_Settings_Click;
            // 
            // txt_set_Layout
            // 
            txt_set_Layout.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_set_Layout.Location = new Point(3, 51);
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
            btn_set_SaveSettings.Click += btn_set_SaveSettings_Click;
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
            panel4.Size = new Size(538, 184);
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
            txt_set_Prefix.Location = new Point(103, 35);
            txt_set_Prefix.MaxLength = 4;
            txt_set_Prefix.Name = "txt_set_Prefix";
            txt_set_Prefix.Size = new Size(94, 35);
            txt_set_Prefix.TabIndex = 3;
            txt_set_Prefix.Text = "TR";
            txt_set_Prefix.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_set_id_ElvEE);
            groupBox1.Controls.Add(label26);
            groupBox1.Controls.Add(txt_set_id_Corridor);
            groupBox1.Controls.Add(txt_set_id_Room);
            groupBox1.Controls.Add(txt_set_id_GW);
            groupBox1.Controls.Add(txt_set_id_ElvES);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(lbl_set_id_Elv);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(1, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(536, 101);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Identifiers";
            // 
            // txt_set_id_ElvEE
            // 
            txt_set_id_ElvEE.Location = new Point(104, 58);
            txt_set_id_ElvEE.MaxLength = 3;
            txt_set_id_ElvEE.Name = "txt_set_id_ElvEE";
            txt_set_id_ElvEE.Size = new Size(89, 33);
            txt_set_id_ElvEE.TabIndex = 9;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label26.Location = new Point(104, 29);
            label26.Name = "label26";
            label26.Size = new Size(80, 25);
            label26.TabIndex = 8;
            label26.Text = "Elevator";
            // 
            // txt_set_id_Corridor
            // 
            txt_set_id_Corridor.Location = new Point(389, 58);
            txt_set_id_Corridor.MaxLength = 3;
            txt_set_id_Corridor.Name = "txt_set_id_Corridor";
            txt_set_id_Corridor.Size = new Size(89, 33);
            txt_set_id_Corridor.TabIndex = 7;
            // 
            // txt_set_id_Room
            // 
            txt_set_id_Room.Location = new Point(294, 58);
            txt_set_id_Room.MaxLength = 3;
            txt_set_id_Room.Name = "txt_set_id_Room";
            txt_set_id_Room.Size = new Size(89, 33);
            txt_set_id_Room.TabIndex = 5;
            // 
            // txt_set_id_GW
            // 
            txt_set_id_GW.Location = new Point(199, 58);
            txt_set_id_GW.MaxLength = 3;
            txt_set_id_GW.Name = "txt_set_id_GW";
            txt_set_id_GW.Size = new Size(89, 33);
            txt_set_id_GW.TabIndex = 3;
            // 
            // txt_set_id_ElvES
            // 
            txt_set_id_ElvES.Location = new Point(4, 58);
            txt_set_id_ElvES.MaxLength = 3;
            txt_set_id_ElvES.Name = "txt_set_id_ElvES";
            txt_set_id_ElvES.Size = new Size(89, 33);
            txt_set_id_ElvES.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(388, 29);
            label15.Name = "label15";
            label15.Size = new Size(83, 25);
            label15.TabIndex = 6;
            label15.Text = "Corridor";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(294, 29);
            label14.Name = "label14";
            label14.Size = new Size(60, 25);
            label14.TabIndex = 4;
            label14.Text = "Room";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(199, 29);
            label13.Name = "label13";
            label13.Size = new Size(84, 25);
            label13.TabIndex = 2;
            label13.Text = "Gateway";
            // 
            // lbl_set_id_Elv
            // 
            lbl_set_id_Elv.AutoSize = true;
            lbl_set_id_Elv.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_set_id_Elv.Location = new Point(4, 29);
            lbl_set_id_Elv.Name = "lbl_set_id_Elv";
            lbl_set_id_Elv.Size = new Size(57, 25);
            lbl_set_id_Elv.TabIndex = 0;
            lbl_set_id_Elv.Text = "Stairs";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(5, 7);
            label12.Name = "label12";
            label12.Size = new Size(94, 25);
            label12.TabIndex = 1;
            label12.Text = "Separator";
            // 
            // txt_set_Separator
            // 
            txt_set_Separator.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_set_Separator.Location = new Point(3, 35);
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
            label11.Location = new Point(8, 100);
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
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 679);
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
            pnl_conn_North.ResumeLayout(false);
            pnl_conn_North.PerformLayout();
            pnl_conn_East.ResumeLayout(false);
            pnl_conn_East.PerformLayout();
            pnl_conn_South.ResumeLayout(false);
            pnl_conn_South.PerformLayout();
            pnl_conn_West.ResumeLayout(false);
            pnl_conn_West.PerformLayout();
            pnl_conn_Up.ResumeLayout(false);
            pnl_conn_Up.PerformLayout();
            pnl_conn_Down.ResumeLayout(false);
            pnl_conn_Down.PerformLayout();
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
        private TextBox txt_set_id_ElvES;
        private Label lbl_set_id_Elv;
        private TextBox txt_set_Layout;
        private Label label16;
        private TextBox txt_set_Prefix;
        private DataGridViewComboBoxColumn dgvcmbx_GW_AvailableNodes;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private Panel pnl_conn_North;
        private ComboBox cmbx_conn_North;
        private Label label17;
        private Label label18;
        private CheckBox ckbx_conn_North;
        private Label label19;
        private Label label20;
        private Panel pnl_conn_East;
        private CheckBox ckbx_conn_East;
        private ComboBox cmbx_conn_East;
        private Label label21;
        private Panel pnl_conn_South;
        private CheckBox ckbx_conn_South;
        private ComboBox cmbx_conn_South;
        private Label label22;
        private Panel pnl_conn_West;
        private CheckBox ckbx_conn_West;
        private ComboBox cmbx_conn_West;
        private Label label23;
        private Panel pnl_conn_Up;
        private Panel pnl_conn_Down;
        private ComboBox cmbx_conn_Down;
        private Label label25;
        private ComboBox cmbx_conn_Up;
        private Label label24;
        private CheckBox ckbx_IsElevator;
        private TextBox txt_set_id_ElvEE;
        private Label label26;
    }
}
