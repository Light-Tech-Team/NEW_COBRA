using FireSharp;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.DATA;
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
        public List<Product> getProductOfFamily(Workbook workbook, byte ID_FAMILY)
        {


            return this.productData.getProductOfFamily(workbook, ID_FAMILY);
        }
    }
}
