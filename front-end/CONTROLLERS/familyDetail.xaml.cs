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
using NEW_COBRA.ENTITY;
namespace NEW_COBRA.CONTROLLERS
{
    /// <summary>
    /// Interaction logic for familyDetail.xaml
    /// </summary>
    public partial class familyDetail : UserControl
    {
        public List<ProductList>  listProduct { get;set; }
        string[] nameProduct;
        string nbtn;
      
         public familyDetail(string nbtn, List<Product> _prot) 
        {
            listProduct = new List<ProductList>();
            this.nameProduct = new string[_prot.Count];
            this.nbtn = nbtn;
            for (int i = 0; i < _prot.Count; i++)
            {
                this.nameProduct[i] = _prot.ElementAt<Product>(i).NAME ;
            }
            InitializeComponent();
            Lip();
            this.DataContext = this;
        }
       
        private void Lip()
        {   ryra.Content = this.nbtn ;
            
           
            int i = 0;
            foreach (string S in this.nameProduct)
            {
                listProduct.Add(new ProductList() { Name = S });   
                i++;
            }
           
        }
        public class ProductList
        { 
            public string Name { get; set; }
        }


    }
}
