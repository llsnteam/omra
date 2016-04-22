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
    public enum KimutatasTipus { Bűneset, Gyanusított};
    public partial class KimutatásWindow : Window
    {
        Kimutatás k;

        public KimutatásWindow()
        {
            InitializeComponent();
            cmb_kimutatasTipus.ItemsSource = Enum.GetValues(typeof(KimutatasTipus));
            cmb_kimutatasTipus.SelectedIndex = 0;
            date_tol.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            date_ig.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            k = new Kimutatás((DateTime)date_tol.SelectedDate,(DateTime)date_ig.SelectedDate);
        }

        private void click_kimutatas_keszites(object sender, RoutedEventArgs e)
        {

        }
    }
}
