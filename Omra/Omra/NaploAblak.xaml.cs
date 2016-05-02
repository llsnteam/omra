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

namespace Omra
{
    /// <summary>
    /// Interaction logic for NaploAblak.xaml
    /// </summary>
    public partial class NaploAblak : Window
    {
        private NaplozoNamespace.Service1Client kliens = new NaplozoNamespace.Service1Client();

        public NaploAblak()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DatumDatePicker.SelectedDate != null)
                    TextboxEredmeny.Text = kliens.GetNaplo((DateTime)DatumDatePicker.SelectedDate);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Nem található erre a napra log!");
            }
        }

        private void TextboxEredmeny_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
