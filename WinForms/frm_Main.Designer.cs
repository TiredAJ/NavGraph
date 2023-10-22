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
            tabControl1 = new TabControl();
            tbpg_Nodes = new TabPage();
            gbx_Node = new GroupBox();
            btn_Node_Delete = new Button();
            btn_Node_Save = new Button();
            btn_Node_Create = new Button();
            txt_Node_Tags = new TextBox();
            label7 = new Label();
            gbx_Node_Connections = new GroupBox();
            lstbx_AvailableNodes = new ListBox();
            label6 = new Label();
            cmbx_NodeDirection = new ComboBox();
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
            tabControl1.SuspendLayout();
            tbpg_Nodes.SuspendLayout();
            gbx_Node.SuspendLayout();
            gbx_Node_Connections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Node_Floor).BeginInit();
            tbpg_Blocks.SuspendLayout();
            pnl_Right_Blocks.SuspendLayout();
            gbx_EditBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_HighestFloor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Edit_LowestFloor).BeginInit();
            gbx_NewBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_New_HighestFloor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_New_LowestFloor).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpg_Nodes);
            tabControl1.Controls.Add(tbpg_Blocks);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(659, 532);
            tabControl1.TabIndex = 0;
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
            gbx_Node.Controls.Add(btn_Node_Delete);
            gbx_Node.Controls.Add(btn_Node_Save);
            gbx_Node.Controls.Add(btn_Node_Create);
            gbx_Node.Controls.Add(txt_Node_Tags);
            gbx_Node.Controls.Add(label7);
            gbx_Node.Controls.Add(gbx_Node_Connections);
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
            // btn_Node_Delete
            // 
            btn_Node_Delete.Enabled = false;
            btn_Node_Delete.Location = new Point(296, 443);
            btn_Node_Delete.Name = "btn_Node_Delete";
            btn_Node_Delete.Size = new Size(95, 33);
            btn_Node_Delete.TabIndex = 16;
            btn_Node_Delete.Text = "Delete";
            btn_Node_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_Node_Save
            // 
            btn_Node_Save.Enabled = false;
            btn_Node_Save.Location = new Point(159, 443);
            btn_Node_Save.Name = "btn_Node_Save";
            btn_Node_Save.Size = new Size(95, 33);
            btn_Node_Save.TabIndex = 15;
            btn_Node_Save.Text = "Save";
            btn_Node_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Node_Create
            // 
            btn_Node_Create.Location = new Point(6, 443);
            btn_Node_Create.Name = "btn_Node_Create";
            btn_Node_Create.Size = new Size(95, 33);
            btn_Node_Create.TabIndex = 14;
            btn_Node_Create.Text = "Create";
            btn_Node_Create.UseVisualStyleBackColor = true;
            btn_Node_Create.Click += btn_Node_Create_Click;
            // 
            // txt_Node_Tags
            // 
            txt_Node_Tags.Enabled = false;
            txt_Node_Tags.Location = new Point(4, 371);
            txt_Node_Tags.Name = "txt_Node_Tags";
            txt_Node_Tags.Size = new Size(387, 27);
            txt_Node_Tags.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 350);
            label7.Name = "label7";
            label7.Size = new Size(172, 20);
            label7.TabIndex = 12;
            label7.Text = "Tags (comma separated)";
            // 
            // gbx_Node_Connections
            // 
            gbx_Node_Connections.Controls.Add(lstbx_AvailableNodes);
            gbx_Node_Connections.Controls.Add(label6);
            gbx_Node_Connections.Controls.Add(cmbx_NodeDirection);
            gbx_Node_Connections.Enabled = false;
            gbx_Node_Connections.Location = new Point(0, 183);
            gbx_Node_Connections.Name = "gbx_Node_Connections";
            gbx_Node_Connections.Padding = new Padding(5);
            gbx_Node_Connections.Size = new Size(402, 164);
            gbx_Node_Connections.TabIndex = 11;
            gbx_Node_Connections.TabStop = false;
            gbx_Node_Connections.Text = "Connections";
            // 
            // lstbx_AvailableNodes
            // 
            lstbx_AvailableNodes.Dock = DockStyle.Right;
            lstbx_AvailableNodes.FormattingEnabled = true;
            lstbx_AvailableNodes.Location = new Point(249, 25);
            lstbx_AvailableNodes.Name = "lstbx_AvailableNodes";
            lstbx_AvailableNodes.Size = new Size(148, 134);
            lstbx_AvailableNodes.TabIndex = 11;
            lstbx_AvailableNodes.SelectedIndexChanged += lstbx_AvailableNodes_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 25);
            label6.Name = "label6";
            label6.Size = new Size(149, 20);
            label6.TabIndex = 9;
            label6.Text = "Connection Direction";
            // 
            // cmbx_NodeDirection
            // 
            cmbx_NodeDirection.FormattingEnabled = true;
            cmbx_NodeDirection.Items.AddRange(new object[] { "North", "East", "South", "West" });
            cmbx_NodeDirection.Location = new Point(6, 46);
            cmbx_NodeDirection.Name = "cmbx_NodeDirection";
            cmbx_NodeDirection.Size = new Size(149, 28);
            cmbx_NodeDirection.TabIndex = 10;
            cmbx_NodeDirection.SelectedIndexChanged += cmbx_NodeDirection_SelectedIndexChanged;
            // 
            // txt_InternalName
            // 
            txt_InternalName.Location = new Point(207, 150);
            txt_InternalName.Name = "txt_InternalName";
            txt_InternalName.Size = new Size(185, 27);
            txt_InternalName.TabIndex = 8;
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
            txt_PublicName.TabIndex = 6;
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
            nud_Node_Floor.TabIndex = 4;
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
            cmbx_NodeType.TabIndex = 1;
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
            cmbx_BlockSelect.FormattingEnabled = true;
            cmbx_BlockSelect.Location = new Point(6, 98);
            cmbx_BlockSelect.Name = "cmbx_BlockSelect";
            cmbx_BlockSelect.Size = new Size(185, 28);
            cmbx_BlockSelect.TabIndex = 2;
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
            trvw_Nodes.Location = new Point(3, 3);
            trvw_Nodes.Name = "trvw_Nodes";
            trvw_Nodes.Size = new Size(246, 493);
            trvw_Nodes.TabIndex = 2;
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
            nud_Edit_HighestFloor.TabIndex = 13;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(6, 212);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(111, 39);
            btn_Delete.TabIndex = 1;
            btn_Delete.Text = "Delete";
            btn_Delete.UseVisualStyleBackColor = true;
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
            btn_SaveBlock.TabIndex = 0;
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
            nud_Edit_LowestFloor.TabIndex = 11;
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
            txt_Edit_BlockName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Edit_BlockName.Location = new Point(6, 62);
            txt_Edit_BlockName.Name = "txt_Edit_BlockName";
            txt_Edit_BlockName.Size = new Size(212, 29);
            txt_Edit_BlockName.TabIndex = 8;
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
            btn_CreateBlock.TabIndex = 1;
            btn_CreateBlock.Text = "Create";
            btn_CreateBlock.UseVisualStyleBackColor = true;
            btn_CreateBlock.Click += btn_CreateBlock_Click;
            // 
            // nud_New_HighestFloor
            // 
            nud_New_HighestFloor.Location = new Point(124, 129);
            nud_New_HighestFloor.Name = "nud_New_HighestFloor";
            nud_New_HighestFloor.Size = new Size(98, 27);
            nud_New_HighestFloor.TabIndex = 7;
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
            nud_New_LowestFloor.TabIndex = 5;
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
            txt_New_BlockName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_New_BlockName.Location = new Point(10, 59);
            txt_New_BlockName.Name = "txt_New_BlockName";
            txt_New_BlockName.Size = new Size(212, 29);
            txt_New_BlockName.TabIndex = 1;
            // 
            // lst_Blocks
            // 
            lst_Blocks.Dock = DockStyle.Left;
            lst_Blocks.FormattingEnabled = true;
            lst_Blocks.Location = new Point(3, 3);
            lst_Blocks.Name = "lst_Blocks";
            lst_Blocks.Size = new Size(234, 493);
            lst_Blocks.TabIndex = 4;
            lst_Blocks.SelectedIndexChanged += lst_Blocks_SelectedIndexChanged;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 532);
            Controls.Add(tabControl1);
            Name = "frm_Main";
            Text = "Main";
            tabControl1.ResumeLayout(false);
            tbpg_Nodes.ResumeLayout(false);
            gbx_Node.ResumeLayout(false);
            gbx_Node.PerformLayout();
            gbx_Node_Connections.ResumeLayout(false);
            gbx_Node_Connections.PerformLayout();
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
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
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
        private GroupBox gbx_Node_Connections;
        private Label label6;
        private ComboBox cmbx_NodeDirection;
        private ListBox lstbx_AvailableNodes;
        private Button btn_Node_Delete;
        private Button btn_Node_Save;
        private Button btn_Node_Create;
        private TextBox txt_Node_Tags;
        private Label label7;
    }
}
