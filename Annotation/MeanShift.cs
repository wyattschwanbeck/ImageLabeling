using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace ScreenRecordCapture.Annotation
{
    public class MeanShiftHelper
    {
        public ScalarArray hsvMin;
        public ScalarArray hsvMax;
        private MCvScalar hsv_max;
        private MCvScalar hsv_min;
        public Mat roi_hist;
        float[] range;
        int[] histSize;
        int[] channels;
        Mat mask;
        public MeanShiftHelper(MCvScalar hsv_min, MCvScalar hsv_max)
        {
            this.hsv_min = hsv_min;
            this.hsv_max = hsv_max;
            range = new float[180];
            for (int i = 0; i < range.Length; i++)
                range[i] = (float)i;
            histSize= new int[180];
            channels = new int[1];
            channels[0] = 0;
            
            hsvMin = new ScalarArray(hsv_min);
            hsvMax = new ScalarArray(hsv_max);
            
        }
        public Rectangle Shift(Image<Bgr, byte> hsv_img1, Image<Bgr, byte> hsv_img2, Rectangle img1Rect, double scale=1) 
        {
            mask = new Mat();
            roi_hist = new Mat();
            //hsv_img1.ROI = img1Rect;
            //hsv_img1.SetValue(new Hsv)
            Image<Bgr, byte> hist_roi = hsv_img1.GetSubRect(img1Rect);
            Image<Bgr, byte> next_roi = hsv_img2.Copy().GetSubRect(img1Rect);
            mask.SetTo(hist_roi);
            
            roi_hist.SetTo(mask);
            roi_hist.SetTo(hist_roi);
            
            VectorOfUMat vou = new VectorOfUMat();
            UMat hsv = new UMat();
            CvInvoke.CvtColor(hist_roi, hsv, ColorConversion.Bgr2Hsv);
            CvInvoke.InRange(hsv, hsvMin, hsvMax, mask);
            vou.Push(hsv);
            
            Mat hist = new Mat();
            //UMat hsv2 = new UMat();

            CvInvoke.CalcHist(vou, new int[] { 0,1,2 }, mask, hist, new int[] { 180,255,255 }, new float[] { 0, 180,0,256,0,256 }, false);
            CvInvoke.Normalize(hist, hist, 0, 255, NormType.MinMax);
            UMat hsv2 = new UMat();
            CvInvoke.CvtColor(next_roi, hsv2, ColorConversion.Bgr2Hsv);
            MCvTermCriteria termCriteria = new MCvTermCriteria();
            //termCriteria.Type = Emgu.CV.CvEnum.;
            termCriteria.Epsilon = .95;
            termCriteria.MaxIter = 500;
            //termCriteria.Type = TermCritType.Iter;
            Mat dst=new Mat();
            //vou.Clear();
            vou.Push(hsv2);
            CvInvoke.CalcBackProject(vou, new int[] { 0,1,2 },hist, dst, new float[] { 0, 180,0,256,0,256 },scale);
            Rectangle rectangle = new Rectangle(img1Rect.Location,img1Rect.Size);
            CvInvoke.MeanShift(dst, ref rectangle, termCriteria);
            rectangle = new Rectangle(new Point(img1Rect.Location.X + rectangle.Location.X, img1Rect.Location.Y + rectangle.Location.Y), img1Rect.Size);
            return rectangle;//new Rectangle(new Point(img1Rect.Left+rectangle.Left, img1Rect.Top+rectangle.Top), img1Rect.Size);
        }

        public Point Detect_object(Image<Gray, Byte> Area_Image, Image<Gray, Byte> image_object)
        {
            //bool success = false;
            Point Location = new Point();
            //Work out padding array size
            Point dftSize = new Point(Area_Image.Width + (image_object.Width * 2), Area_Image.Height + (image_object.Height * 2));
            //Pad the Array with zeros
            using (Image<Gray, Byte> pad_array = new Image<Gray, Byte>(dftSize.X, dftSize.Y))
            {
                //copy centre
                pad_array.ROI = new Rectangle(image_object.Width, image_object.Height, Area_Image.Width, Area_Image.Height);
                CvInvoke.cvCopy(Area_Image, pad_array, IntPtr.Zero);

                pad_array.ROI = (new Rectangle(0, 0, dftSize.X, dftSize.Y));

                //Match Template
                using (Image<Gray, float> result_Matrix = pad_array.MatchTemplate(image_object, TemplateMatchingType.CcoeffNormed))
                {
                    Point[] MAX_Loc, Min_Loc;
                    double[] min, max;
                    //Limit ROI to look for Match

                    result_Matrix.ROI = new Rectangle(image_object.Width, image_object.Height, Area_Image.Width - image_object.Width, Area_Image.Height - image_object.Height);

                    result_Matrix.MinMax(out min, out max, out Min_Loc, out MAX_Loc);

                    Location = new Point((MAX_Loc[0].X), (MAX_Loc[0].Y));
                    //success = true;
                    //Results = result_Matrix.Convert<Gray, Double>();

                }
            }
            return Location;
        }

    }
    

}
