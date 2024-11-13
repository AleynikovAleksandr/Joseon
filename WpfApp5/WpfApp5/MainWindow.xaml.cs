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

namespace WpfApp5
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
        private double _currentval = 0;
        private double _storedval = 0;
        private string _operation = "+";

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string numder = button.Content.ToString();
            if(txtDisplay.Text == "0" && numder != ".")
            {
                txtDisplay.Text = numder;
            }
            else
            {
                txtDisplay.Text += numder;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Content.ToString();
            _storedval = double.Parse(txtDisplay.Text);
            txtDisplay.Text = "0";

        }
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            _currentval = double.Parse(txtDisplay.Text);
            switch (_operation)
            {
                case "-":
                    _currentval = _storedval - _currentval;
                    break;
                case "*":
                    _currentval *= _storedval;
                    break;
                case "/":
                    if(_currentval == 0)
                    {
                        MessageBox.Show("0");
                        break;

                    }
                    _currentval = _storedval / _currentval;
                    break;
                default:
                    _currentval += _storedval;
                    break;

                

            }
            txtDisplay.Text = _currentval.ToString();
            _operation = "+";
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            _storedval =  0;
            _currentval = 0;


        }



        private void btn7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }   
}
