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

namespace pleasantRustle.HelpWindows
{
    /// <summary>
    /// Логика взаимодействия для AdressHelper.xaml
    /// </summary>
    public partial class AdressHelper : Window
    {
        public AdressHelper()
        { 
            InitializeComponent();
            tbRegion.Tag = "Пример: Московская обл.";
        }

        private void btSaveAdress_Click(object sender, RoutedEventArgs e)
        {
            if (tbIndexCity.Text != String.Empty && tbRegion.Text != String.Empty && tbCity.Text != String.Empty && tbStreet.Text != String.Empty && tbHome.Text != String.Empty)
            {
                Add_Agent_Window.adressH = tbIndexCity.Text + "," + tbRegion.Text + "," + tbCity.Text + "," + tbStreet.Text + "," + tbHome.Text;
                Close();
            }
            else MessageBox.Show("Введите все данные");

        }

        private void btCancelAdress_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
}
}
