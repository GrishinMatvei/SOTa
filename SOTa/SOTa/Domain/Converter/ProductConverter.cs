using System;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace SOTa.Domain.Converter
{
    public static class ProductConverter
    {
        private static BitmapImage GetUserImage(string imageName)
        {
            DirectoryInfo defaultDirectory = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/productImages");

            FileInfo currentUserImage = defaultDirectory.GetFiles($"{imageName}").FirstOrDefault();

            if (currentUserImage == null) return new BitmapImage(new Uri($"{defaultDirectory}/picture.png"));

            return new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}/productImages/{currentUserImage.Name}"));
        }

        private static string GetManufacturerName(int manufacturerId)
        {
            string manufacturerName = TradeEntities.GetContext().Manufacturer.FirstOrDefault(manufacturer => manufacturer.ID == manufacturerId).Name;

            if (manufacturerName == null) return null;

            return manufacturerName;
        }

        public static Product ToProduct(SOTa.Product db)
        {
            return new Product(db.ProductArticleNumber, db.ProductName, db.ProductDescription, db.ProductCategoryID,
                GetUserImage(db.ProductPhoto), GetManufacturerName(db.ProductManufacturerID), db.ProductProviderID, db.ProductCost, db.ProductDiscountAmount,
                db.ProductDiscountActual, db.ProductQuantityInStock, db.ProductStatus);
        }

        public static Product[] ToProducts(SOTa.Product[] dbs)
        {
            return dbs.Select(db => ToProduct(db)).ToArray();
        }
    }
}
