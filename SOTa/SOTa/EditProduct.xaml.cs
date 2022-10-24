using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SOTa
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        TradeEntities db = new TradeEntities();

        BitmapImage newPhoto = new BitmapImage();
        Product item;
        public EditProduct(Product Item)
        {
            InitializeComponent();
            item = Item;
            ComboboxsUpdate();
        }
        private void ComboboxsUpdate()
        {
            ManufacturCombobox.ItemsSource = db.Manufacturer.Select(n => n.Name).ToList();
            ProviderCombobox.ItemsSource = db.Provider.Select(n => n.Name).ToList();
            CategoryCombobox.ItemsSource = db.Category.Select(n => n.Name).ToList();

            nameTextbox.Text = item.ProductName;
            CostTextbox.Text = item.ProductCost.ToString();
            ActualDiscountTextbox.Text = item.ProductDiscountActual.ToString();
            DescriptionTextbox.Text = item.ProductDescription;
            MaximalDiscountTextbox.Text = item.ProductDiscountAmount.ToString();
            QuantityTextbox.Text = item.ProductQuantityInStock.ToString();

            for (int i = 0; i < ManufacturCombobox.Items.Count; i++)
            {
                if (item.Manufacturer.Name.ToString() == ManufacturCombobox.Items[i].ToString())
                {
                    ManufacturCombobox.SelectedIndex = i;
                }
            }
            for (int i = 0; i < CategoryCombobox.Items.Count; i++)
            {
                if (item.Category.Name.ToString() == CategoryCombobox.Items[i].ToString())
                {
                    CategoryCombobox.SelectedIndex = i;
                }
            }
            for (int i = 0; i < ProviderCombobox.Items.Count; i++)
            {
                if (item.Provider.Name.ToString() == ProviderCombobox.Items[i].ToString())
                {
                    ProviderCombobox.SelectedIndex = i;
                }
            }
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

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var tmp = db.Product.Where(w => w.ProductArticleNumber == item.ProductArticleNumber).SingleOrDefault();

            tmp.ProductArticleNumber = item.ProductArticleNumber;
            tmp.ProductName = nameTextbox.Text;
            tmp.ProductDescription = DescriptionTextbox.Text;
            tmp.ProductCost = Convert.ToDecimal(CostTextbox.Text);
            tmp.ProductDiscountAmount = (byte?)Convert.ToInt32(MaximalDiscountTextbox.Text);
            tmp.ProductDiscountActual = (byte?)Convert.ToInt32(ActualDiscountTextbox.Text);
            tmp.ProductQuantityInStock = Convert.ToInt32(QuantityTextbox.Text);
            tmp.ProductManufacturerID = ManufacturCombobox.SelectedIndex + 1;
            tmp.ProductCategoryID = CategoryCombobox.SelectedIndex + 1;
            tmp.ProductProviderID = ProviderCombobox.SelectedIndex + 1;
            tmp.ProductPhoto = Path.GetFileName(PathImage);
             
            if (!File.Exists(PathImage))
            {
                File.Move($"{ofd.FileName}", $"{PathImage}");
            }

            db.SaveChanges();

            MessageBox.Show("Продукт изменен");
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
