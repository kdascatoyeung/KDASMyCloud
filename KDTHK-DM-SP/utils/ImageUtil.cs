using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace KDTHK_DM_SP.utils
{
    public class ImageUtil
    {
        public static void SaveImage(string path, Bitmap img, long quality)
        {
            EncoderParameter param = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            ImageCodecInfo jpgCodec = getEncoderInfo("image/jpeg");
            if (jpgCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = param;

            img.Save(path, jpgCodec, encoderParams);
        }

        private static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }
    }
}
