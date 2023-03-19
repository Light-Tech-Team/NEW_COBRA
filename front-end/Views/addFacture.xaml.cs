﻿using FireSharp;
using NEW_COBRA.DATA;
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
        private int i = -1;
        private ProductData productData;

        public addFacture()
        {
            productData = new ProductData();
          
            InitializeComponent();
            DataContext = this;
          
        }
        private void AddFamily(object sender, RoutedEventArgs e)
        {
            AddFami.Children.Add(new Addfamily());
        }
        private void Next(object sender, RoutedEventArgs e)
        {
            i++;
            listFamilyView.Children.Clear();
            _ = listFamilyView.Children.Add(new FamilyDetail(Index.ElementAt<int>(i)));
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            switch (i)
            {
                case 0:
                    ((Grid)VisualTreeHelper.GetParent(Adds.GetParent<UserControl>((Button)sender))).Children.Add(new addFacture());
                    ((Grid)VisualTreeHelper.GetParent(Adds.GetParent<UserControl>((Button)sender))).Children.RemoveAt(0);
                    
                  
                    break;
                default:
                    if (i < 0) break;
                    --i;
                    listFamilyView.Children.Clear();
                    _ = listFamilyView.Children.Add(new FamilyDetail(Index.ElementAt<int>(i)));
                    break;
            }
        }
    
        private void INDEX(object sender, RoutedEventArgs e)
        {
            //Index.Add(listFamily.IndexOf((string)((CheckBox)sender).Content)) ;
            Index.Sort();
        }
    }

}


