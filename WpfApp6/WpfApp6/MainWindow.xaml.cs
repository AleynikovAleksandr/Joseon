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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isFirstPartCompleted = false; // Следит за этапами теста
        private List<string> correctAnswers = new List<string>();
        private List<string> wrongAnswers = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isFirstPartCompleted)
            {
                // Проверка ответов для вопросов 1–4
                CheckFirstPart();
                FirstQuestionGroup.Visibility = Visibility.Collapsed;
                SecondQuestionGroup.Visibility = Visibility.Visible;
                CheckButton.Content = "Завершить тест";
                isFirstPartCompleted = true;
            }
            else
            {
                // Проверка ответов для вопросов 5–8 и вывод результатов
                CheckSecondPart();
                ShowResults();
            }
        }

        private void CheckFirstPart()
        {
            // Проверяем ответы для вопросов 1–4
            if (Question1Option2.IsChecked == true) correctAnswers.Add("1");
            else wrongAnswers.Add("1");

            if (Question2Option1.IsChecked == true) correctAnswers.Add("2");
            else wrongAnswers.Add("2");

            if (Question3Option3.IsChecked == true) correctAnswers.Add("3");
            else wrongAnswers.Add("3");

            if (Question4Option2.IsChecked == true) correctAnswers.Add("4");
            else wrongAnswers.Add("4");
        }

        private void CheckSecondPart()
        {
            // Проверяем ответы для вопросов 5–8
            if (Question5Option1.IsChecked == true && Question5Option4.IsChecked == true &&
                !(Question5Option2.IsChecked == true || Question5Option3.IsChecked == true))
            {
                correctAnswers.Add("5");
            }
            else
            {
                wrongAnswers.Add("5");
            }

            if (Question6Option2.IsChecked == true && Question6Option4.IsChecked == true &&
                !(Question6Option1.IsChecked == true || Question6Option3.IsChecked == true))
            {
                correctAnswers.Add("6");
            }
            else
            {
                wrongAnswers.Add("6");
            }

            if (Question7Option2.IsChecked == true && Question7Option3.IsChecked == true &&
                !(Question7Option1.IsChecked == true || Question7Option4.IsChecked == true))
            {
                correctAnswers.Add("7");
            }
            else
            {
                wrongAnswers.Add("7");
            }

            if (Question8Option1.IsChecked == true && Question8Option3.IsChecked == true &&
                !(Question8Option2.IsChecked == true || Question8Option4.IsChecked == true))
            {
                correctAnswers.Add("8");
            }
            else
            {
                wrongAnswers.Add("8");
            }
        }

        private void ShowResults()
        {
            // Открываем новое окно с результатами
            Window1 resultsWindow = new Window1(correctAnswers, wrongAnswers);
            resultsWindow.Show();
            this.Close();
        }
    }

}
     
