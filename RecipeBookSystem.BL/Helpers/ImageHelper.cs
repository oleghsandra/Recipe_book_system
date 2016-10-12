using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RecipeBookSystem.BL.Helpers
{
    public class ImageHelper
    {
        private CloudHelper _cloud;

        public ImageHelper()
        {
            _cloud = new CloudHelper();
        }

        public Bitmap GetImageFromComputer()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                return image;
            }
            return null;
        }

        public string UploadImage(Bitmap image, int width, int height)
        {
            var minimizedImage = new Bitmap(image, width, height);

            string minimizedImagePath = Path.GetDirectoryName(Application.ExecutablePath);
            minimizedImagePath += @"SmallImage.bmp";

            minimizedImage.Save(minimizedImagePath);

            return _cloud.UploadImage(minimizedImagePath);
        }

        public Bitmap GetImage(string url)
        {
            Bitmap image;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            image = new Bitmap(responseStream);
            return image;
        }
    }
}