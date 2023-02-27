using FireSharp;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.DATA;
using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.SERVICE
{
    class ProductService
    {
        ProductData productData;
       

        public ProductService( FirebaseClient firebaseClient)
        { 
            this.productData = new ProductData(firebaseClient);
          
        }
     
       
     
        public List<Product> getProductOfFamily( byte ID_FAMILY)
        {
            return this.productData.getProductOfFamily(  ID_FAMILY);
        }
    }
}
