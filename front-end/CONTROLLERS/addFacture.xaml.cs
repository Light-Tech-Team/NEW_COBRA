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
<<<<<<< HEAD
        public class zaza
        {
            public string namefamily { get; set; }
        }
        public List<zaza> fmname { get; set; }
        private FamilyService familyService = new FamilyService();
=======
        private byte i = 0;
        private FamilyService familyService=new FamilyService();
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
        private FirebaseClient firebaseClient;
        public addFacture(FirebaseClient firebaseClient)
        {
<<<<<<< HEAD
            this.fmname = new List<zaza>();
            this.firebaseClient = firebaseClient;
            InitializeComponent();
            this.getListFamily();
            this.DataContext = this;
=======
           
            this.productService = new ProductService(firebaseClient);
            this.firebaseClient = firebaseClient;
            InitializeComponent();
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
           
        }
        private void AddFamily(object sender, RoutedEventArgs e)
        {
            this.familyService.addFamily(this.firebaseClient);
        }
        private void Next(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD

        }
        private void getListFamily()
        {
                byte i = 0;
                foreach (string S in this.familyService.getAllFamily(this.firebaseClient))
                {
                   this.fmname.Add(new zaza(){namefamily = (i++) +"  "+ S }) ;
                //byte g = (byte)Int16.Parse(chk.Name.Split('x')[1]);
                }

        }
            public void Back(object sender, RoutedEventArgs e)
            {
                GetParent<Frame>((Button)sender).Content = new FACTURE(this.firebaseClient);
            }
            public TargetType GetParent<TargetType>(DependencyObject o)
                where TargetType : DependencyObject
            {
                return o == null || o is TargetType ? (TargetType)o : GetParent<TargetType>(VisualTreeHelper.GetParent(o));
            }

=======
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
>>>>>>> 6f2c838e678f41aed6d47014fcd0da17a770fac8
        }
    }

