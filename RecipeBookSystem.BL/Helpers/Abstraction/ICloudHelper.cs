namespace RecipeBookSystem.BL.Helpers.Abstraction
{
    public interface ICloudHelper
    {
        /// <summary>
        /// Method upload image to cloud
        /// </summary>
        /// <param name="imagePath">Path of image in computer</param>
        /// <returns>String - image link in the internet</returns>
        string UploadImage(string imagePath);
    }
}
