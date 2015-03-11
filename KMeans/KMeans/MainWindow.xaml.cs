using KMeansLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace KMeans
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public KMeaner Meaner { get; set; }
 
        public MainWindow()
        {
            DataContext = this;
            Meaner = KMeaner.RandomKMeaner(20, 4);
            Meaner.StepOnce();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meaner.StepOnce();
            graph1.ItemsSource = null;
            graph1.ItemsSource = Meaner.DataSet;
            graph2.ItemsSource = null;
            graph2.ItemsSource = Meaner.Centroids;
            //foreach (var i in Meaner.DataSet)
            //{
            //    var properties = typeof (Data).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            //    foreach (var property in properties)
            //    {
            //        i.OnPropertyChanged(new PropertyChangedEventArgs(property.Name));
            //    }
            //}
        }
    }
}
