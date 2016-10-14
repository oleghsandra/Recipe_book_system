namespace RecipeBookSystem.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundProductImageUploader = new System.ComponentModel.BackgroundWorker();
            this.pageSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.pages = new MaterialSkin.Controls.MaterialTabControl();
            this.productsPage = new System.Windows.Forms.TabPage();
            this.noMoreProductMessageLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.searchProductTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedProductsListBox = new System.Windows.Forms.ListBox();
            this.makeRecipeButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.leftSideProductListButton = new System.Windows.Forms.Button();
            this.rightSideProductListButton = new System.Windows.Forms.Button();
            this.leftSideLabel = new System.Windows.Forms.Label();
            this.carbsSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.fatsSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addNewProductButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.proteinsSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.productTableView = new System.Windows.Forms.TableLayoutPanel();
            this.nameSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.filterProductComboBox = new System.Windows.Forms.ComboBox();
            this.dishesPage = new System.Windows.Forms.TabPage();
            this.leftSideDishListButton = new System.Windows.Forms.Button();
            this.rightSideDishListButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.secondDishGroupBox = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.secondDishDescriptionTextLabel = new System.Windows.Forms.Label();
            this.secondDishIngredientsTableView = new System.Windows.Forms.TableLayoutPanel();
            this.secondDishItemImageLabel = new System.Windows.Forms.Label();
            this.firstDishGroupBox = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.firstDishIngredientsTableView = new System.Windows.Forms.TableLayoutPanel();
            this.firstDishItemImageLabel = new System.Windows.Forms.Label();
            this.firstDishDescriptionTextLabel = new System.Windows.Forms.Label();
            this.addingProductPage = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.updete_createProductButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.productNameAddMessageLabel = new System.Windows.Forms.Label();
            this.creatingProductPhotoPanel = new System.Windows.Forms.Panel();
            this.creatingProductPhotoLabel = new System.Windows.Forms.Label();
            this.photoAddMessageLabel = new System.Windows.Forms.Label();
            this.creatingProductTypeSelector = new System.Windows.Forms.ComboBox();
            this.creatingProductNameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.creatingProductFatsTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.creatingProductCarbsTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.creatingProductProteinsTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.addingRecipePage = new System.Windows.Forms.TabPage();
            this.addingRecipeMessageLabel = new System.Windows.Forms.Label();
            this.ingredientsTableView = new System.Windows.Forms.TableLayoutPanel();
            this.addRecipeButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label19 = new System.Windows.Forms.Label();
            this.newRecipeRichTextField = new System.Windows.Forms.RichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newRecipeImageLabel = new System.Windows.Forms.Label();
            this.newRecipePhotoAddLabel = new System.Windows.Forms.Label();
            this.newRecipeNameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.newRecipeErrorLabel = new System.Windows.Forms.Label();
            this.labelWithMyName = new System.Windows.Forms.Label();
            this.pages.SuspendLayout();
            this.productsPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dishesPage.SuspendLayout();
            this.secondDishGroupBox.SuspendLayout();
            this.firstDishGroupBox.SuspendLayout();
            this.addingProductPage.SuspendLayout();
            this.creatingProductPhotoPanel.SuspendLayout();
            this.addingRecipePage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundProductImageUploader
            // 
            this.backgroundProductImageUploader.WorkerSupportsCancellation = true;
            this.backgroundProductImageUploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundProductImageUploader_DoWork);
            // 
            // pageSelector
            // 
            this.pageSelector.BaseTabControl = this.pages;
            this.pageSelector.Depth = 0;
            this.pageSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pageSelector.Location = new System.Drawing.Point(-3, 24);
            this.pageSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.pageSelector.Name = "pageSelector";
            this.pageSelector.Size = new System.Drawing.Size(709, 21);
            this.pageSelector.TabIndex = 2;
            this.pageSelector.Text = "pageSelector";
            // 
            // pages
            // 
            this.pages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pages.Controls.Add(this.productsPage);
            this.pages.Controls.Add(this.dishesPage);
            this.pages.Controls.Add(this.addingProductPage);
            this.pages.Controls.Add(this.addingRecipePage);
            this.pages.Depth = 0;
            this.pages.Location = new System.Drawing.Point(12, 51);
            this.pages.MouseState = MaterialSkin.MouseState.HOVER;
            this.pages.Name = "pages";
            this.pages.SelectedIndex = 0;
            this.pages.Size = new System.Drawing.Size(675, 540);
            this.pages.TabIndex = 1;
            this.pages.Selected += new System.Windows.Forms.TabControlEventHandler(this.pages_Selected);
            // 
            // productsPage
            // 
            this.productsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.productsPage.Controls.Add(this.noMoreProductMessageLabel);
            this.productsPage.Controls.Add(this.label17);
            this.productsPage.Controls.Add(this.searchProductTextField);
            this.productsPage.Controls.Add(this.groupBox1);
            this.productsPage.Controls.Add(this.makeRecipeButton);
            this.productsPage.Controls.Add(this.label1);
            this.productsPage.Controls.Add(this.leftSideProductListButton);
            this.productsPage.Controls.Add(this.rightSideProductListButton);
            this.productsPage.Controls.Add(this.leftSideLabel);
            this.productsPage.Controls.Add(this.carbsSortButton);
            this.productsPage.Controls.Add(this.fatsSortButton);
            this.productsPage.Controls.Add(this.addNewProductButton);
            this.productsPage.Controls.Add(this.proteinsSortButton);
            this.productsPage.Controls.Add(this.productTableView);
            this.productsPage.Controls.Add(this.nameSortButton);
            this.productsPage.Controls.Add(this.filterProductComboBox);
            this.productsPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productsPage.Location = new System.Drawing.Point(4, 22);
            this.productsPage.Name = "productsPage";
            this.productsPage.Padding = new System.Windows.Forms.Padding(3);
            this.productsPage.Size = new System.Drawing.Size(667, 514);
            this.productsPage.TabIndex = 0;
            this.productsPage.Text = "Product list";
            // 
            // noMoreProductMessageLabel
            // 
            this.noMoreProductMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noMoreProductMessageLabel.Font = new System.Drawing.Font("Berlin Sans FB", 35F, System.Drawing.FontStyle.Underline);
            this.noMoreProductMessageLabel.Location = new System.Drawing.Point(24, 47);
            this.noMoreProductMessageLabel.Name = "noMoreProductMessageLabel";
            this.noMoreProductMessageLabel.Size = new System.Drawing.Size(614, 263);
            this.noMoreProductMessageLabel.TabIndex = 232;
            this.noMoreProductMessageLabel.Text = "Oop\'s, no more products. If you have not found the needed product, add it.";
            this.noMoreProductMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noMoreProductMessageLabel.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(297, 415);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 21);
            this.label17.TabIndex = 234;
            this.label17.Text = "Search:";
            // 
            // searchProductTextField
            // 
            this.searchProductTextField.Depth = 0;
            this.searchProductTextField.Hint = "";
            this.searchProductTextField.Location = new System.Drawing.Point(371, 415);
            this.searchProductTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchProductTextField.Name = "searchProductTextField";
            this.searchProductTextField.PasswordChar = '\0';
            this.searchProductTextField.SelectedText = "";
            this.searchProductTextField.SelectionLength = 0;
            this.searchProductTextField.SelectionStart = 0;
            this.searchProductTextField.Size = new System.Drawing.Size(185, 23);
            this.searchProductTextField.TabIndex = 233;
            this.searchProductTextField.UseSystemPasswordChar = false;
            this.searchProductTextField.TextChanged += new System.EventHandler(this.searchProductTextField_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectedProductsListBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 437);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected products";
            // 
            // selectedProductsListBox
            // 
            this.selectedProductsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedProductsListBox.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedProductsListBox.FormattingEnabled = true;
            this.selectedProductsListBox.ItemHeight = 18;
            this.selectedProductsListBox.Items.AddRange(new object[] {
            "No products yet"});
            this.selectedProductsListBox.Location = new System.Drawing.Point(18, 22);
            this.selectedProductsListBox.Name = "selectedProductsListBox";
            this.selectedProductsListBox.Size = new System.Drawing.Size(128, 72);
            this.selectedProductsListBox.TabIndex = 4;
            // 
            // makeRecipeButton
            // 
            this.makeRecipeButton.Depth = 0;
            this.makeRecipeButton.Location = new System.Drawing.Point(290, 446);
            this.makeRecipeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.makeRecipeButton.Name = "makeRecipeButton";
            this.makeRecipeButton.Primary = true;
            this.makeRecipeButton.Size = new System.Drawing.Size(269, 62);
            this.makeRecipeButton.TabIndex = 16;
            this.makeRecipeButton.Text = "Make recipe from selected products";
            this.makeRecipeButton.UseVisualStyleBackColor = true;
            this.makeRecipeButton.Click += new System.EventHandler(this.makeRecipeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // leftSideProductListButton
            // 
            this.leftSideProductListButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.leftSideProductListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.leftSideProductListButton.Location = new System.Drawing.Point(562, 398);
            this.leftSideProductListButton.Name = "leftSideProductListButton";
            this.leftSideProductListButton.Size = new System.Drawing.Size(45, 40);
            this.leftSideProductListButton.TabIndex = 12;
            this.leftSideProductListButton.UseVisualStyleBackColor = false;
            this.leftSideProductListButton.Click += new System.EventHandler(this.leftSideButton_Click);
            // 
            // rightSideProductListButton
            // 
            this.rightSideProductListButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rightSideProductListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rightSideProductListButton.Location = new System.Drawing.Point(613, 398);
            this.rightSideProductListButton.Name = "rightSideProductListButton";
            this.rightSideProductListButton.Size = new System.Drawing.Size(45, 40);
            this.rightSideProductListButton.TabIndex = 11;
            this.rightSideProductListButton.UseVisualStyleBackColor = false;
            this.rightSideProductListButton.Click += new System.EventHandler(this.rightSideButton_Click);
            // 
            // leftSideLabel
            // 
            this.leftSideLabel.Location = new System.Drawing.Point(513, 427);
            this.leftSideLabel.Name = "leftSideLabel";
            this.leftSideLabel.Size = new System.Drawing.Size(0, 0);
            this.leftSideLabel.TabIndex = 10;
            // 
            // carbsSortButton
            // 
            this.carbsSortButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.carbsSortButton.Depth = 0;
            this.carbsSortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.carbsSortButton.Location = new System.Drawing.Point(531, 4);
            this.carbsSortButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.carbsSortButton.Name = "carbsSortButton";
            this.carbsSortButton.Primary = true;
            this.carbsSortButton.Size = new System.Drawing.Size(69, 29);
            this.carbsSortButton.TabIndex = 7;
            this.carbsSortButton.Text = "Carbs";
            this.carbsSortButton.UseVisualStyleBackColor = true;
            this.carbsSortButton.Click += new System.EventHandler(this.carbsSortButton_Click);
            // 
            // fatsSortButton
            // 
            this.fatsSortButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fatsSortButton.Depth = 0;
            this.fatsSortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fatsSortButton.Location = new System.Drawing.Point(456, 3);
            this.fatsSortButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.fatsSortButton.Name = "fatsSortButton";
            this.fatsSortButton.Primary = true;
            this.fatsSortButton.Size = new System.Drawing.Size(69, 29);
            this.fatsSortButton.TabIndex = 6;
            this.fatsSortButton.Text = "Fats";
            this.fatsSortButton.UseVisualStyleBackColor = true;
            this.fatsSortButton.Click += new System.EventHandler(this.fatsSortButton_Click);
            // 
            // addNewProductButton
            // 
            this.addNewProductButton.Depth = 0;
            this.addNewProductButton.Location = new System.Drawing.Point(164, 446);
            this.addNewProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addNewProductButton.Name = "addNewProductButton";
            this.addNewProductButton.Primary = true;
            this.addNewProductButton.Size = new System.Drawing.Size(120, 62);
            this.addNewProductButton.TabIndex = 2;
            this.addNewProductButton.Text = "Add new product";
            this.addNewProductButton.UseVisualStyleBackColor = true;
            this.addNewProductButton.Click += new System.EventHandler(this.addNewProductButton_Click);
            // 
            // proteinsSortButton
            // 
            this.proteinsSortButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.proteinsSortButton.Depth = 0;
            this.proteinsSortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.proteinsSortButton.Location = new System.Drawing.Point(369, 4);
            this.proteinsSortButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.proteinsSortButton.Name = "proteinsSortButton";
            this.proteinsSortButton.Primary = true;
            this.proteinsSortButton.Size = new System.Drawing.Size(81, 29);
            this.proteinsSortButton.TabIndex = 5;
            this.proteinsSortButton.Text = "Proteins";
            this.proteinsSortButton.UseVisualStyleBackColor = true;
            this.proteinsSortButton.Click += new System.EventHandler(this.proteinsSortButton_Click);
            // 
            // productTableView
            // 
            this.productTableView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productTableView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.productTableView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.productTableView.ColumnCount = 9;
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.productTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.productTableView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productTableView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.productTableView.Location = new System.Drawing.Point(-4, 47);
            this.productTableView.Margin = new System.Windows.Forms.Padding(0);
            this.productTableView.Name = "productTableView";
            this.productTableView.RowCount = 6;
            this.productTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.productTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.productTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.productTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.productTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.productTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.productTableView.Size = new System.Drawing.Size(662, 348);
            this.productTableView.TabIndex = 0;
            // 
            // nameSortButton
            // 
            this.nameSortButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameSortButton.Depth = 0;
            this.nameSortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameSortButton.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameSortButton.Location = new System.Drawing.Point(136, 3);
            this.nameSortButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.nameSortButton.Name = "nameSortButton";
            this.nameSortButton.Primary = true;
            this.nameSortButton.Size = new System.Drawing.Size(124, 29);
            this.nameSortButton.TabIndex = 4;
            this.nameSortButton.Text = "Name";
            this.nameSortButton.UseVisualStyleBackColor = true;
            this.nameSortButton.Click += new System.EventHandler(this.nameSortButton_Click);
            // 
            // filterProductComboBox
            // 
            this.filterProductComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filterProductComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterProductComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.filterProductComboBox.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterProductComboBox.FormattingEnabled = true;
            this.filterProductComboBox.Items.AddRange(new object[] {
            "All"});
            this.filterProductComboBox.Location = new System.Drawing.Point(266, 3);
            this.filterProductComboBox.Name = "filterProductComboBox";
            this.filterProductComboBox.Size = new System.Drawing.Size(97, 29);
            this.filterProductComboBox.TabIndex = 8;
            // 
            // dishesPage
            // 
            this.dishesPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dishesPage.Controls.Add(this.leftSideDishListButton);
            this.dishesPage.Controls.Add(this.rightSideDishListButton);
            this.dishesPage.Controls.Add(this.label16);
            this.dishesPage.Controls.Add(this.materialSingleLineTextField1);
            this.dishesPage.Controls.Add(this.secondDishGroupBox);
            this.dishesPage.Controls.Add(this.firstDishGroupBox);
            this.dishesPage.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dishesPage.ForeColor = System.Drawing.Color.Black;
            this.dishesPage.Location = new System.Drawing.Point(4, 22);
            this.dishesPage.Name = "dishesPage";
            this.dishesPage.Padding = new System.Windows.Forms.Padding(3);
            this.dishesPage.Size = new System.Drawing.Size(667, 514);
            this.dishesPage.TabIndex = 1;
            this.dishesPage.Text = "My dishes";
            this.dishesPage.Enter += new System.EventHandler(this.dishesPage_Enter);
            // 
            // leftSideDishListButton
            // 
            this.leftSideDishListButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.leftSideDishListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.leftSideDishListButton.Location = new System.Drawing.Point(524, 278);
            this.leftSideDishListButton.Name = "leftSideDishListButton";
            this.leftSideDishListButton.Size = new System.Drawing.Size(45, 40);
            this.leftSideDishListButton.TabIndex = 238;
            this.leftSideDishListButton.UseVisualStyleBackColor = false;
            this.leftSideDishListButton.Click += new System.EventHandler(this.leftSideDishListButton_Click);
            // 
            // rightSideDishListButton
            // 
            this.rightSideDishListButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rightSideDishListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rightSideDishListButton.Location = new System.Drawing.Point(575, 278);
            this.rightSideDishListButton.Name = "rightSideDishListButton";
            this.rightSideDishListButton.Size = new System.Drawing.Size(45, 40);
            this.rightSideDishListButton.TabIndex = 237;
            this.rightSideDishListButton.UseVisualStyleBackColor = false;
            this.rightSideDishListButton.Click += new System.EventHandler(this.rightSideDishListButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(351, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 21);
            this.label16.TabIndex = 236;
            this.label16.Text = "Search:";
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(425, 18);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(185, 23);
            this.materialSingleLineTextField1.TabIndex = 235;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // secondDishGroupBox
            // 
            this.secondDishGroupBox.Controls.Add(this.label12);
            this.secondDishGroupBox.Controls.Add(this.label13);
            this.secondDishGroupBox.Controls.Add(this.secondDishDescriptionTextLabel);
            this.secondDishGroupBox.Controls.Add(this.secondDishIngredientsTableView);
            this.secondDishGroupBox.Controls.Add(this.secondDishItemImageLabel);
            this.secondDishGroupBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondDishGroupBox.Location = new System.Drawing.Point(49, 309);
            this.secondDishGroupBox.Name = "secondDishGroupBox";
            this.secondDishGroupBox.Size = new System.Drawing.Size(574, 230);
            this.secondDishGroupBox.TabIndex = 1;
            this.secondDishGroupBox.TabStop = false;
            this.secondDishGroupBox.Text = "Dish1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(425, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 23);
            this.label12.TabIndex = 239;
            this.label12.Text = "Weight(gram)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(313, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 23);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ingredient";
            // 
            // secondDishDescriptionTextLabel
            // 
            this.secondDishDescriptionTextLabel.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondDishDescriptionTextLabel.ForeColor = System.Drawing.Color.Black;
            this.secondDishDescriptionTextLabel.Location = new System.Drawing.Point(275, 153);
            this.secondDishDescriptionTextLabel.Name = "secondDishDescriptionTextLabel";
            this.secondDishDescriptionTextLabel.Size = new System.Drawing.Size(283, 75);
            this.secondDishDescriptionTextLabel.TabIndex = 238;
            this.secondDishDescriptionTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondDishIngredientsTableView
            // 
            this.secondDishIngredientsTableView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.secondDishIngredientsTableView.ColumnCount = 2;
            this.secondDishIngredientsTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.10904F));
            this.secondDishIngredientsTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.89096F));
            this.secondDishIngredientsTableView.Location = new System.Drawing.Point(292, 52);
            this.secondDishIngredientsTableView.Name = "secondDishIngredientsTableView";
            this.secondDishIngredientsTableView.RowCount = 2;
            this.secondDishIngredientsTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.secondDishIngredientsTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.secondDishIngredientsTableView.Size = new System.Drawing.Size(245, 86);
            this.secondDishIngredientsTableView.TabIndex = 237;
            // 
            // secondDishItemImageLabel
            // 
            this.secondDishItemImageLabel.AutoSize = true;
            this.secondDishItemImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F);
            this.secondDishItemImageLabel.Location = new System.Drawing.Point(15, 41);
            this.secondDishItemImageLabel.Name = "secondDishItemImageLabel";
            this.secondDishItemImageLabel.Size = new System.Drawing.Size(245, 153);
            this.secondDishItemImageLabel.TabIndex = 26;
            this.secondDishItemImageLabel.Text = "     ";
            this.secondDishItemImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstDishGroupBox
            // 
            this.firstDishGroupBox.Controls.Add(this.label11);
            this.firstDishGroupBox.Controls.Add(this.label10);
            this.firstDishGroupBox.Controls.Add(this.firstDishIngredientsTableView);
            this.firstDishGroupBox.Controls.Add(this.firstDishItemImageLabel);
            this.firstDishGroupBox.Controls.Add(this.firstDishDescriptionTextLabel);
            this.firstDishGroupBox.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstDishGroupBox.Location = new System.Drawing.Point(49, 44);
            this.firstDishGroupBox.Name = "firstDishGroupBox";
            this.firstDishGroupBox.Size = new System.Drawing.Size(574, 230);
            this.firstDishGroupBox.TabIndex = 0;
            this.firstDishGroupBox.TabStop = false;
            this.firstDishGroupBox.Text = "Dish1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(425, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 23);
            this.label11.TabIndex = 28;
            this.label11.Text = "Weight(gram)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Ingredient";
            // 
            // firstDishIngredientsTableView
            // 
            this.firstDishIngredientsTableView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.firstDishIngredientsTableView.ColumnCount = 2;
            this.firstDishIngredientsTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.10904F));
            this.firstDishIngredientsTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.89096F));
            this.firstDishIngredientsTableView.Location = new System.Drawing.Point(292, 54);
            this.firstDishIngredientsTableView.Name = "firstDishIngredientsTableView";
            this.firstDishIngredientsTableView.RowCount = 2;
            this.firstDishIngredientsTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.firstDishIngredientsTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.firstDishIngredientsTableView.Size = new System.Drawing.Size(245, 86);
            this.firstDishIngredientsTableView.TabIndex = 26;
            // 
            // firstDishItemImageLabel
            // 
            this.firstDishItemImageLabel.AutoSize = true;
            this.firstDishItemImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F);
            this.firstDishItemImageLabel.Location = new System.Drawing.Point(15, 41);
            this.firstDishItemImageLabel.Name = "firstDishItemImageLabel";
            this.firstDishItemImageLabel.Size = new System.Drawing.Size(245, 153);
            this.firstDishItemImageLabel.TabIndex = 25;
            this.firstDishItemImageLabel.Text = "     ";
            this.firstDishItemImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstDishDescriptionTextLabel
            // 
            this.firstDishDescriptionTextLabel.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstDishDescriptionTextLabel.ForeColor = System.Drawing.Color.Black;
            this.firstDishDescriptionTextLabel.Location = new System.Drawing.Point(275, 152);
            this.firstDishDescriptionTextLabel.Name = "firstDishDescriptionTextLabel";
            this.firstDishDescriptionTextLabel.Size = new System.Drawing.Size(283, 75);
            this.firstDishDescriptionTextLabel.TabIndex = 13;
            this.firstDishDescriptionTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addingProductPage
            // 
            this.addingProductPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addingProductPage.Controls.Add(this.label8);
            this.addingProductPage.Controls.Add(this.label7);
            this.addingProductPage.Controls.Add(this.label6);
            this.addingProductPage.Controls.Add(this.updete_createProductButton);
            this.addingProductPage.Controls.Add(this.label5);
            this.addingProductPage.Controls.Add(this.label4);
            this.addingProductPage.Controls.Add(this.label3);
            this.addingProductPage.Controls.Add(this.label2);
            this.addingProductPage.Controls.Add(this.productNameAddMessageLabel);
            this.addingProductPage.Controls.Add(this.creatingProductPhotoPanel);
            this.addingProductPage.Controls.Add(this.creatingProductTypeSelector);
            this.addingProductPage.Controls.Add(this.creatingProductNameTextField);
            this.addingProductPage.Controls.Add(this.creatingProductFatsTextField);
            this.addingProductPage.Controls.Add(this.creatingProductCarbsTextField);
            this.addingProductPage.Controls.Add(this.creatingProductProteinsTextField);
            this.addingProductPage.Location = new System.Drawing.Point(4, 22);
            this.addingProductPage.Name = "addingProductPage";
            this.addingProductPage.Size = new System.Drawing.Size(667, 514);
            this.addingProductPage.TabIndex = 2;
            this.addingProductPage.Text = "Adding Product";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(333, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(333, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(333, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "%";
            // 
            // updete_createProductButton
            // 
            this.updete_createProductButton.Depth = 0;
            this.updete_createProductButton.Location = new System.Drawing.Point(359, 439);
            this.updete_createProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.updete_createProductButton.Name = "updete_createProductButton";
            this.updete_createProductButton.Primary = true;
            this.updete_createProductButton.Size = new System.Drawing.Size(176, 41);
            this.updete_createProductButton.TabIndex = 17;
            this.updete_createProductButton.Text = "Add product";
            this.updete_createProductButton.UseVisualStyleBackColor = true;
            this.updete_createProductButton.Click += new System.EventHandler(this.updete_createProductButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(160, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "Carbohydrates:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(160, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fats:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Proteins:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Select type:";
            // 
            // productNameAddMessageLabel
            // 
            this.productNameAddMessageLabel.AutoSize = true;
            this.productNameAddMessageLabel.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameAddMessageLabel.Location = new System.Drawing.Point(160, 36);
            this.productNameAddMessageLabel.Name = "productNameAddMessageLabel";
            this.productNameAddMessageLabel.Size = new System.Drawing.Size(65, 21);
            this.productNameAddMessageLabel.TabIndex = 12;
            this.productNameAddMessageLabel.Text = "Name:";
            // 
            // creatingProductPhotoPanel
            // 
            this.creatingProductPhotoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.creatingProductPhotoPanel.Controls.Add(this.creatingProductPhotoLabel);
            this.creatingProductPhotoPanel.Controls.Add(this.photoAddMessageLabel);
            this.creatingProductPhotoPanel.Location = new System.Drawing.Point(160, 76);
            this.creatingProductPhotoPanel.Name = "creatingProductPhotoPanel";
            this.creatingProductPhotoPanel.Size = new System.Drawing.Size(375, 110);
            this.creatingProductPhotoPanel.TabIndex = 11;
            // 
            // creatingProductPhotoLabel
            // 
            this.creatingProductPhotoLabel.AutoSize = true;
            this.creatingProductPhotoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creatingProductPhotoLabel.Location = new System.Drawing.Point(272, 16);
            this.creatingProductPhotoLabel.Name = "creatingProductPhotoLabel";
            this.creatingProductPhotoLabel.Size = new System.Drawing.Size(83, 73);
            this.creatingProductPhotoLabel.TabIndex = 1;
            this.creatingProductPhotoLabel.Text = "   ";
            this.creatingProductPhotoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // photoAddMessageLabel
            // 
            this.photoAddMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photoAddMessageLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.photoAddMessageLabel.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoAddMessageLabel.Location = new System.Drawing.Point(-2, 0);
            this.photoAddMessageLabel.Name = "photoAddMessageLabel";
            this.photoAddMessageLabel.Size = new System.Drawing.Size(258, 106);
            this.photoAddMessageLabel.TabIndex = 0;
            this.photoAddMessageLabel.Text = "Click here to add the image from computer";
            this.photoAddMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.photoAddMessageLabel.Click += new System.EventHandler(this.photoAddMessageLabel_Click);
            // 
            // creatingProductTypeSelector
            // 
            this.creatingProductTypeSelector.AutoCompleteCustomSource.AddRange(new string[] {
            "No"});
            this.creatingProductTypeSelector.BackColor = System.Drawing.Color.White;
            this.creatingProductTypeSelector.CausesValidation = false;
            this.creatingProductTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.creatingProductTypeSelector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.creatingProductTypeSelector.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creatingProductTypeSelector.Items.AddRange(new object[] {
            "No Type"});
            this.creatingProductTypeSelector.Location = new System.Drawing.Point(299, 206);
            this.creatingProductTypeSelector.Name = "creatingProductTypeSelector";
            this.creatingProductTypeSelector.Size = new System.Drawing.Size(236, 31);
            this.creatingProductTypeSelector.TabIndex = 9;
            // 
            // creatingProductNameTextField
            // 
            this.creatingProductNameTextField.Depth = 0;
            this.creatingProductNameTextField.Hint = "";
            this.creatingProductNameTextField.Location = new System.Drawing.Point(231, 34);
            this.creatingProductNameTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.creatingProductNameTextField.Name = "creatingProductNameTextField";
            this.creatingProductNameTextField.PasswordChar = '\0';
            this.creatingProductNameTextField.SelectedText = "";
            this.creatingProductNameTextField.SelectionLength = 0;
            this.creatingProductNameTextField.SelectionStart = 0;
            this.creatingProductNameTextField.Size = new System.Drawing.Size(304, 23);
            this.creatingProductNameTextField.TabIndex = 6;
            this.creatingProductNameTextField.UseSystemPasswordChar = false;
            // 
            // creatingProductFatsTextField
            // 
            this.creatingProductFatsTextField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creatingProductFatsTextField.Depth = 0;
            this.creatingProductFatsTextField.Hint = "";
            this.creatingProductFatsTextField.Location = new System.Drawing.Point(299, 330);
            this.creatingProductFatsTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.creatingProductFatsTextField.Name = "creatingProductFatsTextField";
            this.creatingProductFatsTextField.PasswordChar = '\0';
            this.creatingProductFatsTextField.SelectedText = "";
            this.creatingProductFatsTextField.SelectionLength = 0;
            this.creatingProductFatsTextField.SelectionStart = 0;
            this.creatingProductFatsTextField.Size = new System.Drawing.Size(37, 23);
            this.creatingProductFatsTextField.TabIndex = 2;
            this.creatingProductFatsTextField.Text = "0";
            this.creatingProductFatsTextField.UseSystemPasswordChar = false;
            // 
            // creatingProductCarbsTextField
            // 
            this.creatingProductCarbsTextField.Depth = 0;
            this.creatingProductCarbsTextField.Hint = "";
            this.creatingProductCarbsTextField.Location = new System.Drawing.Point(299, 383);
            this.creatingProductCarbsTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.creatingProductCarbsTextField.Name = "creatingProductCarbsTextField";
            this.creatingProductCarbsTextField.PasswordChar = '\0';
            this.creatingProductCarbsTextField.SelectedText = "";
            this.creatingProductCarbsTextField.SelectionLength = 0;
            this.creatingProductCarbsTextField.SelectionStart = 0;
            this.creatingProductCarbsTextField.Size = new System.Drawing.Size(37, 23);
            this.creatingProductCarbsTextField.TabIndex = 1;
            this.creatingProductCarbsTextField.Text = "0";
            this.creatingProductCarbsTextField.UseSystemPasswordChar = false;
            // 
            // creatingProductProteinsTextField
            // 
            this.creatingProductProteinsTextField.Depth = 0;
            this.creatingProductProteinsTextField.Hint = "";
            this.creatingProductProteinsTextField.Location = new System.Drawing.Point(299, 277);
            this.creatingProductProteinsTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.creatingProductProteinsTextField.Name = "creatingProductProteinsTextField";
            this.creatingProductProteinsTextField.PasswordChar = '\0';
            this.creatingProductProteinsTextField.SelectedText = "";
            this.creatingProductProteinsTextField.SelectionLength = 0;
            this.creatingProductProteinsTextField.SelectionStart = 0;
            this.creatingProductProteinsTextField.Size = new System.Drawing.Size(37, 23);
            this.creatingProductProteinsTextField.TabIndex = 0;
            this.creatingProductProteinsTextField.Text = "0";
            this.creatingProductProteinsTextField.UseSystemPasswordChar = false;
            // 
            // addingRecipePage
            // 
            this.addingRecipePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addingRecipePage.Controls.Add(this.addingRecipeMessageLabel);
            this.addingRecipePage.Controls.Add(this.ingredientsTableView);
            this.addingRecipePage.Controls.Add(this.addRecipeButton);
            this.addingRecipePage.Controls.Add(this.label19);
            this.addingRecipePage.Controls.Add(this.newRecipeRichTextField);
            this.addingRecipePage.Controls.Add(this.label18);
            this.addingRecipePage.Controls.Add(this.label9);
            this.addingRecipePage.Controls.Add(this.panel1);
            this.addingRecipePage.Controls.Add(this.newRecipeNameTextField);
            this.addingRecipePage.Controls.Add(this.newRecipeErrorLabel);
            this.addingRecipePage.Location = new System.Drawing.Point(4, 22);
            this.addingRecipePage.Name = "addingRecipePage";
            this.addingRecipePage.Size = new System.Drawing.Size(667, 514);
            this.addingRecipePage.TabIndex = 3;
            this.addingRecipePage.Text = "Adding recipe";
            this.addingRecipePage.Enter += new System.EventHandler(this.addingRecipePage_Enter);
            // 
            // addingRecipeMessageLabel
            // 
            this.addingRecipeMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addingRecipeMessageLabel.Font = new System.Drawing.Font("Berlin Sans FB", 35F, System.Drawing.FontStyle.Underline);
            this.addingRecipeMessageLabel.Location = new System.Drawing.Point(3, 0);
            this.addingRecipeMessageLabel.Name = "addingRecipeMessageLabel";
            this.addingRecipeMessageLabel.Size = new System.Drawing.Size(88, 511);
            this.addingRecipeMessageLabel.TabIndex = 0;
            this.addingRecipeMessageLabel.Text = "Please select more than one product at the product list to form from them a dish " +
    "here.";
            this.addingRecipeMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addingRecipeMessageLabel.Visible = false;
            this.addingRecipeMessageLabel.Click += new System.EventHandler(this.addingRecipeMessageLabel_Click);
            // 
            // ingredientsTableView
            // 
            this.ingredientsTableView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ingredientsTableView.ColumnCount = 2;
            this.ingredientsTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.10904F));
            this.ingredientsTableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.89096F));
            this.ingredientsTableView.Location = new System.Drawing.Point(224, 285);
            this.ingredientsTableView.Name = "ingredientsTableView";
            this.ingredientsTableView.RowCount = 2;
            this.ingredientsTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ingredientsTableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ingredientsTableView.Size = new System.Drawing.Size(265, 119);
            this.ingredientsTableView.TabIndex = 18;
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.Depth = 0;
            this.addRecipeButton.Location = new System.Drawing.Point(476, 474);
            this.addRecipeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Primary = true;
            this.addRecipeButton.Size = new System.Drawing.Size(188, 37);
            this.addRecipeButton.TabIndex = 22;
            this.addRecipeButton.Text = "Add Recipe";
            this.addRecipeButton.UseVisualStyleBackColor = true;
            this.addRecipeButton.Click += new System.EventHandler(this.addRecipeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(146, 407);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 21);
            this.label19.TabIndex = 21;
            this.label19.Text = "Description:";
            // 
            // newRecipeRichTextField
            // 
            this.newRecipeRichTextField.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRecipeRichTextField.Location = new System.Drawing.Point(150, 431);
            this.newRecipeRichTextField.Name = "newRecipeRichTextField";
            this.newRecipeRichTextField.Size = new System.Drawing.Size(278, 44);
            this.newRecipeRichTextField.TabIndex = 20;
            this.newRecipeRichTextField.Text = "";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(146, 221);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(449, 61);
            this.label18.TabIndex = 17;
            this.label18.Text = "Write please weight in front of every product, or leave 0 if you want to add the " +
    "product to the dish to taste:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(153, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 21);
            this.label9.TabIndex = 15;
            this.label9.Text = "Name:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.newRecipeImageLabel);
            this.panel1.Controls.Add(this.newRecipePhotoAddLabel);
            this.panel1.Location = new System.Drawing.Point(150, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 154);
            this.panel1.TabIndex = 14;
            // 
            // newRecipeImageLabel
            // 
            this.newRecipeImageLabel.AutoSize = true;
            this.newRecipeImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F);
            this.newRecipeImageLabel.Location = new System.Drawing.Point(183, -3);
            this.newRecipeImageLabel.Name = "newRecipeImageLabel";
            this.newRecipeImageLabel.Size = new System.Drawing.Size(245, 153);
            this.newRecipeImageLabel.TabIndex = 24;
            this.newRecipeImageLabel.Text = "     ";
            this.newRecipeImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newRecipePhotoAddLabel
            // 
            this.newRecipePhotoAddLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newRecipePhotoAddLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.newRecipePhotoAddLabel.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRecipePhotoAddLabel.Location = new System.Drawing.Point(-2, 0);
            this.newRecipePhotoAddLabel.Name = "newRecipePhotoAddLabel";
            this.newRecipePhotoAddLabel.Size = new System.Drawing.Size(184, 150);
            this.newRecipePhotoAddLabel.TabIndex = 0;
            this.newRecipePhotoAddLabel.Text = "Click here to add the image from computer";
            this.newRecipePhotoAddLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newRecipePhotoAddLabel.Click += new System.EventHandler(this.newRecipePhotoAddLabel_Click);
            // 
            // newRecipeNameTextField
            // 
            this.newRecipeNameTextField.Depth = 0;
            this.newRecipeNameTextField.Hint = "";
            this.newRecipeNameTextField.Location = new System.Drawing.Point(224, 22);
            this.newRecipeNameTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.newRecipeNameTextField.Name = "newRecipeNameTextField";
            this.newRecipeNameTextField.PasswordChar = '\0';
            this.newRecipeNameTextField.SelectedText = "";
            this.newRecipeNameTextField.SelectionLength = 0;
            this.newRecipeNameTextField.SelectionStart = 0;
            this.newRecipeNameTextField.Size = new System.Drawing.Size(361, 23);
            this.newRecipeNameTextField.TabIndex = 13;
            this.newRecipeNameTextField.UseSystemPasswordChar = false;
            // 
            // newRecipeErrorLabel
            // 
            this.newRecipeErrorLabel.AutoSize = true;
            this.newRecipeErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.newRecipeErrorLabel.Location = new System.Drawing.Point(586, 137);
            this.newRecipeErrorLabel.Name = "newRecipeErrorLabel";
            this.newRecipeErrorLabel.Size = new System.Drawing.Size(32, 13);
            this.newRecipeErrorLabel.TabIndex = 23;
            this.newRecipeErrorLabel.Text = "Error ";
            this.newRecipeErrorLabel.Visible = false;
            // 
            // labelWithMyName
            // 
            this.labelWithMyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWithMyName.AutoEllipsis = true;
            this.labelWithMyName.AutoSize = true;
            this.labelWithMyName.Font = new System.Drawing.Font("Brush Script MT", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWithMyName.Location = new System.Drawing.Point(602, 594);
            this.labelWithMyName.Name = "labelWithMyName";
            this.labelWithMyName.Size = new System.Drawing.Size(92, 18);
            this.labelWithMyName.TabIndex = 3;
            this.labelWithMyName.Text = "Designed by Oleg";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 24);
            this.ClientSize = new System.Drawing.Size(706, 605);
            this.Controls.Add(this.pageSelector);
            this.Controls.Add(this.labelWithMyName);
            this.Controls.Add(this.pages);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pages.ResumeLayout(false);
            this.productsPage.ResumeLayout(false);
            this.productsPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.dishesPage.ResumeLayout(false);
            this.dishesPage.PerformLayout();
            this.secondDishGroupBox.ResumeLayout(false);
            this.secondDishGroupBox.PerformLayout();
            this.firstDishGroupBox.ResumeLayout(false);
            this.firstDishGroupBox.PerformLayout();
            this.addingProductPage.ResumeLayout(false);
            this.addingProductPage.PerformLayout();
            this.creatingProductPhotoPanel.ResumeLayout(false);
            this.creatingProductPhotoPanel.PerformLayout();
            this.addingRecipePage.ResumeLayout(false);
            this.addingRecipePage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl pages;
        private System.Windows.Forms.TabPage productsPage;
        private System.Windows.Forms.TabPage dishesPage;
        private MaterialSkin.Controls.MaterialTabSelector pageSelector;
        private MaterialSkin.Controls.MaterialRaisedButton addNewProductButton;
        private System.Windows.Forms.Label labelWithMyName;
        private System.Windows.Forms.TableLayoutPanel productTableView;
        private MaterialSkin.Controls.MaterialRaisedButton carbsSortButton;
        private MaterialSkin.Controls.MaterialRaisedButton fatsSortButton;
        private MaterialSkin.Controls.MaterialRaisedButton proteinsSortButton;
        private System.Windows.Forms.ComboBox filterProductComboBox;
        private System.ComponentModel.BackgroundWorker backgroundProductImageUploader;
        private MaterialSkin.Controls.MaterialRaisedButton nameSortButton;
        private System.Windows.Forms.Label leftSideLabel;
        private System.Windows.Forms.Button rightSideProductListButton;
        private System.Windows.Forms.Button leftSideProductListButton;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton makeRecipeButton;
        private System.Windows.Forms.ListBox selectedProductsListBox;
        private System.Windows.Forms.TabPage addingProductPage;
        private System.Windows.Forms.TabPage addingRecipePage;
        private System.Windows.Forms.Label addingRecipeMessageLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label noMoreProductMessageLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField creatingProductFatsTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField creatingProductCarbsTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField creatingProductProteinsTextField;
        private System.Windows.Forms.ComboBox creatingProductTypeSelector;
        private MaterialSkin.Controls.MaterialSingleLineTextField creatingProductNameTextField;
        private System.Windows.Forms.Panel creatingProductPhotoPanel;
        private System.Windows.Forms.Label productNameAddMessageLabel;
        private System.Windows.Forms.Label photoAddMessageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialRaisedButton updete_createProductButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label newRecipePhotoAddLabel;
        private System.Windows.Forms.GroupBox firstDishGroupBox;
        private System.Windows.Forms.Label firstDishDescriptionTextLabel;
        private System.Windows.Forms.Label label17;
        private MaterialSkin.Controls.MaterialSingleLineTextField searchProductTextField;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TableLayoutPanel ingredientsTableView;
        private MaterialSkin.Controls.MaterialRaisedButton addRecipeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox newRecipeRichTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField newRecipeNameTextField;
        private System.Windows.Forms.Label creatingProductPhotoLabel;
        private System.Windows.Forms.Label newRecipeErrorLabel;
        private System.Windows.Forms.Label newRecipeImageLabel;
        private System.Windows.Forms.Label label16;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private System.Windows.Forms.GroupBox secondDishGroupBox;
        private System.Windows.Forms.Label secondDishItemImageLabel;
        private System.Windows.Forms.Label firstDishItemImageLabel;
        private System.Windows.Forms.TableLayoutPanel secondDishIngredientsTableView;
        private System.Windows.Forms.TableLayoutPanel firstDishIngredientsTableView;
        private System.Windows.Forms.Label secondDishDescriptionTextLabel;
        private System.Windows.Forms.Button leftSideDishListButton;
        private System.Windows.Forms.Button rightSideDishListButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
    }
}