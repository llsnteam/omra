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
            this.Title = d.GetNév();
            uzenetK = new Üzenetkezelő();
            feladatK = new Feladatkezelő();
            AdatokBetoltese();


            
        }

        private void FoablakTestreszabas()  // a bejelentkezett dolgozó rangjától függően alakítja ki a főablak kinézetét, hogy milyen funkciók érhetőek el neki
        {

        }

        private void AdatokBetoltese()  // controllok feltöltése az adott dolgozó adataival
        {
            this.ListboxÜzenetek.ItemsSource = uzenetK.ÜzenetMegtekintése(aktDolgozo);
            ListboxÜzenetek.SelectedIndex = 0;
            kivalasztottUzenet = (Üzenet)ListboxÜzenetek.SelectedItem;

            this.ListboxFeladatok.ItemsSource = feladatK.FeladatokLekérdezése(aktDolgozo);
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

        }

        private void UzenetTorles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UjFelh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UjBun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kimut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FelKio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BunMod_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
