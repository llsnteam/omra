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
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace Omra
{
    /// <summary>
    /// Interaction logic for GyanusitottAblak.xaml
    /// </summary>
    public partial class GyanusitottAblak : Window
    {
        DatabaseElements DE = new DatabaseElements();
        IGyanúsítottkezelő gyKezelo = new Bűnesetkezelő();
        decimal id = 0;
        Bűneset bűneset;
        BitmapSource keplink;

        public GyanusitottAblak(Bűneset buneset)
        {
            InitializeComponent();

            bűneset = buneset;

            var gyanID = from x in DE.Gyanusitottak
                         where x.gyanusitottID == DE.Gyanusitottak.Max(y => y.gyanusitottID)
                         select x.gyanusitottID;
            id = gyanID.First() + 1;
            
            Feltoltes("", "", GyanúsítottStátusz.Szabad);
        }

        public GyanusitottAblak(Bűneset buneset, Gyanúsított gyanusitott) //módosításhoz
        {
            InitializeComponent();
            if (buneset == null)
            {
                var bunID = from x in DE.FelvettGyanusitottak // gyanúsítotthoz tartozó bűneset
                            where x.gyanusitottID == id
                            select x.bunesetID;
                decimal bunesID = bunID.First();

                var bun = from x in DE.Bunesetek  // bűneset kivlasztása
                          where x.bunesetID == bunesID
                          select x;
                Bunesetek kivbuneset = bun.First();

                var felornagy = from x in DE.Dolgozok  // bűnesethez tartozó felelős őrnagy kiválasztása
                                where x.dolgozoID == kivbuneset.felelos_ornagy
                                select x;
                Dolgozok felelősőrnagy = felornagy.First();

                bűneset = new Bűneset(kivbuneset.bunesetID,kivbuneset.leiras,new Dolgozó((Rang)Enum.Parse(typeof(Rang),felelősőrnagy.rang),felelősőrnagy.jelszo,felelősőrnagy.nev,felelősőrnagy.lakcim,felelősőrnagy.dolgozoID));
            }
            else
                bűneset = buneset;
            id = gyanusitott.GetAzonosító();
            Feltoltes(gyanusitott.GetNév(), gyanusitott.GetBejelentettLakcím(), gyanusitott.GetStátusz());
        }

        private void Feltoltes(string nev, string lakcim, GyanúsítottStátusz statusz)
        {
            if (id <= 6) // csak azért kell, mert egyelőre csak 6-os az utolsó elnevezésű kép és hogy ne essen szét a program
                keplink = BitmapFrame.Create(new Uri("../../kepek/" + id + ".jpg", UriKind.Relative));
            kep_img.Source = keplink;
            statusz_cbx.ItemsSource = Enum.GetValues(typeof(GyanúsítottStátusz));
            nev_txt.Text = nev;
            lakcim_txt.Text = lakcim;
            statusz_cbx.SelectedItem = statusz;
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            gyKezelo.ÚjGyanúsított((GyanúsítottStátusz)Enum.Parse(typeof(GyanúsítottStátusz), statusz_cbx.SelectedItem.ToString()), lakcim_txt.Text, id, nev_txt.Text);
            this.DialogResult = true;
        }

        public Gyanúsított ÚjGyanúsítottVissza() // a bűneset ablakban így kapható vissza az új gyanúsított
        {
            return new Gyanúsított((GyanúsítottStátusz)statusz_cbx.SelectedItem, nev_txt.Text, lakcim_txt.Text, id);
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>

        string filepath;

        private void btnLoad_Click(object sender, RoutedEventArgs e) //ez feltölti a képet az openfiledialogból kiválasztott képpel
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName;
                ImageSource imgsource = new BitmapImage(new Uri(filepath));
                kep_img.Source = imgsource;
            }
        }

        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) //a kiválasztott képet elmenti
        {
            string name = System.IO.Path.GetFileName(filepath);
            string destinationPath = GetDestinationPath("7.jpg", "kepek");

            File.Copy(filepath, destinationPath, true);
        }
    }
}
