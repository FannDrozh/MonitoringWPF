using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monitoring
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Emissions_Barashenkov;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select max(ID_Emission) from Emission", connection);
                int n = Convert.ToInt32(command.ExecuteScalar().ToString());
                int[] id = new int[n];
                float[] count = new float[n];
                string[] text = new string[n];
                string[] Date = new string[n];

                for (int i = 1; i <= n; i++)
                {
                    SqlCommand command1 = new SqlCommand("select ID_Source FROM Emission WHERE ID_Emission=" + i + "", connection);
                    if (command1.ExecuteScalar() is null)
                    {

                    }
                    else
                    {
                        id[i - 1] = Convert.ToInt32(command1.ExecuteScalar().ToString());
                        SqlCommand command2 = new SqlCommand("select Count FROM Emission WHERE ID_Emission=" + i + "", connection);
                        count[i - 1] = float.Parse(command2.ExecuteScalar().ToString());
                        SqlCommand command3 = new SqlCommand("select Text FROM Emission WHERE ID_Emission=" + i + "", connection);
                        text[i - 1] = Convert.ToString(command3.ExecuteScalar().ToString());
                        SqlCommand command4 = new SqlCommand("select date FROM Emission WHERE ID_Emission=" + i + "", connection);
                        Date[i - 1] = Convert.ToString(command4.ExecuteScalar().ToString());
                    }
                }
                List<Vibros> vibrosList = new List<Vibros>
                {

                };
                for (int i = 1; i <= n; i++)
                {
                    if (Date[i - 1] == null)
                    {

                    }
                    else
                    {
                        vibrosList.Add(new Vibros { ID_Emission = i, ID_Souce = id[i - 1], Count = count[i - 1], Text = text[i - 1], date = Date[i - 1] });
                    }
                }

                SourceG.ItemsSource = vibrosList;
            }
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Emissions_Barashenkov;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand commandd = new SqlCommand("select max(ID_Source) from Source", connection);
                int n = Convert.ToInt32(commandd.ExecuteScalar().ToString());
                string[] name = new string[n];
                string[] adress = new string[n];

                for (int i = 1; i <= n; i++)
                {
                    SqlCommand commandd1 = new SqlCommand("select Name FROM Source WHERE ID_Source=" + i + "", connection);
                    if (commandd1.ExecuteScalar() is null)
                    {

                    }
                    else
                    {

                        name[i - 1] = Convert.ToString(commandd1.ExecuteScalar().ToString());
                        SqlCommand commandd2 = new SqlCommand("select Address FROM Source WHERE ID_Source=" + i + "", connection);
                        adress[i - 1] = Convert.ToString(commandd2.ExecuteScalar().ToString());
                    }
                }
                List<Istochniki> istochnikList = new List<Istochniki>
                {

                };
                for (int i = 1; i <= n; i++)
                {
                    if (name[i - 1] == null)
                    {

                    }
                    else
                    {
                        istochnikList.Add(new Istochniki { ID_Souce = i, Name = name[i - 1], Adress = adress[i - 1] });
                    }
                }
                EmissionG.ItemsSource = istochnikList;
            }

        }

        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("Data Source=ngknn.ru;Initial Catalog=Emissions_Barashenkov;Persist Security Info=True;User ID=33П;Password=12357");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            sqlConnection.Close();
            return dataTable;
        }
        //Добавление ист
        private void DobIst_Click(object sender, RoutedEventArgs e)
        {
            AddSource addSource = new AddSource();
            addSource.Show();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddSource addSource = new AddSource();
            addSource.Show();
        }
        //Редактирование ист
        private void EditIst_Click(object sender, RoutedEventArgs e)
        {
            EditIst editIst = new EditIst();
            editIst.Show();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            EditIst editIst = new EditIst();
            editIst.Show();
        }
        //Удаленеие ист
        private void DelIst_Click(object sender, RoutedEventArgs e)
        {
            DeleteSource deleteSource = new DeleteSource();
            deleteSource.Show();
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteSource deleteSource = new DeleteSource();
            deleteSource.Show();
        }
        //Добавление выб
        private void DobVib_Click(object sender, RoutedEventArgs e)
        {
            AddOutliers фddOutliers = new AddOutliers();
            фddOutliers.Show();
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            AddOutliers фddOutliers = new AddOutliers();
            фddOutliers.Show();
        }
        //Редактирование выб
        private void EditVib_Click(object sender, RoutedEventArgs e)
        {
            EditOutliers editOutliers = new EditOutliers();
            editOutliers.Show();
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            EditOutliers editOutliers = new EditOutliers();
            editOutliers.Show();
        }
        //Удаление выб
        private void DelVib_Click(object sender, RoutedEventArgs e)
        {
            DeleteOutliers deleteOutliers = new DeleteOutliers();
            deleteOutliers.Show();
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            DeleteOutliers deleteOutliers = new DeleteOutliers();
            deleteOutliers.Show();
        }

        internal class Vibros
        {
            public int ID_Emission { get; set; }
            public int ID_Souce { get; set; }
            public float Count { get; set; }
            public string Text { get; set; }
            public string date { get; set; }

        }
        internal class Istochniki
        {
            public int ID_Souce { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
