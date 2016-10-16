using RecipeBookSystem.BL.Helpers;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;
using RecipeBookSystem.UI.Models.FormModels;
using RecipeBookSystem.UI.Properties;
using System;
using System.Windows.Forms;

namespace RecipeBookSystem.UI
{
    /// <summary>
    /// The form that enables the user to sign up and log in
    /// </summary>
    public partial class LoginForm : MaterialFormBaseModel
    {
        /// <summary>
        /// A user who is using the program
        /// </summary>
        public UserModel CurrentUser
        {
            get;
            private set;
        }

        private readonly UserProvider userProvider;

        public LoginForm()
        {
            InitializeComponent();
            
            this.userProvider = new UserProvider();

            //Test user(login info) who already has a list of available recipes
            emailTextField.Text = "test@gmail.com";
            passwordTextField.Text = "1234";
        }

        private void createNewAccountButton_Click(object sender, EventArgs e)
        {
            showRegisterMenu();
        }

        private void userRegisterButton_Click(object sender, EventArgs e)
        {
            string name = nameTextField.Text;
            string password = passwordTextField.Text;
            string email = emailTextField.Text;

            if(password == string.Empty || email == string.Empty || name == string.Empty)
            {
                MessageBox.Show(Resources.EnterAllFieldsMessage, Resources.WarningMessage);
                return;
            }

            var newUser = new UserModel() {
                Name = name,
                Email = email,
                Password = PasswordEncryptionProvider.EncryptPassword(password)
            };

            bool wasUserAdded;

            try
            {
                wasUserAdded = userProvider.AddUser(newUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
                return;
            }

            if (wasUserAdded)
            {
                MessageBox.Show((name + Resources.AddedMessame), Resources.SuccessMessage);
                clearFields();
                this.nameTextField.Visible = false;
                this.userNameLabel.Visible = false;
                this.createNewAccountButton.Visible = true;
                this.userLoginButton.Visible = true;
                this.cancelButton.Visible = false;
            }
            else
            {
                MessageBox.Show(Resources.UserExistsMessage, Resources.ErrorMessage);
            }
            
        }

        private void userLoginButton_Click(object sender, EventArgs e)
        {
            string password = passwordTextField.Text;
            string email = emailTextField.Text;

            if (password == string.Empty || email == string.Empty)
            {
                MessageBox.Show(Resources.EnterAllFieldsMessage, Resources.WarningMessage);
                return;
            }

            UserModel user;

            try
            {
                user = userProvider.GetUser(email, PasswordEncryptionProvider.EncryptPassword(password));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessage);
                return;
            }

            if(user != null)
            {
                this.CurrentUser = user;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(Resources.IncorrectLoginPasswordMessage, Resources.IncorrectInputMessage);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            showLoginMenu();
        }

        private void showRegisterMenu()
        {
            clearFields();
            this.nameTextField.Visible = true;
            this.userNameLabel.Visible = true;
            this.createNewAccountButton.Visible = false;
            this.userLoginButton.Visible = false;
            this.cancelButton.Visible = true;
        }

        private void showLoginMenu()
        {
            clearFields();
            this.nameTextField.Visible = false;
            this.userNameLabel.Visible = false;
            this.createNewAccountButton.Visible = true;
            this.userLoginButton.Visible = true;
            this.cancelButton.Visible = false;
        }

        private void clearFields()
        {
            this.emailTextField.Text = string.Empty;
            this.passwordTextField.Text = string.Empty;
            this.nameTextField.Text = string.Empty;
        }
    }
}

