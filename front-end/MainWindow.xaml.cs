using NEW_COBRA.DATA;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FireSharp.Config;
using FireSharp;
using NEW_COBRA.SERVICE;

namespace NEW_COBRA
{

    public partial class MainWindow : Window
    {
        
        

        FirebaseConfig firebaseConfig = new FirebaseConfig
        {
            AuthSecret = "J4XSSr91u3cDkBAzbyISbBwVcUC9opLSt6TcJuBx",
            BasePath = "https://cobra-c6303-default-rtdb.firebaseio.com/"

        };
        FirebaseClient firebaseClient;
        private ProductService productService;
        public MainWindow()
        {
            
            InitializeComponent();
            
            try { 
            this.firebaseClient = new FirebaseClient(firebaseConfig);
            this.productService = new ProductService(firebaseClient);
                }
            catch(Exception e)
            {


            }
            
    }

       


        private void Call(object sender, RoutedEventArgs e)
        {
            string S = (sender as ListViewItem).Name;
            switch (S)
            {
                case "Facture":
                    Home.Content = new FACTURE(this.firebaseClient);
                    
                    break;
                case "Bon":
                    Home.Content = new BONS();
                    break;
                case "Client":
                    Home.Content = new CLIENT();
                    break;
                case "Stock":
                    Home.Content = new STOCK();
                    break;
                case "Panne":
                    Home.Content = new PANNE();
                    break;
                case "Exit":
                    Close();
                    break;

            }
           


        }
       
    }
}
