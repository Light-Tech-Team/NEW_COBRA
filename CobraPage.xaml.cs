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

        public object HeadPage
        {
            get { return (object)GetValue(HeadPageProperty); }
            set { SetValue(HeadPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Page.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeadPageProperty =
            DependencyProperty.Register("HeadPage", typeof(object), typeof(CobraPage), new PropertyMetadata(0));

        public object BodyPage
        {
            get { return (object)GetValue(BodyPageProperty); }
            set { SetValue(BodyPageProperty, value); }
        }



        // Using a DependencyProperty as the backing store for Page.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BodyPageProperty =
            DependencyProperty.Register("BodyPage", typeof(object), typeof(CobraPage), new PropertyMetadata(0));


        public CobraPage()
        {
            InitializeComponent();
        }
    }
}
