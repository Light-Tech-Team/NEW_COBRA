using FireSharp;
using FireSharp.Response;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
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
        public async Task<List<Product>> getProductOfFamily(FirebaseClient firebaseClient, byte ID_FAMILY)
        {
            List<Product> product = new List<Product>();
            byte o = 0;
            while (true)
            {
                
                try
                {
                    FirebaseResponse ResponseID_FAMILY = await firebaseClient.GetAsync("PRODUCT/" + o + "/ID_FAMILY").ConfigureAwait(false);
                    if (ID_FAMILY == ResponseID_FAMILY.ResultAs<byte>())
                    {
                        FirebaseResponse ResponseProduct = await firebaseClient.GetAsync("PRODUCT/" + o ).ConfigureAwait(false);
                        product.Add(ResponseProduct.ResultAs<Product>());
                    } 
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("er dia" + o);
                    if (true) { break; }

                }
                o++;

            }
            return product;
        }




    }
}
