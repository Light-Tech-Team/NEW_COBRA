﻿using NEW_COBRA.SERVICE;
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
using Button = System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using DataGrid = System.Windows.Controls.DataGrid;
using NEW_COBRA.ENTITY;
using NEW_COBRA.CONTROLLERS;
using FireSharp;
using NEW_COBRA.DATA;

namespace NEW_COBRA
{

    public partial class FACTURE : System.Windows.Controls.Page
    {
        
        private FirebaseClient firebaseClient;
        FactureData facturedata;

        public FACTURE(FirebaseClient firebaseClient)
        {
            this.firebaseClient = firebaseClient;
            InitializeComponent();
            this.facturedata = new FactureData();
            Dtgd.ItemsSource = this.facturedata.getAllInvoice().Result;


        }
        void Show(object sender, RoutedEventArgs e)
        {
        new FactureDetail(this.firebaseClient, (byte)Dtgd.Items.IndexOf(GetParent<DataGridRow>((Button)sender).Item)).Show();
        }
        private TargetType GetParent<TargetType>(DependencyObject o)
              where TargetType : DependencyObject
        {
            return o == null || o is TargetType ? (TargetType)o : GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HeadPage.Children.RemoveAt(1);
            BodyPage.Children.Clear();
            BrushConverter bc = new BrushConverter();
            BodyPage.Background = (Brush)bc.ConvertFrom("#F6F7F8");
            BodyPage.Children.Add(new addFacture(this.firebaseClient));
            
        }
    }
}