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
    /// Interaction logic for GyanusitottAblak.xaml
    /// </summary>
    public partial class GyanusitottAblak : Window
    {

        IGyanúsítottkezelő gyKezelo;
        public GyanusitottAblak()
        {
            InitializeComponent();
        }

        private void click_mentes(object sender, RoutedEventArgs e)
        {
            if (txt_azonosito.Text.Lenght != 0 && txt_nev.Text.Lenght != 0 && txt_lackim.Text.Lenght != 0 && txt_telszam.Text.Lenght != 0)
            {
 
            }
        }
    }
}
