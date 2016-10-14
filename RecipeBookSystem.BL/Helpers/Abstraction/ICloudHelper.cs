using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookSystem.BL.Helpers.Abstraction
{
    public interface ICloudHelper
    {
        string UploadImage(string imagePath);
    }
}
