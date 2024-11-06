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


namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> imagePaths;

        public MainWindow()
        {
            InitializeComponent();
            imagePaths = new List<string>();
        }

        private void AddImages_Click(object sender, RoutedEventArgs e)
        {
            
            string folderPath = @"C:\Users\Alex\OneDrive\Рабочий стол\12";

            // Проверяем, что папка существует
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Выбранная папка не существует.");
                return;
            }

            // Фильтруем файлы по расширению
            var files = Directory.GetFiles(folderPath);
            imagePaths.Clear();

            foreach (var file in files)
            {
                if (file.EndsWith(".JPEG", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".PNG", StringComparison.OrdinalIgnoreCase))
                {
                    imagePaths.Add(file);
                }
            }

            if (imagePaths.Count > 0)
            {
                MessageBox.Show("Изображения загружены.");
            }
            else
            {
                MessageBox.Show("Нет изображений в формате JPG или PNG в выбранной папке.");
            }
        }
        private void OpenViewer_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, есть ли загруженные изображения
            if (imagePaths.Count == 0)
            {
                MessageBox.Show("Нет загруженных изображений для просмотра.");
                return;
            }

            // Если изображения есть, переходим на окно просмотра
            Window1 window = new Window1(imagePaths); // передаем список изображений
            window.Show();

            // Закрываем текущее окно (MainWindow)
            this.Close();
        }


    }
}
