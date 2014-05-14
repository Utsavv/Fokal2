using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class ProductManager
    {
        private static readonly ProductManager ProductManagerInstance = new ProductManager();

        private ProductManager()
        {
        }

        public static ProductManager GetInstance
        {
            get { return ProductManagerInstance; } //end of get
        }

        public List<product> GetProducts()
        {
            return ProductDAO.GetInstance.GetProducts();
        }

        public List<FilterProductFeature> GetFilterProductData()
        {
            return ProductDAO.GetInstance.GetFilterProductData();
        }

        public DataSet GetProductPrimaryFeatures(int productId)
        {
            return ProductDAO.GetInstance.GetProductPrimaryFeatures(productId);
        }

    }
}
