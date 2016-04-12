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
    enum KimutatasTipus { Bűneset, Gyanusított };   // lehet még további 

    public partial class KimutatásWindow : Window
    {
        KimutatasTipus kt;
        IKimutatáskezelő kezelo;

        public KimutatásWindow()
        {
            InitializeComponent();
            cmb_kimutatasTipus.ItemsSource = Enum.GetValues(typeof(KimutatasTipus));
            cmb_kimutatasTipus.SelectedIndex = 0;
        }

        private void click_kimutatas_keszites(object sender, RoutedEventArgs e)
        {
            switch (cmb_kimutatasTipus.SelectedIndex)
            {
                case 0: kezelo.ÚjKimutatás(date_tol, date_ig);
            }
        }
    }
}
