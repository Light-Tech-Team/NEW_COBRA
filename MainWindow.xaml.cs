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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Call(object sender, RoutedEventArgs e)
        {
            string S = (sender as Button).Content.ToString();

            switch (S)
            {
                case "FACTURE":

                    {
                        Console.WriteLine(S);

                        Home.Content = new FACTURE();
                    }
                    break;
                case "BONS":
                    {
                        Console.WriteLine(S);

                        Home.Content = new BONS();
                    }
                    break;
                case "CLIENT":
                    {
                        Console.WriteLine(S);

                        Home.Content = new CLIENT();
                    }
                    break;
                case "PANNE":
                    {
                        Console.WriteLine(S);

                        Home.Content = new PANNE();
                    }
                    break;
                case "STOCK":
                    {
                        Console.WriteLine(S);

                        Home.Content = new STOCK();
                    }
                    break;
            };

        }

    }
}
