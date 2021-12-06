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
            try
            {
                return this.familyData.getFamily(workbook, id);
            }
            catch(Exception e)
            {
                return this.familyData.getFamily(workbook, id);
            }
        }
        public List<String> getAllFamily(FirebaseClient firebaseClient)
        {
<<<<<<< HEAD
            try
            {
                Console.WriteLine(this.familyData.getAllFamily(firebaseClient).ToString());

                return this.familyData.getAllFamily(firebaseClient).Result;
            }
            catch(Exception e)
            {
                Console.WriteLine(this.familyData.getAllFamily(firebaseClient).ToString());

                return this.familyData.getAllFamily(firebaseClient).Result;


            }
=======
            return this.familyData.getAllFamily(firebaseClient).Result;
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
        }
    }
}
