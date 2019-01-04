using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helpers
{
    public class ImageHandler
    {
        public static string Base64ImgExt(string base64ImgStr) {

            int startIndex = base64ImgStr.IndexOf('/') + 1;
            int endIndex = base64ImgStr.IndexOf(';');
            int length = endIndex - startIndex;
            return base64ImgStr.Substring(startIndex, length);
        }

        public static bool Base64ToImage(string base64String, string imagePath, string imageName)
        {
            try
            {
                byte[] bytes = null;
                if (base64String.StartsWith("data:image"))
                {
                    bytes = Convert.FromBase64String(base64String.Substring(base64String.IndexOf(',') + 1));
                }
                else
                {
                    bytes = Convert.FromBase64String(base64String);
                }
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }

                if (bytes.Length > 0)
                {
                    using (var stream = new FileStream(Path.Combine(imagePath, imageName), FileMode.Create))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string ImageToBase64(string imagePath) {
            string base64String = "";
            if (File.Exists(imagePath))
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(imagePath);
                base64String = Convert.ToBase64String(imageArray);
            }
            return base64String;
        }
    }
}
