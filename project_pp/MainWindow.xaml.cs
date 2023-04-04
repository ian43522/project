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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project_pp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var LoginUser = LoginBox.Text;
            var PassUser = PasswodBox.Password.ToString();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select Id, Login, Password from Users where Login = '{LoginUser}' and Password = '{PassUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                //MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButton.OK);
                Projects skl = new Projects();
                this.Hide();
                skl.Show();

            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButton.OK);
            }

            
        }

        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {
            Registration frm_reg = new Registration();
            frm_reg.Show();
            this.Hide();
        }
    }

    
}
