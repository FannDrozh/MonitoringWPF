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

namespace Monitoring
{
    /// <summary>
    /// Логика взаимодействия для MinEmission.xaml
    /// </summary>
    public partial class MinEmission : Window
    {
        public int id;
        public float count;
        public string text;
        public string Date;

        public MinEmission()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=Emissions_Barashenkov;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select min(count) from Emission", connection);
                int n = Convert.ToInt32(command.ExecuteScalar().ToString());
                int id_em;
                int id;
                string text;
                string Date;
                SqlCommand command0 = new SqlCommand("select ID_Emission FROM Emission WHERE count=" + n + "", connection);
                id_em = Convert.ToInt32(command0.ExecuteScalar().ToString());
                SqlCommand command1 = new SqlCommand("select ID_Source FROM Emission WHERE count=" + n + "", connection);
                id = Convert.ToInt32(command1.ExecuteScalar().ToString());
                SqlCommand command3 = new SqlCommand("select Text FROM Emission WHERE count=" + n + "", connection);
                text = Convert.ToString(command3.ExecuteScalar().ToString());
                SqlCommand command4 = new SqlCommand("select date FROM Emission WHERE count=" + n + "", connection);
                Date = Convert.ToString(command4.ExecuteScalar().ToString());

                List<Vibros> vibrosList = new List<Vibros>
                {

                };
                vibrosList.Add(new Vibros { ID_Emission = id_em, ID_Souce = id, Count = n, Text = text, date = Date });

                MinEmissionG.ItemsSource = vibrosList;
            }
        }
        internal class Vibros
        {
            public int ID_Emission { get; set; }
            public int ID_Souce { get; set; }
            public float Count { get; set; }
            public string Text { get; set; }
            public string date { get; set; }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
