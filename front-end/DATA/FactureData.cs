using FireSharp;
using FireSharp.Response;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
using NEW_COBRA.SERVICE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.DATA
{
    class FactureData
    {

        HttpClient Clien= new HttpClient();

        public void addInvoice()
        {

        }
        public void deleteInvoice()
        {

        }
        public async Task<FactureEntity> getInvoice( )
        {  
            FactureEntity factureEntity = new FactureEntity();
        
           
           
         
            return factureEntity;

        }
         



        public async Task<List<FactureEntity>> getAllInvoice()
        {
            List<FactureEntity> G = new List<FactureEntity>();
            try
            {
                var res = await Clien.GetAsync("http://127.0.0.1:5000//facture").ConfigureAwait(false);       
                string se = await res.Content.ReadAsStringAsync();
                G = JsonConvert.DeserializeObject<List<FactureEntity>>(se) ;
 
            }
            catch (Exception e)
            {
                Console.WriteLine("qqqqqqqqqqqqqq");
            }

            return G;
        }


    }

    
}
