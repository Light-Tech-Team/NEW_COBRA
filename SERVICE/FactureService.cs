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
        public void getInvoice()
        {

        }
        public List<FactureEntity> getAllInvoice()
        {
            return this.facturedata.getAllInvoice();
        }


    }
}
