using System;
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
using System.Windows.Shapes;
using Adatkezelő;

namespace Omra
{
    /// <summary>
    /// Interaction logic for FoAblak.xaml
    /// </summary>
    
    public partial class FoAblak : Window
    {
        Dolgozó aktDolgozo;
        IÜzenetkezelő uzenetK;
        Üzenet kivalasztottUzenet;
        IFeladatkezelő feladatK;
        Feladat kivalasztottFeladat;
        
        public FoAblak(Dolgozó d)
        {
            InitializeComponent();
            //Induláskor: (ezeket lehet akár külön szálon is)
            //Feltölti a listboxgombokat a felhasználónak megengedett funkciók gombjaival (pl. a listbox.childrenbe beleteszel egy újüzenet gombot, aminek a click eseménye kap egy lambda kifejezést, ami megnyitja az üzenet írása ablakot
            //Lekérdezi a felhasználóhoz kapcsolódó feladatokat és üzeneteket, ezeket megjeleníti a listboxaikban
            //A listbox alatt kijelzi a kiválasztott üzenet/feladat adatait
            
            aktDolgozo = d;
            this.Title = d.ToString();
            uzenetK = new Üzenetkezelő();
            feladatK = new Feladatkezelő();
            AdatokBetoltese();

            FoablakTestreszabas();
            
        }

        private void FoablakTestreszabas()  // a bejelentkezett dolgozó rangjától függően alakítja ki a főablak kinézetét, hogy milyen funkciók érhetőek el neki
        {
            Rang r = aktDolgozo.GetBeosztás();
            Visibility hidden = Visibility.Hidden;

            if(r==Rang.Adminisztrátor||r==Rang.Kapitány)
            {
                gr_feladat.Visibility = hidden;
            }
            if (r == Rang.Kapitány || r == Rang.Ornagy || r == Rang.Tiszt) // ha nem admin lép be
            {
                admin_ujfelh.Visibility = hidden;
            }
            if (r == Rang.Adminisztrátor || r == Rang.Ornagy || r == Rang.Tiszt) // ha nem kapitány lép be
            {
                kap_kimut.Visibility = hidden;
                kap_ujbun.Visibility = hidden;
            }
            if (r == Rang.Adminisztrátor || r == Rang.Kapitány || r == Rang.Tiszt) // ha nem őrnagy lép be
            {
                orn_bunmod.Visibility = hidden;
                orn_felkio.Visibility = hidden;
            }
            if(r == Rang.Adminisztrátor||r == Rang.Kapitány || r == Rang.Ornagy) // ha nem tiszt lép be
            {
                tiszt_bunmod.Visibility = hidden;
            }
        }

        private void AdatokBetoltese()  // controllok feltöltése az adott dolgozó adataival
        {
            ListboxÜzenetek.ItemsSource = uzenetK.ÜzenetMegtekintése(aktDolgozo);
            ListboxÜzenetek.SelectedIndex = 0;
            kivalasztottUzenet = (Üzenet)ListboxÜzenetek.SelectedItem;

            ListboxFeladatok.ItemsSource = feladatK.FeladatokLekérdezése(aktDolgozo);
            ListboxFeladatok.SelectedIndex = 0;
            kivalasztottFeladat = (Feladat)ListboxFeladatok.SelectedItem;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            App.Current.MainWindow = mw;
            mw.Show();
            this.Close();
        }

        private void UjUzenet_Click(object sender, RoutedEventArgs e)
        {
            UjUzenet ujuzenetablak = new UjUzenet();
            if(ujuzenetablak.ShowDialog()==true)
            {
                uzenetK.ÜzenetKüldése(ujuzenetablak.Tartalom, ujuzenetablak.Targy, aktDolgozo, ujuzenetablak.Cimzett);
            }
        }

        private void UzenetTorles_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottUzenet = (Üzenet)ListboxÜzenetek.SelectedItem;
            uzenetK.ÜzenetTörlése(kivalasztottUzenet);
        }

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak();
            keresablak.ShowDialog();
        }

        private void UjFelh_Click(object sender, RoutedEventArgs e)
        {
            DolgozoAblak dolgozoablak = new DolgozoAblak();
            dolgozoablak.ShowDialog();
        }

        private void UjBun_Click(object sender, RoutedEventArgs e)
        {
            BunesetAblak bunablak = new BunesetAblak(false);
            bunablak.ShowDialog();
        }

        private void Kimut_Click(object sender, RoutedEventArgs e)
        {
            KimutatásWindow kimutablak = new KimutatásWindow();
            kimutablak.ShowDialog();
        }

        private void FelKio_Click(object sender, RoutedEventArgs e)
        {
            UjFeladat ujfeladatablak = new UjFeladat();
            ujfeladatablak.ShowDialog();
        }

        private void BunMod_Click(object sender, RoutedEventArgs e)
        {
            BunesetAblak bunablak = new BunesetAblak(true);
            bunablak.ShowDialog();
        }

        private void UzenetKival_Click(object sender, RoutedEventArgs e)
        {
            kitol_lbl.Content = (ListboxÜzenetek.SelectedItem as Üzenet).GetKüldő.ToString();
            targy_lbl.Content = (ListboxÜzenetek.SelectedItem as Üzenet).GetTárgy;
            szoveg_txb.Text = (ListboxÜzenetek.SelectedItem as Üzenet).GetTörzs;
        }

    }
}
