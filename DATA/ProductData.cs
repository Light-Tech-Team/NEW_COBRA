using FireSharp;
using FireSharp.Response;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.DATA
{
    class ProductData
    {
        Product product=new Product();
        public void addProduct()
        {

        }
        public void deleteProduct()
        {

        }
        public async  Task<Product> getProduct( FirebaseClient firebaseClient, byte id)
        {   
      
            FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT/" + id).ConfigureAwait(false);
            product = Response.ResultAs<Product>();
       
           
            return  product;
            
        }
        public List<Product> getProductOfFamily(Workbook workbook, byte ID_FAMILY)
        {
            List<Product> product = new List<Product>();

            return product;
        }




    }
}
