using FireSharp;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.DATA
{
    class FamilyData
    {
        List<String> stri = new List<String>();
        string sheet= "Family";

        public async void addFamily(FirebaseClient firebaseClient)
        {
            var Response = await firebaseClient.SetAsync("test/", "");
        }
        public void deleteFamily()
        {

        }
        public string getFamily(Workbook workbook,byte id)
        {
            Worksheet worksheet = workbook.Sheets[sheet];
            int I = 4;
            while (true)
            {   if(   ((byte)worksheet.Cells[I, 1].Value2)==id)    
              { 
                   return (String)worksheet.Cells[I, 2].Value2;
                
                }
                I++;
            }


        }


        public async Task<List<String> > getAllFamily( FirebaseClient firebaseClient)
        {

            var Response = await firebaseClient.GetAsync("FAMILY");
            String[] STR= Response.ResultAs<String[]>();
           
             foreach (String S in STR)
               stri.Add(S);
                   

            return stri;
        }
    }
}
