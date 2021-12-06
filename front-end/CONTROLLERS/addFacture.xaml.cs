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
        private byte i = 0;
        private FamilyService familyService=new FamilyService();
        private ProductService productService;
        public class zaza
        {
            public string namefamily { get; set; }
        }
        public List<zaza> fmname { get; set; }
        
        private FirebaseClient firebaseClient;
        public addFacture(FirebaseClient firebaseClient)
        {
            this.fmname = new List<zaza>();
           
            this.productService = new ProductService(firebaseClient);
            this.firebaseClient = firebaseClient;
            InitializeComponent();
            this.getListFamily();
            this.DataContext = this;
           
        }

        private void AddFamily(object sender, RoutedEventArgs e)
        {
            this.familyService.addFamily(this.firebaseClient);
        }
        private void Next(object sender, RoutedEventArgs e)
        {
            listFamily.Children.Clear();
            listFamily.Children.Add(new familyDetail(this.familyService.getAllFamily(this.firebaseClient).ElementAt<string>(this.i),
                                                     this.productService.getProductOfFamily(this.i++))) ; 
        }
      
        private void Back(object sender, RoutedEventArgs e)
        {   if(this.i==0)
            GetParent<Frame>((Button)sender).Content = new FACTURE(this.firebaseClient);
            listFamily.Children.Clear();
            listFamily.Children.Add(new familyDetail(this.familyService.getAllFamily(this.firebaseClient).ElementAt<string>(--this.i),
                                                     this.productService.getProductOfFamily(this.i)));
        }
        private T GetParent<T>(DependencyObject o)
            where T : DependencyObject
        {
            return o == null || o is T ? (T)o : GetParent<T>(VisualTreeHelper.GetParent(o));
        }
        private void getListFamily()
        {
            byte i = 0;
            foreach (string S in this.familyService.getAllFamily(this.firebaseClient))
            {
                this.fmname.Add(new zaza() { namefamily = (i++) + "  " + S });
                //byte g = (byte)Int16.Parse(chk.Name.Split('x')[1]);
            }

        }
       
       

    }


}
    


