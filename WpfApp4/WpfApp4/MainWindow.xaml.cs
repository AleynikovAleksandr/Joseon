using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
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
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var inputText = TextBox1.Text;

            if (string.IsNullOrWhiteSpace(inputText) || IsOnlyNumbersOrSymbols(inputText))
            {
                MessageLabel.Content = string.Empty;
                return;
            }

            var lettersOnlyText = FilterLettersOnly(inputText);

            if (IsMostlyRussian(lettersOnlyText))
            {
                TextBox1.Language = XmlLanguage.GetLanguage("ru-RU");
                MessageLabel.Content = "Проверка орфографии на русском";
            }
            else
            {
                TextBox1.Language = XmlLanguage.GetLanguage("en-US");
                MessageLabel.Content = "Проверка орфографии на английском";
            }
        }

        private string FilterLettersOnly(string text)
        {
            return Regex.Replace(text, @"[^а-яА-Яa-zA-Z]", string.Empty);
        }

        private bool IsMostlyRussian(string text)
        {
            int russianCount = 0, englishCount = 0;

            foreach (char c in text)
            {
                if ((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я'))
                    russianCount++;
                else if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    englishCount++;
            }

            return russianCount > englishCount;
        }

        private bool IsOnlyNumbersOrSymbols(string text)
        {
            return Regex.IsMatch(text, @"^[\d\W]+$");
        }

        private void TextBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox2.Password))
            {
                MessageLabel.Content = string.Empty;
            }
            else
            {
                MessageLabel.Content = "Пароль введён";
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрытие окна
        }

    }
}
