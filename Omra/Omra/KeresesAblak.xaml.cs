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

        KeresésTípus tipus;

        public KeresesAblak() 
        {
            InitializeComponent();
        }

        public KeresesAblak(KeresésTípus tipus) //specifikus keresés (pl. bűnesetnél gyanúsított hozzáadása -> nem engedjük, csak a gyanúsítottak listázását)
        {
            InitializeComponent();

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IKereséskezelő kezelo = new Kereséskezelő();

            if (RadioBizonyitek.IsChecked == true)
            {
                //típus alapján, vagy ID alapján

                List<Bizonyíték> eredmeny = kezelo.Bizonyítékkeresés(Azon.Text);

                ListboxEredmeny.ItemsSource = null;
                ListboxEredmeny.ItemsSource = eredmeny; 
            }

            else if (RadioBuneset.IsChecked == true)
            {
                //ID alapján - lehetne máshogy is ?

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

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ListboxEredmeny.SelectedItem != null)
            {
                if (RadioBizonyitek.IsChecked == true)
                {
                    //típus alapján, vagy ID alapján

                    feltoltendo = (Bizonyíték)ListboxEredmeny.SelectedItem;
                }

                else if (RadioBuneset.IsChecked == true)
                {
                    //ID alapján - lehetne máshogy is ?
                    feltoltendo = (Bűneset)ListboxEredmeny.SelectedItem;
                }


                else if (RadioDolgozo.IsChecked == true)
                {
                    feltoltendo = (Dolgozó)ListboxEredmeny.SelectedItem;
                }

                else if (RadioGyanusitott.IsChecked == true)
                {
                    feltoltendo = (Gyanúsított)ListboxEredmeny.SelectedItem;
                }

                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
