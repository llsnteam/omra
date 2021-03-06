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
using Adatkezelő;

namespace Omra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDolgozókezelő dolgozokezelo = new Személykezelő();
        NaplozoNamespace.Service1Client kliens = new NaplozoNamespace.Service1Client();
        public MainWindow()
        {
            InitializeComponent();
            //A megadott felhasználónévvel és jelszóval az adatbázisból lekérdezi, hogy van-e ilyen dolgozó, ha van megnyitja a főablakot, ha nincs messagebox, majd a kód legvégén bezárja ezt az ablakot 
            felh.Focus();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Dolgozó dolg = dolgozokezelo.Azonosítás(felh.Text, jelszo.Password);
            if (dolg != null)
            {
                FoAblak foablak_window = new FoAblak(dolg);
                App.Current.MainWindow = foablak_window;
                foablak_window.Show();
                kliens.NaplobaIras("Bejelentkezés: " + felh.Text);
                this.Close();
            }
            else
                MessageBox.Show("Helytelen felhasználónév vagy jelszó lett megadva!","Hiba!",MessageBoxButton.OK,MessageBoxImage.Error);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
