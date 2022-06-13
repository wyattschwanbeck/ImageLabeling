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
            Image<Bgr, byte> next_roi = hsv_img2.Copy();
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
            termCriteria.Type = Emgu.CV.CvEnum.TermCritType.Eps;
            termCriteria.Epsilon = .95;
            termCriteria.MaxIter = 1000;
            //termCriteria.Type = TermCritType.Iter;
            Mat dst=new Mat();
            vou.Clear();
            vou.Push(hsv2);
            CvInvoke.CalcBackProject(vou, new int[] { 0,1,2 },hist, dst, new float[] { 0, 180,0,256,0,256 },scale);
            Rectangle rectangle = new Rectangle(img1Rect.Location,img1Rect.Size);
            CvInvoke.MeanShift(dst, ref rectangle, termCriteria);

            return rectangle;//new Rectangle(new Point(img1Rect.Left+rectangle.Left, img1Rect.Top+rectangle.Top), img1Rect.Size);
        }
        
    }
    

}
