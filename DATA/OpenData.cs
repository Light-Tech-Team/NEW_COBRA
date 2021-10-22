using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace NEW_COBRA.DATA
{
    class OpenData
    {
        protected Application excel = new Application();
        
        public OpenData()
        {

           
           // this.worksheet = this.workbook.Worksheets[1];
         //   Console.WriteLine((String)this.worksheet.Cells[1, 1].Value2);


        }
        public Workbook OpenWorkbook()
        {
            return this.excel.Workbooks.Open("Cobra.xlsx");
        }
        public void CloseWorkbook()
        {
           this.excel.Workbooks.Close();
        }


    }
}
