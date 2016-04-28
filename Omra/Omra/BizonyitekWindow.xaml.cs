﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Adatkezelő;
namespace Omra
{
    /// <summary>
    /// Interaction logic for BizonyitekWindow.xaml
    /// </summary>
    public partial class BizonyitekWindow : Window
    {
        IBizonyítékkezelő bKezelő;
        public BizonyitekWindow()
        {
            InitializeComponent();
           
        }

        public BizonyitekWindow(Bizonyíték bizonyitek) //módosítás
        {
            InitializeComponent();
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            bKezelő = new Bűnesetkezelő();
            bKezelő.ÚjBizonyíték(megnevezes_txb.Text);
        }
    }
}
