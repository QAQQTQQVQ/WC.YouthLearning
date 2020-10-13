using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace WC.YouthLearning.Common
{
    public static class SaveImage
    {
        public static bool ByStringToSave(string name,string iss)
        {
            iss = iss.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
                .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
            byte[] arr = Convert.FromBase64String(iss);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            bmp.Save(@"./wwwroot/StudentImage/"+name+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();
            return true;
        }
        public static bool CreateZip()
        {
            ZipFile.CreateFromDirectory(@"./wwwroot/StudentImage/", @"./wwwroot/StudentImage.zip");
            return true;
        }
        public static bool DelectAll()
        {
            if (Directory.Exists(@"./wwwroot/StudentImage/"))
            {
                DelectDir(@"./wwwroot/StudentImage/");
                File.Delete(@"./wwwroot/StudentImage.zip");
                return true;
            }
            else
                return false;
        }
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
