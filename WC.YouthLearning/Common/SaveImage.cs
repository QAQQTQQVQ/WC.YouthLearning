using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace WC.YouthLearning.Common
{
    public static class SaveImage
    {
        public static bool ByStringToSave(string iss)
        {
            iss = iss.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
                .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
            byte[] arr = Convert.FromBase64String(iss);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            bmp.Save(@"~/StudentImage/test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();
            return true;
        }
    }
}
