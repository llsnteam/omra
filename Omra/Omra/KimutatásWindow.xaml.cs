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
    /// Interaction logic for KimutatásWindow.xaml
    /// </summary>
    /// 
    public enum KimutatasTipus { Bűneset, Gyanusított, Bizonyíték };
    public partial class KimutatásWindow : Window
    {
        IKimutatáskezelő kezelo;
        List<StatAdat> adatok;

        public KimutatásWindow()
        {
            InitializeComponent();

            adatok = new List<StatAdat>();

            cmb_kimutatasTipus.ItemsSource = Enum.GetValues(typeof(KimutatasTipus));
            cmb_kimutatasTipus.SelectedIndex = 0;
            date_tol.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            date_ig.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        }

        private void click_kimutatas_keszites(object sender, RoutedEventArgs e)
        {
            //IKimutatáskezelő kimutatáskezelő = new Kimutatás();

            //Új kimutatás rajzolása előtt, a canvas törlése
            this.grafikon.Children.Clear();

            //Annak ellenőrzése, hogy lett-e választva dátum, illetve, hogy az intervallum eleje kisebb-e, mint a vége. A kimutatás típusa nem lehet null a comboboxból adódóan. 
            if (date_tol.SelectedDate != null && date_ig.SelectedDate != null && (date_ig.SelectedDate >= date_tol.SelectedDate))
            {
                kezelo = new Kimutatáskészítő((DateTime)date_tol.SelectedDate, (DateTime)date_ig.SelectedDate);
                Keszites();
            }
            else
               MessageBox.Show("Válasszon megfelelő időintervallumot!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);         
        }

        private void Keszites()
        {
            //Különböző típusú kimutatások
            switch ((KimutatasTipus)cmb_kimutatasTipus.SelectedItem)
            {
                case KimutatasTipus.Bűneset:
                    (kezelo as Kimutatáskészítő).BűnesetKimutatás();
                    break;
                case KimutatasTipus.Gyanusított:
                    (kezelo as Kimutatáskészítő).GyanusítottKimutatás();
                    break;
                case KimutatasTipus.Bizonyíték:
                    (kezelo as Kimutatáskészítő).BizonyítékKimutatás();
                    break;
                default:
                    break;
            }

            this.adatok = (kezelo as Kimutatáskészítő).GetAdatok();

            Rajzol();
        }

        private void Rajzol()
        {
            Tengelyek();
            Oszlopok();
        }

        private void Oszlopok()
        {
            //Az összes találat száma, később kell az oszlopok arányos szélességéhez
            int osszes = adatok.Count();
            
            //Arányok meghatározása
            double egyOszlopSzelessege = this.grafikon.ActualWidth / osszes;
            double egysegnyiMagassag = this.grafikon.ActualHeight / adatok.Sum(x => x.Darab);

            //Segéd változók
            double elozoOszlopSzele = 0;

            //Oszlopok rajzolása
            List<Rect> oszlopok = new List<Rect>();
            int seged = 0;
            foreach (var akt in adatok)
            {
                oszlopok.Add(new Rect(elozoOszlopSzele,0,egyOszlopSzelessege,egysegnyiMagassag*akt.Darab));
                Rectangle oszlop = new Rectangle();
                oszlop.SetValue(Canvas.LeftProperty, oszlopok.ElementAt(seged).X);
                oszlop.SetValue(Canvas.BottomProperty, oszlopok.ElementAt(seged).Y);
                oszlop.SetValue(Rectangle.WidthProperty, oszlopok.ElementAt(seged).Width);
                oszlop.SetValue(Rectangle.HeightProperty, oszlopok.ElementAt(seged).Height);
                oszlop.Fill = new SolidColorBrush(Color.FromRgb(22,181,229));
                oszlop.Stroke = Brushes.Black;

                elozoOszlopSzele += egyOszlopSzelessege;

                this.grafikon.Children.Add(oszlop);

                //Csoportnevek kiírása
                Label csoportnev = new Label();
                csoportnev.Content = akt.Csoport;
                csoportnev.SetValue(Canvas.LeftProperty, (seged * egyOszlopSzelessege));
                csoportnev.SetValue(Canvas.BottomProperty, oszlopok.ElementAt(seged).Y);
                this.grafikon.Children.Add(csoportnev);


                //Darabszámok kiírása
                Line vonal = new Line();
                vonal.Stroke = System.Windows.Media.Brushes.Black;
                vonal.X1 = 0;
                vonal.X2 = 5;
                vonal.Y1 = this.grafikon.Height - oszlopok.ElementAt(seged).Height;
                vonal.Y2 = vonal.Y1;
                this.grafikon.Children.Add(vonal);

                Label mennyiseg = new Label();
                mennyiseg.Content = akt.Darab;
                mennyiseg.SetValue(Canvas.LeftProperty, oszlopok.ElementAt(0).X);
                if(osszes  > 1 )
                    mennyiseg.SetValue(Canvas.BottomProperty, oszlopok.ElementAt(seged).Y + oszlopok.ElementAt(seged).Height);
                else
                    mennyiseg.SetValue(Canvas.BottomProperty, oszlopok.ElementAt(seged).Y + oszlopok.ElementAt(seged).Height - 20);
                this.grafikon.Children.Add(mennyiseg);

                seged++;
            }
        }

        private void Tengelyek()
        {
            //x tengely
            Line xTengely = new Line();
            xTengely.Stroke = System.Windows.Media.Brushes.Black;
            xTengely.X1 = 0;
            xTengely.X2 = this.grafikon.ActualWidth;
            xTengely.Y1 = this.grafikon.ActualHeight;
            xTengely.Y2 = xTengely.Y1;
            this.grafikon.Children.Add(xTengely);

            //y tengely
            Line yTengely = new Line();
            yTengely.Stroke = System.Windows.Media.Brushes.Black;
            yTengely.X1 = 0;
            yTengely.X2 = yTengely.X1;
            yTengely.Y1 = 0;
            yTengely.Y2 = this.grafikon.ActualHeight;
            this.grafikon.Children.Add(yTengely);
        }
    }
}
