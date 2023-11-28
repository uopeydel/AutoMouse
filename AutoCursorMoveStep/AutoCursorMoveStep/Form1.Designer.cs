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
            cbAllowNotRecheck = new DataGridViewCheckBoxColumn();
            txtSkipToStepIfImageNotFound = new DataGridViewTextBoxColumn();
            btnAddRow = new Button();
            btnStart = new Button();
            btnStop = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            lbLog = new ListBox();
            label2 = new Label();
            chkHookSpacePosition = new CheckBox();
            numRoundNumber = new NumericUpDown();
            nRowInsert = new NumericUpDown();
            cbSaveType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)gvAutoList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRoundNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nRowInsert).BeginInit();
            SuspendLayout();
            // 
            // gvAutoList
            // 
            gvAutoList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gvAutoList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvAutoList.Columns.AddRange(new DataGridViewColumn[] { imgPosition, txtTopLeftX, txtTopLeftY, txtBotRightX, txtBotRightY, txtInterval, chkActive, imgRecheck, btnFetchImageCheck, IsEqualFetch, btnCheckEqual, cbAllowNotRecheck, txtSkipToStepIfImageNotFound });
            gvAutoList.Location = new Point(20, 10);
            gvAutoList.Margin = new Padding(2);
            gvAutoList.Name = "gvAutoList";
            gvAutoList.RowHeadersWidth = 62;
            gvAutoList.RowTemplate.Height = 40;
            gvAutoList.RowTemplate.Resizable = DataGridViewTriState.True;
            gvAutoList.Size = new Size(835, 596);
            gvAutoList.TabIndex = 0;
            // 
            // imgPosition
            // 
            imgPosition.HeaderText = "Position";
            imgPosition.MinimumWidth = 8;
            imgPosition.Name = "imgPosition";
            imgPosition.Width = 130;
            // 
            // txtTopLeftX
            // 
            txtTopLeftX.HeaderText = "Top Left X";
            txtTopLeftX.MinimumWidth = 80;
            txtTopLeftX.Name = "txtTopLeftX";
            txtTopLeftX.Width = 80;
            // 
            // txtTopLeftY
            // 
            txtTopLeftY.HeaderText = "Top Left Y";
            txtTopLeftY.MinimumWidth = 80;
            txtTopLeftY.Name = "txtTopLeftY";
            txtTopLeftY.Width = 80;
            // 
            // txtBotRightX
            // 
            txtBotRightX.HeaderText = "Bot Right X";
            txtBotRightX.MinimumWidth = 80;
            txtBotRightX.Name = "txtBotRightX";
            txtBotRightX.Width = 80;
            // 
            // txtBotRightY
            // 
            txtBotRightY.HeaderText = "Bot Right Y";
            txtBotRightY.MinimumWidth = 80;
            txtBotRightY.Name = "txtBotRightY";
            txtBotRightY.Width = 80;
            // 
            // txtInterval
            // 
            txtInterval.HeaderText = "Interval (Sec)";
            txtInterval.MinimumWidth = 80;
            txtInterval.Name = "txtInterval";
            txtInterval.Width = 80;
            // 
            // chkActive
            // 
            chkActive.HeaderText = "Active";
            chkActive.MinimumWidth = 8;
            chkActive.Name = "chkActive";
            chkActive.Width = 40;
            // 
            // imgRecheck
            // 
            imgRecheck.HeaderText = "Image Re-Check";
            imgRecheck.Name = "imgRecheck";
            imgRecheck.Width = 130;
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
            // cbAllowNotRecheck
            // 
            cbAllowNotRecheck.HeaderText = "Allow Not Recheck";
            cbAllowNotRecheck.Name = "cbAllowNotRecheck";
            // 
            // txtSkipToStepIfImageNotFound
            // 
            txtSkipToStepIfImageNotFound.HeaderText = "Skip Step Not Found To";
            txtSkipToStepIfImageNotFound.Name = "txtSkipToStepIfImageNotFound";
            // 
            // btnAddRow
            // 
            btnAddRow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddRow.Location = new Point(20, 651);
            btnAddRow.Margin = new Padding(2);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(54, 25);
            btnAddRow.TabIndex = 1;
            btnAddRow.Text = "Add";
            btnAddRow.UseVisualStyleBackColor = true;
            btnAddRow.Click += btnAddRow_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.Location = new Point(285, 649);
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
            btnStop.Location = new Point(364, 651);
            btnStop.Margin = new Padding(2);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 25);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop (s)";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(618, 651);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(43, 25);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(667, 651);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(48, 25);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lbLog
            // 
            lbLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbLog.FormattingEnabled = true;
            lbLog.ItemHeight = 15;
            lbLog.Location = new Point(861, 0);
            lbLog.Name = "lbLog";
            lbLog.Size = new Size(239, 679);
            lbLog.TabIndex = 12;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.Location = new Point(144, 656);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 14;
            label2.Text = "Round Loop";
            // 
            // chkHookSpacePosition
            // 
            chkHookSpacePosition.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkHookSpacePosition.Location = new Point(444, 655);
            chkHookSpacePosition.Name = "chkHookSpacePosition";
            chkHookSpacePosition.Size = new Size(168, 19);
            chkHookSpacePosition.TabIndex = 15;
            chkHookSpacePosition.Text = "Hook Position By Spacebar";
            chkHookSpacePosition.UseVisualStyleBackColor = true;
            chkHookSpacePosition.MouseUp += chkHookSpacePosition_MouseUp;
            // 
            // numRoundNumber
            // 
            numRoundNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numRoundNumber.Location = new Point(222, 651);
            numRoundNumber.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numRoundNumber.Name = "numRoundNumber";
            numRoundNumber.Size = new Size(49, 23);
            numRoundNumber.TabIndex = 16;
            numRoundNumber.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // nRowInsert
            // 
            nRowInsert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nRowInsert.Location = new Point(79, 652);
            nRowInsert.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nRowInsert.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nRowInsert.Name = "nRowInsert";
            nRowInsert.Size = new Size(49, 23);
            nRowInsert.TabIndex = 17;
            nRowInsert.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // cbSaveType
            // 
            cbSaveType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbSaveType.FormattingEnabled = true;
            cbSaveType.Items.AddRange(new object[] { "sqllite sandbox 1", "sqllite sandbox 2", "json sandbox 1", "json sandbox 2" });
            cbSaveType.Location = new Point(721, 653);
            cbSaveType.Name = "cbSaveType";
            cbSaveType.Size = new Size(134, 23);
            cbSaveType.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 692);
            Controls.Add(cbSaveType);
            Controls.Add(nRowInsert);
            Controls.Add(numRoundNumber);
            Controls.Add(chkHookSpacePosition);
            Controls.Add(label2);
            Controls.Add(lbLog);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(btnAddRow);
            Controls.Add(gvAutoList);
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Auto cursor move step";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gvAutoList).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRoundNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nRowInsert).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gvAutoList;
        private Button btnAddRow;
        private Button btnStart;
        private Button btnStop;
        private Button btnSave;
        private Button btnLoad;
        private Label label2;
        public ListBox lbLog;
        private CheckBox chkHookSpacePosition;
        private NumericUpDown numRoundNumber;
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
        private DataGridViewCheckBoxColumn cbAllowNotRecheck;
        private DataGridViewTextBoxColumn txtSkipToStepIfImageNotFound;
        private NumericUpDown nRowInsert;
        private ComboBox cbSaveType;
    }
}