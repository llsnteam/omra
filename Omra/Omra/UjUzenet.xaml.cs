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
    /// Interaction logic for UjUzenet.xaml
    /// </summary>
    public partial class UjUzenet : Window
    {
        private Dolgozó cimzett;
        private string targy;
        private string tartalom;

        public Dolgozó Cimzett { get { return cimzett; } }
        public string Targy { get { return targy; } }
        public string Tartalom { get { return tartalom; } }

        public UjUzenet()
        {
            InitializeComponent();
        }

        private void UjUzenet_Click(object sender, RoutedEventArgs e)
        {
            if (cimzett != null)
            {
                targy = targy_txb.Text;
                tartalom = tartalom_txb.Text;
                this.DialogResult = true;
            }
        }

        private void CimzettKeres_Click(object sender, RoutedEventArgs e)
        {
            KeresesAblak keresablak = new KeresesAblak(KeresésTípus.Dolgozó);
            if (keresablak.ShowDialog() == true)
            {
                cimzett = (Dolgozó)keresablak.feltoltendo;
                cimzett_txb.Text = cimzett.GetNév();
            }
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
