using System.Linq;
using System.Windows;

namespace SOTa
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void AufClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TradeEntities db = new TradeEntities())
                {
                    User user1 = db.User.FirstOrDefault(user => user.UserLogin == loginchik.Text && user.UserPassword == parolchik.Password);
                    if (user1 is null)
                    {
                        Captcha captcha = new Captcha();
                        captcha.ShowDialog();
                    }
                    else
                    { 
                        Main main = new Main(user1);
                        main.Show();
                        this.Close();
                    }
                }
            }
            catch { MessageBox.Show($"BLIN (99((9(", "EKARNIY BABAY"); }
        }

        private void guestButton_Click(object sender, RoutedEventArgs e)
        {
            using (TradeEntities db = new TradeEntities())
            {
                User user1 = db.User.FirstOrDefault(user => user.UserLogin == "n" && user.UserPassword == "1");
                Main main = new Main(user1);
                main.Show();
                this.Close();
            }
        }
    }
}
