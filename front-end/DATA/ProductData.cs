using FireSharp;
using FireSharp.Response;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NEW_COBRA.DATA
{
    class ProductData
    {
        List<Product> product ;
        public ProductData(FirebaseClient firebaseClient)
        {
            this.getFirebaseProduct(firebaseClient);
        }
       
        private async void getFirebaseProduct(FirebaseClient firebaseClient)
        {   
            FirebaseResponse Response = await firebaseClient.GetAsync("PRODUCT").ConfigureAwait(false);
            this.product = Response.ResultAs<List<Product>>() ; 
        }

        public void addProduct()
        {

        }
        public void deleteProduct()
        {

        }
        public Product getProduct( byte id)
        {   
            return  this.product.ElementAt<Product>(id);
        }
        public List<Product> getProductOfFamily(byte ID_FAMILY)
        { List<Product> product = new List<Product>();
          for(byte o = 0; o<this.product.Count; o++)
                    if (ID_FAMILY == this.product.ElementAt<Product>(o).ID_FAMILY)
                        product.Add(this.product.ElementAt<Product>(o));
            return product;
        }




    }
}
