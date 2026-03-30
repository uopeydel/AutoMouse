namespace TrimVideoDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSelectFile = new Button();
            tbxSourceFilePath = new TextBox();
            label1 = new Label();
            btnDestinationSelect = new Button();
            label2 = new Label();
            tbxDestination = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            endSecond = new NumericUpDown();
            startSecond = new NumericUpDown();
            startMinute = new NumericUpDown();
            endMinute = new NumericUpDown();
            btnStartTrimVideo = new Button();
            ((System.ComponentModel.ISupportInitialize)endSecond).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startSecond).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startMinute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)endMinute).BeginInit();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(559, 28);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(212, 23);
            btnSelectFile.TabIndex = 0;
            btnSelectFile.Text = "Select video file to trim";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFileToTrim_Click;
            // 
            // tbxSourceFilePath
            // 
            tbxSourceFilePath.Location = new Point(79, 28);
            tbxSourceFilePath.Name = "tbxSourceFilePath";
            tbxSourceFilePath.Size = new Size(474, 23);
            tbxSourceFilePath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 33);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "Source";
            // 
            // btnDestinationSelect
            // 
            btnDestinationSelect.Location = new Point(559, 58);
            btnDestinationSelect.Name = "btnDestinationSelect";
            btnDestinationSelect.Size = new Size(212, 23);
            btnDestinationSelect.TabIndex = 3;
            btnDestinationSelect.Text = "Select destination path to save";
            btnDestinationSelect.UseVisualStyleBackColor = true;
            btnDestinationSelect.Click += btnDestinationSelect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 63);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 5;
            label2.Text = "Destination";
            // 
            // tbxDestination
            // 
            tbxDestination.Location = new Point(79, 61);
            tbxDestination.Name = "tbxDestination";
            tbxDestination.Size = new Size(474, 23);
            tbxDestination.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 118);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Start time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(170, 157);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 7;
            label4.Text = "End time";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 157);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 9;
            label5.Text = "Minute";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(380, 118);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 8;
            label6.Text = "Minute";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(557, 157);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 11;
            label7.Text = "Second";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(554, 118);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 10;
            label8.Text = "Second";
            // 
            // endSecond
            // 
            endSecond.Location = new Point(431, 155);
            endSecond.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            endSecond.Name = "endSecond";
            endSecond.Size = new Size(120, 23);
            endSecond.TabIndex = 12;
            // 
            // startSecond
            // 
            startSecond.Location = new Point(431, 116);
            startSecond.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            startSecond.Name = "startSecond";
            startSecond.Size = new Size(120, 23);
            startSecond.TabIndex = 13;
            // 
            // startMinute
            // 
            startMinute.Location = new Point(230, 116);
            startMinute.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            startMinute.Name = "startMinute";
            startMinute.Size = new Size(120, 23);
            startMinute.TabIndex = 15;
            // 
            // endMinute
            // 
            endMinute.Location = new Point(230, 155);
            endMinute.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            endMinute.Name = "endMinute";
            endMinute.Size = new Size(120, 23);
            endMinute.TabIndex = 14;
            // 
            // btnStartTrimVideo
            // 
            btnStartTrimVideo.Location = new Point(16, 208);
            btnStartTrimVideo.Name = "btnStartTrimVideo";
            btnStartTrimVideo.Size = new Size(755, 35);
            btnStartTrimVideo.TabIndex = 16;
            btnStartTrimVideo.Text = "Start Trim Video !";
            btnStartTrimVideo.UseVisualStyleBackColor = true;
            btnStartTrimVideo.Click += btnStartTrimVideo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 259);
            Controls.Add(btnStartTrimVideo);
            Controls.Add(startMinute);
            Controls.Add(endMinute);
            Controls.Add(startSecond);
            Controls.Add(endSecond);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbxDestination);
            Controls.Add(btnDestinationSelect);
            Controls.Add(label1);
            Controls.Add(tbxSourceFilePath);
            Controls.Add(btnSelectFile);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Fast video trim";
            ((System.ComponentModel.ISupportInitialize)endSecond).EndInit();
            ((System.ComponentModel.ISupportInitialize)startSecond).EndInit();
            ((System.ComponentModel.ISupportInitialize)startMinute).EndInit();
            ((System.ComponentModel.ISupportInitialize)endMinute).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFile;
        private TextBox tbxSourceFilePath;
        private Label label1;
        private Button btnDestinationSelect;
        private Label label2;
        private TextBox tbxDestination;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown endSecond;
        private NumericUpDown startSecond;
        private NumericUpDown startMinute;
        private NumericUpDown endMinute;
        private Button btnStartTrimVideo;
    }
}