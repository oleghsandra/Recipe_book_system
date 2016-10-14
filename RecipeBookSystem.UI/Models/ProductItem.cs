using RecipeBookSystem.Model.Models;
using System.Windows.Forms;

namespace RecipeBookSystem.UI.Models
{
    public class ProductItem
    {
        /// <summary>
        /// Gets the product model
        /// </summary>
        public ProductModel ProductModel
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a label with image
        /// </summary>
        public Label PictureLabel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModel"/> class.
        /// </summary>
        /// <param name="productModel">Product info model</param>
        public ProductItem(ProductModel productModel)
        {
            this.ProductModel = productModel;
        }
    }
}

