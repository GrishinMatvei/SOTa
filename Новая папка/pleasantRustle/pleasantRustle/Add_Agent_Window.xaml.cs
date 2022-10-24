using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Add_Agent_Window.xaml
    /// </summary>
    public partial class Add_Agent_Window : Window
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
        public Add_Agent_Window()
        {
            InitializeComponent();
            var allTypes = AgentsEntities.GetContext().AgentTypes.Select(n => n.TypeName).ToList();
            allTypes.Insert(0, "Все типы");
            cbTypeAgent.ItemsSource = allTypes;
            cbTypeAgent.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Agents agent = new Agents();
            int localId = 0;
            var listId = AgentsEntities.GetContext().Agents.Select(n => n.Id).ToList();
            if (tbName.Text != String.Empty && cbTypeAgent.SelectedIndex != 0 && tbPriority.Text != String.Empty &&
                tbAdress.Text != String.Empty && tbINN.Text != String.Empty && tbKPP.Text != String.Empty &&
                tbDirector.Text != String.Empty && tbPhone.Text != String.Empty && tbEmail.Text != String.Empty)
            {
                while (true)
                {
                if (!listId.Contains(localId))
                {
                    agent.Id = localId;
                    break;
                }
                else localId++;
                }

                agent.NameCompany = tbName.Text;
                agent.AgentTypeId = cbTypeAgent.SelectedIndex;
                agent.Priority = Convert.ToInt32( tbPriority.Text);
                agent.Adress = tbAdress.Text;
                agent.INN = tbINN.Text;
                agent.KPP = tbKPP.Text;
                agent.Director = tbDirector.Text;
                agent.Phone = tbPhone.Text;
                agent.Email = tbEmail.Text;

                if (!File.Exists(sPathImage))
                {
                    if (newByteImage != null)
                    {
                        int i = 1;

                        do
                        {
                            i += 1;
                            PathImage = $"\\agents\\agent_{i}.png";

                        } while (File.Exists(sPathImage));

                        File.WriteAllBytes(sPathImage, newByteImage);
                    }
                }
                agent.Logo = PathImage;
                AgentsEntities.GetContext().Agents.Add(agent);
                AgentsEntities.GetContext().SaveChanges();
                MessageBox.Show("Агент сохранен");
                MainWindow mainWindow = new MainWindow();
                mainWindow.UpdateAgents();
                Close();
            }

        }

        private void buttonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string[] extensions = { ".jpg", ".bmp", ".png", ".jpeg" };
            if (ofd.ShowDialog() == true)
            {

                if (extensions.Contains(System.IO.Path.GetExtension(ofd.FileName)))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        newByteImage = new byte[fs.Length];
                        fs.Read(newByteImage, 0, newByteImage.Length);
                    }

                    MemoryStream ms = new MemoryStream(newByteImage);

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.EndInit();

                    logoImageBox.Source = image;
                    logoTextBox.Content = "";

                    PathImage = $"\\agents\\{System.IO.Path.GetFileName(ofd.FileName)}";
                }
                else
                {
                    MessageBox.Show("Выбранный файл не является фотографией", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
        public static string adressH { get; set; }
        private void tbAdress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HelpWindows.AdressHelper adressHelper = new HelpWindows.AdressHelper();
            adressHelper.Owner = this;
            adressHelper.ShowDialog();

            tbAdress.Text = adressH;
        }

        public static string fioDirector { get; set; }
        private void tbDirector_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HelpWindows.DirectorHelper directirFIO = new HelpWindows.DirectorHelper();
            directirFIO.Owner = this;
            directirFIO.ShowDialog();
            tbDirector.Text = fioDirector;
        }

        private void tbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tbPhone.Text.Contains(".")
               && tbPhone.Text.Length != 0)))
            {
                e.Handled = true;
            }
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tbPhone.Text.Contains(".")
               && tbINN.Text.Length != 0)))
            {
                e.Handled = true;
            }
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tbKPP.Text.Contains(".")
               && tbPhone.Text.Length != 0)))
            {
                e.Handled = true;
            }
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tbPriority.Text.Contains(".")
               && tbPhone.Text.Length != 0)))
            {
                e.Handled = true;
            }
            if (!(Char.IsLetterOrDigit(e.Text, 0) || (e.Text == ".")
                    && (!tbName.Text.Contains(".")
                    && tbName.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
