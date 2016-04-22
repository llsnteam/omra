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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Omra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseEntities DE = new DatabaseEntities();//
        public MainWindow()
        {
            InitializeComponent();
            //A megadott felhasználónévvel és jelszóval az adatbázisból lekérdezi, hogy van-e ilyen dolgozó, ha van megnyitja a főablakot, ha nincs messagebox, majd a kód legvégén bezárja ezt az ablakot 
        }
    }
}
