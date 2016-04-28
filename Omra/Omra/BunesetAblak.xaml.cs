using System;
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

        public BunesetAblak() // új létrehozása
        {
            InitializeComponent();
            id = bunesetK.AzonosítóGenerálás(null);
            gyanúsítottak = new ObservableCollection<Gyanúsított>();
            bizonyítékok = new ObservableCollection<Bizonyíték>();
            Feltoltes(new Dolgozó(Rang.Ornagy, "", "", "", 0), "", gyanúsítottak, bizonyítékok);
        }

        public BunesetAblak(Bűneset buneset) //módosítással meghívás
        {
            InitializeComponent();
            mod = true;
            kivBűneset = buneset;
            id = kivBűneset.GetAzonosító;
            gyanúsítottak = bunesetK.GyanúsítottakKigyűjtése(buneset);
            bizonyítékok = bunesetK.BizonyítékokKigyűjtése(buneset);
            Feltoltes(buneset.GetFelelős, buneset.GetLeiras, gyanúsítottak, bizonyítékok);
        }

        private void Feltoltes(Dolgozó felelosOrnagy, string leírás, ObservableCollection<Gyanúsított> gyan, ObservableCollection<Bizonyíték> biz)
        {
            felorn_txb.Text = felelosOrnagy.GetNév();
            leiras_txb.Text = leírás;
            ListboxGyanúsítottak.ItemsSource = gyan;
            ListboxBizonyítékok.ItemsSource = biz;
        }

        private void FelelosOrnagyKereses_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Dolgozó);
            if (keresablak.ShowDialog() == true)
            {
                felelősŐrnagy = (Dolgozó)keresablak.feltoltendo;
                if (felelősŐrnagy.GetBeosztás() == Rang.Ornagy)
                    felorn_txb.Text = felelősŐrnagy.GetNév();
                else
                {
                    MessageBox.Show("Ez a felhasználó nem rendelkezik a szükséges beosztással!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    felelősŐrnagy = null;
                }
            }
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            if(felelősŐrnagy!=null)
            {
                if (mod)
                {
                    var modositott = DE.Bunesetek.Single(x => x.bunesetID == id);
                    modositott.allapot = BÁllapot.Folyamatban.ToString();
                    modositott.felelos_ornagy = felelősŐrnagy.GetAzonosító();
                    modositott.felvetel = kivBűneset.GetFelvetel;
                    modositott.leiras = leiras_txb.Text;
                    modositott.lezaras = null;
                }
                else
                {
                    var ujbun = new Bunesetek()
                    {
                        bunesetID = id,
                        allapot = BÁllapot.Folyamatban.ToString(),
                        felelos_ornagy = felelősŐrnagy.GetAzonosító(),
                        felvetel = DateTime.Now,
                        leiras = leiras_txb.Text,
                        lezaras = null
                    };
                    DE.Bunesetek.Add(ujbun);
                }
                DE.SaveChanges();
                this.DialogResult = true;
            }
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
                gyanúsítottak.Add((Gyanúsított)keresablak.feltoltendo);
                ListboxGyanúsítottak.ItemsSource = gyanúsítottak;
            }
        }

        private void BizonyitekFelvetel_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Bizonyíték);
            if (keresablak.ShowDialog() == true)
            {
                bizonyítékok.Add((Bizonyíték)keresablak.feltoltendo);

                ListboxBizonyítékok.ItemsSource = bizonyítékok;
            }
        }

        private void UjGyan_Click(object sender, RoutedEventArgs e)
        {
            GyanusitottAblak gyanablak = new GyanusitottAblak();
            gyanablak.ShowDialog();
        }

        private void UjBiz_Click(object sender, RoutedEventArgs e)
        {
            BizonyitekWindow bizablak = new BizonyitekWindow();
            bizablak.ShowDialog();
        }

    }
}
