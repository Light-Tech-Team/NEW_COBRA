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
    /// Interaction logic for CobraPage.xaml
    /// </summary>
    public partial class CobraPage : UserControl
    {

        public object Page
        {
            get { return (object)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }



        // Using a DependencyProperty as the backing store for Page.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageProperty =
            DependencyProperty.Register("Page", typeof(object), typeof(CobraPage), new PropertyMetadata(0));
        public CobraPage()
        {
            InitializeComponent();
        }
    }
}
