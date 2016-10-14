using RecipeBookSystem.BL.Helpers.Abstraction;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;

namespace RecipeBookSystem.BL.Helpers
{
    public class ImageHelper
    {
        private ICloudHelper _cloud;
        
        private static object imageLoadLockObject = new object();
        private static object imageUploadLockObject = new object();

        public ImageHelper(ICloudHelper cloud)
        {
            _cloud = cloud;
        }

        public Bitmap UploadImageFromComputer(string path)
        {
            Bitmap image;
            try
            {
                image = new Bitmap(path);
            }
            catch (Exception ex)
            {
                throw new Exception("error while getting image computer: " + ex.Message, ex);
            }
            return image;
        }

        public string UploadImage(Bitmap image, int width, int height)
        {
            var minimizedImage = new Bitmap(image, width, height);

            lock(imageUploadLockObject)
            {
                string minimizedImagePath = getAssemblyDirectory();
                minimizedImagePath += "Image.bmp";

                minimizedImage.Save(minimizedImagePath);

                return _cloud.UploadImage(minimizedImagePath);
            }
        }

        private string getAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public Bitmap GetProductDefaultImage()
        {
            return Resources.ProductStandartImage;
        }

        public Bitmap GetDishDefaultImage()
        {
            return Resources.DishStandartImage;
        }

        public Bitmap GetProductImage(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return Resources.ProductStandartImage;
                }

                return getImageByUrl(url);
            }
            catch (WebException)
            {
                return Resources.ProductStandartImage;
            }
            catch (Exception ex)
            {
                throw new Exception("error while getting product image: " + ex.Message, ex);
            }
        }

        public Bitmap GetDishImage(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return Resources.DishStandartImage;
                }

                return getImageByUrl(url);
            }
            catch (WebException)
            {
                return Resources.DishStandartImage;
            }
            catch (Exception ex)
            {
                throw new Exception("error while getting dish image: " + ex.Message, ex);
            }
        }

        private Bitmap getImageByUrl(string url)
        {
            lock (imageLoadLockObject)
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                var image = new Bitmap(responseStream);

                return image;
            }
        }
    }
}