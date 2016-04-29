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

namespace Omra
{
    /// <summary>
    /// Interaction logic for KeresesAblak.xaml
    /// </summary>
    public partial class KeresesAblak : Window
    {
        public object feltoltendo;

        public bool altalanos = true;

        public KeresesAblak() 
        {
            InitializeComponent();
        }

        public KeresesAblak(KeresésTípus tipus) //specifikus keresés (pl. bűnesetnél gyanúsított hozzáadása -> nem engedjük, csak a gyanúsítottak listázását)
        {
            InitializeComponent();
            Azon.Focus(); // hogy egyből lehessen írni azonosítót, ha a radiobutton-ök miatt úgysem vesztené el a focust az ablak a textboxról

            if (tipus == KeresésTípus.Bizonyíték)
            {
                RadioBizonyitek.IsChecked = true;
            }

            if (tipus == KeresésTípus.Bűneset)
            {
                RadioBuneset.IsChecked = true;
            }

            if (tipus == KeresésTípus.Dolgozó)
            {
                RadioDolgozo.IsChecked = true;
            }

            if (tipus == KeresésTípus.Gyanúsított)
            {
                RadioGyanusitott.IsChecked = true;
            }

            RadioBizonyitek.IsEnabled = false;
            RadioBuneset.IsEnabled = false;
            RadioDolgozo.IsEnabled = false;
            RadioGyanusitott.IsEnabled = false;

            altalanos = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Keresés indítása: kereséskezelőtől kikéri a keresett listát, betölti a listboxba
        {
            IKereséskezelő kezelo = new Kereséskezelő();

            if (RadioBizonyitek.IsChecked == true) 
            {
                List<Bizonyíték> eredmeny = kezelo.Bizonyítékkeresés(Azon.Text);

                ListboxEredmeny.ItemsSource = null;
                ListboxEredmeny.ItemsSource = eredmeny; 
            }

            else if (RadioBuneset.IsChecked == true)
            {

                List<Bűneset> eredmeny = kezelo.Bűnesetkeresés(Azon.Text);

                ListboxEredmeny.ItemsSource = null;
                ListboxEredmeny.ItemsSource = eredmeny; 
            }


            else if (RadioDolgozo.IsChecked == true)
            {
                List<Dolgozó> eredmeny = kezelo.Dolgozókeresés(Azon.Text);

                ListboxEredmeny.ItemsSource = null;
                ListboxEredmeny.ItemsSource = eredmeny;
            }

            else if (RadioGyanusitott.IsChecked == true)
            {
                List<Gyanúsított> eredmeny = kezelo.Gyanúsítottkeresés(Azon.Text);

                ListboxEredmeny.ItemsSource = null;
                ListboxEredmeny.ItemsSource = eredmeny;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //bezárja az ablakot, mintha nem történt volna semmi
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //a feltöltendő publikus változóba (amit majd kiolvas a hívó ablak) értéket tesz, a kereséstől függően Dolgozó, bűneset stb.
        {
            if (ListboxEredmeny.SelectedItem != null)
            {
                if (!altalanos)
                {

                    if (RadioBizonyitek.IsChecked == true) //ha bizonyíték
                    {
                        feltoltendo = (Bizonyíték)ListboxEredmeny.SelectedItem;
                    }

                    else if (RadioBuneset.IsChecked == true) //ha bűneset
                    {

                        feltoltendo = (Bűneset)ListboxEredmeny.SelectedItem;
                    }

                    else if (RadioDolgozo.IsChecked == true) //ha dolgozó
                    {
                        feltoltendo = (Dolgozó)ListboxEredmeny.SelectedItem;
                    }

                    else if (RadioGyanusitott.IsChecked == true) //ha gyanusított
                    {
                        feltoltendo = (Gyanúsított)ListboxEredmeny.SelectedItem;
                    }

                    this.DialogResult = true;
                    this.Close();
                }
                else //kiválasztott módosítása
                {
                    if (RadioBizonyitek.IsChecked == true) //ha bizonyíték
                    {
                        BizonyitekWindow bw = new BizonyitekWindow((Bizonyíték)ListboxEredmeny.SelectedItem);
                        bw.ShowDialog();
                    }

                    else if (RadioBuneset.IsChecked == true) //ha bűneset
                    {
                        BunesetAblak ba = new BunesetAblak((Bűneset)ListboxEredmeny.SelectedItem);
                        ba.ShowDialog();
                    }

                    else if (RadioDolgozo.IsChecked == true) //ha dolgozó
                    {
                        DolgozoAblak da = new DolgozoAblak((Dolgozó)ListboxEredmeny.SelectedItem);
                        da.ShowDialog();
                    }

                    else if (RadioGyanusitott.IsChecked == true) //ha gyanusított
                    {
                        GyanusitottAblak ga = new GyanusitottAblak(null,(Gyanúsított)ListboxEredmeny.SelectedItem);
                        ga.ShowDialog();
                    }

                    Button_Click(null, null);
                }
            }
        }
    }
}
