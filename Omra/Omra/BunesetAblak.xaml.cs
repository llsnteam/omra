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
    /// Interaction logic for BunesetAblak.xaml
    /// </summary>
    public partial class BunesetAblak : Window
    {
        public BunesetAblak(bool mod) // módosítási szándékkal lett-e meghívva, vagy új bűnesetet kell létrehozni
        {
            InitializeComponent();
        }

        public BunesetAblak(bool mod, Bűneset buneset) //módosítási szándákkal
        {
            InitializeComponent();
        }
    }
}
