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
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<string> images;
        private int ind = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadImages(@"C:\Users\aleynikov_a\Desktop\12");
            Displaylmage();
        }
        private void LoadImages(string path)
        {
            if (Directory.Exists(path))
            {
                images = new List<string>(Directory.GetFiles(path, "*.jpg"));
                images.AddRange(Directory.GetFiles(path , "*.png"));
                images.AddRange(Directory.GetFiles(path, "*.webp"));
            }
        }


        private void Displaylmage ()
        {
            if (images == null || images.Count == 0) 
            {
                MessageBox.Show("1");
                return;
            }
            var ip = images[ind];
            ghj.Source = new BitmapImage(new Uri(ip));


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
