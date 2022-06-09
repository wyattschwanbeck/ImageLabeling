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
using System.Xml;
using System.Xml.Linq;

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
            //DoubleBuffered = true;
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
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
            
            if (pictureBox1.Image != null && _classLabel>-1)
            {
                Rectangle imgRect = new Rectangle(pictureBox1.Location, new Size(pictureBox1.Image.Width, pictureBox1.Image.Height));
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
            if (e.Button != MouseButtons.Left && this.pictureBox1.Image !=null)
                return;
            //Point tempEndPoint = e.Location;
            if(SelectedBoundingBox!=null)
            {
                SelectedBoundingBox.UpdateEndPoint(e.Location);
                //if(this)
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
            //Graphics g = e.Graphics;
            if (pictureBox1.Image != null && _classLabel>-1)
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
        double baseW;
        double baseH;
        double AdjW;
        double AdjH;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
            }else if(this.pictureBox1.Image!=null && this._classLabel>-1)
            {
                this.needsAdded = false;
                //will be used to capture bounding boxes adjusted for rendering
                baseW = int.Parse(BaseWidthTxt.Text);
                baseH = int.Parse(BaseHeightTxt.Text);
                AdjW = pictureBox1.Width;
                AdjH = pictureBox1.Height;


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

                this.pictureBox1.Image = new Bitmap(tempImg);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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
                this._Imgfiles = imgInfo.EnumerateFiles("*jpg",SearchOption.AllDirectories).ToList();
                this.lblImgCount.Text = this._Imgfiles.Count.ToString();
                setImage(new Bitmap(this._Imgfiles.First().FullName));
                this.listBoxImages.Items.Clear();
                foreach (FileInfo fileInfo in this._Imgfiles)
                    this.listBoxImages.Items.Add(fileInfo.FullName);
                this.btnSaveXML.Enabled = true;
                this._selectedIndex = 0;
                checkSaved();
                this.btnNext.Enabled = true;
                this.btnPrevious.Enabled = true;
            }
                
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //save on next check
            if (this.checkBox1.Checked)
                SaveBoundingBoxes();
            if (this._selectedIndex < this._Imgfiles.Count - 1)
                this._selectedIndex += 1;
            setImage(new Bitmap(_Imgfiles[this._selectedIndex].FullName));
            checkSaved();
        }
        private void checkSaved()
        {
            FileInfo fi = _Imgfiles[this._selectedIndex];
            string xmlCounterpart = fi.Directory.FullName + '\\' + fi.Name.Replace("jpg","xml");
            
            if (File.Exists(xmlCounterpart))
            {
                this.boundingBoxes.Clear();
                var xmlStr = File.ReadAllText(xmlCounterpart);


                XmlDocument str = new XmlDocument();
                
                str.LoadXml(xmlStr);
                var resultxMin = str.SelectNodes("/annotation/object/bndbox/xmin");
                var resultxMax = str.SelectNodes("/annotation/object/bndbox/xmax");
                var resultyMin = str.SelectNodes("/annotation/object/bndbox/ymin");
                var resultyMax = str.SelectNodes("/annotation/object/bndbox/ymax");
                var resultLabels = str.SelectNodes("/annotation/object/name");
                double baseW = int.Parse(BaseWidthTxt.Text);
                double baseH = int.Parse(BaseHeightTxt.Text);
                double AdjW = pictureBox1.Width;
                double AdjH = pictureBox1.Height;

                for (int i = 0; i < resultxMin.Count; i++)
                    {
                    int xMin = int.Parse(resultxMin[i].InnerText);
                    int yMin = int.Parse(resultyMin[i].InnerText);
                    int xMax = int.Parse(resultxMax[i].InnerText);
                    int yMax = int.Parse(resultyMax[i].InnerText);

                    Point adjXYMin = RenderAdjustments.ConvertFromImageCoords(new Point(xMin, yMin),
                                                        pictureBox1.ClientRectangle.Size, pictureBox1.Image.Size);
                    Point adjXYMax = RenderAdjustments.ConvertFromImageCoords(new Point(xMax, yMax),
                                                        pictureBox1.ClientRectangle.Size, pictureBox1.Image.Size);
                    this.boundingBoxes.Add(new BoundingBox(adjXYMin,adjXYMax, resultLabels[i].InnerText));
                        this.SelectedBoundingBox = this.boundingBoxes.Last();
                        if (!this.listBoxImageClasses.Items.Contains(resultLabels[i].InnerText))
                        {
                            this.listBoxImageClasses.Items.Add(resultLabels[i].InnerText);
                            this.listBoxImageClasses.SelectedIndex = 0;
                        }
                    }
                    this.pictureBox1.Invalidate();

            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this._selectedIndex >0)
                this._selectedIndex -= 1;
            setImage(new Bitmap(this._Imgfiles[this._selectedIndex].FullName));
            checkSaved();
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

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            SaveBoundingBoxes();
        }
        
        private void SaveBoundingBoxes()
        {
            //https://towardsdatascience.com/coco-data-format-for-object-detection-a4c5eaf518c5#:~:text=Pascal%20VOC%20is%20an%20XML,for%20training%2C%20testing%20and%20validation.
            FileInfo fi = _Imgfiles[this._selectedIndex];
            string[] parentFolders = fi.FullName.Split('\\');
            DirectoryInfo directoryInfo = new DirectoryInfo(fi.Directory.FullName);
            //double baseW = int.Parse(BaseWidthTxt.Text);
            //double baseH = int.Parse(BaseHeightTxt.Text);
            double AdjW = pictureBox1.Width;
            double AdjH = pictureBox1.Height;


            if (SelectedBoundingBox.boundingBox.Size.Width > 0)
            {
                
            }

            using (XmlWriter writer = XmlWriter.Create(fi.Directory.FullName + '\\' + fi.Name.Replace("jpg", "xml")))
            {
                writer.WriteStartElement("annotation");
                writer.WriteStartElement("folder");
                writer.WriteString(parentFolders[parentFolders.Length - 1]);
                writer.WriteEndElement();
                writer.WriteStartElement("filename");
                writer.WriteString(fi.Name);
                writer.WriteEndElement();
                writer.WriteStartElement("path");
                writer.WriteString(fi.FullName);
                writer.WriteEndElement();
                writer.WriteStartElement("size");
                writer.WriteStartElement("width");
                writer.WriteString(this.pictureBox1.Image.Width.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("height");
                writer.WriteString(this.pictureBox1.Image.Height.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("depth");
                writer.WriteString("3");//System.Drawing.Image.GetPixelFormatSize(this.pictureBox1.BackgroundImage.PixelFormat).ToString());
                writer.WriteEndElement();
                //End Size
                writer.WriteEndElement();

                foreach (BoundingBox boundingBox in boundingBoxes)
                {
                    //double AdjWidth = Math.Round((boundingBox.boundingBox.Size.Width / AdjW) * baseW, 2);
                    //double AdjHeight = Math.Round((boundingBox.boundingBox.Size.Height / AdjH) * baseH, 2);
                    //double AdjTop = Math.Round((boundingBox.boundingBox.Top / AdjH) * baseH, 0);
                    //double AdjLeft = Math.Round((boundingBox.boundingBox.Left / AdjW) * baseW, 0);
                    Point realXYMin = RenderAdjustments.ConvertToImageCoords(boundingBox.boundingBox.Location, 
                                                        pictureBox1.ClientRectangle.Size, pictureBox1.Image.Size);
                    Point realXYMax = RenderAdjustments.ConvertToImageCoords(new Point(boundingBox.boundingBox.Right, boundingBox.boundingBox.Bottom), 
                                                        pictureBox1.ClientRectangle.Size, pictureBox1.Image.Size);
                    writer.WriteStartElement("object");
                    writer.WriteStartElement("name");
                    writer.WriteString(boundingBox.label);
                    writer.WriteEndElement();
                    writer.WriteStartElement("pose");
                    writer.WriteString("unspecified");
                    writer.WriteEndElement();
                    writer.WriteStartElement("truncated");
                    writer.WriteString("0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("difficult");
                    writer.WriteString("1");
                    writer.WriteEndElement();

                    writer.WriteStartElement("bndbox");
                    writer.WriteStartElement("xmin");
                    writer.WriteString(realXYMin.X.ToString());//boundingBox.boundingBox.X.ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ymin");
                    writer.WriteString(realXYMin.Y.ToString());//boundingBox.boundingBox.Y.ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("xmax");
                    writer.WriteString(((int)(realXYMax.X)).ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ymax");
                    writer.WriteString(((int)(realXYMax.Y)).ToString());
                    writer.WriteEndElement();
                    //End Bounding Box
                    writer.WriteEndElement();
                    //End Object
                    writer.WriteEndElement();
                }


                //End Annotation
                writer.WriteEndElement();
                writer.Flush();


            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //if (pictureBox1.Image != null && _classLabel > -1)
            //{

            //    foreach (BoundingBox box in boundingBoxes)
            //    {
            //        box.DrawBoundingBox(sender, e);
            //    }
            //    if (SelectedBoundingBox != null && SelectedBoundingBox.boundingBox.Width > 0 && SelectedBoundingBox.boundingBox.Height > 0)
            //    {
            //        SelectedBoundingBox.DrawSelectCircles(sender, e);
            //    }
            //}
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }


}
