using System.Drawing;
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

        public string AddImageFromComputer(int width, int height)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                var minimizedImage = new Bitmap(image, width, height);

                string minimizedImagePath = @"D:\SmallImage.bmp";//Path.GetDirectoryName(Application.ExecutablePath);
                //minimizedImagePath += @"SmallImage.bmp";

                minimizedImage.Save(minimizedImagePath);

                return _cloud.UploadImage(minimizedImagePath);
            }
            return string.Empty;
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