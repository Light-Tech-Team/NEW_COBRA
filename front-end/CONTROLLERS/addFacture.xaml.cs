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
        private FamilyService familyService;
        private FirebaseClient firebaseClient;

        public addFacture()
        {
            InitializeComponent();
        }

        private void AddFamily(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("test0");
            this.familyService.addFamily(this.firebaseClient);

        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("test1");
        }
    }
}
