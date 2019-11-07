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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für NutzerErfassenDatenGrid.xaml
    /// </summary>
    public partial class NutzerErfassenDatenGrid : UserControl
    {
        private ScrollViewer placeholder;
        public NutzerErfassenDatenGrid(ScrollViewer placeholder)
        {
            InitializeComponent();
            this.placeholder = placeholder;
        }

        private void DgNutzer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgNutzer.SelectedItem != null)
            {
                Data.Bibliothek currentElement = (Data.Bibliothek)dgNutzer.SelectedItem;
            }
        }

        private void showNutzer()
        {
            dgNutzer.ItemsSource = Data.Bibliothek.LesenAlle();
        }

        private void DgNutzer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

    }
}
