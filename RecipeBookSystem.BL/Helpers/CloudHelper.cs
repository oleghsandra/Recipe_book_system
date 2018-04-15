using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RecipeBookSystem.BL.Helpers.Abstraction;
using System.Configuration;

namespace RecipeBookSystem.BL.Helpers
{
    /// <summary>
    /// The class that provides an opportunity to work with cloud
    /// </summary>
    public class CloudHelper : ICloudHelper
    {
        private Cloudinary _cloudinary;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudHelper"/> class.
        /// </summary>
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
        
        /// <summary>
        /// Method upload image to cloud
        /// </summary>
        /// <param name="imagePath">Path of image in computer</param>
        /// <returns>String - image link in the internet</returns>
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
