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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private List<string> imagePaths;
        private int currentIndex = 0;

        public Window1(List<string> images)
        {
            InitializeComponent();
            imagePaths = images;
            ShowImage(currentIndex);
        }

        public void ShowImage(int index)
        {
            if (imagePaths.Count == 0) return;

            var imagePath = imagePaths[index];
            var bitmap = new BitmapImage(new Uri(imagePath));

            // Отображаем изображение в ImageViewer и выравниваем по центру
            ImageViewer.Source = bitmap;
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            if (imagePaths.Count == 0) return;

            currentIndex = (currentIndex + 1) % imagePaths.Count;
            ShowImage(currentIndex);
        }

        private void PreviousImage_Click(object sender, RoutedEventArgs e)
        {
            if (imagePaths.Count == 0) return;

            currentIndex = (currentIndex - 1 + imagePaths.Count) % imagePaths.Count;
            ShowImage(currentIndex);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем и показываем главное окно
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закрываем текущее окно (Window1)
            this.Close();
        }
    }
}
