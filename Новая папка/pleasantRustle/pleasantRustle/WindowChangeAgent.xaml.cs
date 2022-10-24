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
    /// Логика взаимодействия для WindowChangeAgent.xaml
    /// </summary>
    public partial class WindowChangeAgent : Window
    {
        private byte[] newByteImage;
        string pathImage;
        string PathImage
        {
            get
            {
                return pathImage;
            }
            set
            {
                pathImage = value;
            }
        }
        string sPathImage
        {
            get
            {
                return pathImage.Substring(1);
            }
        }
        public WindowChangeAgent(Agents agent)
        {
            InitializeComponent();
            tbName.Text = agent.NameCompany1;
            tbPhone.Text = agent.Phone;
            tbKPP.Text = agent.KPP;
            tbDirector.Text = agent.Director;
            tbEmail.Text = agent.Email;
            tbINN.Text = agent.INN;
            tbAdress.Text = agent.Adress;
            tbPriority.Text = agent.Priority.ToString();
            cbTypeAgent.ItemsSource = AgentsEntities.GetContext().AgentTypes.Select(N => N.TypeName).ToList();
            
            for (int i = 0; i < cbTypeAgent.Items.Count; i++)
            {
                if (agent.AType.ToString() == cbTypeAgent.Items[i].ToString())
                {
                    cbTypeAgent.SelectedIndex = i;
                }
            }
        }

        private void tbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void tbAdress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void buttonAddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbDirector_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
