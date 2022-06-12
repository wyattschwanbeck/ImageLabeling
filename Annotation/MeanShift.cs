using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;

namespace ScreenRecordCapture.Annotation
{
    public class MeanShiftHelper
    {
        public ScalarArray hsvMin;
        public ScalarArray hsvMax;
        public Mat roi_hist;
        float[] range;
        int[] histSize;
        int[] channels;
        Mat mask;
        public MeanShiftHelper(MCvScalar hsv_min, MCvScalar hsv_max)
        {
            range = new float[100];
            histSize= new int[180];
            channels = new int[0];
            mask = new Mat();
            roi_hist = new Mat();
            hsvMin = new ScalarArray(hsv_min);
            hsvMax = new ScalarArray(hsv_max);
            
        }
        public Rectangle Shift(Image<Hsv, byte> hsv_img1, Image<Hsv, byte> hsv_img2, Rectangle img1Rect) 
        {
            hsv_img1.ROI = img1Rect;
            Image<Hsv, byte> hist_roi = hsv_img1.GetSubRect(hsv_img1.ROI);
            mask.SetTo(hist_roi);
            CvInvoke.InRange(hist_roi,hsvMin, hsvMax, mask);
            CvInvoke.CalcHist(hist_roi, channels, mask, roi_hist, histSize, range,true);
            CvInvoke.Normalize(hist_roi, roi_hist, 0, 255, Emgu.CV.CvEnum.NormType.MinMax);

            //Take in first picture, second picture, and the original bounding box
            // use Meanshift to return the estimate for the next bounding box
            MCvTermCriteria termCriteria = new MCvTermCriteria();
            termCriteria.Type = Emgu.CV.CvEnum.TermCritType.Eps;
            termCriteria.Epsilon = .90;
            termCriteria.MaxIter = 10;
            Mat dst=new Mat();
            CvInvoke.CalcBackProject(hsv_img2, channels, roi_hist, dst, range);
            CvInvoke.MeanShift(hsv_img2, ref img1Rect, termCriteria);
            return img1Rect;
        }
        
    }
    

}
