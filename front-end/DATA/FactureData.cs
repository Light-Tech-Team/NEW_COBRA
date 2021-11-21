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
        public async Task<FactureEntity> getInvoice( FirebaseClient firebaseClient, byte b)
        {   ProductService productService = new ProductService(firebaseClient);
            FactureEntity factureEntity = new FactureEntity();
        
            factureEntity.FactureElement=new List<FactureElement>();
           
            byte J = 1;
            while (true)
            {
                int P;
                try {
               
                    FirebaseResponse ResponseP =await firebaseClient.GetAsync("FACTURE/" + b + "/FactureElement/"+ (J-1) +"/P").ConfigureAwait(false);
                 
                    P = ResponseP.ResultAs<int>();
                    Console.WriteLine(P);
                }
                catch(Exception e)
                {
                    if (true) { break; }

                }



                Product pro  = productService.getProduct( (byte) P);
               
                FirebaseResponse ResponseQuan = await firebaseClient.GetAsync("FACTURE/" + b + "/FactureElement/" + (J - 1) + "/Quan").ConfigureAwait(false);
                Console.WriteLine(pro.CODE);
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
                
               
             
            }
         
            return factureEntity;

        }
         



        public async Task<List<FactureEntity>> getAllInvoice(FirebaseClient firebaseClient)
        {
            List<FactureEntity> F = new List<FactureEntity>();
            byte o = 1;
            while (true)
            {
                float P;
                try
                {
                    FirebaseResponse ResponseTotalAmount = await firebaseClient.GetAsync("FACTURE/" + (o-1) + "/totalAmount").ConfigureAwait(false);
                    P = ResponseTotalAmount.ResultAs<float>();
                    
                    F.Add(new FactureEntity()
                    {
                        id = o,
                        totalAmount = P,
                       date = new DateTime(1995, 2, 7)

                    });
                    Console.WriteLine(P);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error dia");
                    if (true) { break; }

                }
                o++;

            }
          
      

            return F;

        }


    }

    
}
