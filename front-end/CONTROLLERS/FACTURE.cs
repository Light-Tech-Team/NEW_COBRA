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
using Button = System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using DataGrid = System.Windows.Controls.DataGrid;
using NEW_COBRA.ENTITY;
using NEW_COBRA.CONTROLLERS;
using FireSharp;

namespace NEW_COBRA
{

    public partial class FACTURE : System.Windows.Controls.Page
    {

        FamilyService familyService;
        FactureService factureService;
        ProductService productService;
        FirebaseClient firebaseClient;
        public FACTURE(FirebaseClient firebaseClient)
        {
            this.familyService = new FamilyService();
            this.factureService = new FactureService();
            this.firebaseClient = firebaseClient;
            this.productService = new ProductService(firebaseClient);
            InitializeComponent();
            Dtgd.ItemsSource = this.factureService.getAllInvoice(firebaseClient).Result;
        }
         void Show(object sender, RoutedEventArgs e)
          {
              Button btn = (Button)sender;

                  var row = GetParent<DataGridRow>((Button)sender);
                  var index = Dtgd.Items.IndexOf(row.Item);
            
              FactureDetail factureDetail = new FactureDetail( this.firebaseClient, (byte)index);
              factureDetail.ShowDialog();

          }
          private TargetType GetParent<TargetType>(DependencyObject o)
              where TargetType : DependencyObject
          {
              if (o == null || o is TargetType) return (TargetType)o;
              return GetParent<TargetType>(VisualTreeHelper.GetParent(o));
          }

        /*  private async void Button_Click(object sender, RoutedEventArgs e)
          {   HeadPage.Children.RemoveAt(1);
              grd.Children.Clear();
              grd.Children.Add
              StackPanel stack = new StackPanel();
              StackPanel ST = new StackPanel();

              byte i = 0;
              foreach (string S in await this.familyService.getAllFamily(this.firebaseClient))
              { List<Product> pr = this.productService.getProductOfFamily(firebaseClient, i).Result;

                  ST.Children.Add(new familyDetail(S, pr));
                  i++;
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

          }*/
    }
}
