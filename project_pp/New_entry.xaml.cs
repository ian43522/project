using project_pp.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для New_entry.xaml
    /// </summary>
    public partial class New_entry : Window
    {
        DataBase dataBase = new DataBase();
        public New_entry()
        {
            InitializeComponent();
        }

        private void Savebut_Click_1(object sender, RoutedEventArgs e)
        {
            dataBase.openConnecion();

            var name = textbox_name.Text;
            var description = textbox_description.Text;
            var start_date = textbox_date_start.Text;
            var end_date = textbox_date_end.Text;
            var budget = textbox_budget.Text;

            var AddQuery = $"insert into projects (name, description, start_date, end_date, budget) values ('{name}', '{description}', '{start_date}', '{end_date}', '{budget}')";

            var command = new SqlCommand(AddQuery, dataBase.getConnection());
            command.ExecuteNonQuery();
            dataBase.closeConnecion();
        }
    }
}
