namespace ScreenRecordCapture
{
    partial class DynaCapture
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ScreensToChooseFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HeightLbl = new System.Windows.Forms.Label();
            this.WidthLbl = new System.Windows.Forms.Label();
            this.BaseHeightTxt = new System.Windows.Forms.TextBox();
            this.BaseWidthTxt = new System.Windows.Forms.TextBox();
            this.txtAdjWidth = new System.Windows.Forms.TextBox();
            this.lblAdjustedWidth = new System.Windows.Forms.Label();
            this.lblAdjustedHeight = new System.Windows.Forms.Label();
            this.txtAdjustedHeight = new System.Windows.Forms.TextBox();
            this.lblAdjTop = new System.Windows.Forms.Label();
            this.txtAdjustedTop = new System.Windows.Forms.TextBox();
            this.lblAdjLeft = new System.Windows.Forms.Label();
            this.txtAdjustedLeft = new System.Windows.Forms.TextBox();
            this.Record = new System.Windows.Forms.Button();
            this.ChkBoxMacroEnabled = new System.Windows.Forms.CheckBox();
            this.btnRecordInput = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 439);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ScreensToChooseFrom
            // 
            this.ScreensToChooseFrom.FormattingEnabled = true;
            this.ScreensToChooseFrom.Location = new System.Drawing.Point(115, 471);
            this.ScreensToChooseFrom.Name = "ScreensToChooseFrom";
            this.ScreensToChooseFrom.Size = new System.Drawing.Size(121, 21);
            this.ScreensToChooseFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Screen To Capture";
            // 
            // HeightLbl
            // 
            this.HeightLbl.AutoSize = true;
            this.HeightLbl.Location = new System.Drawing.Point(1024, 311);
            this.HeightLbl.Name = "HeightLbl";
            this.HeightLbl.Size = new System.Drawing.Size(44, 13);
            this.HeightLbl.TabIndex = 4;
            this.HeightLbl.Text = "Height: ";
            // 
            // WidthLbl
            // 
            this.WidthLbl.AutoSize = true;
            this.WidthLbl.Location = new System.Drawing.Point(1030, 344);
            this.WidthLbl.Name = "WidthLbl";
            this.WidthLbl.Size = new System.Drawing.Size(38, 13);
            this.WidthLbl.TabIndex = 5;
            this.WidthLbl.Text = "Width:";
            // 
            // BaseHeightTxt
            // 
            this.BaseHeightTxt.Enabled = false;
            this.BaseHeightTxt.Location = new System.Drawing.Point(1074, 308);
            this.BaseHeightTxt.Name = "BaseHeightTxt";
            this.BaseHeightTxt.Size = new System.Drawing.Size(62, 20);
            this.BaseHeightTxt.TabIndex = 6;
            // 
            // BaseWidthTxt
            // 
            this.BaseWidthTxt.Enabled = false;
            this.BaseWidthTxt.Location = new System.Drawing.Point(1074, 341);
            this.BaseWidthTxt.Name = "BaseWidthTxt";
            this.BaseWidthTxt.Size = new System.Drawing.Size(62, 20);
            this.BaseWidthTxt.TabIndex = 7;
            // 
            // txtAdjWidth
            // 
            this.txtAdjWidth.Location = new System.Drawing.Point(1074, 488);
            this.txtAdjWidth.Name = "txtAdjWidth";
            this.txtAdjWidth.Size = new System.Drawing.Size(63, 20);
            this.txtAdjWidth.TabIndex = 8;
            // 
            // lblAdjustedWidth
            // 
            this.lblAdjustedWidth.AutoSize = true;
            this.lblAdjustedWidth.Location = new System.Drawing.Point(989, 491);
            this.lblAdjustedWidth.Name = "lblAdjustedWidth";
            this.lblAdjustedWidth.Size = new System.Drawing.Size(82, 13);
            this.lblAdjustedWidth.TabIndex = 9;
            this.lblAdjustedWidth.Text = "Selection Width";
            // 
            // lblAdjustedHeight
            // 
            this.lblAdjustedHeight.AutoSize = true;
            this.lblAdjustedHeight.Location = new System.Drawing.Point(986, 517);
            this.lblAdjustedHeight.Name = "lblAdjustedHeight";
            this.lblAdjustedHeight.Size = new System.Drawing.Size(85, 13);
            this.lblAdjustedHeight.TabIndex = 11;
            this.lblAdjustedHeight.Text = "Selection Height";
            // 
            // txtAdjustedHeight
            // 
            this.txtAdjustedHeight.Location = new System.Drawing.Point(1074, 514);
            this.txtAdjustedHeight.Name = "txtAdjustedHeight";
            this.txtAdjustedHeight.Size = new System.Drawing.Size(63, 20);
            this.txtAdjustedHeight.TabIndex = 10;
            // 
            // lblAdjTop
            // 
            this.lblAdjTop.AutoSize = true;
            this.lblAdjTop.Location = new System.Drawing.Point(1151, 491);
            this.lblAdjTop.Name = "lblAdjTop";
            this.lblAdjTop.Size = new System.Drawing.Size(98, 13);
            this.lblAdjTop.TabIndex = 13;
            this.lblAdjTop.Text = "Selection Top Pixel";
            // 
            // txtAdjustedTop
            // 
            this.txtAdjustedTop.Location = new System.Drawing.Point(1074, 400);
            this.txtAdjustedTop.Name = "txtAdjustedTop";
            this.txtAdjustedTop.Size = new System.Drawing.Size(63, 20);
            this.txtAdjustedTop.TabIndex = 12;
            this.txtAdjustedTop.TextChanged += new System.EventHandler(this.txtAdjustedTop_TextChanged);
            // 
            // lblAdjLeft
            // 
            this.lblAdjLeft.AutoSize = true;
            this.lblAdjLeft.Location = new System.Drawing.Point(974, 429);
            this.lblAdjLeft.Name = "lblAdjLeft";
            this.lblAdjLeft.Size = new System.Drawing.Size(97, 13);
            this.lblAdjLeft.TabIndex = 15;
            this.lblAdjLeft.Text = "Selection Left Pixel";
            // 
            // txtAdjustedLeft
            // 
            this.txtAdjustedLeft.Location = new System.Drawing.Point(1074, 426);
            this.txtAdjustedLeft.Name = "txtAdjustedLeft";
            this.txtAdjustedLeft.Size = new System.Drawing.Size(63, 20);
            this.txtAdjustedLeft.TabIndex = 14;
            // 
            // Record
            // 
            this.Record.Location = new System.Drawing.Point(253, 465);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(149, 30);
            this.Record.TabIndex = 3;
            this.Record.Text = "Record";
            this.Record.UseVisualStyleBackColor = true;
            // 
            // ChkBoxMacroEnabled
            // 
            this.ChkBoxMacroEnabled.AutoSize = true;
            this.ChkBoxMacroEnabled.Location = new System.Drawing.Point(15, 536);
            this.ChkBoxMacroEnabled.Name = "ChkBoxMacroEnabled";
            this.ChkBoxMacroEnabled.Size = new System.Drawing.Size(201, 17);
            this.ChkBoxMacroEnabled.TabIndex = 16;
            this.ChkBoxMacroEnabled.Text = "Enable Macro For Starting Recording";
            this.ChkBoxMacroEnabled.UseVisualStyleBackColor = true;
            // 
            // btnRecordInput
            // 
            this.btnRecordInput.Location = new System.Drawing.Point(15, 577);
            this.btnRecordInput.Name = "btnRecordInput";
            this.btnRecordInput.Size = new System.Drawing.Size(127, 23);
            this.btnRecordInput.TabIndex = 17;
            this.btnRecordInput.Text = "Record Macro";
            this.btnRecordInput.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 577);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 18;
            // 
            // DynaCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 756);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnRecordInput);
            this.Controls.Add(this.ChkBoxMacroEnabled);
            this.Controls.Add(this.lblAdjLeft);
            this.Controls.Add(this.txtAdjustedLeft);
            this.Controls.Add(this.lblAdjTop);
            this.Controls.Add(this.txtAdjustedTop);
            this.Controls.Add(this.lblAdjustedHeight);
            this.Controls.Add(this.txtAdjustedHeight);
            this.Controls.Add(this.lblAdjustedWidth);
            this.Controls.Add(this.txtAdjWidth);
            this.Controls.Add(this.BaseWidthTxt);
            this.Controls.Add(this.BaseHeightTxt);
            this.Controls.Add(this.WidthLbl);
            this.Controls.Add(this.HeightLbl);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScreensToChooseFrom);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DynaCapture";
            this.Text = "Screen Record";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DynaCapture_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ScreensToChooseFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HeightLbl;
        private System.Windows.Forms.Label WidthLbl;
        private System.Windows.Forms.TextBox BaseHeightTxt;
        private System.Windows.Forms.TextBox BaseWidthTxt;
        private System.Windows.Forms.TextBox txtAdjWidth;
        private System.Windows.Forms.Label lblAdjustedWidth;
        private System.Windows.Forms.Label lblAdjustedHeight;
        private System.Windows.Forms.TextBox txtAdjustedHeight;
        private System.Windows.Forms.Label lblAdjTop;
        private System.Windows.Forms.TextBox txtAdjustedTop;
        private System.Windows.Forms.Label lblAdjLeft;
        private System.Windows.Forms.TextBox txtAdjustedLeft;
        private System.Windows.Forms.Button Record;
        private System.Windows.Forms.CheckBox ChkBoxMacroEnabled;
        private System.Windows.Forms.Button btnRecordInput;
        private System.Windows.Forms.TextBox textBox1;
    }
}

