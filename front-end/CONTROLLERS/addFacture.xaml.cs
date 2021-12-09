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
        private List<int> Index=new List<int>();
        private List<string> listFamily = new List<string>();
        private int i = -1;
        private readonly FamilyService familyService = new FamilyService();
        FirebaseClient firebaseClient;
        private ProductService productService;
        public class Zaza
        {
            public string Namefamily { get; set; }
        }
        public List<Zaza> Fmname { get; set; }
        public addFacture(FirebaseClient firebaseClient)
        {
            productService = new ProductService(firebaseClient);
            Fmname = new List<Zaza>();
            this.firebaseClient = firebaseClient;
            InitializeComponent();
            listFamily = familyService.getAllFamily(this.firebaseClient);
            getListFamily();
            DataContext = this;
        }
        private void AddFamily(object sender, RoutedEventArgs e)
        {
            //familyService.addFamily(firebaseClient);
            new Addfamily(listFamily.Count+1,firebaseClient).Show();
        }
        private void Next(object sender, RoutedEventArgs e)
        {
            i++;
            listFamilyView.Children.Clear();
            _ = listFamilyView.Children.Add(new FamilyDetail(Index.ElementAt<int>(i), firebaseClient, 
                                            productService.getProductOfFamily((byte)Index.ElementAt<int>(i))));
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            switch (i)
            {
                case 0:
                    GetParent<Frame>((Button)sender).Content = new FACTURE(firebaseClient);
                    break;
                default:
                    --i;
                    listFamilyView.Children.Clear();
                    _ = listFamilyView.Children.Add(new FamilyDetail(Index.ElementAt<int>(i), firebaseClient,
                                                    productService.getProductOfFamily((byte)Index.ElementAt<int>(i))));
                    break;
            }
        }
        private T GetParent<T>(DependencyObject o)
            where T : DependencyObject
        {
            return o == null || o is T ? (T)o : GetParent<T>(VisualTreeHelper.GetParent(o));
        }
        private void getListFamily()
        {
            foreach (string S in listFamily)
            {
                this.Fmname.Add(new Zaza() { Namefamily = S });
            }
        }
        private void INDEX(object sender, RoutedEventArgs e)
        {
            Index.Add(listFamily.IndexOf((string)((CheckBox)sender).Content)) ;
            Index.Sort();
        }
    }
}


