using SOTa.Domain.Converter;
using System;
using System.Linq;
using System.Windows;

namespace SOTa
{
    public partial class Main : Window
    {
        TradeEntities db = new TradeEntities();

        User user;
        public Main(User user1)
        {
            user = user1;
            InitializeComponent();

            if (user.Role.RoleID != Convert.ToInt32(Enums.Role.Administator)) addItem.Visibility = Visibility.Hidden;

            userInfo.Text = $"{user1.UserSurname} {user1.UserName[0]}. {user1.UserPatronymic[0]}.";

            products.ItemsSource = ProductConverter.ToProducts(TradeEntities.GetContext().Product.ToArray()); 
        }

        private void products_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var f = products.SelectedItem;

                if (f != null && user.Role.RoleID == Convert.ToInt32(Enums.Role.Administator))
                {
                    deleteItem.Visibility = Visibility.Visible;
                    editItem.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

            }

        }

        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            var f = products.SelectedValue.ToString();

            Product delProduct = db.Product.SingleOrDefault(n => n.ProductArticleNumber == f);

            if (delProduct != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    db.Product.Remove(delProduct);
                    products.SelectedItem = null;
                    db.SaveChanges();
                    deleteItem.Visibility = Visibility.Hidden;
                    editItem.Visibility = Visibility.Hidden;
                    products.ItemsSource = ProductConverter.ToProducts(TradeEntities.GetContext().Product.ToArray());
                }
            }
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            AddNewProduct addNewProduct = new AddNewProduct();
            addNewProduct.ShowDialog();
        }

        private void editItem_Click(object sender, RoutedEventArgs e)
        {          
            Product product = db.Product.SingleOrDefault(n => n.ProductArticleNumber == products.SelectedValue);

            EditProduct editProduct = new EditProduct(product);
            editProduct.ShowDialog();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
