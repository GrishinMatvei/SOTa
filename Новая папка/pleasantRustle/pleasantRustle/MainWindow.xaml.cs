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


namespace pleasantRustle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static StackPanel stackPanel = new StackPanel();

        Button[] buttons = new Button[stackPanel.Children.Count];

        public static int k = 0;

        public static List<object> list = new List<object>();

        public int kolvoPage = 0;
        public int page { get; set; }
        public int skip;
        public MainWindow()
        {
            InitializeComponent();
            var allTypes = AgentsEntities.GetContext().AgentTypes.Select(n=>n.TypeName).ToList();
            allTypes.Insert(0, "Все типы");
            combobox_Filter.ItemsSource = allTypes;
            combobox_Filter.SelectedIndex = 0;
            combobox_Sort.Items.Add("Название по возрастанию");
            combobox_Sort.Items.Add("Размер скидки по возрастанию");
            combobox_Sort.Items.Add("Приоритет по возрастанию");
            combobox_Sort.Items.Add("Название по убыванию");
            combobox_Sort.Items.Add("Размер скидки по убыванию");
            combobox_Sort.Items.Add("Приотритет по убыванию");
            combobox_Sort.SelectedIndex = 0;
            textbox_Poisk.Text = "";
            page = 1;
            UpdateAgents();

        }
        public void UpdateAgents()
        {
            listBox.ItemsSource = null;
            var currentAgents = AgentsEntities.GetContext().Agents.ToList();

            if (combobox_Filter.SelectedIndex > 0)
            {
               // AgentTypes agentTypes = combobox_Filter.SelectedItem as AgentTypes;
                string filter = combobox_Filter.SelectedItem.ToString();
                currentAgents = currentAgents.Where(p => p.AType.Contains(filter)).ToList();
            }
            else currentAgents = AgentsEntities.GetContext().Agents.ToList();

            switch (combobox_Sort.SelectedIndex)
            {
                case 0:
                    currentAgents = currentAgents.OrderBy(p => p.NameCompany).ToList();
                    break;
                case 1:
                    currentAgents = currentAgents.OrderBy(p => p.Skidka).ToList();
                    break;
                case 2:
                    currentAgents = currentAgents.OrderBy(p => p.Priority).ToList();
                    break;
                case 3:
                    currentAgents = currentAgents.OrderByDescending(p => p.NameCompany).ToList();
                    break;
                case 4:
                    currentAgents = currentAgents.OrderByDescending(p => p.Skidka).ToList();
                    break;
                case 5:
                    currentAgents = currentAgents.OrderByDescending(p => p.Priority).ToList();
                    break;
            }

            if (textbox_Poisk.Text != "")
            {
                 currentAgents = currentAgents.Where(p => p.NameCompany.ToLower().Contains(textbox_Poisk.Text.ToLower()) ||
                p.Phone.ToLower().Contains(textbox_Poisk.Text.ToLower()) || p.Email.ToLower().Contains(textbox_Poisk.Text.ToLower())).ToList();
            }

            double g = currentAgents.Count % 10;
            if (g == 0)
            {
                kolvoPage = currentAgents.Count / 10;
            }
            else
            {
                kolvoPage = (currentAgents.Count / 10) + 1;
            }

            if (k == 0)
            {
                listBox.ItemsSource = currentAgents.Skip(0).Take(10);
            }
            else
            {
                listBox.ItemsSource = currentAgents.Skip(skip).Take(10);
            }
            AddPagePagination();
        }

        private void AddPagePagination()
        {
            if (combobox_Filter.SelectedItem == null && combobox_Sort.SelectedItem == null && textbox_Poisk.Text == "")
            {
                stackPanel.Orientation = Orientation.Horizontal;
                canvasMain.Children.Remove(stackPanel);
                canvasMain.Children.Add(stackPanel);
                for (int i = 1; i <= kolvoPage; i++)
                {
                    Button button = new Button();
                    button.Content = $"{i}";
                    button.Name = $"bttn_{i}";
                    button.Margin = new Thickness(3, 3, 3, 0);
                    button.BorderThickness = new Thickness(0, 0, 0, 1);
                    button.Background = Brushes.Transparent;
                    button.Opacity = 0.9;
                    button.Width = 25;
                    button.Height = 20;
                    button.Click += Button_Click;
                    stackPanel.Children.Add(button);
                    k++;
                }

                buttons = new Button[stackPanel.Children.Count];
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i] = (Button)stackPanel.Children[i];
                }
            }
            else
            {
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Children.Clear();
                canvasMain.Children.Remove(stackPanel);
                canvasMain.Children.Add(stackPanel);

                for (int i = 1; i <= kolvoPage; i++)
                {
                    Button button = new Button();
                    button.Content = $"{i}";
                    button.Name = $"bttn_{i}";
                    button.Margin = new Thickness(3, 3, 3, 0);
                    button.BorderThickness = new Thickness(0, 0, 0, 1);
                    button.Background = Brushes.Transparent;
                    button.BorderBrush = Brushes.Black;
                    button.Opacity = 0.79;
                    button.Width = 25;
                    button.Height = 20;
                    button.Click += Button_Click;
                    stackPanel.Children.Add(button);
                    k++;
                }

                buttons = new Button[stackPanel.Children.Count];
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i] = (Button)stackPanel.Children[i];
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            skip = 0;
            int R = 0;
            if (((Button)sender).Content.ToString() == "1")
            {
                skip = 0;
                page = 1;
                UpdateAgents();
            }

            else if (Convert.ToInt32(buttons[page - 1].Content) < Convert.ToInt32(((Button)sender).Content))
            {
                int n = Convert.ToInt32(((Button)sender).Content) - Convert.ToInt32(buttons[page - 1].Content);

                if (Convert.ToInt32(buttons[page - 1].Content) == 1 && Convert.ToInt32(((Button)sender).Content) == 2)//1 - 2
                {
                    skip = 10;
                }
                else
                {
                    skip = Math.Abs(10 * (Convert.ToInt32(((Button)sender).Content) - 1));
                }

                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i] == (Button)sender)
                    {
                        page = Convert.ToInt32(((Button)sender).Content);
                        UpdateAgents();
                    }
                }
            }
            else if (Convert.ToInt32(buttons[page - 1].Content) > Convert.ToInt32(((Button)sender).Content))
            {
                R = Convert.ToInt32(buttons[page - 1].Content) - Convert.ToInt32(((Button)sender).Content);
                skip = (Convert.ToInt32(buttons[page - 1].Content) - 1) * 10 - R * 10;

                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i] == (Button)sender)
                    {
                        page = Convert.ToInt32(((Button)sender).Content);
                        UpdateAgents();
                    }
                }
            }
        }

        private void combobox_Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void combobox_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void textbox_Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void bttn_Add_Agent_Click(object sender, RoutedEventArgs e)
        {
            Add_Agent_Window add_Agent = new Add_Agent_Window();
            add_Agent.Owner = this;
            add_Agent.ShowDialog();


        }

        private void listBox_MultiSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int count = listBox.SelectedItems.Count;
            if (count > 1)
            {
                priority_change.Visibility = Visibility.Visible;
                list.Add(listBox.SelectedItems);
            }
            else
            {
                priority_change.Visibility = Visibility.Hidden;
            }

        }

        private void priority_change_Click(object sender, RoutedEventArgs e)
        {

            List<Agents> selected = new List<Agents>();
            foreach (var item in listBox.SelectedItems)
            {
                selected.Add((Agents)item);
            }
            PriorityChangeAgents priorityChange = new PriorityChangeAgents(selected);
            priorityChange.Owner = this;
            priorityChange.ShowDialog();
            UpdateAgents();

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (listBox.SelectedItem != null)
            //{
            //    WindowChangeAgent wsa = new WindowChangeAgent(listBox.SelectedItem as Agents);
            //    wsa.Owner = this;
            //    wsa.ShowDialog();
            //    listBox.SelectedItem = null;
            //}
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                listBox.SelectionMode = SelectionMode.Multiple;
                listBox.SelectionChanged -= listBox_SelectionChanged;
                listBox.SelectionChanged += listBox_MultiSelectionChanged;
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                listBox.SelectionMode = SelectionMode.Single;
                listBox.SelectionChanged += listBox_SelectionChanged;
                listBox.SelectionChanged -= listBox_MultiSelectionChanged;
            }
        }

        private void listBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                WindowChangeAgent wsa = new WindowChangeAgent(listBox.SelectedItem as Agents);
                wsa.Owner = this;
                wsa.ShowDialog();
                listBox.SelectedItem = null;
            }
        }
    }
}
