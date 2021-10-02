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

namespace NEW_COBRA
{
    /// <summary>
    /// Interaction logic for FACTURE.xaml
    /// </summary>
    public partial class FACTURE : Page
    {
        CobraPage FACT;
        FamilyService familyService;
        public FACTURE()
        {
            familyService=new FamilyService();
            //FactureTable.ItemsSource= null;
            InitializeComponent();
          
        }


        private void CobraPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.FACT = (CobraPage)sender;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.FACT.PageControl.bodyPage.Children.Clear();

            StackPanel ST = new StackPanel();
            //foreach (string S in this.familyService.getAllFamily())
            for (int i = 0; i < 4; i++)
            {
                StackPanel s = new StackPanel();
                Label label = new Label();
                label.Content = i;
                CheckBox checkBox = new CheckBox();
                s.Children.Add(label);
                s.Children.Add(checkBox);
               
                ST.Children.Add(s);
            }
            this.FACT.PageControl.bodyPage.Children.Add(ST);
        }
    }
}
