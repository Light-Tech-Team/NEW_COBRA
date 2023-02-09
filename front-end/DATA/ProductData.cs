using FireSharp;
using FireSharp.Response;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;


namespace NEW_COBRA.DATA
{
    class ProductData
    {   
        List<Product> product ;
        HttpClient Client = new HttpClient();
        HttpResponseMessage response;
        public ProductData(FirebaseClient firebaseClient)
        {
         
                this.getFirebaseProduct(firebaseClient);
            
        
        }

        private async void getFirebaseProduct(FirebaseClient firebaseClient)
        {

                
              
                try
            {
                Console.WriteLine(firebaseClient.ToString() + "gggggggggg");
                FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT").ConfigureAwait(false);
                this.product = Response.ResultAs<List<Product>>();
                Console.WriteLine(this.product.Count);
                var resp = await Client.GetAsync("http://127.0.0.1:5000//product/1");
                string se = await resp.Content.ReadAsStringAsync();
                Product p = JsonConvert.DeserializeObject<List<Product>>(se).ElementAt(0);
                Console.WriteLine(p.NAME);

            }
            catch (Exception e) {
                Console.WriteLine("rrrrrrrrr");
            }




           

        }

        public async void addProduct(Product product)
        {
           //var dui = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
          //  await Client.PostAsync("http://127.0.0.1:5000//product/", dui) ;
            //Console.WriteLine(dui.ReadAsStringAsync) ;
           //Console.WriteLine("success");
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
