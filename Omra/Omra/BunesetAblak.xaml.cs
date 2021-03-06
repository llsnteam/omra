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
using System.Collections.ObjectModel;

namespace Omra
{
    /// <summary>
    /// Interaction logic for BunesetAblak.xaml
    /// </summary>
    public partial class BunesetAblak : Window
    {
        private bool mod; // azt jelzi, hogy módosítási céllal lett-e meghívva ez az osztály, vagy új elem felvétellel
        private decimal id;
        private ObservableCollection<Gyanúsított> gyanúsítottak;
        private ObservableCollection<Bizonyíték> bizonyítékok;
        private DatabaseElements DE = new DatabaseElements();
        private Bűnesetkezelő bunesetK = new Bűnesetkezelő();
        private Kereséskezelő keresesK = new Kereséskezelő();
        private Dolgozó felelősŐrnagy;
        private Bűneset kivBűneset;

        private NaplozoNamespace.Service1Client kliens = new NaplozoNamespace.Service1Client();

        public BunesetAblak() // új létrehozása
        {
            InitializeComponent();
            Bűneset idhez = null; // csak azért kell, hogy az azonosítógenerálásnál el tudja dönteni, hogy melyik metódust hívja meg null értékkel, mert két fajta bemeneti paramétere is lehet
            id = bunesetK.AzonosítóGenerálás(idhez);
            gyanúsítottak = new ObservableCollection<Gyanúsított>();
            bizonyítékok = new ObservableCollection<Bizonyíték>();
            Feltoltes(new Dolgozó(Rang.Ornagy, "", "", "", 0), "", gyanúsítottak, bizonyítékok,BÁllapot.Folyamatban);
        }

        public BunesetAblak(Bűneset buneset) //módosítással meghívás
        {
            InitializeComponent();
            mod = true;
            kivBűneset = buneset;
            id = kivBűneset.GetAzonosító;
            felelősŐrnagy = buneset.GetFelelős;
            gyanúsítottak = bunesetK.GyanúsítottakKigyűjtése(buneset);
            bizonyítékok = bunesetK.BizonyítékokKigyűjtése(buneset);
            Feltoltes(buneset.GetFelelős, buneset.GetLeiras, gyanúsítottak, bizonyítékok,buneset.GetÁllapot());

            if (FoAblak.aktDolgozo.GetBeosztás() != Rang.Kapitány)  //Csak kapitány zárhatja le -Laczkó
                allapot_cbx.IsEnabled = false;
        }

        private void Feltoltes(Dolgozó felelosOrnagy, string leírás, ObservableCollection<Gyanúsított> gyan, ObservableCollection<Bizonyíték> biz, BÁllapot allapot)
        {
            felorn_txb.Text = felelosOrnagy.GetNév();
            leiras_txb.Text = leírás;
            ListboxGyanúsítottak.ItemsSource = gyan;
            ListboxBizonyítékok.ItemsSource = biz;
            if (allapot == BÁllapot.Folyamatban)
                allapot_cbx.IsChecked = true;
            else
                allapot_cbx.IsChecked = false;
        }

        private void FelelosOrnagyKereses_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Dolgozó);
            if (keresablak.ShowDialog() == true)
            {
                felelősŐrnagy = (Dolgozó)keresablak.feltoltendo;
                if (felelősŐrnagy.GetBeosztás() == Rang.Ornagy)
                {
                    felorn_txb.Text = felelősŐrnagy.GetNév();
                }
                else
                {
                    MessageBox.Show("Ez a felhasználó nem rendelkezik a szükséges beosztással!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    felelősŐrnagy = null;
                }
            }
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            if (felelősŐrnagy != null)
            {
                string allapot = (bool)allapot_cbx.IsChecked ? BÁllapot.Folyamatban.ToString() : BÁllapot.Lezárt.ToString();
                if (mod)
                {
                    bunesetK.BűnesetMódosítás(kivBűneset, felelősŐrnagy.GetAzonosító(), leiras_txb.Text, allapot);
                }
                else
                {                    
                    bunesetK.ÚjBűneset(id, allapot, DateTime.Now, leiras_txb.Text, felelősŐrnagy.GetAzonosító());
                }
                this.DialogResult = true;
            }
            else
                MessageBox.Show("Nincs kiválasztva a bűnesethez felelős őrnagy!","Hiba!",MessageBoxButton.OK,MessageBoxImage.Warning);
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GyanusitottFelvetel_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Gyanúsított);
            if (keresablak.ShowDialog() == true)
            {
                bunesetK.GyanúsítottHozzáadása((Gyanúsított)keresablak.feltoltendo, kivBűneset);
                if (bunesetK.Hozzaadhato)
                {
                    gyanúsítottak.Add((Gyanúsított)keresablak.feltoltendo);
                    kliens.NaplobaIras("Meglévő gyanúsított (" + (keresablak.feltoltendo as Gyanúsított).GetNév() + ") bűnesethez (" + id + ") rendelése.");
                    bunesetK.Hozzaadhato = false;
                }
            }
        }

        private void BizonyitekFelvetel_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Bizonyíték);
            if (keresablak.ShowDialog() == true)
            {
                bunesetK.BizonyítékHozzáadása((Bizonyíték)keresablak.feltoltendo, kivBűneset);
                if (bunesetK.Hozzaadhato)
                {
                    bizonyítékok.Add((Bizonyíték)keresablak.feltoltendo);
                    kliens.NaplobaIras("Meglévő bizonyíték (" + (keresablak.feltoltendo as Bizonyíték).GetAzonosító + ") bűnesethez (" + id + ") rendelése.");
                    bunesetK.Hozzaadhato = false;
                }                
            }
        }

        private void UjGyan_Click(object sender, RoutedEventArgs e)
        {
            GyanusitottAblak gyanablak = new GyanusitottAblak(new Bűneset(id,leiras_txb.Text,felelősŐrnagy));
            if (gyanablak.ShowDialog() == true)
            {
                Gyanúsított újgyan = gyanablak.ÚjGyanúsítottVissza();
                bunesetK.ÚjGyanúsított(újgyan.GetStátusz(), újgyan.GetBejelentettLakcím(), újgyan.GetAzonosító(), újgyan.GetNév());
                bunesetK.GyanúsítottHozzáadása(újgyan, kivBűneset);
                gyanúsítottak.Add(gyanablak.ÚjGyanúsítottVissza());
                kliens.NaplobaIras("Új gyanúsított (" + gyanablak.ÚjGyanúsítottVissza().GetNév() + ") felvétele és bűnesethez (" + id + ") rendelése.");
            }
        }

        private void UjBiz_Click(object sender, RoutedEventArgs e)
        {
            BizonyitekWindow bizablak = new BizonyitekWindow();
            if(bizablak.ShowDialog()==true)
            {
                Bizonyíték újbiz = bizablak.ÚjBizonyítékVissza();
                bunesetK.BizonyítékHozzáadása(újbiz, kivBűneset);
                bizonyítékok.Add(bizablak.ÚjBizonyítékVissza());
                kliens.NaplobaIras("Új bizonyíték (" + bizablak.BizonyitekMegnevezesNaplozashoz() + ") felvétele és bűnesethez (" + id + ") rendelése.");
            }
        }

        public decimal BűnesetIDNaplózáshoz()
        {
            return id;
        }

    }
}
