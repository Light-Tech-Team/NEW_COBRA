using FireSharp;
using NEW_COBRA.CONTROLLERS;
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
using System.Windows.Shapes;

namespace NEW_COBRA
{
    /// <summary>
    /// Interaction logic for addfamily.xaml
    /// </summary>
    public partial class Addfamily : Window
    {
        private int id_family;
        private FirebaseClient firebaseClient;

        public Addfamily(int id_family, FirebaseClient firebaseClient)
        {
            this.id_family = id_family;
            this.firebaseClient = firebaseClient;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addfml.Close();
        }

        private void AddFamily(object sender, RoutedEventArgs e)
        {
            if (stt.Children.Add(new AddProduct((byte)id_family, firebaseClient)) != 0)
            {
                stt.Children.Clear();
            }
        }

     

    
    }
}
