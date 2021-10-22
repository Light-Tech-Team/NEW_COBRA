using FireSharp;
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

        public void addFamily(FirebaseClient firebaseClient)
        {
            this.familyData.addFamily(firebaseClient);
        }
        public void deleteFamily()
        {

        }
        public string getFamily(Workbook workbook, byte id)
        {
            return this.familyData.getFamily(workbook, id);
        }
        public Task<List<String>> getAllFamily(FirebaseClient firebaseClient)
        {
            return this.familyData.getAllFamily(firebaseClient);
        }
    }
}
