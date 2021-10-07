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
        public List<String> getAllFamily(Workbook workbook)
        {
            Worksheet worksheet = workbook.Sheets["Family"];
            int I = 4;
          //  for (; I < 45; I++)
            {
               // Console.WriteLine((String)worksheet.Cells[I, 2].Value2);
              //  if (((String)worksheet.Cells[I, 2].Value2)==null)
                //    Console.WriteLine("VIDE");
            }
             while ((String)worksheet.Cells[I, 2].Value2!=null)
              {
                Console.WriteLine("TEST");
                stri.Add((String)worksheet.Cells[I, 2].Value2);
                  I++;
               }

            return stri;
        }
    }
}
