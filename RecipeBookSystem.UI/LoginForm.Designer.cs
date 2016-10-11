namespace RecipeBookSystem.UI
{
    partial class LoginForm
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
            this.createNewAccountButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.userNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.passwordTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.emailTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.nameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.userLoginButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.userRegisterButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cancelButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // createNewAccountButton
            // 
            this.createNewAccountButton.AutoSize = true;
            this.createNewAccountButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createNewAccountButton.Depth = 0;
            this.createNewAccountButton.Location = new System.Drawing.Point(209, 191);
            this.createNewAccountButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.createNewAccountButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.createNewAccountButton.Name = "createNewAccountButton";
            this.createNewAccountButton.Primary = false;
            this.createNewAccountButton.Size = new System.Drawing.Size(163, 36);
            this.createNewAccountButton.TabIndex = 10;
            this.createNewAccountButton.Text = "Create new account";
            this.createNewAccountButton.UseVisualStyleBackColor = true;
            this.createNewAccountButton.Click += new System.EventHandler(this.createNewAccountButton_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Depth = 0;
            this.userNameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.userNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.userNameLabel.Location = new System.Drawing.Point(68, 80);
            this.userNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(57, 19);
            this.userNameLabel.TabIndex = 9;
            this.userNameLabel.Text = "Name: ";
            this.userNameLabel.Visible = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(68, 113);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(55, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Email: ";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(68, 150);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(79, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "Password:";
            // 
            // passwordTextField
            // 
            this.passwordTextField.Depth = 0;
            this.passwordTextField.Hint = "";
            this.passwordTextField.Location = new System.Drawing.Point(180, 148);
            this.passwordTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordTextField.Name = "passwordTextField";
            this.passwordTextField.PasswordChar = '\0';
            this.passwordTextField.SelectedText = "";
            this.passwordTextField.SelectionLength = 0;
            this.passwordTextField.SelectionStart = 0;
            this.passwordTextField.Size = new System.Drawing.Size(192, 23);
            this.passwordTextField.TabIndex = 4;
            this.passwordTextField.UseSystemPasswordChar = true;
            // 
            // emailTextField
            // 
            this.emailTextField.Depth = 0;
            this.emailTextField.Font = new System.Drawing.Font("Mistral", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailTextField.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.emailTextField.Hint = "";
            this.emailTextField.Location = new System.Drawing.Point(180, 113);
            this.emailTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.emailTextField.Name = "emailTextField";
            this.emailTextField.PasswordChar = '\0';
            this.emailTextField.SelectedText = "";
            this.emailTextField.SelectionLength = 0;
            this.emailTextField.SelectionStart = 0;
            this.emailTextField.Size = new System.Drawing.Size(192, 23);
            this.emailTextField.TabIndex = 3;
            this.emailTextField.UseSystemPasswordChar = false;
            // 
            // nameTextField
            // 
            this.nameTextField.Depth = 0;
            this.nameTextField.Hint = "";
            this.nameTextField.Location = new System.Drawing.Point(180, 76);
            this.nameTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.nameTextField.Name = "nameTextField";
            this.nameTextField.PasswordChar = '\0';
            this.nameTextField.SelectedText = "";
            this.nameTextField.SelectionLength = 0;
            this.nameTextField.SelectionStart = 0;
            this.nameTextField.Size = new System.Drawing.Size(192, 23);
            this.nameTextField.TabIndex = 2;
            this.nameTextField.UseSystemPasswordChar = false;
            this.nameTextField.Visible = false;
            // 
            // userLoginButton
            // 
            this.userLoginButton.Depth = 0;
            this.userLoginButton.Font = new System.Drawing.Font("Berlin Sans FB", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLoginButton.Location = new System.Drawing.Point(72, 191);
            this.userLoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.userLoginButton.Name = "userLoginButton";
            this.userLoginButton.Primary = true;
            this.userLoginButton.Size = new System.Drawing.Size(130, 33);
            this.userLoginButton.TabIndex = 0;
            this.userLoginButton.Text = "Login";
            this.userLoginButton.UseVisualStyleBackColor = true;
            this.userLoginButton.Click += new System.EventHandler(this.userLoginButton_Click);
            // 
            // userRegisterButton
            // 
            this.userRegisterButton.Depth = 0;
            this.userRegisterButton.Location = new System.Drawing.Point(72, 191);
            this.userRegisterButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.userRegisterButton.Name = "userRegisterButton";
            this.userRegisterButton.Primary = true;
            this.userRegisterButton.Size = new System.Drawing.Size(130, 33);
            this.userRegisterButton.TabIndex = 11;
            this.userRegisterButton.Text = "Register";
            this.userRegisterButton.UseVisualStyleBackColor = true;
            this.userRegisterButton.Click += new System.EventHandler(this.userRegisterButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Depth = 0;
            this.cancelButton.Location = new System.Drawing.Point(209, 191);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Primary = true;
            this.cancelButton.Size = new System.Drawing.Size(163, 33);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 261);
            this.Controls.Add(this.createNewAccountButton);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.passwordTextField);
            this.Controls.Add(this.emailTextField);
            this.Controls.Add(this.nameTextField);
            this.Controls.Add(this.userLoginButton);
            this.Controls.Add(this.userRegisterButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton userLoginButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField nameTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField emailTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField passwordTextField;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel userNameLabel;
        private MaterialSkin.Controls.MaterialFlatButton createNewAccountButton;
        private MaterialSkin.Controls.MaterialRaisedButton userRegisterButton;
        private MaterialSkin.Controls.MaterialRaisedButton cancelButton;
    }
}