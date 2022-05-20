using MainProgrammForms;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LoginAndRegister
{
    public partial class LoginForm : Form
    {
        public static MySqlConnection CreateConnection()
        {
            try
            {
                string host = "localhost";
                int port = 3306;
                string database = "zoo_users";
                string username = "root";
                string password = "1234";

                string connString = "Server=" + host + ";Database=" + database +
                    ";port=" + port + ";User Id=" + username + ";password=" + password;

                return new MySqlConnection(connString);
            }
            catch (Exception)
            {

                throw new Exception("База данных не была подключена!");
            }

        }

        public LoginForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myCon = CreateConnection();
            myCon.Open();

            string login = "SELECT * FROM data WHERE username = @username and password = @password";
            MySqlCommand command = new MySqlCommand(login, myCon);

            command.Parameters.AddWithValue("@username", txtUsername.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);

            var dr = command.ExecuteReader();

            if (dr.Read() == true)
            {
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неккоректные данные, попробуйте ещё !", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtUsername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';                
            }
            else
            {

                txtPassword.PasswordChar = '•';
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
            this.Hide();
        }
    }
}
