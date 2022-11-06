using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SOTa
{
    /// <summary>
    /// Логика взаимодействия для AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Window
    {
        TradeEntities db = new TradeEntities();

        BitmapImage newPhoto = new BitmapImage();

        public AddNewProduct()
        {
            InitializeComponent();

            ComboboxsUpdate();
        }

        private void ComboboxsUpdate()
        {
            ManafacturCombobox.ItemsSource = db.Manufacturer.Select(n => n.Name).ToList();
            ProviderCombobox.ItemsSource = db.Provider.Select(n => n.Name).ToList();
            CategoryCombobox.ItemsSource = db.Category.Select(n => n.Name).ToList();
        }

        private byte[] newByteImage;
        string pathImage;
        OpenFileDialog ofd = new OpenFileDialog();
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

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] extensions = { ".jpg", ".bmp", ".png", ".jpeg" };
                if (ofd.ShowDialog() == true)
                {
                    if (extensions.Contains(Path.GetExtension(ofd.FileName)))
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
                        PathImage = $"productImages\\{Path.GetFileName(ofd.FileName)}";
                        var path2 = ofd.FileName;
                        newPhoto = image;
                        ProductPhotoImage.Source = BitmapFrame.Create(new Uri(ofd.FileName));
                    }
                    else
                        MessageBox.Show("Выбранный файл не является фотографией", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch { }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = (new Product
                {
                    ProductArticleNumber = articleTextbox.Text,
                    ProductName = nameTextbox.Text,
                    ProductDescription = DescriptionTextbox.Text,
                    ProductCost = Convert.ToDecimal(CostTextbox.Text),
                    ProductDiscountAmount = (byte?)Convert.ToInt32(MaximalDiscountTextbox.Text),
                    ProductDiscountActual = (byte?)Convert.ToInt32(ActualDiscountTextbox.Text),
                    ProductQuantityInStock = Convert.ToInt32(QuantityTextbox.Text),
                    ProductManufacturerID = ManafacturCombobox.SelectedIndex + 1,
                    ProductCategoryID = CategoryCombobox.SelectedIndex + 1,
                    ProductProviderID = ProviderCombobox.SelectedIndex + 1,
                    ProductPhoto = Path.GetFileName(PathImage)
                });

                if (!File.Exists(PathImage))
                {
                    File.Copy($"{ofd.FileName}", $"{PathImage}");
                }
                db.Product.Add(product);
                db.SaveChanges();

                MessageBox.Show("Продукт добавлен");

                Close();
            }
            catch { }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
