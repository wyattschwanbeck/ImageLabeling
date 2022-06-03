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
using ScreenRecordCapture.Recording;

namespace ScreenRecordCapture
{
    public partial class DynaCapture : Form
    {
        public DynaCapture()
        {
            InitializeComponent();
            ScreensToChooseFrom.DataSource = Enumerable.Range(1, Screen.AllScreens.Length).ToList();
            
            setImage(CaptureMyScreen(GetScreen()));
        }



        private bool Recording;
        private int ScreenNum;

        private RecordQueue RecQ;
        
        //Capture locations and set details for overlay selection
        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(100, 72, 145, 220));

        // Start Rectangle
        //
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            RectStartPoint = e.Location;
            Recording = false;
            Invalidate();
        }

        // Draw Rectangle
        //
        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));

            


            pictureBox1.Invalidate();
        }

        // Draw Area
        //
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBox1.BackgroundImage != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Rect.Contains(e.Location))
                {
                    System.Console.WriteLine("Right click");
                }
            }
            double baseW = int.Parse(BaseWidthTxt.Text);
            double baseH = int.Parse(BaseHeightTxt.Text);
            double AdjW = pictureBox1.Width;
            double AdjH = pictureBox1.Height;
            

            if (Rect.Size.Width > 0)
            {
                txtAdjWidth.Text = Math.Round((Rect.Size.Width / AdjW) * baseW).ToString();
                txtAdjustedHeight.Text = Math.Round((Rect.Size.Height / AdjH) * baseH).ToString();
                txtAdjustedTop.Text = Math.Round((Rect.Top / AdjH) * baseH).ToString();
                txtAdjustedLeft.Text = Math.Round((Rect.Left / AdjW) * baseW).ToString();
            }

            setImage(CaptureMyScreen(ScreenNum));
        }

        

        public static Bitmap CaptureMyScreen(int ScreenNum)

        {

            try

            {
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = Screen.AllScreens[ScreenNum].Bounds;
                
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(captureRectangle.Width, captureRectangle.Height, PixelFormat.Format32bppArgb);



                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);



                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                return captureBitmap;

            }

            catch (Exception ex)

            {

                System.Console.WriteLine(ex.Message);
                
            }

            return null;

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

        public int GetScreen()
        {
            return ScreenNum;
        
        }


        private void ScreensToChooseFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ScreenNum = int.Parse(ScreensToChooseFrom.SelectedValue.ToString()) - 1;
            setImage(CaptureMyScreen(GetScreen()));

        }

        private async void Record_Click(object sender, EventArgs e)
        {
            if (Recording)
            {
                Recording = false;
                Record.Text = "Record";   
                //RecQ = null;
                
            } else
            {
                Record.Text = "Recording...";
                RecQ = new RecordQueue( GetScreen(),
                                        int.Parse(txtAdjustedHeight.Text),
                                        int.Parse(txtAdjWidth.Text),
                                        int.Parse(txtAdjustedLeft.Text),
                                        int.Parse(txtAdjustedTop.Text));
                Recording = true;
                Task<int> RecTask = new Task<int>(FormRecord);
                RecTask.Start();
                int RecCount = await RecTask;

            }

        }

        public int FormRecord()
        {
            DateTime LastCapture = DateTime.Now;
            TimeSpan TS = TimeSpan.FromMilliseconds(0);
            int captures = 0;
            while (Recording)
            {
                if(DateTime.Now- LastCapture>= TS)
                {
// RecQ.CaptureMyScreen(LastCapture, );
                    LastCapture = DateTime.Now;
                    captures++;
                    
                }
                
            }
            //RecQ.SaveAnimatedFrames();
           RecQ.SaveAnimatedGifImage();
            return captures;
            
        }

        private void DynaCapture_DragDrop(object sender, DragEventArgs e)
        {
             setImage(CaptureMyScreen(ScreenNum));
        }

        private void DynaCapture_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnRecordInput_Click(object sender, EventArgs e)
        {

        }

        private void txtAdjustedTop_TextChanged(object sender, EventArgs e)
        {

        }

        private void Record_Click_1(object sender, EventArgs e)
        {

        }
    }


}
