using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для EditOutliers.xaml
    /// </summary>
    public partial class EditOutliers : Window
    {
        public string IdE;
        public string IdI;
        public string countEmis;
        public string comm;
        public string dateEmis;
        public EditOutliers()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
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
        private void Izm_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Emissions_Barashenkov;User ID=33П;Password=12357"))
            {
                sqlConnection.Open();
                IdE = IdEmission.Text;
                IdI = IdIst.Text;
                countEmis = CountEmis.Text;
                comm = Comm.Text;
                dateEmis = DateEmis.Text;
                int id1 = Convert.ToInt32(IdE);
                int id2 = Convert.ToInt32(IdI);
                DataTable sqlCommand = Select($"UPDATE [dbo].[Emission] SET [ID_Source] = '{id2}',[count] = '{countEmis}' ,[Text] = '{comm}' ,[date] = '{dateEmis}' WHERE [ID_Emission] = '{id1}';");
                sqlConnection.Close();
            }
            Close();
        }
}
}
