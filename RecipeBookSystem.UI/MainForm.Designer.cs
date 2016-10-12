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
            this.components = new System.ComponentModel.Container();
            this.backgroundImageUploader = new System.ComponentModel.BackgroundWorker();
            this.SpinnerTimer = new System.Windows.Forms.Timer(this.components);
            this.pageSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.pages = new MaterialSkin.Controls.MaterialTabControl();
            this.productsPage = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.searchProductTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.noMoreProductMessageLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedProductsListBox = new System.Windows.Forms.ListBox();
            this.makeRecipeButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.leftSideButton = new System.Windows.Forms.Button();
            this.rightSideButton = new System.Windows.Forms.Button();
            this.leftSideLabel = new System.Windows.Forms.Label();
            this.carbsSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.fatsSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addNewProductButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.proteinsSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.productTableView = new System.Windows.Forms.TableLayoutPanel();
            this.nameSortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.filterProductComboBox = new System.Windows.Forms.ComboBox();
            this.dishesPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
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
            this.creatingProductPhoto = new System.Windows.Forms.PictureBox();
            this.photoAddMessageLabel = new System.Windows.Forms.Label();
            this.creatingProductTypeSelector = new System.Windows.Forms.ComboBox();
            this.creatingProductNameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.creatingProductFatsTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.creatingProductCarbsTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.creatingProductProteinsTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.addingRecipePage = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.addingRecipeMessageLabel = new System.Windows.Forms.Label();
            this.labelWithMyName = new System.Windows.Forms.Label();
            this.pages.SuspendLayout();
            this.productsPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dishesPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.addingProductPage.SuspendLayout();
            this.creatingProductPhotoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.creatingProductPhoto)).BeginInit();
            this.addingRecipePage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundImageUploader
            // 
            this.backgroundImageUploader.WorkerSupportsCancellation = true;
            this.backgroundImageUploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundImageUploader_DoWork);
            // 
            // SpinnerTimer
            // 
            this.SpinnerTimer.Interval = 1000;
            // 
            // pageSelector
            // 
            this.pageSelector.BaseTabControl = this.pages;
            this.pageSelector.Depth = 0;
            this.pageSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pageSelector.Location = new System.Drawing.Point(-12, 24);
            this.pageSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.pageSelector.Name = "pageSelector";
            this.pageSelector.Size = new System.Drawing.Size(718, 21);
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
            this.productsPage.Controls.Add(this.label17);
            this.productsPage.Controls.Add(this.searchProductTextField);
            this.productsPage.Controls.Add(this.noMoreProductMessageLabel);
            this.productsPage.Controls.Add(this.groupBox1);
            this.productsPage.Controls.Add(this.makeRecipeButton);
            this.productsPage.Controls.Add(this.label1);
            this.productsPage.Controls.Add(this.leftSideButton);
            this.productsPage.Controls.Add(this.rightSideButton);
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
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(216, 409);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 21);
            this.label17.TabIndex = 234;
            this.label17.Text = "Search:";
            // 
            // searchProductTextField
            // 
            this.searchProductTextField.Depth = 0;
            this.searchProductTextField.Hint = "";
            this.searchProductTextField.Location = new System.Drawing.Point(301, 407);
            this.searchProductTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchProductTextField.Name = "searchProductTextField";
            this.searchProductTextField.PasswordChar = '\0';
            this.searchProductTextField.SelectedText = "";
            this.searchProductTextField.SelectionLength = 0;
            this.searchProductTextField.SelectionStart = 0;
            this.searchProductTextField.Size = new System.Drawing.Size(161, 23);
            this.searchProductTextField.TabIndex = 233;
            this.searchProductTextField.UseSystemPasswordChar = false;
            this.searchProductTextField.TextChanged += new System.EventHandler(this.searchProductTextField_TextChanged);
            // 
            // noMoreProductMessageLabel
            // 
            this.noMoreProductMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noMoreProductMessageLabel.Font = new System.Drawing.Font("Berlin Sans FB", 35F, System.Drawing.FontStyle.Underline);
            this.noMoreProductMessageLabel.Location = new System.Drawing.Point(39, 105);
            this.noMoreProductMessageLabel.Name = "noMoreProductMessageLabel";
            this.noMoreProductMessageLabel.Size = new System.Drawing.Size(520, 222);
            this.noMoreProductMessageLabel.TabIndex = 232;
            this.noMoreProductMessageLabel.Text = "Oop\'s, no more products. If you have not found the needed product, add it.";
            this.noMoreProductMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noMoreProductMessageLabel.Visible = false;
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
            this.makeRecipeButton.Location = new System.Drawing.Point(301, 459);
            this.makeRecipeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.makeRecipeButton.Name = "makeRecipeButton";
            this.makeRecipeButton.Primary = true;
            this.makeRecipeButton.Size = new System.Drawing.Size(258, 52);
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
            // leftSideButton
            // 
            this.leftSideButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.leftSideButton.Location = new System.Drawing.Point(562, 398);
            this.leftSideButton.Name = "leftSideButton";
            this.leftSideButton.Size = new System.Drawing.Size(45, 40);
            this.leftSideButton.TabIndex = 12;
            this.leftSideButton.UseVisualStyleBackColor = false;
            this.leftSideButton.Click += new System.EventHandler(this.leftSideButton_Click);
            // 
            // rightSideButton
            // 
            this.rightSideButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rightSideButton.Location = new System.Drawing.Point(613, 398);
            this.rightSideButton.Name = "rightSideButton";
            this.rightSideButton.Size = new System.Drawing.Size(45, 40);
            this.rightSideButton.TabIndex = 11;
            this.rightSideButton.UseVisualStyleBackColor = false;
            this.rightSideButton.Click += new System.EventHandler(this.rightSideButton_Click);
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
            this.addNewProductButton.Location = new System.Drawing.Point(174, 459);
            this.addNewProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addNewProductButton.Name = "addNewProductButton";
            this.addNewProductButton.Primary = true;
            this.addNewProductButton.Size = new System.Drawing.Size(110, 52);
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
            this.filterProductComboBox.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterProductComboBox.FormattingEnabled = true;
            this.filterProductComboBox.Items.AddRange(new object[] {
            "All"});
            this.filterProductComboBox.Location = new System.Drawing.Point(266, 3);
            this.filterProductComboBox.Name = "filterProductComboBox";
            this.filterProductComboBox.Size = new System.Drawing.Size(97, 29);
            this.filterProductComboBox.TabIndex = 8;
            this.filterProductComboBox.SelectedIndexChanged += new System.EventHandler(this.filterProductComboBox_SelectedIndexChanged);
            // 
            // dishesPage
            // 
            this.dishesPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dishesPage.Controls.Add(this.groupBox3);
            this.dishesPage.Controls.Add(this.groupBox2);
            this.dishesPage.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dishesPage.ForeColor = System.Drawing.Color.White;
            this.dishesPage.Location = new System.Drawing.Point(4, 22);
            this.dishesPage.Name = "dishesPage";
            this.dishesPage.Padding = new System.Windows.Forms.Padding(3);
            this.dishesPage.Size = new System.Drawing.Size(667, 514);
            this.dishesPage.TabIndex = 1;
            this.dishesPage.Text = "My dishes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Controls.Add(this.panel5);
            this.groupBox3.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(46, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 232);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dish1";
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(306, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(217, 45);
            this.label14.TabIndex = 13;
            this.label14.Text = "Description here";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(20, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 171);
            this.panel4.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(12, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(217, 101);
            this.label15.TabIndex = 14;
            this.label15.Text = "Image 240\\144px here";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(3, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(240, 144);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(310, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(235, 94);
            this.panel5.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(3, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(214, 70);
            this.label16.TabIndex = 14;
            this.label16.Text = "Table(with scroll) with product name - weight here";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(46, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 232);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dish1";
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(306, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(217, 45);
            this.label11.TabIndex = 13;
            this.label11.Text = "Description here";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(20, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 171);
            this.panel3.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(12, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(217, 101);
            this.label13.TabIndex = 14;
            this.label13.Text = "Image 240\\144px here";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(3, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 144);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(310, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 94);
            this.panel2.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(214, 70);
            this.label12.TabIndex = 14;
            this.label12.Text = "Table(with scroll) with product name - weight here";
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
            this.creatingProductPhotoPanel.Controls.Add(this.creatingProductPhoto);
            this.creatingProductPhotoPanel.Controls.Add(this.photoAddMessageLabel);
            this.creatingProductPhotoPanel.Location = new System.Drawing.Point(160, 76);
            this.creatingProductPhotoPanel.Name = "creatingProductPhotoPanel";
            this.creatingProductPhotoPanel.Size = new System.Drawing.Size(375, 110);
            this.creatingProductPhotoPanel.TabIndex = 11;
            // 
            // creatingProductPhoto
            // 
            this.creatingProductPhoto.Location = new System.Drawing.Point(274, 21);
            this.creatingProductPhoto.Name = "creatingProductPhoto";
            this.creatingProductPhoto.Size = new System.Drawing.Size(80, 64);
            this.creatingProductPhoto.TabIndex = 1;
            this.creatingProductPhoto.TabStop = false;
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
            this.creatingProductTypeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(235)))), ((int)(((byte)(180)))));
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
            this.addingRecipePage.Controls.Add(this.label9);
            this.addingRecipePage.Controls.Add(this.panel1);
            this.addingRecipePage.Controls.Add(this.materialSingleLineTextField1);
            this.addingRecipePage.Controls.Add(this.addingRecipeMessageLabel);
            this.addingRecipePage.Location = new System.Drawing.Point(4, 22);
            this.addingRecipePage.Name = "addingRecipePage";
            this.addingRecipePage.Size = new System.Drawing.Size(667, 514);
            this.addingRecipePage.TabIndex = 3;
            this.addingRecipePage.Text = "Adding recipe";
            this.addingRecipePage.Click += new System.EventHandler(this.addingRecipePage_Click);
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
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(153, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 110);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(274, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 64);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label10.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(-2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(258, 106);
            this.label10.TabIndex = 0;
            this.label10.Text = "Click here to add the image from computer";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(224, 22);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(192, 23);
            this.materialSingleLineTextField1.TabIndex = 13;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // addingRecipeMessageLabel
            // 
            this.addingRecipeMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addingRecipeMessageLabel.Font = new System.Drawing.Font("Berlin Sans FB", 35F, System.Drawing.FontStyle.Underline);
            this.addingRecipeMessageLabel.Location = new System.Drawing.Point(3, 346);
            this.addingRecipeMessageLabel.Name = "addingRecipeMessageLabel";
            this.addingRecipeMessageLabel.Size = new System.Drawing.Size(614, 181);
            this.addingRecipeMessageLabel.TabIndex = 0;
            this.addingRecipeMessageLabel.Text = "Please select more than one product at the product list to form from them a dish " +
    "here.";
            this.addingRecipeMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addingRecipeMessageLabel.Visible = false;
            this.addingRecipeMessageLabel.Click += new System.EventHandler(this.addingRecipeMessageLabel_Click);
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
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.addingProductPage.ResumeLayout(false);
            this.addingProductPage.PerformLayout();
            this.creatingProductPhotoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.creatingProductPhoto)).EndInit();
            this.addingRecipePage.ResumeLayout(false);
            this.addingRecipePage.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.ComponentModel.BackgroundWorker backgroundImageUploader;
        private MaterialSkin.Controls.MaterialRaisedButton nameSortButton;
        private System.Windows.Forms.Timer SpinnerTimer;
        private System.Windows.Forms.Label leftSideLabel;
        private System.Windows.Forms.Button rightSideButton;
        private System.Windows.Forms.Button leftSideButton;
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
        private System.Windows.Forms.PictureBox creatingProductPhoto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private MaterialSkin.Controls.MaterialSingleLineTextField searchProductTextField;
    }
}