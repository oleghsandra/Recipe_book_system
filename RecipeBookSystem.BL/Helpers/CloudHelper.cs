using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Configuration;

namespace RecipeBookSystem.BL.Helpers
{
    class CloudHelper
    {
        Cloudinary _cloudinary;
        Account _account;

        public CloudHelper()
        {
            string cloudName = ConfigurationManager.AppSettings.Get("Cloud_Name");
            string apiKey = ConfigurationManager.AppSettings.Get("API_Key");
            string apiSecret = ConfigurationManager.AppSettings.Get("API_Secret");

            _account = new Account(cloudName, apiKey, apiSecret);

            _cloudinary = new Cloudinary(_account);
        }

        //Помилка тут, виправити!!!
        public string UploadImage(string imagePath)
        {
            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imagePath)
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.SecureUri.ToString();
        }
    }
}
