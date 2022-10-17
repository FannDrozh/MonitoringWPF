using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Collections;

namespace Monitoring
{
    /// <summary>
    /// Логика взаимодействия для DeleteOutliers.xaml
    /// </summary>
    public partial class DeleteOutliers : Window
    {
        public string dele;
        public DeleteOutliers()
        {
            InitializeComponent();
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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
                Close();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Emissions_Barashenkov;User ID=33П;Password=12357"))
            {
                sqlConnection.Open();
                dele = IdEmis.Text;
                int dele1 = Convert.ToInt32(dele);
                DataTable sqlCommand = Select($"DELETE FROM [dbo].[Emission] WHERE [ID_Emission] = '{dele1}';");
            }
        }
    }
}
