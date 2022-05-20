using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgrammForms
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green900, Primary.Green900, Primary.Green500, Accent.LightGreen400, TextShade.WHITE);
        }

        private void materialListBox1_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            if (materialComboBox1.SelectedItem.ToString() == "Зелёный")
            {          
               
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green900, Primary.Green900, Primary.Green500, Accent.LightGreen400, TextShade.WHITE);
                pictureBox1.Image = Properties.Resources.green_logo_png;
                materialSkinManager.AddFormToManage(this);
            }
            if (materialComboBox1.SelectedItem.ToString() == "Синий")
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue900, Primary.Blue500, Accent.LightBlue400, TextShade.WHITE);

               

                pictureBox1.Image = Properties.Resources.blue_logo_png;
                materialSkinManager.AddFormToManage(this);
            }
            if (materialComboBox1.SelectedItem.ToString() == "Фиолетовый")     
            {
              
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.Purple900, Primary.Purple500, Accent.DeepPurple400, TextShade.WHITE);


                pictureBox1.Image = Properties.Resources.purple_logo_png;
            }

            if (materialSwitch1.Checked)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }

     
    }
}
