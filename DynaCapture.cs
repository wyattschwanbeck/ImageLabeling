using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using ScreenRecordCapture.Annotation;

namespace ScreenRecordCapture
{
    public partial class LabelImagesWindow : Form
    {
        private List<FileInfo> _Imgfiles = new List<FileInfo>();
        private Dictionary<string, List<BoundingBox>> ImgBoundingBoxes;
        private int _selectedIndex;
        private int _classLabel=-1;
        public LabelImagesWindow()
        {
            ImgBoundingBoxes = new Dictionary<string, List<BoundingBox>>();

            boundingBoxes = new List<BoundingBox>();
            InitializeComponent();
            
            //ScreensToChooseFrom.DataSource = Enumerable.Range(1, Screen.AllScreens.Length).ToList();
            
            //setImage(CaptureMyScreen(GetScreen()));
        }



        private List<BoundingBox> boundingBoxes;
        private BoundingBox SelectedBoundingBox;

        // Start Rectangle
        //
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (pictureBox1.BackgroundImage != null && _classLabel>-1)
            {
                Rectangle imgRect = new Rectangle(pictureBox1.Location, new Size(pictureBox1.BackgroundImage.Width, pictureBox1.BackgroundImage.Height));
                if (imgRect.Contains(e.Location))
                {
                    SelectedBoundingBox = null;
                    //Check if click 
                    foreach (BoundingBox box in boundingBoxes)
                        if (box.boundingBox.Contains(e.Location))
                        {
                            SelectedBoundingBox = box;
                            SelectedBoundingBox.setSelectedCircles(e.Location);
                            break;
                        }
                    if (SelectedBoundingBox == null)
                    {
                        this.needsAdded = true;
                        //this.addSizeSatisfied = false;
                        SelectedBoundingBox = new BoundingBox(e.Location, e.Location, this.listBoxImageClasses.Items[_classLabel].ToString());
                        
                    }
                        
                    this.pictureBox1.Invalidate();
                }
            }
            
        }
        private bool needsAdded = false;
        //private bool addSizeSatisfied = false;
        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && this.pictureBox1.BackgroundImage!=null)
                return;
            //Point tempEndPoint = e.Location;
            if(SelectedBoundingBox!=null)
            {
                SelectedBoundingBox.UpdateEndPoint(e.Location);

                if (this.needsAdded)
                    if (SelectedBoundingBox.boundingBox.Height > 10 && SelectedBoundingBox.boundingBox.Width > 10)
                    {
                        this.needsAdded = false;
                        boundingBoxes.Add(SelectedBoundingBox);
                    }
            }
                
            pictureBox1.Invalidate();
        }

        // Draw Area
        //
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBox1.BackgroundImage != null && _classLabel>-1)
            {
                
                foreach(BoundingBox box in boundingBoxes)
                {
                    box.DrawBoundingBox(sender,e);
                }
                if (SelectedBoundingBox != null && SelectedBoundingBox.boundingBox.Width > 0 && SelectedBoundingBox.boundingBox.Height > 0)
                {
                    SelectedBoundingBox.DrawSelectCircles(sender, e);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
            }else if(this.pictureBox1.BackgroundImage!=null && this._classLabel>-1)
            {
                this.needsAdded = false;
                //this.addSizeSatisfied = false;
                double baseW = int.Parse(BaseWidthTxt.Text);
                double baseH = int.Parse(BaseHeightTxt.Text);
                double AdjW = pictureBox1.BackgroundImage.Width;
                double AdjH = pictureBox1.BackgroundImage.Height;


                if (SelectedBoundingBox.boundingBox.Size.Width > 0)
                {
                    txtAdjWidth.Text = Math.Round((SelectedBoundingBox.boundingBox.Size.Width / AdjW) * baseW,1).ToString();
                    txtAdjustedHeight.Text = Math.Round((SelectedBoundingBox.boundingBox.Size.Height / AdjH) * baseH,1).ToString();
                    txtAdjustedTop.Text = Math.Round((SelectedBoundingBox.boundingBox.Top / AdjH) * baseH,1).ToString();
                    txtAdjustedLeft.Text = Math.Round((SelectedBoundingBox.boundingBox.Left / AdjW) * baseW,1).ToString();
                }
                SelectedBoundingBox.setSelectedCircles(new Point(-1, -1));
            }
            this.pictureBox1.Invalidate();
            

        }

        

        private void setImage(Bitmap tempImg)
        {
            using (tempImg)
            {


                Rectangle rect = new Rectangle(0, 0, tempImg.Width, tempImg.Height);

                PixelFormat format = tempImg.PixelFormat;

                this.pictureBox1.BackgroundImage = new Bitmap(tempImg);
                BaseWidthTxt.Text = tempImg.Width.ToString();
                BaseHeightTxt.Text = tempImg.Height.ToString();

            }
        }



        private void txtAdjustedTop_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogSelectImgDir.ShowDialog();
            if(FolderBrowserDialogSelectImgDir.ShowDialog() == DialogResult.OK)
            {
                txtImgDirectory.Text = FolderBrowserDialogSelectImgDir.SelectedPath;
                DirectoryInfo imgInfo = new DirectoryInfo(FolderBrowserDialogSelectImgDir.SelectedPath);
                this._Imgfiles = imgInfo.EnumerateFiles("*jpg").ToList();
                this.lblImgCount.Text = this._Imgfiles.Count.ToString();
                setImage(new Bitmap(this._Imgfiles.First().FullName));

            }
                
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(this._selectedIndex<this._Imgfiles.Count-1)
                this._selectedIndex += 1;
            setImage(new Bitmap(this._Imgfiles[this._selectedIndex].FullName));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this._selectedIndex >0)
                this._selectedIndex -= 1;
            setImage(new Bitmap(this._Imgfiles[this._selectedIndex].FullName));
        }

        private void listBoxImages_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void LabelImagesWindow_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            //TODO Validate input is onlyCharacters and numbers via regex
            if (this.txtClassInput.Text != "")
            {
                this.listBoxImageClasses.Items.Add(this.txtClassInput.Text);
            }
        }

        private void listBoxImageClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._classLabel = this.listBoxImageClasses.SelectedIndex;
        }
    }


}
