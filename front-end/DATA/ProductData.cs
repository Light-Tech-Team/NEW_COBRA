using FireSharp;
using FireSharp.Response;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NEW_COBRA.DATA
{
    class ProductData
    {   
        List<Product> product ;
        HttpClient Client = new HttpClient();
        HttpResponseMessage response;
        public ProductData(FirebaseClient firebaseClient)
        {
            try
            {
                this.getFirebaseProduct(firebaseClient);
            }
            catch (Exception e) {
                this.getFirebaseProduct(firebaseClient);

            }
        }

        private async void getFirebaseProduct(FirebaseClient firebaseClient)
        {
                do
                {
                    FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT").ConfigureAwait(false);
                    this.product = Response.ResultAs<List<Product>>();
                } while (this.product == null);
                Console.WriteLine(this.product);
                Console.WriteLine("xxxxxxxxxxxxxxxxx");
                //response = Client.GetAsync("http://127.0.0.1:5000//product/1").Result;
               // Console.WriteLine(response.Content.ReadAsStringAsync().Result);
               
            
        }

        public void addProduct()
        {

        }
        public void deleteProduct()
        {

        }
        public Product getProduct(byte id)
        {
            try
            {
                return this.product.ElementAt<Product>(id);
            }
            catch (Exception e)
            { return this.product.ElementAt<Product>(id); }
        }

         
        public List<Product> getProductOfFamily(byte ID_FAMILY)
        {
            try
            {
                List<Product> product = new List<Product>();
                
                for (byte o = 0; o < this.product.Count; o++)
                    if (ID_FAMILY == this.product.ElementAt<Product>(o).ID_FAMILY)
                        product.Add(this.product.ElementAt<Product>(o));

                return product;
            }
            catch(Exception e) { return product; }
        }




    }
}
