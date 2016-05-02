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
    /// Interaction logic for BizonyitekWindow.xaml
    /// </summary>
    public partial class BizonyitekWindow : Window
    {
        IBizonyítékkezelő bKezelő;
        public Bizonyíték AktBizonyitek { get; set; }

        public BizonyitekWindow() // új jön létre
        {
            InitializeComponent();
            Feltoltes("", DateTime.Now);
        }

        public BizonyitekWindow(Bizonyíték bizonyitek) //módosítás
        {
            InitializeComponent();
            AktBizonyitek = bizonyitek;
            Feltoltes(bizonyitek.GetMegnevezés(), bizonyitek.Felvetel());
        }

        private void Feltoltes(string megnevezes, DateTime felvetel)
        {
            megnevezes_txb.Text = megnevezes;
            datepicker.SelectedDate = felvetel;
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            bKezelő = new Bűnesetkezelő();
            bKezelő.ÚjBizonyíték(megnevezes_txb.Text, AktBizonyitek.GetAzonosító);
            this.DialogResult = true;
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string BizonyitekMegnevezesNaplozashoz()
        {
            return AktBizonyitek.GetMegnevezés();
        }
    }
}
