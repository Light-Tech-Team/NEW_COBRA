using FireSharp;
using Microsoft.Office.Interop.Excel;
using NEW_COBRA.ENTITY;
using NEW_COBRA.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace NEW_COBRA.CONTROLLERS
{
    /// <summary>
    /// Interaction logic for FactureDetail.xaml
    /// </summary>
    public partial class FactureDetail : System.Windows.Window
    {
        FactureService factureService = new FactureService(); 
        FactureEntity factureEntity = new FactureEntity();
        public  FactureDetail( FirebaseClient firebaseClient, byte I)
        {
            
            InitializeComponent();
            this.factureEntity = this.factureService.getInvoice( firebaseClient, I).Result;
            factureTable.ItemsSource = this.factureEntity.FactureElement;
            DateTime Date= this.factureEntity.date;
           /* id.Text = (I + 1).ToString();
            totalAmount.Text = this.factureEntity.totalAmount.ToString() ;
            TVA.Text = (this.factureEntity.totalAmount * 0.19).ToString();
            TTC.Text = (this.factureEntity.totalAmount * 1.19).ToString();*/
       

        }

     
    }
}
