using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndRegister
{
    public partial class RegistrationForm : Form
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
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Некорректные данные.", "Ошибка регистрации.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtComPassword.Text)
            {
                var myCon = CreateConnection();
                myCon.Open();
                string register = "INSERT INTO data" + "(username, password) Values(@username, @password)";

                MySqlCommand command = new MySqlCommand(register, myCon);

                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@password", txtPassword.Text);
                command.ExecuteNonQuery();

                myCon.Close();               


                MessageBox.Show("Ваш аккаунт зарегистрирован !", "Успешная регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Пароли не совпадают, попробуйте ещё раз.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = string.Empty;
                txtComPassword.Text = string.Empty;
                txtPassword.Focus();
            }
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {

                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtComPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
