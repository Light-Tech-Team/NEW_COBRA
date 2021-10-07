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


namespace NEW_COBRA
{
    
    /// <summary>
    /// Interaction logic for FACTURE.xaml
    /// </summary>
    public partial class FACTURE : System.Windows.Controls.Page
    {
        
        Workbook workbook;
        
        FamilyService familyService;
        FactureService factureService;
        public FACTURE(Workbook workbook)
        {
          
            this.workbook = workbook;
            this.familyService =new FamilyService();
            this.factureService = new FactureService();
           
            InitializeComponent();
            DataGrid1.ItemsSource = this.factureService.getAllInvoice();
        }
        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                    row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BodyPage.Children.Clear();

            StackPanel ST = new StackPanel();
            foreach (string S in this.familyService.getAllFamily(this.workbook))
            {
             
                CheckBox checkBox = new CheckBox();
                checkBox.Content = S;  
                ST.Children.Add(checkBox);

            }
            
            BodyPage.Children.Add(ST);

        }
    }
}
