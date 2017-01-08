namespace MIPS_ScoreBoard
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader Header_Instruction;
            System.Windows.Forms.ColumnHeader Header_i;
            System.Windows.Forms.ColumnHeader Header_j;
            System.Windows.Forms.ColumnHeader Header_k;
            System.Windows.Forms.ColumnHeader Header_Issue;
            System.Windows.Forms.ColumnHeader Header_ReadOperand;
            System.Windows.Forms.ColumnHeader Header_ExecutionComplete;
            System.Windows.Forms.ColumnHeader Header_WriteResult;
            System.Windows.Forms.ColumnHeader Header_Busy;
            System.Windows.Forms.ColumnHeader Header_Op;
            System.Windows.Forms.ColumnHeader Header_Fi;
            System.Windows.Forms.ColumnHeader Header_Fj;
            System.Windows.Forms.ColumnHeader Header_Fk;
            System.Windows.Forms.ColumnHeader Header_Time;
            System.Windows.Forms.ColumnHeader Header_Name;
            System.Windows.Forms.ColumnHeader Header_Qj;
            System.Windows.Forms.ColumnHeader Header_Qk;
            System.Windows.Forms.ColumnHeader Header_Rj;
            System.Windows.Forms.ColumnHeader Header_Rk;
            System.Windows.Forms.ColumnHeader Header_Line;
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("已執行完成", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("執行中", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup21 = new System.Windows.Forms.ListViewGroup("等待隊列中", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem31 = new System.Windows.Forms.ListViewItem("Integer");
            System.Windows.Forms.ListViewItem listViewItem32 = new System.Windows.Forms.ListViewItem("Mult1");
            System.Windows.Forms.ListViewItem listViewItem33 = new System.Windows.Forms.ListViewItem("Mult2");
            System.Windows.Forms.ListViewItem listViewItem34 = new System.Windows.Forms.ListViewItem("Add");
            System.Windows.Forms.ListViewItem listViewItem35 = new System.Windows.Forms.ListViewItem("Divide");
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.InstructionStatus = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button_last = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.skipbox = new System.Windows.Forms.CheckBox();
            this.button_first = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.stepnow = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FunctionalUnitStatus = new System.Windows.Forms.ListView();
            this.RegisterResultStatus = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            Header_Instruction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_i = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_j = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_k = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Issue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_ReadOperand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_ExecutionComplete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_WriteResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Busy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Op = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Fi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Fj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Fk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Qj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Qk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Rj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Rk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Header_Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepnow)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header_Instruction
            // 
            Header_Instruction.Text = "Instruction";
            Header_Instruction.Width = 63;
            // 
            // Header_i
            // 
            Header_i.Text = "i";
            Header_i.Width = 40;
            // 
            // Header_j
            // 
            Header_j.Text = "j";
            Header_j.Width = 34;
            // 
            // Header_k
            // 
            Header_k.Text = "k";
            Header_k.Width = 36;
            // 
            // Header_Issue
            // 
            Header_Issue.Text = "Issue";
            // 
            // Header_ReadOperand
            // 
            Header_ReadOperand.Text = "ReadOperand";
            Header_ReadOperand.Width = 91;
            // 
            // Header_ExecutionComplete
            // 
            Header_ExecutionComplete.Text = "ExecutionComplete";
            Header_ExecutionComplete.Width = 118;
            // 
            // Header_WriteResult
            // 
            Header_WriteResult.Text = "WriteResult";
            Header_WriteResult.Width = 106;
            // 
            // Header_Busy
            // 
            Header_Busy.Text = "Busy";
            Header_Busy.Width = 40;
            // 
            // Header_Op
            // 
            Header_Op.Text = "Op";
            Header_Op.Width = 50;
            // 
            // Header_Fi
            // 
            Header_Fi.Text = "Fi(Dest)";
            Header_Fi.Width = 50;
            // 
            // Header_Fj
            // 
            Header_Fj.Text = "Fj(S1)";
            Header_Fj.Width = 50;
            // 
            // Header_Fk
            // 
            Header_Fk.Text = "Fk(S2)";
            Header_Fk.Width = 50;
            // 
            // Header_Time
            // 
            Header_Time.Text = "Time";
            Header_Time.Width = 40;
            // 
            // Header_Name
            // 
            Header_Name.Text = "Name";
            Header_Name.Width = 70;
            // 
            // Header_Qj
            // 
            Header_Qj.Text = "Qj(FU for j)";
            Header_Qj.Width = 80;
            // 
            // Header_Qk
            // 
            Header_Qk.Text = "Qk(FU for k)";
            Header_Qk.Width = 80;
            // 
            // Header_Rj
            // 
            Header_Rj.Text = "Rj(Fj?)";
            // 
            // Header_Rk
            // 
            Header_Rk.Text = "Rk(Fk?)";
            // 
            // Header_Line
            // 
            Header_Line.Text = "Line";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "input.txt";
            this.openFileDialog.Filter = "文字檔|*.txt";
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "開啟Intput檔";
            // 
            // InstructionStatus
            // 
            this.InstructionStatus.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.InstructionStatus.BackColor = System.Drawing.SystemColors.Window;
            this.InstructionStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Header_Line,
            Header_Instruction,
            Header_i,
            Header_j,
            Header_k,
            Header_Issue,
            Header_ReadOperand,
            Header_ExecutionComplete,
            Header_WriteResult});
            this.InstructionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstructionStatus.FullRowSelect = true;
            this.InstructionStatus.GridLines = true;
            listViewGroup19.Header = "已執行完成";
            listViewGroup19.Name = "Group_Complete";
            listViewGroup20.Header = "執行中";
            listViewGroup20.Name = "Group_CPU";
            listViewGroup21.Header = "等待隊列中";
            listViewGroup21.Name = "Group_Queue";
            this.InstructionStatus.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup19,
            listViewGroup20,
            listViewGroup21});
            this.InstructionStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.InstructionStatus.Location = new System.Drawing.Point(0, 0);
            this.InstructionStatus.MultiSelect = false;
            this.InstructionStatus.Name = "InstructionStatus";
            this.InstructionStatus.Size = new System.Drawing.Size(897, 266);
            this.InstructionStatus.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.InstructionStatus.TabIndex = 1;
            this.InstructionStatus.TabStop = false;
            this.InstructionStatus.UseCompatibleStateImageBehavior = false;
            this.InstructionStatus.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InstructionStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 266);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(635, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button_last);
            this.panel5.Controls.Add(this.button_next);
            this.panel5.Controls.Add(this.button_back);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 48);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(256, 33);
            this.panel5.TabIndex = 2;
            // 
            // button_last
            // 
            this.button_last.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_last.Location = new System.Drawing.Point(145, 5);
            this.button_last.Name = "button_last";
            this.button_last.Size = new System.Drawing.Size(106, 23);
            this.button_last.TabIndex = 12;
            this.button_last.Text = "顯示結果";
            this.button_last.UseVisualStyleBackColor = true;
            this.button_last.Click += new System.EventHandler(this.button_last_Click);
            // 
            // button_next
            // 
            this.button_next.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_next.Location = new System.Drawing.Point(75, 5);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(70, 23);
            this.button_next.TabIndex = 11;
            this.button_next.Text = "下一步";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_back
            // 
            this.button_back.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_back.Location = new System.Drawing.Point(5, 5);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(70, 23);
            this.button_back.TabIndex = 10;
            this.button_back.Text = "上一步";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.skipbox);
            this.panel4.Controls.Add(this.button_first);
            this.panel4.Controls.Add(this.button_open);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 18);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(256, 30);
            this.panel4.TabIndex = 14;
            // 
            // skipbox
            // 
            this.skipbox.AutoSize = true;
            this.skipbox.Checked = true;
            this.skipbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skipbox.Location = new System.Drawing.Point(167, 8);
            this.skipbox.Name = "skipbox";
            this.skipbox.Size = new System.Drawing.Size(84, 16);
            this.skipbox.TabIndex = 14;
            this.skipbox.Text = "跳過空回合";
            this.skipbox.UseVisualStyleBackColor = true;
            // 
            // button_first
            // 
            this.button_first.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_first.Location = new System.Drawing.Point(75, 5);
            this.button_first.Name = "button_first";
            this.button_first.Size = new System.Drawing.Size(86, 20);
            this.button_first.TabIndex = 13;
            this.button_first.Text = "回到第一步";
            this.button_first.UseVisualStyleBackColor = true;
            this.button_first.Click += new System.EventHandler(this.button_first_Click);
            // 
            // button_open
            // 
            this.button_open.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_open.Location = new System.Drawing.Point(5, 5);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(70, 20);
            this.button_open.TabIndex = 1;
            this.button_open.Text = "開啟檔案";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.stepnow);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 25);
            this.panel3.TabIndex = 9;
            // 
            // stepnow
            // 
            this.stepnow.AutoSize = true;
            this.stepnow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepnow.Location = new System.Drawing.Point(38, 0);
            this.stepnow.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.stepnow.Name = "stepnow";
            this.stepnow.Size = new System.Drawing.Size(176, 22);
            this.stepnow.TabIndex = 7;
            this.stepnow.TabStop = false;
            this.stepnow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stepnow.ValueChanged += new System.EventHandler(this.stepnow_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(214, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "/9487";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(38, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Step:";
            // 
            // FunctionalUnitStatus
            // 
            this.FunctionalUnitStatus.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.FunctionalUnitStatus.BackColor = System.Drawing.SystemColors.Window;
            this.FunctionalUnitStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Header_Name,
            Header_Time,
            Header_Busy,
            Header_Op,
            Header_Fi,
            Header_Fj,
            Header_Fk,
            Header_Qj,
            Header_Qk,
            Header_Rj,
            Header_Rk});
            this.FunctionalUnitStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.FunctionalUnitStatus.FullRowSelect = true;
            this.FunctionalUnitStatus.GridLines = true;
            this.FunctionalUnitStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem31.UseItemStyleForSubItems = false;
            listViewItem32.UseItemStyleForSubItems = false;
            listViewItem33.UseItemStyleForSubItems = false;
            listViewItem34.UseItemStyleForSubItems = false;
            listViewItem35.UseItemStyleForSubItems = false;
            this.FunctionalUnitStatus.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem31,
            listViewItem32,
            listViewItem33,
            listViewItem34,
            listViewItem35});
            this.FunctionalUnitStatus.LabelWrap = false;
            this.FunctionalUnitStatus.Location = new System.Drawing.Point(0, 0);
            this.FunctionalUnitStatus.MultiSelect = false;
            this.FunctionalUnitStatus.Name = "FunctionalUnitStatus";
            this.FunctionalUnitStatus.ShowGroups = false;
            this.FunctionalUnitStatus.Size = new System.Drawing.Size(635, 109);
            this.FunctionalUnitStatus.TabIndex = 5;
            this.FunctionalUnitStatus.TabStop = false;
            this.FunctionalUnitStatus.UseCompatibleStateImageBehavior = false;
            this.FunctionalUnitStatus.View = System.Windows.Forms.View.Details;
            // 
            // RegisterResultStatus
            // 
            this.RegisterResultStatus.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.RegisterResultStatus.BackColor = System.Drawing.SystemColors.Window;
            this.RegisterResultStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RegisterResultStatus.FullRowSelect = true;
            this.RegisterResultStatus.GridLines = true;
            this.RegisterResultStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.RegisterResultStatus.Location = new System.Drawing.Point(0, 375);
            this.RegisterResultStatus.MultiSelect = false;
            this.RegisterResultStatus.Name = "RegisterResultStatus";
            this.RegisterResultStatus.ShowGroups = false;
            this.RegisterResultStatus.Size = new System.Drawing.Size(897, 43);
            this.RegisterResultStatus.TabIndex = 6;
            this.RegisterResultStatus.TabStop = false;
            this.RegisterResultStatus.UseCompatibleStateImageBehavior = false;
            this.RegisterResultStatus.View = System.Windows.Forms.View.Details;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.FunctionalUnitStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 109);
            this.panel2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(897, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.RegisterResultStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "ScoreBoard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepnow)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView InstructionStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView FunctionalUnitStatus;
        private System.Windows.Forms.ListView RegisterResultStatus;
        private System.Windows.Forms.NumericUpDown stepnow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_first;
        private System.Windows.Forms.Button button_last;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox skipbox;
    }
}

