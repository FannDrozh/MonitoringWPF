using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Monitoring
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public string log;
        public string par;

        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
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
        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Emissions_Barashenkov;User ID=33П;Password=12357"))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select Count(*) from Autorization", sqlConnection);
                int n = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                for (int i = 0; i <= n; i++)
                {
                    SqlCommand sqlCommand1 = new SqlCommand("Select [Login] from [dbo].[Autorization] Where [ID_Log] = " + i + "", sqlConnection);

                    log = sqlCommand1.ExecuteScalar().ToString();
                    if (log == Log.Text)
                    {
                        int h = i;
                        SqlCommand command2 = new SqlCommand("SELECT [Password] FROM [dbo].[Autorization] WHERE [ID_Log] = " + h + "", sqlConnection);
                        par = command2.ExecuteScalar().ToString();
                        if (par == Pas.Text)
                        {
                            MainWindow glavnaya = new MainWindow();
                            glavnaya.Show();
                            Close();
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные");
                        break;
                    }
                }
            }


            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }

    }
}
