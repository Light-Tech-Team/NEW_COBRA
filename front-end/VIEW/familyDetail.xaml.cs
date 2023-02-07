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
using FireSharp;
using NEW_COBRA.ENTITY;
using NEW_COBRA.SERVICE;

namespace NEW_COBRA.CONTROLLERS
{
    /// <summary>
    /// Interaction logic for familyDetail.xaml
    /// </summary>
    public partial class FamilyDetail : UserControl
    {
        public List<ProductList> ListProduct { get; set; }
        int Id_family;
        FirebaseClient firebaseClient;
        private string[] nameProduct;
        private readonly string nbtn;
        private readonly FamilyService familyService = new FamilyService();


        public FamilyDetail(int Id_family, FirebaseClient firebaseClient, List<Product> prot)
        {
            this.Id_family = Id_family;
            this.firebaseClient = firebaseClient;
            ListProduct = new List<ProductList>();
            this.nbtn = familyService.getAllFamily(firebaseClient).ElementAt(Id_family);
            InitializeComponent();
            mop(prot);
            Lip();
            this.DataContext = this;
        }
        private void mop(List<Product> proto)
        {
            nameProduct = new string[proto.Count];
            for (int i = proto.Count - 1; i >= 0; i--)
            {
                nameProduct[i] = proto.ElementAt(i).NAME;
                Console.WriteLine(nameProduct[i]);
            }
        }
        private void Lip()
        {
            ryra.Content = this.nbtn;
            int i = 0;
            foreach (string S in this.nameProduct)
            {
                ListProduct.Add(new ProductList() { Name = S });
                i++;
            }

        }
        public class ProductList
        {
            public string Name { get; set; }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            if (add_product.Children.Add(new AddProduct((byte)Id_family, firebaseClient)) != 0)
            {
                add_product.Children.Clear();
            }
        
        }
    }

}
