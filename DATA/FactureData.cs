using FireSharp;
using FireSharp.Response;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
using NEW_COBRA.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NEW_COBRA.DATA
{
    class FactureData
    {
    

     
      

        public void addInvoice()
        {

        }
        public void deleteInvoice()
        {

        }
        public  async Task<FactureEntity> getInvoice( FirebaseClient firebaseClient, byte b)
        {   ProductService productService = new ProductService();
            FactureEntity factureEntity = new FactureEntity();
        
            factureEntity.FactureElement=new List<FactureElement>();
           
            byte J = 0;
            while (true)
            {    
                FirebaseResponse ResponseP = await firebaseClient.GetAsync("FACTURE/" + b + "/FactureElement/"+ J +"/P").ConfigureAwait(false);
                
                int P = ResponseP.ResultAs<int>();

                var product = productService.getProduct(firebaseClient, (byte) P);
                Product pro = product.Result;
                FirebaseResponse ResponseQuan = await firebaseClient.GetAsync("FACTURE/" + b + "/FactureElement/" + J  + "/Quan").ConfigureAwait(false);
    
                factureEntity.FactureElement.Add(new FactureElement()
                {
                    IdFactureElement = J,
                    Quantity = (byte)ResponseQuan.ResultAs<int>(),
                    CodeProduct = pro.CODE,
                    NameProduct = pro.NAME,
                    Price_buy = pro.PRICE_BUY,
                    Amount = (byte)ResponseQuan.ResultAs<int>() * pro.PRICE_BUY
                });

                J++;
                if (ResponseP.Body.Length == J) { break; }
            }
         
            return factureEntity;

        }
         



        public List<FactureEntity> getAllInvoice()
        {
            List<FactureEntity> F = new List<FactureEntity>();
            F.Add(new FactureEntity()
            {
                id = 0,
                totalAmount = 3447,
                date = new DateTime(1995, 2, 7)

            });
            F.Add(new FactureEntity()
            {
                id = 1,
                totalAmount = 3447,
                date = new DateTime(1995, 2, 7),

            });
            F.Add(new FactureEntity()
            {
                id = 2,
                totalAmount = 3447,
                date = new DateTime(1995, 2, 7),

            });

            return F;

        }


    }

    
}
