namespace FastTrimVideoOnWindows
{
    partial class FastVideoTrim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastVideoTrim));
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbxSourceFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDestinationSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDestination = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.endSecond = new System.Windows.Forms.NumericUpDown();
            this.startSecond = new System.Windows.Forms.NumericUpDown();
            this.startMinute = new System.Windows.Forms.NumericUpDown();
            this.endMinute = new System.Windows.Forms.NumericUpDown();
            this.btnStartTrimVideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.endSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(559, 28);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(212, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select video file to trim";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFileToTrim_Click);
            // 
            // tbxSourceFilePath
            // 
            this.tbxSourceFilePath.Location = new System.Drawing.Point(79, 28);
            this.tbxSourceFilePath.Name = "tbxSourceFilePath";
            this.tbxSourceFilePath.Size = new System.Drawing.Size(474, 20);
            this.tbxSourceFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source";
            // 
            // btnDestinationSelect
            // 
            this.btnDestinationSelect.Location = new System.Drawing.Point(559, 58);
            this.btnDestinationSelect.Name = "btnDestinationSelect";
            this.btnDestinationSelect.Size = new System.Drawing.Size(212, 23);
            this.btnDestinationSelect.TabIndex = 3;
            this.btnDestinationSelect.Text = "Select destination path to save";
            this.btnDestinationSelect.UseVisualStyleBackColor = true;
            this.btnDestinationSelect.Click += new System.EventHandler(this.btnDestinationSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination";
            // 
            // tbxDestination
            // 
            this.tbxDestination.Location = new System.Drawing.Point(79, 61);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.Size = new System.Drawing.Size(474, 20);
            this.tbxDestination.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "End time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Minute";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Minute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(557, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Second";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(554, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Second";
            // 
            // endSecond
            // 
            this.endSecond.Location = new System.Drawing.Point(431, 155);
            this.endSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.endSecond.Name = "endSecond";
            this.endSecond.Size = new System.Drawing.Size(120, 20);
            this.endSecond.TabIndex = 12;
            // 
            // startSecond
            // 
            this.startSecond.Location = new System.Drawing.Point(431, 116);
            this.startSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startSecond.Name = "startSecond";
            this.startSecond.Size = new System.Drawing.Size(120, 20);
            this.startSecond.TabIndex = 13;
            // 
            // startMinute
            // 
            this.startMinute.Location = new System.Drawing.Point(230, 116);
            this.startMinute.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.startMinute.Name = "startMinute";
            this.startMinute.Size = new System.Drawing.Size(120, 20);
            this.startMinute.TabIndex = 15;
            // 
            // endMinute
            // 
            this.endMinute.Location = new System.Drawing.Point(230, 155);
            this.endMinute.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.endMinute.Name = "endMinute";
            this.endMinute.Size = new System.Drawing.Size(120, 20);
            this.endMinute.TabIndex = 14;
            // 
            // btnStartTrimVideo
            // 
            this.btnStartTrimVideo.Location = new System.Drawing.Point(16, 208);
            this.btnStartTrimVideo.Name = "btnStartTrimVideo";
            this.btnStartTrimVideo.Size = new System.Drawing.Size(755, 35);
            this.btnStartTrimVideo.TabIndex = 16;
            this.btnStartTrimVideo.Text = "Start Trim Video !";
            this.btnStartTrimVideo.UseVisualStyleBackColor = true;
            this.btnStartTrimVideo.Click += new System.EventHandler(this.btnStartTrimVideo_Click);
            // 
            // FastVideoTrim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 259);
            this.Controls.Add(this.btnStartTrimVideo);
            this.Controls.Add(this.startMinute);
            this.Controls.Add(this.endMinute);
            this.Controls.Add(this.startSecond);
            this.Controls.Add(this.endSecond);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDestination);
            this.Controls.Add(this.btnDestinationSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSourceFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FastVideoTrim";
            this.Text = "Fast video trim";
            ((System.ComponentModel.ISupportInitialize)(this.endSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbxSourceFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDestinationSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDestination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown endSecond;
        private System.Windows.Forms.NumericUpDown startSecond;
        private System.Windows.Forms.NumericUpDown startMinute;
        private System.Windows.Forms.NumericUpDown endMinute;
        private System.Windows.Forms.Button btnStartTrimVideo;
    }
}

