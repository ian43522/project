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
    /// Логика взаимодействия для Projects.xaml
    /// </summary>
    public partial class Projects : Window
    {
        DataBase dataBase = new DataBase();
        public Projects()
        {
            InitializeComponent();
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGrid1);
        }

        private void CreateColumns()
        {
            dataGrid1.Columns.Add(new DataGridTextColumn() { Header = "ID", Binding = new Binding("id") });
            dataGrid1.Columns.Add(new DataGridTextColumn() { Header = "Название", Binding = new Binding("name") });
            dataGrid1.Columns.Add(new DataGridTextColumn() { Header = "Примечание", Binding = new Binding("description") });
            dataGrid1.Columns.Add(new DataGridTextColumn() { Header = "Начало проекта", Binding = new Binding("start_date") });
            dataGrid1.Columns.Add(new DataGridTextColumn() { Header = "Конец проекта", Binding = new Binding("end_date") });
            dataGrid1.Columns.Add(new DataGridTextColumn() { Header = "Бюджет", Binding = new Binding("budget") });
        }


        private Project ReadSingleRow(IDataRecord record)
        {
            var sklad = new Project()
            {
                id = record.GetInt32(0),
                name = record.GetString(1),
                description = record.GetString(2),
                start_date = record.GetDateTime(3),
                end_date = record.GetDateTime(4),
                budget = record.GetString(5),


            };

            return sklad;
        }

        private void RefreshDataGrid(DataGrid dgw)
        {
            dgw.Items.Clear();
            string queryString = $"select * from projects";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnecion();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dgw.Items.Add(ReadSingleRow(reader));
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            New_entry new_Entry = new New_entry();
            new_Entry.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) => RefreshDataGrid(dataGrid1);



        private void TextBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search(dataGrid1);
        }

        private void Search(DataGrid dgw)
        {
            dgw.Items.Clear();

            string searchString = $"select * from projects where concat (Id, Name, description, start_date, end_date, budget) like '%" + TextBox_Search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnecion();


            using (SqlDataReader read = com.ExecuteReader())
            {
                while (read.Read())
                {
                    dgw.Items.Add(ReadSingleRow(read));
                }
            }


        }
    }
}
