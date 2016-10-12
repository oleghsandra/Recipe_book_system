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

        private readonly UserModel currentUser;

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

        public MainForm(UserModel currentUser)
        {
            InitializeComponent();
            
            this.currentUser = currentUser;
            label1.Text = currentUser.Id.ToString();
            label1.Text += currentUser.Name;

            productProvider = new ProductProvider();
            imageHelper = new ImageHelper();
            productTypeProvider = new ProductTypeProvider();  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            spinner = Image.FromFile(path);
            productDefaultImage = Image.FromFile(standartImagePath);

            productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;

            InitializeProductList();
        }

        #region Product list view logic
        private void InitializeProductList()
        {
            newProduct = new ProductModel();
            updatingProduct = new ProductModel();
            editIcom = Image.FromFile(editIconPath);
            deleteIcon = Image.FromFile(deleteIconPath);
            creatingProductPhoto.Image = productDefaultImage;

            selectedProducts = new List<ProductModel>();
            productItems = new List<ProductItem>();

            sortButtons = new Control[sortButtonCount];

            productsGridOptions = new ProductsGridOptions()
            {
                ItemsCount = productsPerPageCount,
                PageNumber = 1
            };

            productTypes = productTypeProvider.GetAllProductTypes().ToList();

            foreach (var productType in productTypes)
            {
                filterProductComboBox.Items.Insert(productType.Id, productType.Name);
                creatingProductTypeSelector.Items.Insert(productType.Id, productType.Name);
            }

            sortButtons[nameSortButtonPosition] = nameSortButton;
            sortButtons[proteinsSortButtonPosition] = proteinsSortButton;
            sortButtons[fatsSortButtonPosition] = fatsSortButton;
            sortButtons[carbsSortButtonPosition] = carbsSortButton;

            var leftSideImage = new Bitmap(leftSideImagePath);
            var rightSideImag = new Bitmap(rightSideImagePath);

            leftSideButton.Image = leftSideImage;
            rightSideButton.Image = rightSideImag;
            leftSideButton.Enabled = false;
            filterProductComboBox.SelectedIndex = 0;
            creatingProductTypeSelector.SelectedIndex = 0;

            makeRecipeButton.Hide();

            filterProductComboBox.SelectedValueChanged += (sender, e) =>
            {
                filterProducts();
            };

            backgroundImageUploader.WorkerSupportsCancellation = true;
            showProducts();
            backgroundImageUploader.RunWorkerAsync();
        }

        private void clearTable()
        {
            productTableView.Controls.Clear();
            productItems = new List<ProductItem>();
        }

        private void changePlan(ProductItem productItem)
        {
            if(selectedProducts.Count > 1)
            {
                makeRecipeButton.Show();
            }
            else if (selectedProducts.Count == 1)
            {
                makeRecipeButton.Hide();
            }
            else
            {
                makeRecipeButton.Hide();
            }
        }

        private void showProducts()
        {
            backgroundImageUploader.CancelAsync();
            clearTable();
            rightSideButton.Enabled = true;

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
                productsGridOptions.PageNumber = 1;
                leftSideButton.Enabled = false;
                filteredProducts = productProvider.SearchProductByName(
                    productsGridOptions.searchedProductName).ToList();
            }

            if(filteredProducts.Count == 0)
            {
                noMoreProductMessageLabel.Visible = true;
                rightSideButton.Enabled = false;
                return;
            }

            noMoreProductMessageLabel.Visible = false;
            rightSideButton.Enabled = true;

            foreach (var product in filteredProducts)
            {
                MaterialCheckBox productCheckBox = new MaterialCheckBox();
                productCheckBox.Anchor = AnchorStyles.Bottom & AnchorStyles.None;
                
                rowLabels = new Control[tableColumnCount];

                foreach (var selectedProduct in selectedProducts)
                {
                    if (selectedProduct.Id == product.Id)
                    {
                        productCheckBox.Checked = true;
                    }
                }

                rowLabels[0] = productCheckBox;
                int initialTableDataColIndex = 2;
                for (int i = initialTableDataColIndex; i < rowLabels.Length; i++)
                {
                    rowLabels[i] = new Label();
                    rowLabels[i].AutoSize = true;
                    rowLabels[i].Anchor = AnchorStyles.None;
                    rowLabels[i].Font = new Font("Berlin Sans FB", 14F);
                    productTableView.Controls.Add(rowLabels[i], i, row);
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
                        selectedProductsListBox.Items.Insert(0, productItem.ProductModel.Name);
                        selectedProducts.Add(productItem.ProductModel);
                    }
                    else if (!productItem.IsSelected)
                    {
                        selectedProducts.RemoveAll((p) => (p.Id == productItem.ProductModel.Id));
                        
                        selectedProductsListBox.Items.Remove(productItem.ProductModel.Name);
                            
                        if (selectedProducts.Count == 0)
                        {
                            selectedProductsListBox.Items.Insert(0, "No products yet");
                        }
                    }
                    changePlan(productItem);
                };

                productTableView.Controls.Add(productCheckBox, 0, row);
                productTableView.Controls.Add(rowLabels[0], 0, row);

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

                productTableView.Controls.Add(editIconLabel, 7, row);
                productTableView.Controls.Add(deleteIconLabel, 8, row);

                productItem.PictureLabel = new Label();
                productItem.PictureLabel.AutoSize = true;
                productItem.PictureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
                productItem.PictureLabel.Text = string.Format("{0,4}", string.Empty);
                productItem.PictureLabel.Anchor = AnchorStyles.None;
                productTableView.Controls.Add(productItem.PictureLabel, 1, row);

                rowLabels[2].Text = product.Name;
                rowLabels[3].Text = product.ProductTypeName;
                rowLabels[4].Text = product.Proteins.ToString();
                rowLabels[5].Text = product.Fats.ToString();
                rowLabels[6].Text = product.Carbohydrates.ToString();
                row++;
                productTableView.Refresh();

            }
        }

        private void deleteProduct(ProductModel productToDelete)
        {
            productProvider.DeleteProduct(productToDelete.Id);
            
            foreach(var selectedProduct in selectedProducts)
            {
                if(selectedProduct.Id == productToDelete.Id)
                {
                    selectedProductsListBox.Items.Remove(productToDelete.Name);
                    break;
                }
            }

            selectedProducts.RemoveAll((p) => (p.Id == productToDelete.Id));

            if (selectedProductsListBox.Items.Count == 0)
            {
                selectedProductsListBox.Items.Insert(0, "No products yet");
            }

            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                backgroundImageUploader.RunWorkerAsync();
            }
        }


        private void setProductToUpdate(ProductItem productToUpdate)
        {
            newProduct.SmallPhotoLink = productToUpdate.ProductModel.SmallPhotoLink;
            updete_createProductButton.Text = "UPDATE";

            updatingProduct = productToUpdate.ProductModel;
            productsManipulationPlan = ProductsManipulationPlan.UpdatingExistingProduct;

            creatingProductNameTextField.Text = productToUpdate.ProductModel.Name;
            creatingProductProteinsTextField.Text = productToUpdate.ProductModel.Proteins.ToString();
            creatingProductFatsTextField.Text = productToUpdate.ProductModel.Fats.ToString();
            creatingProductCarbsTextField.Text = productToUpdate.ProductModel.Carbohydrates.ToString();
            creatingProductPhoto.Image = productToUpdate.PictureLabel.Image;
            
            creatingProductTypeSelector.SelectedIndex = productToUpdate.ProductModel.productTypeId;

            pages.SelectedTab = addingProductPage;
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
            spinner = Image.FromFile(path);

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
            leftSideButton.Enabled = false;
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
            productsGridOptions.SortColumnName = sortColumn;
            productsGridOptions.PageNumber = 1;
            string[] buttonTextWords = clickedButton.Text.Split(' ');
            if (buttonTextWords.Length > 1)
            {
                if (buttonTextWords[1] == upper)
                {
                    clickedButton.Text = buttonTextWords[0] + " " + lower;
                    productsGridOptions.SortOrder = "ASC";
                }
                else if (buttonTextWords[1] == lower)
                {
                    clickedButton.Text = buttonTextWords[0] + " " + upper;
                    productsGridOptions.SortOrder = "DESC";
                }
            }
            else
            {
                clickedButton.Text += " " + lower;
                productsGridOptions.SortOrder = "ASC";
            }
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                backgroundImageUploader.RunWorkerAsync();
            }
            clickedButton.Enabled = true;
        }
        

        private void leftSideButton_Click(object sender, EventArgs e)
        {
            var clicked = (Button)sender;
            clicked.Enabled = false;
            productsGridOptions.PageNumber--;
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                backgroundImageUploader.RunWorkerAsync();
            }
            clicked.Enabled = (productsGridOptions.PageNumber != 1);
        }  

        private void rightSideButton_Click(object sender, EventArgs e)
        {
            var clicked = (Button)sender;
            clicked.Enabled = false;
            leftSideButton.Enabled = true;
            productsGridOptions.PageNumber++;
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                backgroundImageUploader.RunWorkerAsync();
            }
        }

        private void filterProducts()
        {
            leftSideButton.Enabled = false;
            var selectedTypeId = filterProductComboBox.SelectedIndex;
            productsGridOptions.PageNumber = 1;
            if (selectedTypeId == 0)
            {
                productsGridOptions.FilterProductTypeId = null;
            }
            else
            {
                productsGridOptions.FilterProductTypeId = selectedTypeId;
            }
            showProducts();
            if (!backgroundImageUploader.IsBusy)
            {
                backgroundImageUploader.RunWorkerAsync();
            }
        }
        #endregion

        private void addNewProductButton_Click(object sender, EventArgs e)
        {
            clearAddingProductPage();
            productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;
            pages.SelectedTab = addingProductPage;
        }

        private void clearAddingProductPage()
        {
            creatingProductTypeSelector.SelectedIndex = 0;
            newProduct.SmallPhotoLink = null;
            updatingProduct.SmallPhotoLink = null;
            creatingProductPhoto.Image = productDefaultImage;
            creatingProductNameTextField.Text = string.Empty;
            creatingProductFatsTextField.Text = string.Empty;
            creatingProductCarbsTextField.Text = string.Empty;
            creatingProductProteinsTextField.Text = string.Empty;
        }

        private void makeRecipeButton_Click(object sender, EventArgs e)
        {
            pages.SelectedTab = addingRecipePage;
        }

        private void addingRecipeMessageLabel_Click(object sender, EventArgs e)
        {
            pages.SelectedTab = productsPage;
        }

        private void addingRecipePage_Click(object sender, EventArgs e)
        {

        }

        private void pages_Selected(object sender, TabControlEventArgs e)
        {
            if(pages.SelectedTab == addingRecipePage)
            {
                addingRecipeMessageLabel.Visible = (selectedProducts.Count < 2);
            }
        }

        private void updete_createProductButton_Click(object sender, EventArgs e)
        {
            string newProductName = creatingProductNameTextField.Text;
            int newProductTypeId = creatingProductTypeSelector.SelectedIndex;

            float newProductProteinsCount;
            bool hasProteinsValue = Single.TryParse(creatingProductProteinsTextField.Text, out newProductProteinsCount);

            float newProductFatsCount;
            bool hasFatsValue = Single.TryParse(creatingProductFatsTextField.Text, out newProductFatsCount);

            float newProductCarbsCount;
            bool hasCarbsValue = Single.TryParse(creatingProductCarbsTextField.Text, out newProductCarbsCount);

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
            
            newProduct.Name = newProductName;
            newProduct.Proteins = newProductProteinsCount;
            newProduct.Fats = newProductFatsCount;
            newProduct.Carbohydrates = newProductCarbsCount;
            newProduct.productTypeId = newProductTypeId;
            
            if (productsManipulationPlan == ProductsManipulationPlan.UpdatingExistingProduct)
            {
                newProduct.Id = updatingProduct.Id;

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
                productProvider.AddProduct(newProduct);
                productsGridOptions.FilterProductTypeId = null;
                productsGridOptions.PageNumber = 1;
            }
            clearTable();
            showProducts();
            pages.SelectedTab = productsPage;
            if (!backgroundImageUploader.IsBusy)
            {
                backgroundImageUploader.RunWorkerAsync();
            }
            clearAddingProductPage();
            updete_createProductButton.Text = "ADD PRODUCT";
        }
        private void filterProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void photoAddMessageLabel_Click(object sender, EventArgs e)
        {
            creatingProductPhoto.Image = spinner;

            var newPhoto = imageHelper.GetImageFromComputer();

            if (newPhoto != null)
            {
                Thread newImageLoader = new Thread(() =>
                {
                    loadNewImage(creatingProductPhoto, newPhoto);
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

                newProduct.SmallPhotoLink = newImageLink;

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
            productItems = new List<ProductItem>();

            string name = searchProductTextField.Text;

            bool isEmptyName = (name == string.Empty);

            foreach (var sortButton in sortButtons)
            {
                sortButton.Visible = isEmptyName;
            }

            filterProductComboBox.Visible = isEmptyName;

            var searchedProducts = productProvider.SearchProductByName(name);

            productsGridOptions.searchedProductName = name;

            showProducts();
            pages.SelectedTab = productsPage;
            if (!backgroundImageUploader.IsBusy)
            {
                backgroundImageUploader.RunWorkerAsync();
            }
        }
    }
}

