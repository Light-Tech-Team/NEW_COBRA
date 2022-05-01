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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : UserControl
    {   private byte id_family;
        private FirebaseClient firebaseClient;
        private ProductService productService;
        public AddProduct(byte id_family, FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
            productService = new ProductService(this .firebaseClient) ;
            this.id_family = id_family;
            InitializeComponent();
        }

        public AddProduct()
        {
        }

        private void SAVE(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ID_FAMILY = this.id_family;
            product.NAME = NAME.Text;
            product.CODE = CODE.Text;
            product.PRICE_BUY = (int)Int32.Parse( PRICE_BUY.Text);
            product.PRICE_SELL = (int)Int32.Parse(PRICE_SELL.Text);
            productService.addProduct(product);
            ((StackPanel)GetParent<UserControl>((Button)sender).Parent).Children.Add(new AddProduct(id_family, firebaseClient));
            ((StackPanel)GetParent<UserControl>((Button)sender).Parent).Children.RemoveAt(0);
        }
        private TargetType GetParent<TargetType>(DependencyObject o)
            where TargetType : DependencyObject
        {
            return o == null || o is TargetType ? (TargetType)o : GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }

        private void FINISH(object sender, RoutedEventArgs e)
        {
            if (((Window)GetParent<Window>((Button)sender)).Name == "addfml") GetParent<Window>((Button)sender).Close();
            ((StackPanel)GetParent<UserControl>((Button)sender).Parent).Children.Clear() ;
            
        }
        
        
    }
}
