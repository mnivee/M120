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
    /// Interaktionslogik für NutzerErstellenLeer.xaml
    /// </summary>
    public partial class NutzerErstellenLeer : UserControl
    {
        private ScrollViewer placeholder;

        public NutzerErstellenLeer(ScrollViewer placeholder)
        {
            InitializeComponent();
            this.placeholder = placeholder;
            showNutzer();

        }

        private void NutzerErfassen(object sender, RoutedEventArgs e)
        {
            NutzerErstellen formulareintrag = new NutzerErstellen(placeholder, "new");
            placeholder.Content = formulareintrag;

            formulareintrag.Delete.IsEnabled = false;
            formulareintrag.Save.IsEnabled = false;
        }

        private void showNutzer()
        {
            dgNutzer.ItemsSource = Data.Bibliothek.LesenAlle();
        }

        private void DgNutzer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DgNutzer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgNutzer.SelectedItem != null)
            {
                Data.Bibliothek currentElement = (Data.Bibliothek)dgNutzer.SelectedItem;
                Int32 currentId = Convert.ToInt32(currentElement.BibliothekID);

                NutzerErstellen formulareintrag = new NutzerErstellen(placeholder, "edit", currentId);
                placeholder.Content = formulareintrag;
            }
        }

    }

}



