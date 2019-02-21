using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public static class DAL
    {
        static connectionString DbContext;

        static DAL()
        {
            DbContext = new connectionString();
        }

        #region Get List of Products
        public static List<Product> GetAllProducts()
        {
            return DbContext.Products.ToList();
        }
        #endregion

        #region Get Product by ID
        public static Product GetProduct(int productId)
        {
            return DbContext.Products.Where(p => p.id == productId).FirstOrDefault();
        }
        #endregion

        #region Add New Product
        public static bool InsertProduct(Product productItem)
        {
            bool status;
            try
            {
                DbContext.Products.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                e.ToString();
                status = false;
            }
            return status;
        }
        #endregion

        #region Update Product Details
        public static bool UpdateProduct(Product productItem)
        {
            bool status;
            try
            {
                Product prodItem = DbContext.Products.Where(p => p.id == productItem.id).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.productname = productItem.productname ?? prodItem.productname;
                    prodItem.qty = productItem.qty ?? prodItem.qty;
                    prodItem.price = productItem.price ?? prodItem.price;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception e)
            {
                e.ToString();
                status = false;
            }
            return status;
        }
        #endregion

        #region Delete Product Details
        public static bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                Product prodItem = DbContext.Products.Where(p => p.id == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.Products.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion
    }
}