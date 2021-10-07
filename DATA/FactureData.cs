using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.DATA
{
    class FactureData
    {
        List<FactureEntity> F;

        public FactureData()
        {
            this.F = new List<FactureEntity>();
        }

        public void OpenSheet(Workbook workbook)
        { 
        Worksheet worksheet = workbook.Sheets[""];
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
            this.F.Add(new FactureEntity()
            {
                id = 0,
                totalAmount = 3447,
                date = new DateTime(1995, 2, 7)

            });
            this.F.Add(new FactureEntity()
            {
                id = 1,
                totalAmount = 3447,
                date = new DateTime(1995, 2, 7),

            });
            this.F.Add(new FactureEntity()
            {
                id = 2,
                totalAmount = 3447,
                date = new DateTime(1995, 2, 7),

            });

            return this.F;

        }




    }
}
