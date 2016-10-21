using System;
//Review RZ: unused namespaces shoud remove
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeBookSystem.UI
{
    static class Program
    {
        // Review RZ: should write comments in english  
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            // Review RZ: this comment has not sense
            
            //перейменувати CurrentUser в LogedUser
            Application.Run(new MainForm(loginForm.CurrentUser));
        }
    }
}
