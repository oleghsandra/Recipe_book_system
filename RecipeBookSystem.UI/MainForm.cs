using MaterialSkin.Controls;
using RecipeBookSystem.BL.Helpers;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;
using RecipeBookSystem.UI.Models;
using RecipeBookSystem.UI.Models.FormModels;
using RecipeBookSystem.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RecipeBookSystem.UI
{ 
    public partial class MainForm : MaterialFormBaseModel
    {   
        private const int sortButtonCount = 4;
        private const int tableColumnCount = 7;
        private const int productsPerPageCount = 5;
        private const int dishesPerPageCount = 2;
        private const int productImageWigth = 80;
        private const int productImageHeight = 64;
        private const int dishImageWeigth = 240;
        private const int dishImageHeight = 144;
        private const int nameSortButtonPosition = 0;
        private const int proteinsSortButtonPosition = 1;
        private const int fatsSortButtonPosition = 2;
        private const int carbsSortButtonPosition = 3;
        private const int ingredientNameTablePosition = 0;
        private const int ingerdientWeightTablePosition = 1;

        private readonly UserModel loggedUser;

        private readonly ProductProvider productProvider;
        private readonly ProductTypeProvider productTypeProvider;
        private readonly ImageHelper imageHelper;
        private readonly IngredientProvider ingredientProvider;
        private readonly DishProvider dishProvider;

        private readonly Font commonFont;
        private readonly Padding commonTablePadding;

        private List<ProductItem> productItems;
        private List<ProductModel> selectedProducts;
        private List<ProductTypeModel> productTypes;
        private Control[] sortButtons;
        private ProductsGridOptions productsGridOptions;

        private DishModel newDishModel;
        private List<IngredientModel> newRecipeIngredients;
        private List<DishItem> dishItems;
        private DishGridOptions dishGridOptions;
        private ProductModel updatingProduct;
        private ProductModel newProduct;

        private ProductsManipulationPlan productsManipulationPlan;

        private Control[] productTableRowLabels;
        
        public MainForm(UserModel loggedUser)
        {
            InitializeComponent();
            
            this.loggedUser = loggedUser;

            productProvider = new ProductProvider();
            imageHelper = new ImageHelper();
            productTypeProvider = new ProductTypeProvider();
            ingredientProvider = new IngredientProvider();
            dishProvider = new DishProvider();

            commonFont = new Font("Berlin Sans FB", 14F);

            commonTablePadding = new Padding(
                0,
                0,
                System.Windows.Forms.SystemInformation.VerticalScrollBarWidth,
                0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;

            InitializeProductList();
            InitializeRecipeAdding();
            InitializeDishList();
        }
        
        #region Product list view logic
        private void InitializeProductList()
        {
            this.newProduct = new ProductModel();
            this.updatingProduct = new ProductModel();
            this.creatingProductPhotoLabel.Image = imageHelper.GetProductDefaultImage();

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

            var leftSideImage = Resources.LeftSideImage;
            var rightSideImag = Resources.RightSideImage;

            this.leftSideProductListButton.Image = leftSideImage;
            this.rightSideProductListButton.Image = rightSideImag;
            this.leftSideProductListButton.Enabled = false;
            this.filterProductComboBox.SelectedIndex = 0;
            this.creatingProductTypeSelector.SelectedIndex = 0;

            this.makeRecipeButton.Hide();

            this.filterProductComboBox.SelectedValueChanged += (sender, e) =>
            {
                filterProducts();
            };

            this.backgroundProductImageUploader.WorkerSupportsCancellation = true;
            showProducts();
            this.backgroundProductImageUploader.RunWorkerAsync();
        }

        private void clearTable()
        {
            this.productTableView.Controls.Clear();
            this.productItems = new List<ProductItem>();
        }

        private void changePlan(ProductItem productItem)
        {
            if (selectedProducts.Count > 1)
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
            this.backgroundProductImageUploader.CancelAsync();
            clearTable();
            this.rightSideProductListButton.Enabled = true;

            int row = productItems.Count;

            List<ProductModel> filteredProducts;

            if (productsGridOptions.searchProductName == null
                || productsGridOptions.searchProductName == string.Empty)
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
                this.leftSideProductListButton.Enabled = false;
                filteredProducts = productProvider.SearchProductByName(
                    productsGridOptions.searchProductName).ToList();
            }

            if (filteredProducts.Count == 0)
            {
                this.noMoreProductMessageLabel.Visible = true;
                this.rightSideProductListButton.Enabled = false;
                return;
            }

            this.noMoreProductMessageLabel.Visible = false;
            this.rightSideProductListButton.Enabled = true;

            foreach (var product in filteredProducts)
            {
                MaterialCheckBox productCheckBox = new MaterialCheckBox();
                productCheckBox.Anchor = AnchorStyles.Bottom & AnchorStyles.None;

                this.productTableRowLabels = new Control[tableColumnCount];

                foreach (var selectedProduct in selectedProducts)
                {
                    if (selectedProduct.Id == product.Id)
                    {
                        productCheckBox.Checked = true;
                    }
                }

                this.productTableRowLabels[0] = productCheckBox;
                int initialTableDataColIndex = 2;

                for (int i = initialTableDataColIndex; i < productTableRowLabels.Length; i++)
                {
                    this.productTableRowLabels[i] = new Label();
                    this.productTableRowLabels[i].AutoSize = true;
                    this.productTableRowLabels[i].Anchor = AnchorStyles.None;
                    this.productTableRowLabels[i].Font = commonFont;
                    this.productTableView.Controls.Add(productTableRowLabels[i], i, row);
                }

                var productItem = new ProductItem(product);
                productItems.Add(productItem);
                
                //Перенести у функцію з (sender, e)
                productCheckBox.CheckedChanged += (sender, e) =>
                {
                    var chackBox = (MaterialCheckBox)sender;
                    if (chackBox.Checked)
                    {
                        if (selectedProducts.Count == 0)
                        {
                            selectedProductsListBox.Items.RemoveAt(0);
                        }

                        this.selectedProductsListBox.Items.Insert(0, productItem.ProductModel.Name);
                        this.selectedProducts.Add(productItem.ProductModel);
                    }
                    else
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
                this.productTableView.Controls.Add(productTableRowLabels[0], 0, row);

                var deleteIconLabel = new Label();
                var editIconLabel = new Label();
                
                editIconLabel.Anchor = AnchorStyles.Left;
                deleteIconLabel.Anchor = AnchorStyles.Left;

                deleteIconLabel.Width = 25;

                deleteIconLabel.Image = Resources.DeleteIcon;
                editIconLabel.Image = Resources.EditIcon;

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
                productItem.PictureLabel.Font = new Font("Microsoft Sans Serif", 50F);
                productItem.PictureLabel.Text = string.Format("{0,4}", string.Empty);
                productItem.PictureLabel.Anchor = AnchorStyles.None;
                this.productTableView.Controls.Add(productItem.PictureLabel, 1, row);

                this.productTableRowLabels[2].Text = product.Name;
                this.productTableRowLabels[3].Text = product.ProductTypeName;
                this.productTableRowLabels[4].Text = product.Proteins.ToString();
                this.productTableRowLabels[5].Text = product.Fats.ToString();
                this.productTableRowLabels[6].Text = product.Carbohydrates.ToString();
                row++;
                this.productTableView.Refresh();

            }
        }

        private void deleteProduct(ProductModel productToDelete)
        {
            this.productProvider.DeleteProduct(productToDelete.Id);
            
            foreach (var selectedProduct in selectedProducts)
            {
                if (selectedProduct.Id == productToDelete.Id)
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
            if (!backgroundProductImageUploader.IsBusy)
            {
                this.backgroundProductImageUploader.RunWorkerAsync();
            }
        }


        private void setProductToUpdate(ProductItem productToUpdate)
        {
            this.newProduct.SmallPhotoLink = productToUpdate.ProductModel.SmallPhotoLink;
            this.updete_createProductButton.Text = "UPDATE";

            this.updatingProduct = productToUpdate.ProductModel;
            this.productsManipulationPlan = ProductsManipulationPlan.UpdatingExistingProduct;

            this.creatingProductNameTextField.Text = productToUpdate.ProductModel.Name;
            this.creatingProductProteinsTextField.Text = productToUpdate.ProductModel.Proteins.ToString();
            this.creatingProductFatsTextField.Text = productToUpdate.ProductModel.Fats.ToString();
            this.creatingProductCarbsTextField.Text = productToUpdate.ProductModel.Carbohydrates.ToString();
            this.creatingProductPhotoLabel.Image = productToUpdate.PictureLabel.Image;

            this.creatingProductTypeSelector.SelectedIndex = productToUpdate.ProductModel.productTypeId;

            this.pages.SelectedTab = addingProductPage;
        }


        private void backgroundProductImageUploader_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread imageLoader = new Thread(() =>
            {
                showProductsImages();
            });
            imageLoader.Start();
        }

        private void showProductsImages()
        {
            foreach (var item in productItems)
            {
                if (item.PictureLabel.Image == null)
                {
                    item.PictureLabel.Image = Resources.Spinner;
                }
            }

            foreach (var item in productItems)
            {
                item.PictureLabel.Image = imageHelper.GetProductImage(item.ProductModel.SmallPhotoLink);
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
            this.leftSideProductListButton.Enabled = false;
            clickedButton.Enabled = false;
            string upper = "⇑";
            string lower = "⇓";

            foreach (var button in sortButtons)
            {
                if (button != clickedButton)
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
            if (!backgroundProductImageUploader.IsBusy)
            {
                this.backgroundProductImageUploader.RunWorkerAsync();
            }
            clickedButton.Enabled = true;
        }
        

        private void leftSideButton_Click(object sender, EventArgs e)
        {
            var clicked = (Button)sender;
            clicked.Enabled = false;
            this.productsGridOptions.PageNumber--;
            showProducts();
            if (!backgroundProductImageUploader.IsBusy)
            {
                this.backgroundProductImageUploader.RunWorkerAsync();
            }
            clicked.Enabled = (productsGridOptions.PageNumber != 1);
        }  

        private void rightSideButton_Click(object sender, EventArgs e)
        {
            var clicked = (Button)sender;
            clicked.Enabled = false;
            this.leftSideProductListButton.Enabled = true;
            this.productsGridOptions.PageNumber++;
            showProducts();
            if (!backgroundProductImageUploader.IsBusy)
            {
                this.backgroundProductImageUploader.RunWorkerAsync();
            }
        }

        private void filterProducts()
        {
            this.leftSideProductListButton.Enabled = false;
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
            if (!backgroundProductImageUploader.IsBusy)
            {
                this.backgroundProductImageUploader.RunWorkerAsync();
            }
        }


        private void searchProductTextField_TextChanged(object sender, EventArgs e)
        {
            clearTable();

            string name = this.searchProductTextField.Text;

            bool isEmptyName = (name == string.Empty);

            foreach (var sortButton in this.sortButtons)
            {
                sortButton.Visible = isEmptyName;
            }

            this.filterProductComboBox.Visible = isEmptyName;

            var searchedProducts = this.productProvider.SearchProductByName(name);

            this.productsGridOptions.searchProductName = name;

            showProducts();
            this.pages.SelectedTab = productsPage;
            if (!backgroundProductImageUploader.IsBusy)
            {
                this.backgroundProductImageUploader.RunWorkerAsync();
            }
        }

        private void addNewProductButton_Click(object sender, EventArgs e)
        {
            clearAddingProductPage();
            this.productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;
            this.pages.SelectedTab = addingProductPage;
            this.updete_createProductButton.Text = "ADD PRODUCT";
        }
        #endregion

        #region Product update/add view logic
        private void clearAddingProductPage()
        {
            this.creatingProductTypeSelector.SelectedIndex = 0;
            this.newProduct.SmallPhotoLink = null;
            this.updatingProduct.SmallPhotoLink = null;
            this.creatingProductPhotoLabel.Image = imageHelper.GetProductDefaultImage();
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
            if (pages.SelectedTab == addingRecipePage)
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
            else if (newProductTypeId == 0)
            {
                MessageBox.Show("Select the ptoduct type!", "Warning!");
                return;
            }
            else if (newProductName.Length > 20)
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
            if (!backgroundProductImageUploader.IsBusy)
            {
                this.backgroundProductImageUploader.RunWorkerAsync();
            }
            clearAddingProductPage();
            this.updete_createProductButton.Text = "ADD PRODUCT";
        }

        private void photoAddMessageLabel_Click(object sender, EventArgs e)
        {
            this.creatingProductPhotoLabel.Image = Resources.Spinner;

            string newImagePath = getNewImagePath();

            if (string.IsNullOrEmpty(newImagePath))
            {
                return;
            }

            var newImage = new Bitmap(newImagePath);

            if (newImage != null)
            {
                Thread newImageLoader = new Thread(() =>
                {
                    this.newProduct.SmallPhotoLink = loadNewImage(
                        this.creatingProductPhotoLabel,
                        newImage,
                        imageHelper.GetProductDefaultImage(),
                        productImageWigth,
                        productImageHeight);
                });
                newImageLoader.Start();
            }
        }

        private string getNewImagePath()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ConfigurationManager.AppSettings["Support_Image_Filter"];

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        private string loadNewImage(
            Label element, 
            Bitmap image, 
            Bitmap defaultImage, 
            int weidht, 
            int heigth)
        {
            try
            {
                string newImageLink = imageHelper.UploadImage(image, weidht, heigth);
                
                element.Image = imageHelper.GetProductImage(newImageLink);

                return newImageLink;
            }
            catch
            {
                element.Image = defaultImage;
                return null;
            }
        }
        #endregion

        #region recipe add view logic
        private void InitializeRecipeAdding()
        {
            ingredientsTableView.AutoScroll = true;
            ingredientsTableView.Padding = commonTablePadding;
            this.newRecipeImageLabel.Image = imageHelper.GetDishDefaultImage();
            this.newDishModel = new DishModel();
        }


        private void addingRecipePage_Enter(object sender, EventArgs e)
        {
            newRecipeIngredients = new List<IngredientModel>();
            this.ingredientsTableView.Controls.Clear();
            int row = 0;
            foreach (var selectedProduct in selectedProducts)
            {
                var newIngredient = new IngredientModel();
                newIngredient.ProductId = selectedProduct.Id;

                var ingredientNameLabel = new Label();
                ingredientNameLabel.AutoSize = true;
                ingredientNameLabel.Anchor = AnchorStyles.Top;
                ingredientNameLabel.Font = commonFont;

                ingredientNameLabel.Text = selectedProduct.Name;

                this.ingredientsTableView.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

                this.ingredientsTableView.Controls.Add(ingredientNameLabel, 0, row);
                row++;
            }
        }

        private void newRecipePhotoAddLabel_Click(object sender, EventArgs e)
        {
            this.newRecipeImageLabel.Image = Resources.Spinner;
            string newImagePath = getNewImagePath();

            if (string.IsNullOrEmpty(newImagePath))
            {
                return;
            }
            var newImage = new Bitmap(newImagePath);

            if (newImage != null)
            {
                Thread newImageLoader = new Thread(() =>
                {
                    this.newDishModel.SmallPhotoLink = loadNewImage(
                        this.newRecipeImageLabel,
                        newImage,
                        imageHelper.GetDishDefaultImage(),
                        dishImageWeigth,
                        dishImageHeight);
                });
                newImageLoader.Start();
            }
        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            string newDishName = newRecipeNameTextField.Text;

            if (newDishName == string.Empty)
            {
                MessageBox.Show("Do not leave a clear name field!", "Warning!");
                return;
            }
        }
        #endregion

        #region Dish list view logic
        private void InitializeDishList()
        {
            this.dishGridOptions = new DishGridOptions();
            this.dishGridOptions.PageNumber = 1;
            this.dishGridOptions.ItemsCount = dishesPerPageCount;

            this.firstDishIngredientsTableView.AutoScroll = true;
            this.secondDishIngredientsTableView.AutoScroll = true;
   
            this.firstDishIngredientsTableView.Padding = commonTablePadding;
            this.secondDishIngredientsTableView.Padding = commonTablePadding;
         
            this.dishItems = new List<DishItem>();
        }
        
        private void ShowDishes()
        {
            clearDishesTableView();
            dishItems = new List<DishItem>();
            var userDishes = dishProvider.GetUserDishes(
                loggedUser.Id,
                dishGridOptions.ItemsCount,
                dishGridOptions.PageNumber);

            foreach (var dish in userDishes)
            {
                dishItems.Add(new DishItem(dish)
                {
                    Ingredients = ingredientProvider.GetIngredients(dish.Id).ToList()
                });
            }

            if (dishItems.Count > 0)
            {
                fillDishGroupBox(
                    firstDishGroupBox,
                    firstDishItemImageLabel,
                    firstDishDescriptionTextLabel,
                    firstDishIngredientsTableView,
                    dishItems[0]);
            }

            if (dishItems.Count > 1)
            {
                fillDishGroupBox(
                    secondDishGroupBox,
                    secondDishItemImageLabel,
                    secondDishDescriptionTextLabel,
                    secondDishIngredientsTableView,
                    dishItems[1]);
            }

            //Here will be others Dish Group Boxes
            //...

            else
            {

            }
        }

        private void fillDishGroupBox
            (GroupBox dishGroupBox,
            Label imageLabel,
            Label descriptionLabel,
            TableLayoutPanel ingredientsTable,
            DishItem dishToShow)
        {
            dishGroupBox.Visible = true;
            descriptionLabel.Text = dishToShow.DishModel.CookingInstructions;
            dishGroupBox.Text = dishToShow.DishModel.Name;
            
            imageLabel.Image = dishToShow.Image;

            int row = 0;
            foreach(var ingredient in dishToShow.Ingredients)
            {
                Label ingredientNameLabel = new Label();
                Label ingredientWeightLabel = new Label();

                ingredientNameLabel.Font = commonFont;
                ingredientWeightLabel.Font = commonFont;

                ingredientNameLabel.Anchor = AnchorStyles.None;
                ingredientWeightLabel.Anchor = AnchorStyles.None;

                ingredientNameLabel.Text = ingredient.ProductName;
                ingredientWeightLabel.Text = ingredient.Weight.ToString();

                ingredientsTable.Controls.Add(ingredientNameLabel, ingredientNameTablePosition,row);
                ingredientsTable.Controls.Add(ingredientWeightLabel, ingerdientWeightTablePosition, row);
                row++;
            }

            Thread imageLoader = new Thread(() =>
            {
                showDisheImage(imageLabel, dishToShow);
            });
            imageLoader.Start();
        }

        private void showDisheImage(Label element, DishItem dishItem)
        {
            if (element.Image == null)
            {
                element.Image = Resources.Spinner;
            }

            element.Image = imageHelper.GetProductImage(dishItem.DishModel.BigPhotoLink);
        }

        private void clearDishesTableView()
        {
            this.firstDishIngredientsTableView.Controls.Clear();
            this.secondDishIngredientsTableView.Controls.Clear();
            this.firstDishItemImageLabel.Image = null;
            this.secondDishItemImageLabel.Image = null;
            this.firstDishDescriptionTextLabel.Text = string.Empty;
            this.firstDishDescriptionTextLabel.Text = string.Empty;
            this.firstDishGroupBox.Visible = false;
            this.secondDishGroupBox.Visible = false;
        }

        private void leftSideDishListButton_Click(object sender, EventArgs e)
        {

        }

        private void rightSideDishListButton_Click(object sender, EventArgs e)
        {

        }

        private void dishesPage_Enter(object sender, EventArgs e)
        {
            ShowDishes();
        }
        #endregion
    }
}

