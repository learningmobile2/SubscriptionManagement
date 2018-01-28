﻿using System;
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

namespace WinClient.Controls
{

    /// <summary>
    /// Interaction logic for PageContainer.xaml
    /// </summary>
    public partial class PageContainer : UserControl
    {
        public PageContainer()
        {
            InitializeComponent();
        }

        public EventHandler ListLoader { get; set; }
        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(ListLoader!=null)
            {
                this.ListLoader(this.MasterList, e);
            }
        }
    }
}
