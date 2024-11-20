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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(List<string> correctAnswers, List<string> wrongAnswers)
        {
            InitializeComponent();

            // Формируем результат
            string resultMessage = "Результаты теста:\n\n";
            resultMessage += $"Правильные ответы: {(correctAnswers.Count > 0 ? string.Join(", ", correctAnswers) : "0")}\n";
            resultMessage += $"Неправильные ответы: {(wrongAnswers.Count > 0 ? string.Join(", ", wrongAnswers) : "0")}\n";

            // Общая оценка
            if (correctAnswers.Count == 8)
            {
                resultMessage += "\n Отлично!";
            }
            else if (correctAnswers.Count == 7 || correctAnswers.Count == 6)
            {
                resultMessage += "\n Хорошо!";
            }
            else if (correctAnswers.Count == 5 || correctAnswers.Count == 4)
            {
                resultMessage += "\n Неплохо!";
            }
            else
            {
                resultMessage += "\n Плохо!";
            }


            ResultsTextBlock.Text = resultMessage;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
