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
       
        public MainWindow()
        {
            InitializeComponent();
            this. firebaseClient = new FirebaseClient(firebaseConfig);
        }

        private  void Call(object sender, RoutedEventArgs e)
        {

            Button B = (Button)sender;
            string S = B.Content.ToString();

            switch (S)
            {
                case "FACTURE":

                    {
                        Home.Content = new FACTURE( this.firebaseClient) ;
                    }
                    break;
                case "BONS":
                    {
                        Home.Content = new BONS();
                    }
                    break;
                case "CLIENT":
                    {
                        Home.Content = new CLIENT();
                    }
                    break;
                case "PANNE":
                    {
                        Home.Content = new PANNE();
                    }
                    break;
                case "STOCK":
                    {
                        Home.Content = new STOCK();
                    }
                    break;
            };

        }

     
    }
}
