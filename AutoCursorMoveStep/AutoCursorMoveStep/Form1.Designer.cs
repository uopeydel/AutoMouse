namespace AutoCursorMoveStep
{
    partial class Form1
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
            gvAutoList = new DataGridView();
            imgPosition = new DataGridViewImageColumn();
            txtTopLeftX = new DataGridViewTextBoxColumn();
            txtTopLeftY = new DataGridViewTextBoxColumn();
            txtBotRightX = new DataGridViewTextBoxColumn();
            txtBotRightY = new DataGridViewTextBoxColumn();
            txtInterval = new DataGridViewTextBoxColumn();
            chkActive = new DataGridViewCheckBoxColumn();
            imgRecheck = new DataGridViewImageColumn();
            btnFetchImageCheck = new DataGridViewButtonColumn();
            IsEqualFetch = new DataGridViewTextBoxColumn();
            btnCheckEqual = new DataGridViewButtonColumn();
            btnAddRow = new Button();
            btnStart = new Button();
            btnStop = new Button();
            btnFetchImageManual = new Button();
            label1 = new Label();
            lbStatusValue = new Label();
            lbStepValue = new Label();
            label3 = new Label();
            btnSave = new Button();
            btnLoad = new Button();
            btnTruncate = new Button();
            lbLog = new ListBox();
            txtRoundNumber = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)gvAutoList).BeginInit();
            SuspendLayout();
            // 
            // gvAutoList
            // 
            gvAutoList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gvAutoList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvAutoList.Columns.AddRange(new DataGridViewColumn[] { imgPosition, txtTopLeftX, txtTopLeftY, txtBotRightX, txtBotRightY, txtInterval, chkActive, imgRecheck, btnFetchImageCheck, IsEqualFetch, btnCheckEqual });
            gvAutoList.Location = new Point(20, 10);
            gvAutoList.Margin = new Padding(2);
            gvAutoList.Name = "gvAutoList";
            gvAutoList.RowHeadersWidth = 62;
            gvAutoList.RowTemplate.Height = 100;
            gvAutoList.Size = new Size(1157, 587);
            gvAutoList.TabIndex = 0;
            // 
            // imgPosition
            // 
            imgPosition.HeaderText = "Position";
            imgPosition.MinimumWidth = 8;
            imgPosition.Name = "imgPosition";
            imgPosition.Width = 150;
            // 
            // txtTopLeftX
            // 
            txtTopLeftX.HeaderText = "Top Left X";
            txtTopLeftX.MinimumWidth = 100;
            txtTopLeftX.Name = "txtTopLeftX";
            // 
            // txtTopLeftY
            // 
            txtTopLeftY.HeaderText = "Top Left Y";
            txtTopLeftY.MinimumWidth = 100;
            txtTopLeftY.Name = "txtTopLeftY";
            // 
            // txtBotRightX
            // 
            txtBotRightX.HeaderText = "Bot Right X";
            txtBotRightX.MinimumWidth = 100;
            txtBotRightX.Name = "txtBotRightX";
            // 
            // txtBotRightY
            // 
            txtBotRightY.HeaderText = "Bot Right Y";
            txtBotRightY.MinimumWidth = 100;
            txtBotRightY.Name = "txtBotRightY";
            // 
            // txtInterval
            // 
            txtInterval.HeaderText = "Interval (Sec)";
            txtInterval.MinimumWidth = 100;
            txtInterval.Name = "txtInterval";
            // 
            // chkActive
            // 
            chkActive.HeaderText = "Active";
            chkActive.MinimumWidth = 8;
            chkActive.Name = "chkActive";
            chkActive.Width = 50;
            // 
            // imgRecheck
            // 
            imgRecheck.HeaderText = "Image Re-Check";
            imgRecheck.Name = "imgRecheck";
            imgRecheck.Width = 150;
            // 
            // btnFetchImageCheck
            // 
            btnFetchImageCheck.HeaderText = "Fetch Image";
            btnFetchImageCheck.Name = "btnFetchImageCheck";
            btnFetchImageCheck.Width = 70;
            // 
            // IsEqualFetch
            // 
            IsEqualFetch.HeaderText = "Equal";
            IsEqualFetch.Name = "IsEqualFetch";
            // 
            // btnCheckEqual
            // 
            btnCheckEqual.HeaderText = "Check Equal";
            btnCheckEqual.Name = "btnCheckEqual";
            btnCheckEqual.Width = 70;
            // 
            // btnAddRow
            // 
            btnAddRow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddRow.Location = new Point(11, 622);
            btnAddRow.Margin = new Padding(2);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(75, 25);
            btnAddRow.TabIndex = 1;
            btnAddRow.Text = "Add Row";
            btnAddRow.UseVisualStyleBackColor = true;
            btnAddRow.Click += btnAddRow_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.Location = new Point(323, 620);
            btnStart.Margin = new Padding(2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 25);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStop.Location = new Point(421, 620);
            btnStop.Margin = new Padding(2);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 25);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop (s)";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnFetchImageManual
            // 
            btnFetchImageManual.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFetchImageManual.Location = new Point(523, 618);
            btnFetchImageManual.Margin = new Padding(2);
            btnFetchImageManual.Name = "btnFetchImageManual";
            btnFetchImageManual.Size = new Size(75, 25);
            btnFetchImageManual.TabIndex = 4;
            btnFetchImageManual.Text = "Fetch Image Manual";
            btnFetchImageManual.UseVisualStyleBackColor = true;
            btnFetchImageManual.Click += btnFetchImageManual_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(655, 622);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Status";
            // 
            // lbStatusValue
            // 
            lbStatusValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbStatusValue.AutoSize = true;
            lbStatusValue.Location = new Point(726, 622);
            lbStatusValue.Name = "lbStatusValue";
            lbStatusValue.Size = new Size(39, 15);
            lbStatusValue.TabIndex = 6;
            lbStatusValue.Text = "Status";
            // 
            // lbStepValue
            // 
            lbStepValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbStepValue.AutoSize = true;
            lbStepValue.Location = new Point(844, 622);
            lbStepValue.Name = "lbStepValue";
            lbStepValue.Size = new Size(58, 15);
            lbStepValue.TabIndex = 8;
            lbStepValue.Text = "StepValue";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(788, 622);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 7;
            label3.Text = "Step";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(955, 620);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 25);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(1036, 618);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 25);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnTruncate
            // 
            btnTruncate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTruncate.Location = new Point(1117, 618);
            btnTruncate.Name = "btnTruncate";
            btnTruncate.Size = new Size(75, 25);
            btnTruncate.TabIndex = 11;
            btnTruncate.Text = "Clear";
            btnTruncate.UseVisualStyleBackColor = true;
            btnTruncate.Click += btnTruncate_Click;
            // 
            // lbLog
            // 
            lbLog.Dock = DockStyle.Right;
            lbLog.FormattingEnabled = true;
            lbLog.ItemHeight = 15;
            lbLog.Location = new Point(1198, 0);
            lbLog.Name = "lbLog";
            lbLog.Size = new Size(347, 651);
            lbLog.TabIndex = 12;
            // 
            // txtRoundNumber
            // 
            txtRoundNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRoundNumber.Location = new Point(208, 624);
            txtRoundNumber.Name = "txtRoundNumber";
            txtRoundNumber.Size = new Size(100, 23);
            txtRoundNumber.TabIndex = 13;
            txtRoundNumber.Text = "3";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(114, 627);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 14;
            label2.Text = "Round Loop";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1545, 651);
            Controls.Add(label2);
            Controls.Add(txtRoundNumber);
            Controls.Add(lbLog);
            Controls.Add(btnTruncate);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(lbStepValue);
            Controls.Add(label3);
            Controls.Add(lbStatusValue);
            Controls.Add(label1);
            Controls.Add(btnFetchImageManual);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(btnAddRow);
            Controls.Add(gvAutoList);
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Auto cursor move step";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)gvAutoList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvAutoList;
        private Button btnAddRow;
        private Button btnStart;
        private Button btnStop;
        private Button btnFetchImageManual;
        private Label label1;
        private Label lbStatusValue;
        private Label lbStepValue;
        private Label label3;
        private Button btnSave;
        private Button btnLoad;
        private Button btnTruncate;
        private DataGridViewImageColumn imgPosition;
        private DataGridViewTextBoxColumn txtTopLeftX;
        private DataGridViewTextBoxColumn txtTopLeftY;
        private DataGridViewTextBoxColumn txtBotRightX;
        private DataGridViewTextBoxColumn txtBotRightY;
        private DataGridViewTextBoxColumn txtInterval;
        private DataGridViewCheckBoxColumn chkActive;
        private DataGridViewImageColumn imgRecheck;
        private DataGridViewButtonColumn btnFetchImageCheck;
        private DataGridViewTextBoxColumn IsEqualFetch;
        private DataGridViewButtonColumn btnCheckEqual;
        private TextBox txtRoundNumber;
        private Label label2;
        public ListBox lbLog;
    }
}