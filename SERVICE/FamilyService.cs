using Microsoft.Office.Interop.Excel;
using NEW_COBRA.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.SERVICE
{
    class FamilyService
    { FamilyData familyData;
        public FamilyService()
        {
            this.familyData = new FamilyData();
        }

        public void addFamily()
        {

        }
        public void deleteFamily()
        {

        }
        public void getFamily()
        {

        }
        public List<String> getAllFamily(Workbook workbook)
        {
            return this.familyData.getAllFamily(workbook);
        }
    }
}
