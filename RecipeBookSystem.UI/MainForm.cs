using MaterialSkin.Controls;
using RecipeBookSystem.BL.Helpers;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;
using RecipeBookSystem.UI.Models;
using RecipeBookSystem.UI.Models.FormModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeBookSystem.UI
{ 
    public partial class MainForm : MaterialFormBaseModel
    {
        //Додати в ресурси
        private string deleteIconPath = @"D:\DeleteIcon.png";
        private string editIconPath = @"D:\AditIcon.png";
        private string path = @"D:\default.gif";
        private string standartImagePath = @"D:\Standart.png";
        private string leftSideImagePath = @"D:\left.png";
        private string rightSideImagePath = @"D:\right.png";

        private readonly UserModel loginedUser;

        private const int sortButtonCount = 4;
        private const int tableColumnCount = 7;
        private const int productsPerPageCount = 5;
        private const int productPhotoWeigth = 80;
        private const int productPhotoHeight = 64;
        private const int nameSortButtonPosition = 0;
        private const int proteinsSortButtonPosition = 1;
        private const int fatsSortButtonPosition = 2;
        private const int carbsSortButtonPosition = 3;

        private readonly ProductProvider productProvider;
        private readonly ProductTypeProvider productTypeProvider;
        private readonly ImageHelper imageHelper;

        private List<ProductItem> productItems;
        private List<ProductModel> selectedProducts;
        private List<ProductTypeModel> productTypes;
        private Control[] sortButtons;
        private ProductsGridOptions productsGridOptions;

        private ProductModel updatingProduct;
        ProductModel newProduct;

        ProductsManipulationPlan productsManipulationPlan;

        Control[] rowLabels;

        Image editIcom;
        Image deleteIcon;

        Image spinner;
        Image productDefaultImage;

        public MainForm(UserModel loginedUser)
        {
            InitializeComponent();
            
            this.loginedUser = loginedUser;
            this.label1.Text = loginedUser.Id.ToString();
            this.label1.Text += loginedUser.Name;

            productProvider = new ProductProvider();
            imageHelper = new ImageHelper();
            productTypeProvider = new ProductTypeProvider();  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.spinner = Image.FromFile(path);
            this.productDefaultImage = Image.FromFile(standartImagePath);

            this.productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;

            InitializeProductList();
        }

        #region Product list view logic
        private void InitializeProductList()
        {
            this.newProduct = new ProductModel();
            this.updatingProduct = new ProductModel();
            this.editIcom = Image.FromFile(editIconPath);
            this.deleteIcon = Image.FromFile(deleteIconPath);
            this.creatingProductPhoto.Image = productDefaultImage;

            this.selectedProducts = new List<ProductModel>();
            this.productItems = new List<ProductItem>();

            this.sortButtons = new Control[sortButtonCount];

            productsGridOptions = new ProductsGridOptions()
            {
                ItemsCount = productsPerPageCount,
                PageNumber = 1
            };

            this.productTypes = productTypeProvider.GetAllProductTypes().ToList();

            foreach (var productType in productTypes)
            {
                filterProductComboBox.Items.Insert(productType.Id, productType.Name);
                creatingProductTypeSelector.Items.Insert(productType.Id, productType.Name);
            }

            this.sortButtons[nameSortButtonPosition] = nameSortButton;
            this.sortButtons[proteinsSortButtonPosition] = proteinsSortButton;
            this.sortButtons[fatsSortButtonPosition] = fatsSortButton;
            this.sortButtons[carbsSortButtonPosition] = carbsSortButton;

            var leftSideImage = new Bitmap(leftSideImagePath);
            var rightSideImag = new Bitmap(rightSideImagePath);

            this.leftSideButton.Image = leftSideImage;
            this.rightSideButton.Image = rightSideImag;
            this.leftSideButton.Enabled = false;
            this.filterProductComboBox.SelectedIndex = 0;
            this.creatingProductTypeSelector.SelectedIndex = 0;

            this.makeRecipeButton.Hide();

            this.filterProductComboBox.SelectedValueChanged += (sender, e) =>
            {
                filterProducts();
            };

            this.backgroundImageUploader.WorkerSupportsCancellation = true;
            showProducts();
            this.backgroundImageUploader.RunWorkerAsync();
        }

        private void clearTable()
        {
            this.productTableView.Controls.Clear();
            this.productItems = new List<ProductItem>();
        }

        private void changePlan(ProductItem productItem)
        {
            if(selectedProducts.Count > 1)
            {
                this.makeRecipeButton.Show();
            }
            else if (selectedProducts.Count == 1)
            {
                this.makeRecipeButton.Hide();
            }
            else
            {
                this.makeRecipeButton.Hide();
            }
        }

        private void showProducts()
        {
            this.backgroundImageUploader.CancelAsync();
            clearTable();
            this.rightSideButton.Enabled = true;

            int row = productItems.Count;

            List<ProductModel> filteredProducts;

            if (productsGridOptions.searchedProductName == null
                || productsGridOptions.searchedProductName == string.Empty)
            {
                filteredProducts = productProvider.GetProducts(
                productsPerPageCount,
                productsGridOptions.PageNumber,
                productsGridOptions.SortColumnName,
                productsGridOptions.SortOrder, 
                productsGridOptions.FilterProductTypeId).ToList();
            }
            else
            {
                this.productsGridOptions.PageNumber = 1;
                this.leftSideButton.Enabled = false;
                filteredProducts = productProvider.SearchProductByName(
                    productsGridOptions.searchedProductName).ToList();
            }

            if(filteredProducts.Count == 0)
            {
                this.noMoreProductMessageLabel.Visible = true;
                this.rightSideButton.Enabled = false;
                return;
            }

            this.noMoreProductMessageLabel.Visible = false;
            this.rightSideButton.Enabled = true;

            foreach (var product in filteredProducts)
            {
                MaterialCheckBox productCheckBox = new MaterialCheckBox();
                productCheckBox.Anchor = AnchorStyles.Bottom & AnchorStyles.None;

                this.rowLabels = new Control[tableColumnCount];

                foreach (var selectedProduct in selectedProducts)
                {
                    if (selectedProduct.Id == product.Id)
                    {
                        productCheckBox.Checked = true;
                    }
                }

                this.rowLabels[0] = productCheckBox;
                int initialTableDataColIndex = 2;
                for (int i = initialTableDataColIndex; i < rowLabels.Length; i++)
                {
                    this.rowLabels[i] = new Label();
                    this.rowLabels[i].AutoSize = true;
                    this.rowLabels[i].Anchor = AnchorStyles.None;
                    this.rowLabels[i].Font = new Font("Berlin Sans FB", 14F);
                    this.productTableView.Controls.Add(rowLabels[i], i, row);
                }

                var productItem = new ProductItem(product);
                productItem.Position = row;
                productItems.Add(productItem);
                
                //Перенести у функцію з (sender, e)
                productCheckBox.CheckedChanged += (sender, e) =>
                {
                    var chackBox = (MaterialCheckBox)sender;
                    productItem.IsSelected = chackBox.Checked;
                    if (productItem.IsSelected)
                    {
                        if (selectedProducts.Count == 0)
                        {
                            selectedProductsListBox.Items.RemoveAt(0);
                        }
                        this.selectedProductsListBox.Items.Insert(0, productItem.ProductModel.Name);
                        this.selectedProducts.Add(productItem.ProductModel);
                    }
                    else if (!productItem.IsSelected)
                    {
                        this.selectedProducts.RemoveAll((p) => (p.Id == productItem.ProductModel.Id));

                        this.selectedProductsListBox.Items.Remove(productItem.ProductModel.Name);
                            
                        if (selectedProducts.Count == 0)
                        {
                            this.selectedProductsListBox.Items.Insert(0, "No products yet");
                        }
                    }
                    changePlan(productItem);
                };

                this.productTableView.Controls.Add(productCheckBox, 0, row);
                this.productTableView.Controls.Add(rowLabels[0], 0, row);

                var deleteIconLabel = new Label();
                var editIconLabel = new Label();
                
                editIconLabel.Anchor = AnchorStyles.Left;
                deleteIconLabel.Anchor = AnchorStyles.Left;

                deleteIconLabel.Width = 25;

                deleteIconLabel.Image = deleteIcon;
                editIconLabel.Image = editIcom;

                deleteIconLabel.Click += (sender, e) =>
                {
                    deleteProduct(productItem.ProductModel); 
                };

                editIconLabel.Click += (sender, e) =>
                {
                    setProductToUpdate(productItem);
                };

                this.productTableView.Controls.Add(editIconLabel, 7, row);
                this.productTableView.Controls.Add(deleteIconLabel, 8, row);

                productItem.PictureLabel = new Label();
                productItem.PictureLabel.AutoSize = true;
                productItem.PictureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
                productItem.PictureLabel.Text = string.Format("{0,4}", string.Empty);
                productItem.PictureLabel.Anchor = AnchorStyles.None;
                this.productTableView.Controls.Add(productItem.PictureLabel, 1, row);

                this.rowLabels[2].Text = product.Name;
                this.rowLabels[3].Text = product.ProductTypeName;
                this.rowLabels[4].Text = product.Proteins.ToString();
                this.rowLabels[5].Text = product.Fats.ToString();
                this.rowLabels[6].Text = product.Carbohydrates.ToString();
                row++;
                this.productTableView.Refresh();

            }
        }

        private void deleteProduct(ProductModel productToDelete)
        {
            this.productProvider.DeleteProduct(productToDelete.Id);
            
            foreach(var selectedProduct in selectedProducts)
            {
                if(selectedProduct.Id == productToDelete.Id)
                {
                    this.selectedProductsListBox.Items.Remove(productToDelete.Name);
                    break;
                }
            }

            this.selectedProducts.RemoveAll((p) => (p.Id == productToDelete.Id));

            if (selectedProductsListBox.Items.Count == 0)
            {
                this.selectedProductsListBox.Items.Insert(0, "No products yet");
            }

            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                this.backgroundImageUploader.RunWorkerAsync();
            }
        }


        private void setProductToUpdate(ProductItem productToUpdate)
        {
            this.newProduct.SmallPhotoLink = productToUpdate.ProductModel.SmallPhotoLink;
            this.updete_createProductButton.Text = "UPDATE";

            this.updatingProduct = productToUpdate.ProductModel;
            this.productsManipulationPlan = ProductsManipulationPlan.UpdatingExistingProduct;

            creatingProductNameTextField.Text = productToUpdate.ProductModel.Name;
            creatingProductProteinsTextField.Text = productToUpdate.ProductModel.Proteins.ToString();
            creatingProductFatsTextField.Text = productToUpdate.ProductModel.Fats.ToString();
            creatingProductCarbsTextField.Text = productToUpdate.ProductModel.Carbohydrates.ToString();
            creatingProductPhoto.Image = productToUpdate.PictureLabel.Image;

            this.creatingProductTypeSelector.SelectedIndex = productToUpdate.ProductModel.productTypeId;

            this.pages.SelectedTab = addingProductPage;
        }

        private void backgroundImageUploader_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread imageLoader = new Thread(() =>
            {
                showProductsImages();
            });
            imageLoader.Start();
        }

        private void showProductsImages()
        {
            this.spinner = Image.FromFile(path);

            foreach (var item in productItems)
            {
                if (item.PictureLabel.Image == null)
                {
                    item.PictureLabel.Image = spinner;
                }
            }

            foreach (var item in productItems)
            {
                if (item.PictureLabel.Image == spinner || item.PictureLabel.Image == null)
                {
                    try
                    {
                        Bitmap image = imageHelper.GetImage(item.ProductModel.SmallPhotoLink);
                        item.PictureLabel.Image = image;
                    }
                    catch
                    {
                        item.PictureLabel.Image = productDefaultImage;
                    }
                }
            }
        }

        private void nameSortButton_Click(object sender, EventArgs e)
        {
            sortProducts((Button)sender, "Name");
        }

        private void proteinsSortButton_Click(object sender, EventArgs e)
        {
            sortProducts((Button)sender, "Proteins");
        }
        //Додати в проект модел сорт пропертісз цими констатнатами
        private void fatsSortButton_Click(object sender, EventArgs e)
        {
            sortProducts((Button)sender, "Fats");
        }

        private void carbsSortButton_Click(object sender, EventArgs e)
        {
            sortProducts((Button)sender, "Carbohydrates");
        }

        private void sortProducts(Button clickedButton, string sortColumn)
        {
            this.leftSideButton.Enabled = false;
            clickedButton.Enabled = false;
            string upper = "⇑";
            string lower = "⇓";

            foreach(var button in sortButtons)
            {
                if(button != clickedButton)
                {
                    button.Text = button.Text.Split(' ')[0];
                }
            }
            clearTable();
            this.productsGridOptions.SortColumnName = sortColumn;
            this.productsGridOptions.PageNumber = 1;
            string[] buttonTextWords = clickedButton.Text.Split(' ');
            if (buttonTextWords.Length > 1)
            {
                if (buttonTextWords[1] == upper)
                {
                    clickedButton.Text = buttonTextWords[0] + " " + lower;
                    this.productsGridOptions.SortOrder = "ASC";
                }
                else if (buttonTextWords[1] == lower)
                {
                    clickedButton.Text = buttonTextWords[0] + " " + upper;
                    this.productsGridOptions.SortOrder = "DESC";
                }
            }
            else
            {
                clickedButton.Text += " " + lower;
                this.productsGridOptions.SortOrder = "ASC";
            }
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                this.backgroundImageUploader.RunWorkerAsync();
            }
            clickedButton.Enabled = true;
        }
        

        private void leftSideButton_Click(object sender, EventArgs e)
        {
            var clicked = (Button)sender;
            clicked.Enabled = false;
            this.productsGridOptions.PageNumber--;
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                this.backgroundImageUploader.RunWorkerAsync();
            }
            clicked.Enabled = (productsGridOptions.PageNumber != 1);
        }  

        private void rightSideButton_Click(object sender, EventArgs e)
        {
            var clicked = (Button)sender;
            clicked.Enabled = false;
            this.leftSideButton.Enabled = true;
            this.productsGridOptions.PageNumber++;
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                this.backgroundImageUploader.RunWorkerAsync();
            }
        }

        private void filterProducts()
        {
            this.leftSideButton.Enabled = false;
            var selectedTypeId = filterProductComboBox.SelectedIndex;
            this.productsGridOptions.PageNumber = 1;
            if (selectedTypeId == 0)
            {
                this.productsGridOptions.FilterProductTypeId = null;
            }
            else
            {
                this.productsGridOptions.FilterProductTypeId = selectedTypeId;
            }
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                this.backgroundImageUploader.RunWorkerAsync();
            }
        }
        #endregion

        private void addNewProductButton_Click(object sender, EventArgs e)
        {
            clearAddingProductPage();
            this.productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;
            this.pages.SelectedTab = addingProductPage;
            this.updete_createProductButton.Text = "ADD PRODUCT";
        }

        private void clearAddingProductPage()
        {
            this.creatingProductTypeSelector.SelectedIndex = 0;
            this.newProduct.SmallPhotoLink = null;
            this.updatingProduct.SmallPhotoLink = null;
            this.creatingProductPhoto.Image = productDefaultImage;
            this.creatingProductNameTextField.Text = string.Empty;
            this.creatingProductFatsTextField.Text = string.Empty;
            this.creatingProductCarbsTextField.Text = string.Empty;
            this.creatingProductProteinsTextField.Text = string.Empty;
        }

        private void makeRecipeButton_Click(object sender, EventArgs e)
        {
            this.pages.SelectedTab = addingRecipePage;
        }

        private void addingRecipeMessageLabel_Click(object sender, EventArgs e)
        {
            this.pages.SelectedTab = productsPage;
        }

        private void pages_Selected(object sender, TabControlEventArgs e)
        {
            if(pages.SelectedTab == addingRecipePage)
            {
                this.addingRecipeMessageLabel.Visible = (selectedProducts.Count < 2);
            }
        }

        private void updete_createProductButton_Click(object sender, EventArgs e)
        {
            string newProductName = creatingProductNameTextField.Text;
            int newProductTypeId = creatingProductTypeSelector.SelectedIndex;

            float newProductProteinsCount;
            bool hasProteinsValue = Single.TryParse(
                this.creatingProductProteinsTextField.Text,
                out newProductProteinsCount);

            float newProductFatsCount;
            bool hasFatsValue = Single.TryParse(
                this.creatingProductFatsTextField.Text,
                out newProductFatsCount);

            float newProductCarbsCount;
            bool hasCarbsValue = Single.TryParse(
                this.creatingProductCarbsTextField.Text, 
                out newProductCarbsCount);

            if (newProductName == string.Empty)
            {
                MessageBox.Show("Do not leave a clear name field!", "Warning!");
                return;
            }
            else if(newProductTypeId == 0)
            {
                MessageBox.Show("Select the ptoduct type!", "Warning!");
                return;
            }
            else if(newProductName.Length > 20)
            {
                MessageBox.Show("Name is too long!", "Warning!");
                return;
            }
            else if (!hasProteinsValue)
            {
                MessageBox.Show("Incorrect input in proteins field", "Warning!");
                return;
            }
            else if (!hasFatsValue)
            {
                MessageBox.Show("Incorrect input in fats field", "Warning!");
                return;
            }
            else if (!hasCarbsValue)
            {
                MessageBox.Show("Incorrect input in carbohydrades field", "Warning!");
                return;
            }
            else if ((newProductProteinsCount + newProductCarbsCount + newProductFatsCount) > 100)
            {
                MessageBox.Show("The sum of all product parameters can not be more than 100!", "Warning!");
                return;
            }
            
            this.newProduct.Name = newProductName;
            this.newProduct.Proteins = newProductProteinsCount;
            this.newProduct.Fats = newProductFatsCount;
            this.newProduct.Carbohydrates = newProductCarbsCount;
            this.newProduct.productTypeId = newProductTypeId;
            
            if (productsManipulationPlan == ProductsManipulationPlan.UpdatingExistingProduct)
            {
                this.newProduct.Id = updatingProduct.Id;

                productProvider.UpdateProduct(
                    newProduct.Id,
                    newProduct.Name,
                    newProduct.productTypeId,
                    newProduct.Proteins,
                    newProduct.Fats,
                    newProduct.Carbohydrates,
                    newProduct.SmallPhotoLink);
            }
            else
            {
                this.productProvider.AddProduct(newProduct);
                this.productsGridOptions.FilterProductTypeId = null;
                this.productsGridOptions.PageNumber = 1;
            }
            clearTable();
            showProducts();
            pages.SelectedTab = productsPage;
            if (!backgroundImageUploader.IsBusy)
            {
                this.backgroundImageUploader.RunWorkerAsync();
            }
            clearAddingProductPage();
            this.updete_createProductButton.Text = "ADD PRODUCT";
        }

        private void photoAddMessageLabel_Click(object sender, EventArgs e)
        {
            this.creatingProductPhoto.Image = spinner;

            var newPhoto = imageHelper.GetImageFromComputer();

            if (newPhoto != null)
            {
                Thread newImageLoader = new Thread(() =>
                {
                    loadNewImage(this.creatingProductPhoto, newPhoto);
                });
                newImageLoader.Start();
            }
        }

        private void loadNewImage(PictureBox element, Bitmap image)
        {
            try
            {
                string newImageLink = imageHelper.UploadImage(
                    image,
                    productPhotoWeigth, 
                    productPhotoHeight);

                this.newProduct.SmallPhotoLink = newImageLink;

                element.Image = imageHelper.GetImage(newImageLink);
            }
            catch
            {
                element.Image = productDefaultImage;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void searchProductTextField_TextChanged(object sender, EventArgs e)
        {
            clearTable();
            this.productItems = new List<ProductItem>();

            string name = this.searchProductTextField.Text;

            bool isEmptyName = (name == string.Empty);

            foreach (var sortButton in this.sortButtons)
            {
                sortButton.Visible = isEmptyName;
            }

            this.filterProductComboBox.Visible = isEmptyName;

            var searchedProducts = this.productProvider.SearchProductByName(name);

            this.productsGridOptions.searchedProductName = name;

            showProducts();
            this.pages.SelectedTab = productsPage;
            if (!backgroundImageUploader.IsBusy)
            {
                this.backgroundImageUploader.RunWorkerAsync();
            }
        }
    }
}

