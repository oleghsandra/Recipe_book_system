using RecipeBookSystem.BL.Helpers.Abstraction;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;

namespace RecipeBookSystem.BL.Helpers
{
    /// <summary>
    /// The class that provides an opportunity to work with images
    /// </summary>
    public class ImageHelper
    {
        private ICloudHelper _cloud;

        //Objects blocking concurrent operations on remote pictures
        private static object imageUploadLockObject = new object();
        private static object imageLoadLockObject = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageHelper"/> class.
        /// </summary>
        /// <param name="cloud">Instance of cloud helper</param>
        public ImageHelper(ICloudHelper cloud)
        {
            _cloud = cloud;
        }

        /// <summary>
        /// Gets image from local computer
        /// </summary>
        /// <param name="path">Path to the local image</param>
        /// <returns>Local image</returns>
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

        /// <summary>
        /// Method upload image to the cloud
        /// </summary>
        /// <param name="image">Image to upload</param>
        /// <param name="width">Target width of image</param>
        /// <param name="height">Target height of image</param>
        /// <returns>String - ling on image in the internet</returns>
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

        /// <summary>
        /// Method for getting Product Default 
        /// Image from resources
        /// </summary>
        /// <returns>Product Default image</returns>
        public Bitmap GetProductDefaultImage()
        {
            return Resources.ProductStandartImage;
        }

        /// <summary>
        /// Method for getting Dish Default 
        /// Image from resources
        /// </summary>
        /// <returns>Dish Default image</returns>
        public Bitmap GetDishDefaultImage()
        {
            return Resources.DishStandartImage;
        }

        /// <summary>
        /// Method gets product image from cloud
        /// if no eny errors
        /// </summary>
        /// <param name="url">Link on the image</param>
        /// <returns>Remove image - if no errors while loading image,
        /// otherwise - defoult product image</returns>
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
            catch
            {
                return Resources.ProductStandartImage;
            }
        }

        /// <summary>
        /// Method gets dish image from cloud
        /// if no eny errors
        /// </summary>
        /// <param name="url">Link on the image</param>
        /// <returns>Remove image - if no errors while loading image,
        /// otherwise - defoult dish image</returns>
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
            catch 
            {
                return Resources.DishStandartImage;
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

        private string getAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }
    }
}