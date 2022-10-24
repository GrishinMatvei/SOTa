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

namespace pleasantRustle
{
    /// <summary>
    /// Логика взаимодействия для PriorityChangeAgents.xaml
    /// </summary>
    public partial class PriorityChangeAgents : Window
    {
        public List<Agents> SelectedItems { get; }
        public PriorityChangeAgents(List<Agents> selectedItems)
        {
            InitializeComponent();
            SelectedItems = selectedItems;
            textBox_PriorityChange.Text = SelectedItems.Max(n => n.Priority).ToString();
        }

        private void bttn_PriorityChange_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in SelectedItems)
            {
                item.Priority = Convert.ToInt32(textBox_PriorityChange.Text);
                AgentsEntities.GetContext().Entry(item).State = System.Data.Entity.EntityState.Modified;
            }
            AgentsEntities.GetContext().SaveChanges();
            MessageBox.Show("Приоритет изменен");
            Close();
        }

        private void textBox_PriorityChange_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
    }
}
