using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ScreenRecordCapture.Recording
{
    class FrameDetails
    {
        public int FrameAddTime;
        public System.Drawing.Bitmap frame;

        public FrameDetails(System.Drawing.Bitmap capture, int frameAddTime)
        {
            FrameAddTime = frameAddTime;
            frame = new System.Drawing.Bitmap(capture);

        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

    }
}
