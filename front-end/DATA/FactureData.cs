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
        public async Task<FactureEntity> getInvoice( )
        {  
            FactureEntity factureEntity = new FactureEntity();
        
            factureEntity.FactureElement=new List<FactureElement>();
           
           
         
            return factureEntity;

        }
         



        public async Task<List<FactureEntity>> getAllInvoice()
        {
            List<FactureEntity> F = new List<FactureEntity>();
           
               
              
                    Console.WriteLine("error dia");
      
            return F;

        }


    }

    
}
