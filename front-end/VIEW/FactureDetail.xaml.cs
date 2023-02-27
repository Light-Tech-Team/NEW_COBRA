using FireSharp;
using NEW_COBRA.DATA;
using NEW_COBRA.ENTITY;
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
        FactureData facturedata=new FactureData();
        FactureEntity factureEntity = new FactureEntity();
        public FactureDetail(FirebaseClient firebaseClient, byte I)
        {

            InitializeComponent();
            try { 
            this.factureEntity = this.facturedata.getInvoice().Result;
           // factureTable.ItemsSource = this.factureEntity.FactureElement;
          //DateTime Date = this.factureEntity.date;
        }
            catch(Exception e)
            {
               
                    
                
            }

           /* id.Text = (I + 1).ToString();
            totalAmount.Text = this.factureEntity.totalAmount.ToString() ;
            TVA.Text = (this.factureEntity.totalAmount * 0.19).ToString();
            TTC.Text = (this.factureEntity.totalAmount * 1.19).ToString();*/
       

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                    printDialog.PrintVisual(BECH,"INVOICE") ;
            }
            finally
            {
                this.IsEnabled = true;

            }
        }
    }
}
