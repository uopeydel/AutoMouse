namespace DetectSameImageInScreen
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
            pbBase = new PictureBox();
            pbFound = new PictureBox();
            nBaseX = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            nBaseY = new NumericUpDown();
            nBaseWidth = new NumericUpDown();
            nBaseHeigh = new NumericUpDown();
            nFoundHeigh = new NumericUpDown();
            nFoundWidth = new NumericUpDown();
            nFoundY = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            nFoundX = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            btnCropInitial = new Button();
            btnSearch = new Button();
            pbScreenShort = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbBase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFound).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nBaseX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nBaseY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nBaseWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nBaseHeigh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nFoundHeigh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nFoundWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nFoundY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nFoundX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbScreenShort).BeginInit();
            SuspendLayout();
            // 
            // pbBase
            // 
            pbBase.Location = new Point(12, 50);
            pbBase.Name = "pbBase";
            pbBase.Size = new Size(316, 199);
            pbBase.TabIndex = 0;
            pbBase.TabStop = false;
            // 
            // pbFound
            // 
            pbFound.Location = new Point(457, 50);
            pbFound.Name = "pbFound";
            pbFound.Size = new Size(331, 199);
            pbFound.TabIndex = 1;
            pbFound.TabStop = false;
            // 
            // nBaseX
            // 
            nBaseX.Location = new Point(87, 255);
            nBaseX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nBaseX.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nBaseX.Name = "nBaseX";
            nBaseX.Size = new Size(241, 23);
            nBaseX.TabIndex = 2;
            nBaseX.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 257);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 3;
            label1.Text = "X : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 294);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 4;
            label2.Text = "Y : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 380);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 6;
            label3.Text = "Heigh : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 343);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 5;
            label4.Text = "Width : ";
            // 
            // nBaseY
            // 
            nBaseY.Location = new Point(87, 292);
            nBaseY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nBaseY.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nBaseY.Name = "nBaseY";
            nBaseY.Size = new Size(241, 23);
            nBaseY.TabIndex = 7;
            nBaseY.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // nBaseWidth
            // 
            nBaseWidth.Location = new Point(87, 341);
            nBaseWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nBaseWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nBaseWidth.Name = "nBaseWidth";
            nBaseWidth.Size = new Size(241, 23);
            nBaseWidth.TabIndex = 8;
            nBaseWidth.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // nBaseHeigh
            // 
            nBaseHeigh.Location = new Point(87, 378);
            nBaseHeigh.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nBaseHeigh.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nBaseHeigh.Name = "nBaseHeigh";
            nBaseHeigh.Size = new Size(241, 23);
            nBaseHeigh.TabIndex = 9;
            nBaseHeigh.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // nFoundHeigh
            // 
            nFoundHeigh.Location = new Point(533, 380);
            nFoundHeigh.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nFoundHeigh.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nFoundHeigh.Name = "nFoundHeigh";
            nFoundHeigh.Size = new Size(241, 23);
            nFoundHeigh.TabIndex = 17;
            nFoundHeigh.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nFoundWidth
            // 
            nFoundWidth.Location = new Point(533, 343);
            nFoundWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nFoundWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nFoundWidth.Name = "nFoundWidth";
            nFoundWidth.Size = new Size(241, 23);
            nFoundWidth.TabIndex = 16;
            nFoundWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nFoundY
            // 
            nFoundY.Location = new Point(533, 294);
            nFoundY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nFoundY.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nFoundY.Name = "nFoundY";
            nFoundY.Size = new Size(241, 23);
            nFoundY.TabIndex = 15;
            nFoundY.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(458, 382);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 14;
            label5.Text = "Heigh : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(458, 345);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 13;
            label6.Text = "Width : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(458, 296);
            label7.Name = "label7";
            label7.Size = new Size(23, 15);
            label7.TabIndex = 12;
            label7.Text = "Y : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(458, 259);
            label8.Name = "label8";
            label8.Size = new Size(23, 15);
            label8.TabIndex = 11;
            label8.Text = "X : ";
            // 
            // nFoundX
            // 
            nFoundX.Location = new Point(533, 257);
            nFoundX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nFoundX.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nFoundX.Name = "nFoundX";
            nFoundX.Size = new Size(241, 23);
            nFoundX.TabIndex = 10;
            nFoundX.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(458, 11);
            label9.Name = "label9";
            label9.Size = new Size(41, 15);
            label9.TabIndex = 19;
            label9.Text = "Found";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 9);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 18;
            label10.Text = "Base";
            // 
            // btnCropInitial
            // 
            btnCropInitial.Location = new Point(12, 436);
            btnCropInitial.Name = "btnCropInitial";
            btnCropInitial.Size = new Size(316, 36);
            btnCropInitial.TabIndex = 20;
            btnCropInitial.Text = "Crop Inintial";
            btnCropInitial.UseVisualStyleBackColor = true;
            btnCropInitial.Click += btnCropInitial_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(458, 436);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(316, 36);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // pbScreenShort
            // 
            pbScreenShort.Location = new Point(813, 9);
            pbScreenShort.Name = "pbScreenShort";
            pbScreenShort.Size = new Size(694, 513);
            pbScreenShort.TabIndex = 22;
            pbScreenShort.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 534);
            Controls.Add(pbScreenShort);
            Controls.Add(btnSearch);
            Controls.Add(btnCropInitial);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(nFoundHeigh);
            Controls.Add(nFoundWidth);
            Controls.Add(nFoundY);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(nFoundX);
            Controls.Add(nBaseHeigh);
            Controls.Add(nBaseWidth);
            Controls.Add(nBaseY);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nBaseX);
            Controls.Add(pbFound);
            Controls.Add(pbBase);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbBase).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFound).EndInit();
            ((System.ComponentModel.ISupportInitialize)nBaseX).EndInit();
            ((System.ComponentModel.ISupportInitialize)nBaseY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nBaseWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nBaseHeigh).EndInit();
            ((System.ComponentModel.ISupportInitialize)nFoundHeigh).EndInit();
            ((System.ComponentModel.ISupportInitialize)nFoundWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nFoundY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nFoundX).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbScreenShort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbBase;
        private PictureBox pbFound;
        private NumericUpDown nBaseX;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown nBaseY;
        private NumericUpDown nBaseWidth;
        private NumericUpDown nBaseHeigh;
        private NumericUpDown nFoundHeigh;
        private NumericUpDown nFoundWidth;
        private NumericUpDown nFoundY;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown nFoundX;
        private Label label9;
        private Label label10;
        private Button btnCropInitial;
        private Button btnSearch;
        private PictureBox pbScreenShort;
    }
}