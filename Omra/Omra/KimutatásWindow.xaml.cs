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

    public partial class KimutatásWindow : Window
    {
        IKimutatáskezelő kezelo;

        public KimutatásWindow()
        {
            InitializeComponent();
            cmb_kimutatasTipus.ItemsSource = Enum.GetValues(typeof(IKimutatáskezelő.KimutatásTípus));
            cmb_kimutatasTipus.SelectedIndex = 0;
            date_tol.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            date_ig.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            kezelo = new Kimutatás((DateTime)date_tol.SelectedDate,(DateTime)date_ig.SelectedDate);
        }

        private void click_kimutatas_keszites(object sender, RoutedEventArgs e)
        {
            switch (cmb_kimutatasTipus.SelectedIndex)
            {
                case 0: kezelo.ÚjKimutatás(0); break;
                case 1: kezelo.ÚjKimutatás(1); break;
                case 2: kezelo.ÚjKimutatás(2); break;
                case 3: kezelo.ÚjKimutatás(3); break;
            }
        }
    }
}
