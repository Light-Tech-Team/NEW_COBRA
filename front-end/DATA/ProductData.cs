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
<<<<<<< HEAD
    {
        List<Product> product;
=======
    {   
        List<Product> product ;
        HttpClient Client = new HttpClient();
        HttpResponseMessage response;
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
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
<<<<<<< HEAD
            try
            {
                FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT").ConfigureAwait(false);
                Console.WriteLine("xxxxxxxxxxxxxxxxx");
                this.product = Response.ResultAs<List<Product>>();
            }
            catch (Exception e) {
                FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT").ConfigureAwait(false);
                Console.WriteLine("xxxxxxxxxxxxxxxxx");
                this.product = Response.ResultAs<List<Product>>();
            }
=======
                do
                {
                    FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT").ConfigureAwait(false);
                    this.product = Response.ResultAs<List<Product>>();
                } while (this.product == null);
                Console.WriteLine(this.product);
                Console.WriteLine("xxxxxxxxxxxxxxxxx");
                response = Client.GetAsync("http://127.0.0.1:5000//product/1").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
               
            
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
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
<<<<<<< HEAD
            

        { List<Product> product = new List<Product>();
            try
            {

                for (byte o = 0; o < this.product.Count; o++)
                    if (ID_FAMILY == this.product.ElementAt<Product>(o).ID_FAMILY)
                        product.Add(this.product.ElementAt<Product>(o));



                for (byte o = 0; o < this.product.Count; o++)
                    if (ID_FAMILY == this.product.ElementAt<Product>(o).ID_FAMILY)
                        product.Add(this.product.ElementAt<Product>(o));



                return product;
            }
            catch(Exception e) {
=======
        {
            try
            {
                List<Product> product = new List<Product>();
                
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
                for (byte o = 0; o < this.product.Count; o++)
                    if (ID_FAMILY == this.product.ElementAt<Product>(o).ID_FAMILY)
                        product.Add(this.product.ElementAt<Product>(o));

<<<<<<< HEAD


                for (byte o = 0; o < this.product.Count; o++)
                    if (ID_FAMILY == this.product.ElementAt<Product>(o).ID_FAMILY)
                        product.Add(this.product.ElementAt<Product>(o));



                return product;









            }
        
        
=======
                return product;
            }
            catch(Exception e) { return product; }
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
        }
    
    
    
    





    }
}
