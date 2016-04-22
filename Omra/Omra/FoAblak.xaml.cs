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
    /// Interaction logic for FoAblak.xaml
    /// </summary>
    
    public partial class FoAblak : Window
    {
        public FoAblak(Dolgozó d)
        {
            InitializeComponent();
            //Induláskor: (ezeket lehet akár külön szálon is)
            //Feltölti a listboxgombokat a felhasználónak megengedett funkciók gombjaival (pl. a listbox.childrenbe beleteszel egy újüzenet gombot, aminek a click eseménye kap egy lambda kifejezést, ami megnyitja az üzenet írása ablakot
            //Lekérdezi a felhasználóhoz kapcsolódó feladatokat és üzeneteket, ezeket megjeleníti a listboxaikban
            //A listbox alatt kijelzi a kiválasztott üzenet/feladat adatait
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
