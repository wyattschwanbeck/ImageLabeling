using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenRecordCapture.Annotation
{
    public static class RenderAdjustments
    {
        //Revised code from: https://stackoverflow.com/questions/48716515/how-to-get-real-image-pixel-point-x-y-from-picturebox
        public static Point ConvertToImageCoords(Point pictureBoxCoord, Size pictureBoxsize, Size ImageSize)
        {

            Double zoomW = ((Double)pictureBoxsize.Width / (Double)ImageSize.Width);
            Double zoomH = ((Double)pictureBoxsize.Height/ (Double)ImageSize.Height);
            Double zoomActual = Math.Min(zoomW, zoomH);
            Double padX = zoomActual == zoomW ? 0 : ((Double)pictureBoxsize.Width - (zoomActual * ImageSize.Width)) / 2.0;
            Double padY = zoomActual == zoomH ? 0 : ((Double)pictureBoxsize.Height- (zoomActual * ImageSize.Height)) / 2.0;

            Int32 realX = (Int32)((pictureBoxCoord.X - padX) / zoomActual);
            Int32 realY = (Int32)((pictureBoxCoord.Y - padY) / zoomActual);

            return new Point(realX, realY);
        }
        public static Point ConvertFromImageCoords(Point pictureBoxCoord, Size pictureBoxsize, Size ImageSize)
        {
            Double zoomW = ((Double)ImageSize.Width / (Double)pictureBoxsize.Width);
            Double zoomH = ((Double)ImageSize.Height / (Double)pictureBoxsize.Height);
            Double zoomActual = Math.Max(zoomW, zoomH);
            Double padX = zoomActual == zoomW ? 0 : ((Double)ImageSize.Width - (zoomActual * pictureBoxsize.Width)) / 2.0;
            Double padY = zoomActual == zoomH ? 0 : ((Double)ImageSize.Height- (zoomActual * pictureBoxsize.Height)) / 2.0;

            Int32 adjX = (Int32)((pictureBoxCoord.X- padX) / zoomActual);
            Int32 adjY= (Int32)((pictureBoxCoord.Y-padY) / zoomActual);

            return new Point(adjX, adjY);
        }
    }
}
