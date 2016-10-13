using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Configuration;

namespace RecipeBookSystem.BL.Helpers
{
    class CloudHelper
    {
        Cloudinary _cloudinary;

        public CloudHelper()
        {
            //// TODO: Create class ConfigurationManagerHelper that will
            //// contain methods for getting configs and throw exceptions 
            //// if config value does not exists.
            string apiKey = ConfigurationManager.AppSettings["Api_Key"];
            string cloudName = ConfigurationManager.AppSettings["Cloud_Name"];
            string apiSecret = ConfigurationManager.AppSettings["Api_Secret"];

            var account = new Account(cloudName, apiKey, apiSecret);

            _cloudinary = new Cloudinary(account);
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
