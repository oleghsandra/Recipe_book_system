using MaterialSkin;
using MaterialSkin.Controls;

namespace RecipeBookSystem.UI.Models.FormModels
{
    /// <summary>
    /// The basic form for other forms of application
    /// containing common properties and design.
    /// </summary>
    public class MaterialFormBaseModel : MaterialForm
    {
        private MaterialSkinManager skipManager;

        public MaterialFormBaseModel()
        {
            InitializeComponent();

            skipManager = MaterialSkinManager.Instance;
            skipManager.AddFormToManage(this);
            skipManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skipManager.ColorScheme = new ColorScheme
                   (Primary.LightGreen800,
                   Primary.BlueGrey500,
                   Primary.Green400,
                   Accent.Red200,
                   TextShade.BLACK);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MaterialFormBaseModel
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.MaximizeBox = false;
            this.Name = "MaterialFormBaseModel";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
