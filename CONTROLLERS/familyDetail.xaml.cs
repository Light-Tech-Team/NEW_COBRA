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

        string[] fam;
        string nbtn;
        

       
         public familyDetail(string nbtn, List<Product> _prot) 
        {
            this.fam = new string[_prot.Count];
            this.nbtn = nbtn;
            for (int i = 0; i < _prot.Count; i++)
            {
                this.fam[i] = _prot.ElementAt<Product>(i).NAME;
                Console.WriteLine(this.fam[i]);
            }
            InitializeComponent();
            Lip();
         
        }
       
        private void Lip()
        {   ryra.Content = this.nbtn ;
            ryry.Orientation = Orientation.Vertical;
           
            int i = 0;
            foreach (string S in this.fam)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                Label label = new Label();
                label.Content = S;
                TextBox textBox = new TextBox();
                textBox.Name = "text" + i;

                stackPanel.Children.Add(label);
                stackPanel.Children.Add(textBox);
                ryry.Children.Add(stackPanel);
            }

        }

        private void view_Click(object sender, RoutedEventArgs e)
        {if(ryry.Visibility==Visibility.Collapsed)
             ryry.Visibility = Visibility.Visible; 
        else ryry.Visibility = Visibility.Collapsed;
        }
    }
}
