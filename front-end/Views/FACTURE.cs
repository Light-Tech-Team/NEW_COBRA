using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;
using NEW_COBRA.CONTROLLERS;
using FireSharp;
using NEW_COBRA.DATA;
using NEW_COBRA.Models;
using NEW_COBRA.ViewModels;

namespace NEW_COBRA
{ 

    public partial class FACTURE : System.Windows.Controls.Page
    {
        private FirebaseClient firebaseClient;
        BuyInvoiceViewModel buyInvoiceViewModel;

        public FACTURE(FirebaseClient firebaseClient)
        {   
            this.firebaseClient = firebaseClient;
            InitializeComponent();
            buyInvoiceViewModel= new BuyInvoiceViewModel();
            this.DataContext = this.buyInvoiceViewModel;
        }
        void Show(object sender, RoutedEventArgs e)
        {
            Grid D=(Grid)VisualTreeHelper.GetParent(HeadPage);
            D.Children.RemoveAt(0);
            BodyPage.Children.Clear();
            BodyPage.Children.Add(new FactureDetail((byte)Dtgd.Items.IndexOf(Adds.GetParent<DataGridRow>((Button)sender).Item)));
            
        }
      

        private void Add_facture(object sender, RoutedEventArgs e)
        {
            HeadPage.Children.RemoveAt(1);
            BodyPage.Children.Clear();
            BodyPage.Children.Add(new addFacture());
        }

        
    }
}
