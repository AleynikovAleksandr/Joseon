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

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<DateTime, List<(string Name, string Description)>> eventsByDate
            = new Dictionary<DateTime, List<(string Name, string Description)>>();

        public MainWindow()
        {
            InitializeComponent();
            RadioTask1.IsChecked = true;
            UpdateRender();
        }

        private void UpdateRender()
        {
            StackPanelTask1.Visibility = (RadioTask1.IsChecked == true) ? Visibility.Visible : Visibility.Hidden;
            StackPanelTask2.Visibility = (RadioTask2.IsChecked == true) ? Visibility.Visible : Visibility.Hidden;
            DATEPICK.Visibility = (RadioDate.IsChecked == true) ? Visibility.Visible : Visibility.Collapsed;
            CALENDAR.Visibility = (RadioCalendar.IsChecked == true) ? Visibility.Visible : Visibility.Collapsed;

            if (CALENDAR.SelectedDate != null)
            {
                ShowerText.Text = $"Выбрана дата: {CALENDAR.SelectedDate.Value.Date.ToShortDateString()}";
            }
        }

        private void RadioGlobal_Checked(object sender, RoutedEventArgs e)
        {
            UpdateRender();
        }

        private void DATEPICK_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CALENDAR.SelectedDate = DATEPICK.SelectedDate;
            UpdateRender();
        }

        private void CALENDAR_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DATEPICK.SelectedDate = CALENDAR.SelectedDate;
            UpdateRender();
        }

        private void ActionSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ActionSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                string action = selectedItem.Content.ToString();

                if (action == "Сохранить событие")
                {
                    SaveEvent();
                }
                else if (action == "Отмена")
                {
                    CancelEvent();
                }
            }

            ActionSelector.Text = "Добавить заметку";
            ActionSelector.SelectedIndex = -1; 
        }

        private void SaveEvent()
        {
            if (EventCalendar.SelectedDate == null || string.IsNullOrWhiteSpace(EventName.Text))
            {
                MessageBox.Show("Пожалуйста, выберите дату и введите название события.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime selectedDate = EventCalendar.SelectedDate.Value;
            string eventName = EventName.Text.Trim();
            string eventDesc = EventDesc.Text.Trim();

           
            if (!eventsByDate.ContainsKey(selectedDate))
            {
                eventsByDate[selectedDate] = new List<(string, string)>();
            }
            eventsByDate[selectedDate].Add((eventName, eventDesc));

            
            UpdateEventsTreeView();

            
            EventName.Text = "Название события";
            EventDesc.Text = "Описание события";
        }

        private void CancelEvent()
        {
            EventName.Text = "Название события";
            EventDesc.Text = "Описание события";
        }

        private void UpdateEventsTreeView()
        {
            
            EventsTreeView.Items.Clear();

            
            TreeViewItem rootItem = new TreeViewItem
            {
                Header = "Список событий по датам",
                IsExpanded = true 
            };

            
            foreach (var date in eventsByDate.Keys.OrderBy(d => d))
            {
               
                TreeViewItem dateItem = new TreeViewItem
                {
                    Header = date.ToString("dd.MM.yyyy"),
                    IsExpanded = false
                };

               
                foreach (var (name, description) in eventsByDate[date])
                {
                    
                    TreeViewItem eventItem = new TreeViewItem
                    {
                        Header = name,
                        IsExpanded = false 
                    };

                   
                    eventItem.Items.Add(new TreeViewItem
                    {
                        Header = description,
                        IsExpanded = false 
                    });

                    
                    dateItem.Items.Add(eventItem);
                }

                
                rootItem.Items.Add(dateItem);
            }

            
            EventsTreeView.Items.Add(rootItem);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "Название события" || textBox.Text == "Описание события")
                {
                    textBox.Text = string.Empty;
                    textBox.Foreground = Brushes.Black;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Foreground = Brushes.Gray;
                    textBox.Text = textBox.Name == "EventName" ? "Название события" : "Описание события";
                }
            }
        }
    }
}
