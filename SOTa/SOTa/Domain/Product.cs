using System;
using System.Windows.Media.Imaging;

namespace SOTa.Domain
{
    public class Product
    {
        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategoryID { get; set; }
        public BitmapImage ProductPhoto { get; set; }
        public string ManufacturerName { get; set; }
        public int ProductProviderID { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<byte> ProductDiscountAmount { get; set; }
        public Nullable<byte> ProductDiscountActual { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set; }

        public Product(string productArticleNumber, string productName, string productDescription, int productCategoryID, BitmapImage productPhoto, string manufacturerName, int productProviderID, decimal productCost, byte? productDiscountAmount, byte? productDiscountActual, int productQuantityInStock, string productStatus)
        {
            ProductArticleNumber = productArticleNumber;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductCategoryID = productCategoryID;
            ProductPhoto = productPhoto;
            ManufacturerName = manufacturerName;
            ProductProviderID = productProviderID;
            ProductCost = productCost;
            ProductDiscountAmount = productDiscountAmount;
            ProductDiscountActual = productDiscountActual;
            ProductQuantityInStock = productQuantityInStock;
            ProductStatus = productStatus;
        }
    }
}
