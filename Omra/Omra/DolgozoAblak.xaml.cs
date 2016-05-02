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
    /// Interaction logic for DolgozoAblak.xaml
    /// </summary>
    public partial class DolgozoAblak : Window
    {
        private decimal id; // ezt a program számolja ki, nem a felhasználó adja meg
        private bool mod; // azt jelzi, hogy módosítás céljából lett megnyitva az ablak, vagy új dolgozó felvételéhez
        DatabaseElements DE = new DatabaseElements();
        public DolgozoAblak()  // ez a konstruktor új dolgozó felvételéhez van
        {
            InitializeComponent();
            mod = false;
            var utolso_id = from x in DE.Dolgozok
                            where x.dolgozoID == DE.Dolgozok.Max(y=>y.dolgozoID)
                            select x.dolgozoID;

            if (utolso_id.Count() != 0)
                id = utolso_id.First() + 1;

            Feltoltes("", "", Rang.Adminisztrátor, "");
        }
        public DolgozoAblak(Dolgozó kivDolgozó)  // ez a konstruktor a módosításhoz van, kiválasztott dolgozót kapja bemenetnek
        {
            InitializeComponent();
            mod = true;
            id = kivDolgozó.GetAzonosító();
            Feltoltes(kivDolgozó.GetNév(), kivDolgozó.GetJelszó(), kivDolgozó.GetBeosztás(), kivDolgozó.GetBejelentettLakcím());
        }

        private void Feltoltes(string nev, string jelszo, Rang rang, string lakcim) // bemeneti paraméterek alapján feltölti a mezőket az ablakban
        {
            rang_cbx.ItemsSource = Enum.GetValues(typeof(Rang));
            nev_txb.Text = nev;
            jelszo_txb.Text = jelszo;
            rang_cbx.SelectedItem = rang;
            lakcim_txb.Text = lakcim;
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            if(mod)
            {
                var modositott = DE.Dolgozok.Single(x => x.dolgozoID == id);
                modositott.nev = nev_txb.Text;
                modositott.jelszo = jelszo_txb.Text;
                modositott.rang = rang_cbx.SelectedItem.ToString();
                modositott.lakcim = lakcim_txb.Text;
            }
            else
            {
                var ujdolg = new Dolgozok()
                {
                    dolgozoID = id,
                    nev = nev_txb.Text,
                    jelszo = jelszo_txb.Text,
                    rang = rang_cbx.SelectedItem.ToString(),
                    lakcim = lakcim_txb.Text
                };
                DE.Dolgozok.Add(ujdolg);
            }
            DE.SaveChanges();
            this.DialogResult = true;
        }

        public string DologozóNévNaplózáshoz()
        {
            return nev_txb.Text;
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
