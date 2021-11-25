using FireSharp;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.DATA;
using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.SERVICE
{
    class FactureService
    {
        FactureData facturedata;
        public FactureService()
        {
            this.facturedata = new FactureData(); 

        }

        public void addInvoice()
        {

        }
        public void deleteInvoice()
        {

        }
        public Task<FactureEntity> getInvoice( FirebaseClient firebaseClient, byte id)
        {
            return this.facturedata.getInvoice(  firebaseClient,  id);
        }
        public Task<List<FactureEntity>> getAllInvoice(FirebaseClient firebaseClient)
        {
            return this.facturedata.getAllInvoice(firebaseClient);
        }


    }
}
