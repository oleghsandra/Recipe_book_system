using RecipeBookSystem.Model.Models;
using System.Windows.Forms;

namespace RecipeBookSystem.UI.Models
{
    public class ProductItem
    {
        /// <summary>
        /// Gets or sets a value indicated if product item is selected
        /// </summary>
        public bool IsSelected { get; set; }

        public int Position { get; set; }

        /// <summary>
        /// Gets or sets a label with image
        /// </summary>
        public Label PictureLabel { get; set; }

        /// <summary>
        /// Gets the product model
        /// </summary>
        public ProductModel ProductModel
        {
            get;
            private set;
        }

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

