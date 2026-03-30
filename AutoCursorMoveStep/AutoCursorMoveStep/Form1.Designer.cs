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
			label1 = new Label();
			pictureBox1 = new PictureBox();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			toplx1 = new NumericUpDown();
			toply1 = new NumericUpDown();
			botry1 = new NumericUpDown();
			botrx1 = new NumericUpDown();
			botry2 = new NumericUpDown();
			botrx2 = new NumericUpDown();
			toply2 = new NumericUpDown();
			toplx2 = new NumericUpDown();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			pictureBox2 = new PictureBox();
			label11 = new Label();
			label12 = new Label();
			stepFource1 = new NumericUpDown();
			stepFoure2 = new NumericUpDown();
			label13 = new Label();
			((System.ComponentModel.ISupportInitialize)gvAutoList).BeginInit();
			((System.ComponentModel.ISupportInitialize)numRoundNumber).BeginInit();
			((System.ComponentModel.ISupportInitialize)nRowInsert).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)toplx1).BeginInit();
			((System.ComponentModel.ISupportInitialize)toply1).BeginInit();
			((System.ComponentModel.ISupportInitialize)botry1).BeginInit();
			((System.ComponentModel.ISupportInitialize)botrx1).BeginInit();
			((System.ComponentModel.ISupportInitialize)botry2).BeginInit();
			((System.ComponentModel.ISupportInitialize)botrx2).BeginInit();
			((System.ComponentModel.ISupportInitialize)toply2).BeginInit();
			((System.ComponentModel.ISupportInitialize)toplx2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)stepFource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)stepFoure2).BeginInit();
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
			gvAutoList.Size = new Size(932, 650);
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
			btnAddRow.Location = new Point(20, 752);
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
			btnStart.Location = new Point(285, 750);
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
			btnStop.Location = new Point(364, 752);
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
			btnSave.Location = new Point(618, 752);
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
			btnLoad.Location = new Point(667, 752);
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
			lbLog.Location = new Point(957, 0);
			lbLog.Name = "lbLog";
			lbLog.Size = new Size(261, 769);
			lbLog.TabIndex = 12;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label2.Location = new Point(144, 757);
			label2.Name = "label2";
			label2.Size = new Size(72, 15);
			label2.TabIndex = 14;
			label2.Text = "Round Loop";
			// 
			// chkHookSpacePosition
			// 
			chkHookSpacePosition.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			chkHookSpacePosition.Location = new Point(444, 756);
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
			numRoundNumber.Location = new Point(222, 752);
			numRoundNumber.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
			numRoundNumber.Name = "numRoundNumber";
			numRoundNumber.Size = new Size(49, 23);
			numRoundNumber.TabIndex = 16;
			numRoundNumber.Value = new decimal(new int[] { 500, 0, 0, 0 });
			// 
			// nRowInsert
			// 
			nRowInsert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			nRowInsert.Location = new Point(79, 753);
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
			cbSaveType.Location = new Point(721, 754);
			cbSaveType.Name = "cbSaveType";
			cbSaveType.Size = new Size(134, 23);
			cbSaveType.TabIndex = 18;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(20, 662);
			label1.Name = "label1";
			label1.Size = new Size(146, 15);
			label1.TabIndex = 19;
			label1.Text = "Fource Change Step While";
			label1.Click += label1_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(20, 680);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(146, 50);
			pictureBox1.TabIndex = 20;
			pictureBox1.TabStop = false;
			pictureBox1.Click += pictureBox1_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(172, 680);
			label3.Name = "label3";
			label3.Size = new Size(57, 15);
			label3.TabIndex = 21;
			label3.Text = "TopLeft X";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(235, 680);
			label4.Name = "label4";
			label4.Size = new Size(57, 15);
			label4.TabIndex = 22;
			label4.Text = "TopLeft Y";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(303, 680);
			label5.Name = "label5";
			label5.Size = new Size(63, 15);
			label5.TabIndex = 23;
			label5.Text = "BotRight X";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(372, 680);
			label6.Name = "label6";
			label6.Size = new Size(63, 15);
			label6.TabIndex = 24;
			label6.Text = "BotRight Y";
			// 
			// toplx1
			// 
			toplx1.Location = new Point(172, 707);
			toplx1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			toplx1.Name = "toplx1";
			toplx1.Size = new Size(57, 23);
			toplx1.TabIndex = 26;
			toplx1.Value = new decimal(new int[] { 240, 0, 0, 0 });
			// 
			// toply1
			// 
			toply1.Location = new Point(235, 707);
			toply1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			toply1.Name = "toply1";
			toply1.Size = new Size(57, 23);
			toply1.TabIndex = 27;
			toply1.Value = new decimal(new int[] { 450, 0, 0, 0 });
			// 
			// botry1
			// 
			botry1.Location = new Point(366, 707);
			botry1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			botry1.Name = "botry1";
			botry1.Size = new Size(57, 23);
			botry1.TabIndex = 29;
			botry1.Value = new decimal(new int[] { 470, 0, 0, 0 });
			// 
			// botrx1
			// 
			botrx1.Location = new Point(303, 707);
			botrx1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			botrx1.Name = "botrx1";
			botrx1.Size = new Size(57, 23);
			botrx1.TabIndex = 28;
			botrx1.Value = new decimal(new int[] { 360, 0, 0, 0 });
			// 
			// botry2
			// 
			botry2.Location = new Point(826, 707);
			botry2.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			botry2.Name = "botry2";
			botry2.Size = new Size(57, 23);
			botry2.TabIndex = 38;
			botry2.Value = new decimal(new int[] { 680, 0, 0, 0 });
			// 
			// botrx2
			// 
			botrx2.Location = new Point(763, 707);
			botrx2.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			botrx2.Name = "botrx2";
			botrx2.Size = new Size(57, 23);
			botrx2.TabIndex = 37;
			botrx2.Value = new decimal(new int[] { 360, 0, 0, 0 });
			// 
			// toply2
			// 
			toply2.Location = new Point(695, 707);
			toply2.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			toply2.Name = "toply2";
			toply2.Size = new Size(57, 23);
			toply2.TabIndex = 36;
			toply2.Value = new decimal(new int[] { 660, 0, 0, 0 });
			// 
			// toplx2
			// 
			toplx2.Location = new Point(632, 707);
			toplx2.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
			toplx2.Name = "toplx2";
			toplx2.Size = new Size(57, 23);
			toplx2.TabIndex = 35;
			toplx2.Value = new decimal(new int[] { 240, 0, 0, 0 });
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(826, 680);
			label7.Name = "label7";
			label7.Size = new Size(63, 15);
			label7.TabIndex = 34;
			label7.Text = "BotRight Y";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(757, 680);
			label8.Name = "label8";
			label8.Size = new Size(63, 15);
			label8.TabIndex = 33;
			label8.Text = "BotRight X";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(695, 680);
			label9.Name = "label9";
			label9.Size = new Size(57, 15);
			label9.TabIndex = 32;
			label9.Text = "TopLeft Y";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(632, 680);
			label10.Name = "label10";
			label10.Size = new Size(57, 15);
			label10.TabIndex = 31;
			label10.Text = "TopLeft X";
			// 
			// pictureBox2
			// 
			pictureBox2.Location = new Point(480, 680);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(146, 50);
			pictureBox2.TabIndex = 30;
			pictureBox2.TabStop = false;
			pictureBox2.Click += pictureBox2_Click;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(480, 662);
			label11.Name = "label11";
			label11.Size = new Size(146, 15);
			label11.TabIndex = 39;
			label11.Text = "Fource Change Step While";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(441, 680);
			label12.Name = "label12";
			label12.Size = new Size(30, 15);
			label12.TabIndex = 40;
			label12.Text = "Step";
			// 
			// stepFource1
			// 
			stepFource1.Location = new Point(429, 707);
			stepFource1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
			stepFource1.Name = "stepFource1";
			stepFource1.Size = new Size(45, 23);
			stepFource1.TabIndex = 41;
			// 
			// stepFoure2
			// 
			stepFoure2.Location = new Point(898, 707);
			stepFoure2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
			stepFoure2.Name = "stepFoure2";
			stepFoure2.Size = new Size(45, 23);
			stepFoure2.TabIndex = 43;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(910, 680);
			label13.Name = "label13";
			label13.Size = new Size(30, 15);
			label13.TabIndex = 42;
			label13.Text = "Step";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1218, 793);
			Controls.Add(stepFoure2);
			Controls.Add(label13);
			Controls.Add(stepFource1);
			Controls.Add(label12);
			Controls.Add(label11);
			Controls.Add(botry2);
			Controls.Add(botrx2);
			Controls.Add(toply2);
			Controls.Add(toplx2);
			Controls.Add(label7);
			Controls.Add(label8);
			Controls.Add(label9);
			Controls.Add(label10);
			Controls.Add(pictureBox2);
			Controls.Add(botry1);
			Controls.Add(botrx1);
			Controls.Add(toply1);
			Controls.Add(toplx1);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(pictureBox1);
			Controls.Add(label1);
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
			TopMost = true;
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)gvAutoList).EndInit();
			((System.ComponentModel.ISupportInitialize)numRoundNumber).EndInit();
			((System.ComponentModel.ISupportInitialize)nRowInsert).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)toplx1).EndInit();
			((System.ComponentModel.ISupportInitialize)toply1).EndInit();
			((System.ComponentModel.ISupportInitialize)botry1).EndInit();
			((System.ComponentModel.ISupportInitialize)botrx1).EndInit();
			((System.ComponentModel.ISupportInitialize)botry2).EndInit();
			((System.ComponentModel.ISupportInitialize)botrx2).EndInit();
			((System.ComponentModel.ISupportInitialize)toply2).EndInit();
			((System.ComponentModel.ISupportInitialize)toplx2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)stepFource1).EndInit();
			((System.ComponentModel.ISupportInitialize)stepFoure2).EndInit();
			ResumeLayout(false);
			PerformLayout();
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
		private Label label1;
		private PictureBox pictureBox1;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private NumericUpDown toplx1;
		private NumericUpDown toply1;
		private NumericUpDown botry1;
		private NumericUpDown botrx1;
		private NumericUpDown botry2;
		private NumericUpDown botrx2;
		private NumericUpDown toply2;
		private NumericUpDown toplx2;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private PictureBox pictureBox2;
		private Label label11;
		private Label label12;
		private NumericUpDown stepFource1;
		private NumericUpDown stepFoure2;
		private Label label13;
	}
}