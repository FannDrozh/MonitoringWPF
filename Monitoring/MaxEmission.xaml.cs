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
using static Monitoring.MainWindow;

namespace Monitoring
{
    /// <summary>
    /// Логика взаимодействия для MaxEmission.xaml
    /// </summary>
    public partial class MaxEmission : Window
    {
        public MaxEmission()
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

                MaxEmissionG.ItemsSource = vibrosList;
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
