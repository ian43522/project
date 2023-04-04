using project_pp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace project_pp
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DataBase dataBase = new DataBase();

        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase();

            var login = login_box.Text;
            var password = pass_box.Password;

            string querystring = $"insert into Users(Login, Password) values('{login}', '{password}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnecion();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан", "Успех");

                MainWindow frm_login = new MainWindow();
                this.Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
            dataBase.closeConnecion();
        }

        private Boolean checkuser()
        {
            var loginUser = login_box.Text;
            var passUser = pass_box.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select Id, Login, Password from Users where Login = '{loginUser}' and Password = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
