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
        public Window1(int correctAnswers, string correctQuestions, string wrongQuestions)
        {
            InitializeComponent();

            
            string resultMessage = $"{correctQuestions}\n{wrongQuestions}";


            if (correctAnswers == 4)
            {
                resultMessage += "\nХорошо!";
            }
            else if (correctAnswers == 2 || correctAnswers == 3)
            {
                resultMessage += "\nНеплохо!";
            }
            else if (correctAnswers == 0 || correctAnswers == 1)
            {
                resultMessage += "\nПлохо!";
            }

            ResultText.Text = resultMessage;
        }

        
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
