using FireSharp;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.DATA;
using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.SERVICE
{
    class ProductService
    {
        ProductData productData = new ProductData();

        public void addProduct()
        {

        }
        public void deleteProduct()
        {

        }
        public Task<Product> getProduct(FirebaseClient firebaseClient, byte id)
        {
          


            return this.productData.getProduct(  firebaseClient,  id);
        }
        public Task<List<Product>> getProductOfFamily(FirebaseClient firebaseClient, byte ID_FAMILY)
        {


            return this.productData.getProductOfFamily( firebaseClient,  ID_FAMILY);
        }
    }
}
