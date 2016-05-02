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
    /// Interaction logic for UjFeladat.xaml
    /// </summary>
    public partial class UjFeladat : Window
    {
        DatabaseElements DE = new DatabaseElements();
        IFeladatkezelő feladatK = new Feladatkezelő();
        Dolgozó kivdolg;
        Bűneset kivbun;

        public UjFeladat()
        {
            InitializeComponent();
        }

        private void TisztKereses_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Dolgozó);
            if (keresablak.ShowDialog() == true)
            {
                kivdolg = (Dolgozó)keresablak.feltoltendo;
                if (kivdolg.GetBeosztás() == Rang.Tiszt)
                {
                    tiszt_cbx.Text = kivdolg.GetNév();
                }
                else
                {
                    MessageBox.Show("Ez a felhasználó nem rendelkezik a szükséges beosztással!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    kivdolg = null;
                }
            }
        }

        private void FeladatKereses_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Bűneset);
            if (keresablak.ShowDialog() == true)
            {
                kivbun = (Bűneset)keresablak.feltoltendo;
                feladat_cbx.Text = kivbun.GetAzonosító.ToString() + " : " +  kivbun.GetLeiras.Substring(0, kivbun.GetLeiras.Length > 20 ? 20 : kivbun.GetLeiras.Length);
            }
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            feladatK.FeladatMentés(kivdolg, kivbun);
            this.DialogResult = true;
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string FeladatNévIDNaplózáshoz()
        {
            return kivdolg.GetNév() + ";" + kivbun.GetAzonosító;
        }

    }
}
