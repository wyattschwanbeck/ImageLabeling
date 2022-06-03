using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
//using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Drawing;

namespace ScreenRecordCapture.Recording
{
    class RecordQueue
    {
        private int AdjHeight;
        private int AdjWidth;
        private int AdjTop;
        private int AdjLeft;
        private int ScreenNum;
        private int CaptureCount;
        private List<FrameDetails> Captures;


        private DateTime Start;
        private DateTime End;
        private TimeSpan TotalLen;

        private Bitmap LastCapture;
        private MemoryStream Memory;
        private FileStream stream;
        private BinaryFormatter bf;
        private GifBitmapEncoder encoder;
        private BitmapPalette myPalette;
        private int stride ;
        private byte[] pixels;
        private BitmapSource image;
        public RecordQueue(int screenNum, int adjHeight, int adjWidth, int adjLeft, int adjTop)
        {
            CaptureCount = 0;

            bf = new BinaryFormatter();
            Memory = new MemoryStream();

            Captures = new List<FrameDetails>();


            AdjHeight = adjHeight;
            AdjWidth = adjWidth;
            AdjTop = adjTop;
            AdjLeft = adjLeft;
            ScreenNum = screenNum;
            stride = adjWidth / 8;
           
            pixels = new byte[adjHeight * stride];

            // Define the image palette
            myPalette = BitmapPalettes.WebPalette;

            // Creates a new empty image with the pre-defined palette
             image = BitmapSource.Create(
                AdjWidth,
                AdjHeight,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);

            FileStream stream = new FileStream("new.gif", FileMode.Create);
            GifBitmapEncoder encoder = new GifBitmapEncoder();
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
           
            //encoder.Save(stream);


        }

        public void CaptureMyScreen(DateTime Start, IntPtr hwnd)

        {
            

            try

            {
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = Screen.AllScreens[ScreenNum].Bounds;

                //Creating a new Bitmap object
                var captureBitmap = BitmapFrame.Create(
                AdjWidth,
                AdjHeight,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);

                //Creating a New Graphics Object
                //Graphics captureGraphics = Graphics.FromImage(captureBitmap.CloneCurrentValue());

                //Copying Image from The Screen
                //captureGraphics.CopyFromScreen(captureRectangle.X+AdjLeft, captureRectangle.Y+ AdjTop, 0, 0, new Size(AdjWidth, AdjHeight));

                //Determining the time span between captures
                End = DateTime.Now;
                TotalLen = Start - End;

                int BetweenFrames = Math.Abs((int)(TotalLen.TotalMilliseconds));
                Start = End;
                //encoder.Frames.Add(captureBitmap);
                //encoder.AddFrame(captureBitmap, 0, 0, TimeSpan.FromMilliseconds(BetweenFrames));
                //captureBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                //Captures.Add(new FrameDetails(captureBitmap, BetweenFrames));
                //bf.Serialize(stream, new FrameDetails(captureBitmap, BetweenFrames));

                CaptureCount++;
                Console.WriteLine("FPS: " + 1000/BetweenFrames);

                
            }

            catch (Exception ex)

            {

                System.Console.WriteLine(ex.Message);

            }

        }


        public void SaveAnimatedGifImage()
        {
            stream.Flush();
            //Memory.Flush();

            
            //foreach (int value in Enumerable.Range(0, CaptureCount))
            //{
                //bf.Deserialize(stream);
            //    encoder.AddFrame(, 0, 0, TimeSpan.FromMilliseconds(FD.FrameAddTime));
            //}

            

            

            Memory.Position = 0;
            using (var fileStream = new FileStream(@"C:\Users\wyatt\source\repos\ScreenRecordCapture\Test.gif", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Memory.CopyTo(fileStream);
            }
            //encoder.Dispose();
            //stream.Close();
            Memory.Close();
            
        }


    }
}
