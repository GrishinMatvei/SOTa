using SOTa.Domain.Converter;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SOTa
{
    public partial class Main : Window
    {
        TradeEntities db = new TradeEntities();

        User user;

        private readonly Boolean IsInit = false;

        Domain.Product[] Products = new Domain.Product[] { };

        public Main(User user1)
        {
            user = user1;
            InitializeComponent();

            if (user.Role.RoleID != Convert.ToInt32(Enums.Role.Administator)) addItem.Visibility = Visibility.Hidden;

            userInfo.Text = $"{user1.UserSurname} {user1.UserName[0]}. {user1.UserPatronymic[0]}.";

            Products = ProductConverter.ToProducts(TradeEntities.GetContext().Product.ToArray());
            productList.ItemsSource = Products;

            IsInit = true;
        }

        private void products_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var f = productList.SelectedItem;

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
            var f = productList.SelectedValue.ToString();

            Product delProduct = db.Product.SingleOrDefault(n => n.ProductArticleNumber == f);

            if (delProduct != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    db.Product.Remove(delProduct);
                    productList.SelectedItem = null;
                    db.SaveChanges();
                    deleteItem.Visibility = Visibility.Hidden;
                    editItem.Visibility = Visibility.Hidden;
                    productList.ItemsSource = ProductConverter.ToProducts(TradeEntities.GetContext().Product.ToArray());
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
            Product product = db.Product.SingleOrDefault(n => n.ProductArticleNumber == productList.SelectedValue);

            EditProduct editProduct = new EditProduct(product);
            editProduct.ShowDialog();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (!IsInit) return;

            ComboBox comboBox = (ComboBox)sender;

            Domain.Product[] products = new Domain.Product[] { };

            switch (comboBox.SelectedValue)
            {
                case "withoutSort":
                    {
                        products = Products;
                        break;
                    }
                case "ascending":
                    {
                        products = Products.OrderBy(product => product.ProductCost).ToArray();
                        break;
                    }
                case "descending":
                    {
                        products = Products.OrderByDescending(product => product.ProductCost).ToArray();
                        break;
                    }
            }

            if (products.Length == 0) MessageBox.Show("Не удалось загрузить данные");

            productList.ItemsSource = products;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            productList.ItemsSource = Products.Where(w => w.ManufacturerName.ToLower().Contains(search.Text.ToLower()) || w.ProductName.ToLower().Contains(search.Text.ToLower()) || w.ProductDescription.ToLower().Contains(search.Text.ToLower()) || w.ProductName.ToLower().Contains(search.Text.ToLower()) ).ToArray();  
        }
    }
}
