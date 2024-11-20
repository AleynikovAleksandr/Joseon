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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            int correctAnswers = 0;
            string wrongQuestions = "";
            string correctQuestions = "";

            if (Q1_2.IsChecked == true)
            {
                correctAnswers++;
                correctQuestions += "Правильный: Вопрос 1\n";
            }
            else
            {
                wrongQuestions += "Неправильный: Вопрос 1\n";
            }

            if (Q2_1.IsChecked == true)
            {
                correctAnswers++;
                correctQuestions += "Правильный: Вопрос 2\n";
            }
            else
            {
                wrongQuestions += "Неправильный: Вопрос 2\n";
            }

            if (Q3_3.IsChecked == true)
            {
                correctAnswers++;
                correctQuestions += "Правильный: Вопрос 3\n";
            }
            else
            {
                wrongQuestions += "Неправильный: Вопрос 3\n";
            }

            if (Q4_2.IsChecked == true)
            {
                correctAnswers++;
                correctQuestions += "Правильный: Вопрос 4\n";
            }
            else
            {
                wrongQuestions += "Неправильный: Вопрос 4\n";
            }

            
            if (string.IsNullOrEmpty(wrongQuestions)) wrongQuestions = "Неправильных ответов: 0\n";

            
            if (string.IsNullOrEmpty(correctQuestions)) correctQuestions = "Правильных ответов: 0\n";

            
            Window1 resultWindow = new Window1(correctAnswers, correctQuestions, wrongQuestions);
            resultWindow.Show();

            
            this.Close();
        }
    }



































}
     
