using Microsoft.Office.Interop.Excel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Button= System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using DataGrid =  System.Windows.Controls.DataGrid;
using NEW_COBRA.ENTITY;
using NEW_COBRA.CONTROLLERS;
using FireSharp;


namespace NEW_COBRA
{
   
    public partial class FACTURE : System.Windows.Controls.Page
    {
        
        Workbook workbook;
        
        FamilyService familyService;
        FactureService factureService;
        ProductService productService;
        FirebaseClient firebaseClient;
        public FACTURE(Workbook workbook, FirebaseClient firebaseClient)
        {
          
            this.workbook = workbook;
            this.familyService =new FamilyService();
            this.factureService = new FactureService();
            this.firebaseClient = firebaseClient;
            this.productService = new ProductService();
            InitializeComponent();
            DataGrid1.ItemsSource = this.factureService.getAllInvoice();
        }
        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            
           FactureDetail factureDetail = new FactureDetail( this.firebaseClient);
            factureDetail.ShowDialog();
      
           
          
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {   HeadPage.Children.RemoveAt(1);
            BodyPage.Children.Clear();
            StackPanel stack = new StackPanel();
            WrapPanel ST = new WrapPanel();
            var fam = await this.familyService.getAllFamily(this.firebaseClient);
            foreach (string S in fam)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = S;  
                ST.Children.Add(checkBox);
            }
            Button addFamily = new Button();
            addFamily.Content = "add Family";
            addFamily.Click += (s, eb) => {
                Console.WriteLine("test0");
                this.familyService.addFamily(this.firebaseClient);


            };
            stack.Children.Add(addFamily);
            stack.Children.Add(ST);
            Button next = new Button();
            next.Content = "Next";
            next.Click += (s, eb) => {
                Console.WriteLine("test1");
             
               
            };
            stack.Children.Add(next);
            BodyPage.Children.Add(stack);

        }
    }
}
