using FireSharp;
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

namespace NEW_COBRA.CONTROLLERS
{
    /// <summary>
    /// Interaction logic for addFacture.xaml
    /// </summary>
    public partial class addFacture : UserControl
    {
        private FamilyService familyService=new FamilyService();
        private FirebaseClient firebaseClient;
        private ProductService productService;

        public addFacture(FirebaseClient firebaseClient)
        {
            this.productService = new ProductService(firebaseClient);
            this.firebaseClient = firebaseClient;
            InitializeComponent();
            listFamily.Children.Add(this.getListFamily());
        }

        private void AddFamily(object sender, RoutedEventArgs e)
        {
            this.familyService.addFamily(this.firebaseClient);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            
        }
        private StackPanel getListFamily()
        {
            StackPanel ST = new StackPanel();
            byte i = 0;
            List<string> vs = this.familyService.getAllFamily(this.firebaseClient);
            foreach (string S in vs)
            {
                List<Product> pr = this.productService.getProductOfFamily(i);
                ST.Children.Add(new familyDetail(S, pr));
                i++;
            }
            return ST;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            GetParent<Frame>((Button)sender).Content = new FACTURE(this.firebaseClient);
        }
        private TargetType GetParent<TargetType>(DependencyObject o)
            where TargetType : DependencyObject
        {
            return o == null || o is TargetType ? (TargetType)o : GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }
    }
}
