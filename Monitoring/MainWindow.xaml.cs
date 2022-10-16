using System;
using System.Collections.Generic;
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
