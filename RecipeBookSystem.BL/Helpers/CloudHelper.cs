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
            string apiKey = ConfigurationManager.AppSettings.Get("Api_Key");
            string cloudName = ConfigurationManager.AppSettings.Get("Cloud_Name");
            string apiSecret = ConfigurationManager.AppSettings.Get("Api_Secret");

            _account = new Account(cloudName, apiKey, apiSecret);

            _cloudinary = new Cloudinary(_account);
        }
        
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
