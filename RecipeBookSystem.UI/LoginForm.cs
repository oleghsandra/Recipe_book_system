using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;
using RecipeBookSystem.UI.Models.FormModels;
using System;
using System.Windows.Forms;

namespace RecipeBookSystem.UI
{
    public partial class LoginForm : MaterialFormBaseModel
    {
        public UserModel CurrentUser
        {
            get;
            private set;
        }

        private UserProvider userProvider;

        public LoginForm()
        {
            InitializeComponent();
            userProvider = new UserProvider();
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
                // використати це - Resources.SomeMessahe
                MessageBox.Show(this, "Enter all fields!", "Warning!");
                return;
            }

            var newUser = new UserModel() {
                Name = name,
                Email = email,
                Password = password
            };

            bool wasUserAdded = userProvider.AddUser(newUser);

            if (wasUserAdded)
            {
                MessageBox.Show(this, (name + " Added"), "Success!");
                clearFields();
                nameTextField.Visible = false;
                userNameLabel.Visible = false;
                createNewAccountButton.Visible = true;
                userLoginButton.Visible = true;
                cancelButton.Visible = false;
            }
            else
            {
                MessageBox.Show("User exists", "Error!");
            }
            
        }

        private void userLoginButton_Click(object sender, EventArgs e)
        {
            string password = passwordTextField.Text;
            string email = emailTextField.Text;

            if (password == string.Empty || email == string.Empty)
            {
                MessageBox.Show(this, "Enter all fields!", "Warning!");
                return;
            }

            var user = userProvider.GetUser(email, password);

            if(user != null)
            {
                CurrentUser = user;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect login or password", "Incorrect input!");
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            showLoginMenu();
        }

        private void showRegisterMenu()
        {
            clearFields();
            nameTextField.Visible = true;
            userNameLabel.Visible = true;
            createNewAccountButton.Visible = false;
            userLoginButton.Visible = false;
            cancelButton.Visible = true;
        }

        private void showLoginMenu()
        {
            clearFields();
            nameTextField.Visible = false;
            userNameLabel.Visible = false;
            createNewAccountButton.Visible = true;
            userLoginButton.Visible = true;
            cancelButton.Visible = false;
        }

        private void clearFields()
        {
            emailTextField.Text = string.Empty;
            passwordTextField.Text = string.Empty;
            nameTextField.Text = string.Empty;
        }
    }
}

