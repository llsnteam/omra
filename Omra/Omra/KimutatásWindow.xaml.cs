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
        Kimutatáskészítő k;

        public KimutatásWindow()
        {
            InitializeComponent();
            cmb_kimutatasTipus.ItemsSource = Enum.GetValues(typeof(KimutatasTipus));
            cmb_kimutatasTipus.SelectedIndex = 0;
            date_tol.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            date_ig.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        }

        private void click_kimutatas_keszites(object sender, RoutedEventArgs e)
        {
            this.grafikon.Children.Clear();
            if (date_tol.SelectedDate != null && date_ig.SelectedDate != null)
            {
                k = new Kimutatáskészítő((DateTime)date_tol.SelectedDate, (DateTime)date_ig.SelectedDate, (KimutatasTipus)cmb_kimutatasTipus.SelectedItem);
            }
            else
                MessageBox.Show("Válasszon időintervallumot!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

            Rajzol();
        }

        private void Rajzol()
        {
            Tengelyek();
            Oszlopok();
        }

        private void Oszlopok()
        {
        }

        private void Tengelyek()
        {
            //x tengely
            Line xTengely = new Line();
            xTengely.Stroke = System.Windows.Media.Brushes.Black;
            xTengely.X1 = 20;
            xTengely.X2 = this.grafikon.ActualWidth-20;
            xTengely.Y1 = this.grafikon.ActualHeight-20;
            xTengely.Y2 = xTengely.Y1;
            this.grafikon.Children.Add(xTengely);

            //y tengely
            Line yTengely = new Line();
            yTengely.Stroke = System.Windows.Media.Brushes.Black;
            yTengely.X1 = 20;
            yTengely.X2 = yTengely.X1;
            yTengely.Y1 = 20;
            yTengely.Y2 = this.grafikon.ActualHeight - 20;
            this.grafikon.Children.Add(yTengely);
        }
    }
}
