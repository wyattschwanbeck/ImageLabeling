namespace ScreenRecordCapture
{
    partial class LabelImagesWindow
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtImgDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectFolder = new System.Windows.Forms.Button();
            this.FolderBrowserDialogSelectImgDir = new System.Windows.Forms.FolderBrowserDialog();
            this.lblImageCountlabel = new System.Windows.Forms.Label();
            this.lblImgCount = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.listBoxImageClasses = new System.Windows.Forms.ListBox();
            this.listBoxImages = new System.Windows.Forms.ListBox();
            this.lblImageSelection = new System.Windows.Forms.Label();
            this.txtClassInput = new System.Windows.Forms.TextBox();
            this.btnAddClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(51, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 439);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // HeightLbl
            // 
            this.HeightLbl.AutoSize = true;
            this.HeightLbl.Location = new System.Drawing.Point(1011, 575);
            this.HeightLbl.Name = "HeightLbl";
            this.HeightLbl.Size = new System.Drawing.Size(44, 13);
            this.HeightLbl.TabIndex = 4;
            this.HeightLbl.Text = "Height: ";
            // 
            // WidthLbl
            // 
            this.WidthLbl.AutoSize = true;
            this.WidthLbl.Location = new System.Drawing.Point(1011, 608);
            this.WidthLbl.Name = "WidthLbl";
            this.WidthLbl.Size = new System.Drawing.Size(38, 13);
            this.WidthLbl.TabIndex = 5;
            this.WidthLbl.Text = "Width:";
            // 
            // BaseHeightTxt
            // 
            this.BaseHeightTxt.Enabled = false;
            this.BaseHeightTxt.Location = new System.Drawing.Point(1055, 572);
            this.BaseHeightTxt.Name = "BaseHeightTxt";
            this.BaseHeightTxt.Size = new System.Drawing.Size(62, 20);
            this.BaseHeightTxt.TabIndex = 6;
            // 
            // BaseWidthTxt
            // 
            this.BaseWidthTxt.Enabled = false;
            this.BaseWidthTxt.Location = new System.Drawing.Point(1055, 605);
            this.BaseWidthTxt.Name = "BaseWidthTxt";
            this.BaseWidthTxt.Size = new System.Drawing.Size(62, 20);
            this.BaseWidthTxt.TabIndex = 7;
            // 
            // txtAdjWidth
            // 
            this.txtAdjWidth.Location = new System.Drawing.Point(1054, 520);
            this.txtAdjWidth.Name = "txtAdjWidth";
            this.txtAdjWidth.Size = new System.Drawing.Size(63, 20);
            this.txtAdjWidth.TabIndex = 8;
            // 
            // lblAdjustedWidth
            // 
            this.lblAdjustedWidth.AutoSize = true;
            this.lblAdjustedWidth.Location = new System.Drawing.Point(969, 523);
            this.lblAdjustedWidth.Name = "lblAdjustedWidth";
            this.lblAdjustedWidth.Size = new System.Drawing.Size(82, 13);
            this.lblAdjustedWidth.TabIndex = 9;
            this.lblAdjustedWidth.Text = "Selection Width";
            // 
            // lblAdjustedHeight
            // 
            this.lblAdjustedHeight.AutoSize = true;
            this.lblAdjustedHeight.Location = new System.Drawing.Point(966, 549);
            this.lblAdjustedHeight.Name = "lblAdjustedHeight";
            this.lblAdjustedHeight.Size = new System.Drawing.Size(85, 13);
            this.lblAdjustedHeight.TabIndex = 11;
            this.lblAdjustedHeight.Text = "Selection Height";
            // 
            // txtAdjustedHeight
            // 
            this.txtAdjustedHeight.Location = new System.Drawing.Point(1054, 546);
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
            this.txtAdjustedTop.Location = new System.Drawing.Point(1054, 631);
            this.txtAdjustedTop.Name = "txtAdjustedTop";
            this.txtAdjustedTop.Size = new System.Drawing.Size(63, 20);
            this.txtAdjustedTop.TabIndex = 12;
            this.txtAdjustedTop.TextChanged += new System.EventHandler(this.txtAdjustedTop_TextChanged);
            // 
            // lblAdjLeft
            // 
            this.lblAdjLeft.AutoSize = true;
            this.lblAdjLeft.Location = new System.Drawing.Point(954, 660);
            this.lblAdjLeft.Name = "lblAdjLeft";
            this.lblAdjLeft.Size = new System.Drawing.Size(97, 13);
            this.lblAdjLeft.TabIndex = 15;
            this.lblAdjLeft.Text = "Selection Left Pixel";
            // 
            // txtAdjustedLeft
            // 
            this.txtAdjustedLeft.Location = new System.Drawing.Point(1054, 657);
            this.txtAdjustedLeft.Name = "txtAdjustedLeft";
            this.txtAdjustedLeft.Size = new System.Drawing.Size(63, 20);
            this.txtAdjustedLeft.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(954, 634);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Selection Top Pixel";
            // 
            // txtImgDirectory
            // 
            this.txtImgDirectory.Enabled = false;
            this.txtImgDirectory.Location = new System.Drawing.Point(209, 484);
            this.txtImgDirectory.Name = "txtImgDirectory";
            this.txtImgDirectory.Size = new System.Drawing.Size(340, 20);
            this.txtImgDirectory.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Image Directory";
            // 
            // selectFolder
            // 
            this.selectFolder.Location = new System.Drawing.Point(555, 482);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(75, 23);
            this.selectFolder.TabIndex = 19;
            this.selectFolder.Text = "Select";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblImageCountlabel
            // 
            this.lblImageCountlabel.AutoSize = true;
            this.lblImageCountlabel.Location = new System.Drawing.Point(656, 520);
            this.lblImageCountlabel.Name = "lblImageCountlabel";
            this.lblImageCountlabel.Size = new System.Drawing.Size(70, 13);
            this.lblImageCountlabel.TabIndex = 20;
            this.lblImageCountlabel.Text = "Image Count:";
            // 
            // lblImgCount
            // 
            this.lblImgCount.AutoSize = true;
            this.lblImgCount.Location = new System.Drawing.Point(732, 520);
            this.lblImgCount.Name = "lblImgCount";
            this.lblImgCount.Size = new System.Drawing.Size(13, 13);
            this.lblImgCount.TabIndex = 21;
            this.lblImgCount.Text = "0";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(266, 510);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 22;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(452, 510);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 23;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // listBoxImageClasses
            // 
            this.listBoxImageClasses.FormattingEnabled = true;
            this.listBoxImageClasses.Location = new System.Drawing.Point(850, 63);
            this.listBoxImageClasses.Name = "listBoxImageClasses";
            this.listBoxImageClasses.Size = new System.Drawing.Size(279, 186);
            this.listBoxImageClasses.TabIndex = 24;
            this.listBoxImageClasses.SelectedIndexChanged += new System.EventHandler(this.listBoxImageClasses_SelectedIndexChanged);
            // 
            // listBoxImages
            // 
            this.listBoxImages.FormattingEnabled = true;
            this.listBoxImages.Location = new System.Drawing.Point(850, 279);
            this.listBoxImages.Name = "listBoxImages";
            this.listBoxImages.Size = new System.Drawing.Size(279, 199);
            this.listBoxImages.TabIndex = 25;
            this.listBoxImages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxImages_KeyDown);
            // 
            // lblImageSelection
            // 
            this.lblImageSelection.AutoSize = true;
            this.lblImageSelection.Location = new System.Drawing.Point(847, 263);
            this.lblImageSelection.Name = "lblImageSelection";
            this.lblImageSelection.Size = new System.Drawing.Size(41, 13);
            this.lblImageSelection.TabIndex = 26;
            this.lblImageSelection.Text = "Images";
            // 
            // txtClassInput
            // 
            this.txtClassInput.Location = new System.Drawing.Point(850, 37);
            this.txtClassInput.Name = "txtClassInput";
            this.txtClassInput.Size = new System.Drawing.Size(199, 20);
            this.txtClassInput.TabIndex = 27;
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(1054, 35);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(75, 23);
            this.btnAddClass.TabIndex = 28;
            this.btnAddClass.Text = "Add Class";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // LabelImagesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 756);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.txtClassInput);
            this.Controls.Add(this.lblImageSelection);
            this.Controls.Add(this.listBoxImages);
            this.Controls.Add(this.listBoxImageClasses);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblImgCount);
            this.Controls.Add(this.lblImageCountlabel);
            this.Controls.Add(this.selectFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImgDirectory);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.pictureBox1);
            this.Name = "LabelImagesWindow";
            this.Text = "Label Images";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LabelImagesWindow_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImgDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogSelectImgDir;
        private System.Windows.Forms.Label lblImageCountlabel;
        private System.Windows.Forms.Label lblImgCount;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ListBox listBoxImageClasses;
        private System.Windows.Forms.ListBox listBoxImages;
        private System.Windows.Forms.Label lblImageSelection;
        private System.Windows.Forms.TextBox txtClassInput;
        private System.Windows.Forms.Button btnAddClass;
    }
}

