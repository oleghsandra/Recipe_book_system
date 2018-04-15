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
using System.Text;
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
            imageHelper = new ImageHelper(new CloudHelper());
            productTypeProvider = new ProductTypeProvider();
            ingredientProvider = new IngredientProvider();
            dishProvider = new DishProvider();

            //Common Font for all Labels in the forms
            commonFont = new Font("Berlin Sans FB", 14F);

            //Common Table Padding without horisontal ScrollBar
            commonTablePadding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;

            //Initialize all pages
            InitializeProductList();
            InitializeRecipeAdding();
            InitializeDishList();
        }
        
        #region Product list view logic
        private void InitializeProductList()
        {
            this.newProduct = new ProductModel();
            this.newProduct.ProductTypeModel = new ProductTypeModel();
            this.updatingProduct = new ProductModel();
            this.updatingProduct.ProductTypeModel = new ProductTypeModel();
            this.creatingProductPhotoLabel.Image = imageHelper.GetProductDefaultImage();

            this.selectedProducts = new List<ProductModel>();
            this.productItems = new List<ProductItem>();
            
            this.sortButtons = new Control[sortButtonCount];

            productsGridOptions = new ProductsGridOptions()
            {
                ItemsCount = productsPerPageCount,
                PageNumber = 1
            };

            try
            {
                this.productTypes = productTypeProvider.GetAllProductTypes().ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
            }

            //Fill filterProductComboBox with all available product type
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

            //Filter froduct when value of ComboBox is changed
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
                //Hide makeRecipeButton when there no eny selected product
                this.makeRecipeButton.Hide();
            }
        }

        private void showProducts()
        {
            this.backgroundProductImageUploader.CancelAsync();
            clearTable();

            int row = productItems.Count;

            List<ProductModel> filteredProducts = new List<ProductModel>();

            //In case when there are no 
            if (string.IsNullOrEmpty(productsGridOptions.searchProductName))
            {
                try
                {
                    filteredProducts = productProvider.GetProducts(
                        productsPerPageCount,
                        productsGridOptions.PageNumber,
                        productsGridOptions.SortColumnName,
                        productsGridOptions.SortOrder,
                        productsGridOptions.FilterProductTypeId).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.ErrorMessage);
                    return;
                }
            }
            else
            {
                this.productsGridOptions.PageNumber = 1;
                this.leftSideProductListButton.Enabled = false;

                try
                {
                    filteredProducts = productProvider.SearchProductByName(
                        productsGridOptions.searchProductName).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.ErrorMessage);
                    return;
                }
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

                //Each time will be selecting an item in front of the Check box
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
                            this.selectedProductsListBox.Items.Insert(0, Resources.NoProductsYetMessage);
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

                //Configure Label element, so that there could put the picture there
                productItem.PictureLabel = new Label();
                productItem.PictureLabel.AutoSize = true;
                productItem.PictureLabel.Font = new Font("Microsoft Sans Serif", 50F);
                productItem.PictureLabel.Text = string.Format("{0,4}", string.Empty);
                productItem.PictureLabel.Anchor = AnchorStyles.None;
                this.productTableView.Controls.Add(productItem.PictureLabel, 1, row);

                //Set the text values of Label content in the correct order
                this.productTableRowLabels[2].Text = product.Name;
                this.productTableRowLabels[3].Text = product.ProductTypeModel.Name;
                this.productTableRowLabels[4].Text = product.Proteins.ToString();
                this.productTableRowLabels[5].Text = product.Fats.ToString();
                this.productTableRowLabels[6].Text = product.Carbohydrates.ToString();
                row++;

                this.productTableView.Refresh();
            }
        }

        private void deleteProduct(ProductModel productToDelete)
        {
            try
            {
                this.productProvider.DeleteProduct(productToDelete.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
                return;
            }
            
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
                this.selectedProductsListBox.Items.Insert(0, Resources.NoProductsYetMessage);
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
            this.updete_createProductButton.Text = Resources.UpdateText;

            this.updatingProduct = productToUpdate.ProductModel;
            this.productsManipulationPlan = ProductsManipulationPlan.UpdatingExistingProduct;

            //Fill fields whith values of available product
            this.creatingProductNameTextField.Text = productToUpdate.ProductModel.Name;
            this.creatingProductProteinsTextField.Text = productToUpdate.ProductModel.Proteins.ToString();
            this.creatingProductFatsTextField.Text = productToUpdate.ProductModel.Fats.ToString();
            this.creatingProductCarbsTextField.Text = productToUpdate.ProductModel.Carbohydrates.ToString();
            this.creatingProductPhotoLabel.Image = productToUpdate.PictureLabel.Image;

            this.creatingProductTypeSelector.SelectedIndex = productToUpdate.ProductModel.ProductTypeModel.Id;

            this.pages.SelectedTab = addingProductPage;
        }


        private void backgroundProductImageUploader_DoWork(object sender, DoWorkEventArgs e)
        {
            //New Thread created to provide releasing the background 
            //worker for next image loading process.
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
            sortProducts((Button)sender, Resources.NameText);
        }

        private void proteinsSortButton_Click(object sender, EventArgs e)
        {
            sortProducts((Button)sender, Resources.ProteinsText);
        }

        private void fatsSortButton_Click(object sender, EventArgs e)
        {
            sortProducts((Button)sender, Resources.FatsText);
        }

        private void carbsSortButton_Click(object sender, EventArgs e)
        {
            sortProducts((Button)sender, Resources.CarbohydratesText);
        }

        private void sortProducts(Button clickedButton, string sortColumn)
        {
            this.leftSideProductListButton.Enabled = false;
            clickedButton.Enabled = false;
            string upper = Resources.UpperSymbol;
            string lower = Resources.LowerSymbol;

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
                    this.productsGridOptions.SortOrder = Resources.ASCOrder;
                }
                else if (buttonTextWords[1] == lower)
                {
                    clickedButton.Text = buttonTextWords[0] + " " + upper;
                    this.productsGridOptions.SortOrder = Resources.DESCOrder;
                }
            }
            else
            {
                clickedButton.Text += " " + lower;
                this.productsGridOptions.SortOrder = Resources.ASCOrder;
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

            IEnumerable<ProductModel> searchedProducts;

            try
            {
                searchedProducts = this.productProvider.SearchProductByName(name);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
                return;
            }

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
            setAddProductPlan();
        }

        private void noMoreProductMessageLabel_Click(object sender, EventArgs e)
        {
            setAddProductPlan();
        }

        private void setAddProductPlan()
        {
            clearAddingProductPage();
            this.productsManipulationPlan = ProductsManipulationPlan.CreatingNewProduct;
            this.pages.SelectedTab = addingProductPage;
            this.updete_createProductButton.Text = Resources.AddProductMessage;
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
                MessageBox.Show("Do not leave a clear name field!", Resources.WarningMessage);
                return;
            }
            else if (newProductTypeId == 0)
            {
                MessageBox.Show("Select the ptoduct type!", Resources.WarningMessage);
                return;
            }
            else if (newProductName.Length > 20)
            {
                MessageBox.Show("Name is too long!", Resources.WarningMessage);
                return;
            }
            else if (!hasProteinsValue)
            {
                MessageBox.Show("Incorrect input in proteins field", Resources.WarningMessage);
                return;
            }
            else if (!hasFatsValue)
            {
                MessageBox.Show("Incorrect input in fats field", Resources.WarningMessage);
                return;
            }
            else if (!hasCarbsValue)
            {
                MessageBox.Show("Incorrect input in carbohydrades field", Resources.WarningMessage);
                return;
            }
            else if ((newProductProteinsCount + newProductCarbsCount + newProductFatsCount) > 100)
            {
                MessageBox.Show("The sum of all product parameters can not be more than 100!", Resources.WarningMessage);
                return;
            }
            
            this.newProduct.Name = newProductName;
            this.newProduct.Proteins = newProductProteinsCount;
            this.newProduct.Fats = newProductFatsCount;
            this.newProduct.Carbohydrates = newProductCarbsCount;
            this.newProduct.ProductTypeModel.Id = newProductTypeId;
            
            if (productsManipulationPlan == ProductsManipulationPlan.UpdatingExistingProduct)
            {
                this.newProduct.Id = updatingProduct.Id;

                try
                {
                    productProvider.UpdateProduct(
                        newProduct.Id,
                        newProduct.Name,
                        newProduct.ProductTypeModel.Id,
                        newProduct.Proteins,
                        newProduct.Fats,
                        newProduct.Carbohydrates,
                        newProduct.SmallPhotoLink);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.ErrorMessage);
                    return;
                }
            }
            else
            {
                try
                {
                    this.productProvider.AddProduct(newProduct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.ErrorMessage);
                    return;
                }

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
            this.updete_createProductButton.Text = Resources.AddProductMessage;
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
            catch (Exception ex)
            {
                element.Image = defaultImage;
                return null;
            }
        }
        #endregion

        #region Recipe add view logic
        private void InitializeRecipeAdding()
        {
            ingredientsTableView.AutoScroll = true;
            ingredientsTableView.Padding = commonTablePadding;
            this.newRecipeImageLabel.Image = imageHelper.GetDishDefaultImage();
            this.newDishModel = new DishModel();

            this.firstDishDeleteIconLabel.Image = Resources.DeleteIcon;
            this.secondDishDeleteIconLabel.Image = Resources.DeleteIcon;
        }

        private void addingRecipePage_Enter(object sender, EventArgs e)
        {
            newRecipeIngredients = new List<IngredientModel>();
            this.ingredientsTableView.Controls.Clear();
            int selectedProductsCount = selectedProducts.Count;
                
            int row = 0;

            foreach (var selectedProduct in selectedProducts)
            {
                var newIngredient = new IngredientModel();
                newIngredient.ProductId = selectedProduct.Id;

                newRecipeIngredients.Add(newIngredient);

                var ingredientNameLabel = new Label();
                ingredientNameLabel.AutoSize = true;
                ingredientNameLabel.Anchor = AnchorStyles.Left;
                ingredientNameLabel.Font = new Font("Berlin Sans FB", 12F); ;

                ingredientNameLabel.Text = selectedProduct.Name;

                NumericUpDown ingredientWeightNumericUpDown = new NumericUpDown();

                //Set common style for every created NumericUpDown
                ingredientWeightNumericUpDown.BorderStyle = BorderStyle.None;
                ingredientWeightNumericUpDown.Font = commonFont;
                ingredientWeightNumericUpDown.Anchor = AnchorStyles.Left;
                ingredientWeightNumericUpDown.Increment = new decimal(new int[] { 10, 0, 0, 0 });
                ingredientWeightNumericUpDown.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
                ingredientWeightNumericUpDown.Size = new Size(66, 24);

                ingredientWeightNumericUpDown.ValueChanged += (senderObj, args) =>
                {
                    newIngredient.Weight = (double)ingredientWeightNumericUpDown.Value;
                };

                //Set lables in TableView in fixed positions of columns
                this.ingredientsTableView.Controls.Add(ingredientNameLabel, 0, row);
                this.ingredientsTableView.Controls.Add(ingredientWeightNumericUpDown, 1, row);

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
                    this.newDishModel.BigPhotoLink = loadNewImage(
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
                MessageBox.Show(Resources.DontLeaveNameFieldMessage, Resources.WarningMessage);
                return;
            }

            newDishModel.Name = newDishName;
            newDishModel.OwnerId = loggedUser.Id;
            newDishModel.CookingInstructions = this.newRecipeDescriptionRichTextField.Text;

            int newDishId = 0;

            try
            {
                newDishId = dishProvider.AddDish(newDishModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
                return;
            }

            try
            {
                foreach (var ingredient in newRecipeIngredients)
                {
                    ingredient.DishId = newDishId;
                    ingredientProvider.AddIngredient(ingredient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
                return;
            }

            clearAddRecipePage();
            dishGridOptions.PageNumber = 1;
            this.pages.SelectedTab = dishesPage;
        }

        private void clearAddRecipePage()
        {
            this.newDishModel = new DishModel();
            this.newRecipeIngredients = new List<IngredientModel>();
            this.newRecipeNameTextField.Text = string.Empty;
            this.newRecipeDescriptionRichTextField.Text = string.Empty;
            this.newRecipeImageLabel.Image = imageHelper.GetDishDefaultImage();
        }
        #endregion

        #region Dish list view logic
        private void InitializeDishList()
        {
            this.dishGridOptions = new DishGridOptions();
            this.dishGridOptions.PageNumber = 1;
            this.dishGridOptions.ItemsCount = dishesPerPageCount;

            this.leftSideDishListButton.Image = Resources.LeftSideImage;
            this.rightSideDishListButton.Image = Resources.RightSideImage;

            this.dishItems = new List<DishItem>();

            this.leftSideDishListButton.Visible = false;
        }
        
        private void ShowDishes()
        {
            clearDishesTableView();
            dishItems = new List<DishItem>();
            List<DishModel> userDishes = new List<DishModel>();

            try
            {
                userDishes = dishProvider.GetUserDishes(
                    loggedUser.Id,
                    dishGridOptions.ItemsCount,
                    dishGridOptions.PageNumber,
                    dishGridOptions.DishName).ToList();

                foreach (var dish in userDishes)
                {
                    dishItems.Add(new DishItem(dish)
                    {
                        Ingredients = ingredientProvider.GetIngredients(dish.Id).ToList()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
                return;
            }

            if (dishGridOptions.PageNumber == 1)
            {
                this.leftSideDishListButton.Visible = false;
            }
            else
            {
                this.leftSideDishListButton.Visible = true;
            }

            if (dishItems.Count == 0)
            {
                this.rightSideDishListButton.Visible = false;
                this.noDishMessageLabel.Visible = true;
                return;
            }

            if (dishItems.Count > 0)
            {
                this.noDishMessageLabel.Visible = false;
                this.rightSideDishListButton.Visible = true;
                fillDishGroupBox(
                    firstDishGroupBox,
                    firstDishItemImageLabel,
                    firstDishDescriptionTextLabel,
                    firstDishIngredientsListBox,
                    dishItems[0]);
                this.firstDishGroupBox.Visible = true;
            }

            if (dishItems.Count > 1)
            {
                fillDishGroupBox(
                    secondDishGroupBox,
                    secondDishItemImageLabel,
                    secondDishDescriptionTextLabel,
                    secondDishIngredientsListBox,
                    dishItems[1]);
                this.secondDishGroupBox.Visible = true;
            }
        }

        private void fillDishGroupBox
            (GroupBox dishGroupBox,
            Label imageLabel,
            Label descriptionLabel,
            ListBox ingredientsListBox,
            DishItem dishToShow)
        {
            dishGroupBox.Visible = true;
            descriptionLabel.Text = dishToShow.DishModel.CookingInstructions;
            dishGroupBox.Text = dishToShow.DishModel.Name;
            
            imageLabel.Image = dishToShow.Image;
            
            foreach(var ingredient in dishToShow.Ingredients)
            {
                StringBuilder ingredientInfo = new StringBuilder();
                ingredientInfo.Append(ingredient.ProductName);
                ingredientInfo.Append(" - ");
                ingredientInfo.Append(ingredient.Weight);
                ingredientsListBox.Items.Add(ingredientInfo.ToString());
            }

            Thread imageLoader = new Thread(() =>
            {
                showDisheImage(imageLabel, dishToShow);
            });

            imageLoader.Start();
        }

        private void showDisheImage(Label element, DishItem dishItem)
        {
            element.Image = Resources.Spinner;
            element.Image = imageHelper.GetDishImage(dishItem.DishModel.BigPhotoLink);
        }

        private void clearDishesTableView()
        {
            clearListBox(this.firstDishIngredientsListBox);
            clearListBox(this.secondDishIngredientsListBox);
            this.firstDishGroupBox.Visible = false;
            this.secondDishGroupBox.Visible = false;
            this.firstDishDescriptionTextLabel.Text = string.Empty;
            this.firstDishDescriptionTextLabel.Text = string.Empty;
            this.firstDishGroupBox.Visible = false;
            this.secondDishGroupBox.Visible = false;
        }

        private void clearListBox(ListBox listBox)
        {
            while(listBox.Items.Count > 0)
            {
                listBox.Items.RemoveAt(0);
            }
        }

        private void leftSideDishListButton_Click(object sender, EventArgs e)
        {
            dishGridOptions.PageNumber--;
            ShowDishes();
        }

        private void rightSideDishListButton_Click(object sender, EventArgs e)
        {
            dishGridOptions.PageNumber++;
            ShowDishes();
        }

        private void dishesPage_Enter(object sender, EventArgs e)
        {
            searchDishesTextField.Text = string.Empty;
            if (dishItems.Count == 0)
            {
                dishGridOptions.PageNumber = 1;
            }
           
            ShowDishes();
        }

        private void noDishMessageLabel_Click(object sender, EventArgs e)
        {
            this.pages.SelectedTab = addingRecipePage;
        }
        
        private void searchDishesTextField_TextChanged(object sender, EventArgs e)
        {
            dishGridOptions.DishName = searchDishesTextField.Text;
            dishGridOptions.PageNumber = 1;
            ShowDishes();
            if(dishItems.Count > 0)
            {
                this.noDishMessageLabel.Visible = false;
            }
            else
            {
                this.noDishMessageLabel.Visible = true;
            }
            if (!string.IsNullOrEmpty(searchDishesTextField.Text))
            {
                this.noDishMessageLabel.Visible = false;
                this.leftSideDishListButton.Visible = false;
                this.rightSideDishListButton.Visible = false;
            }
        }

        private void firstDishDeleteIconLabel_Click(object sender, EventArgs e)
        {
            var dishToDelete = dishItems[0].DishModel;
            if (isConfirmedDishRemoving(dishToDelete))
            {
                try
                {
                    dishProvider.DeleteDish(dishToDelete.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.ErrorMessage);
                    return;
                }

                ShowDishes();
            }
        }

        private void secondDishDeleteIconLabel_Click(object sender, EventArgs e)
        {
            var dishToDelete = dishItems[1].DishModel;
            if (isConfirmedDishRemoving(dishToDelete))
            {
                try
                {
                    dishProvider.DeleteDish(dishToDelete.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.ErrorMessage);
                    return;
                }

                ShowDishes();
            }
        }

        bool isConfirmedDishRemoving(DishModel dishToDelete)
        {
            StringBuilder confirmMessage = new StringBuilder();
            confirmMessage.Append("Do you really want to delete \"");
            confirmMessage.Append(dishToDelete.Name);
            confirmMessage.Append("\" recipe?");
            DialogResult confirmResult = MessageBox.Show(
                confirmMessage.ToString(), 
                "Confirm deleting",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}

