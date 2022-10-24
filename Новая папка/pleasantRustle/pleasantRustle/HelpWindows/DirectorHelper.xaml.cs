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
    /// Логика взаимодействия для DirectorHelper.xaml
    /// </summary>
    public partial class DirectorHelper : Window
    {
        public DirectorHelper()
        {
            InitializeComponent();
        }

        private void btAccessDirector_Click(object sender, RoutedEventArgs e)
        {
            if (tbLastnameDirector.Text != String.Empty && tbFirstnameDirector.Text != String.Empty)
            {
                Add_Agent_Window.fioDirector = tbLastnameDirector.Text + " " + tbFirstnameDirector.Text + " " + tbMiddlenameDirector.Text;
                Close();
            } else MessageBox.Show("Введите фамилию и имя обязательно");

        }

        private void btCancelDirector_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tbLastnameDirector_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsLetter(e.Text, 0) || (e.Text == ".")
                && (!tbFirstnameDirector.Text.Contains(".")
                && tbFirstnameDirector.Text.Length != 0)))
            {
                e.Handled = true;
            }
            if (!(Char.IsLetter(e.Text, 0) || (e.Text == ".")
                && (!tbMiddlenameDirector.Text.Contains(".")
                && tbMiddlenameDirector.Text.Length != 0)))
            {
                e.Handled = true;
            }
            if (!(Char.IsLetter(e.Text, 0) || (e.Text == ".")
                && (!tbLastnameDirector.Text.Contains(".")
                && tbLastnameDirector.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
