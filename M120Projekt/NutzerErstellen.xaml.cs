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
    /// Interaktionslogik für NutzerErstellen.xaml
    /// </summary>
    public partial class NutzerErstellen : UserControl
    {
        private ScrollViewer placeholder;
        public NutzerErstellen(ScrollViewer placeholder)
        {
            InitializeComponent();
            this.placeholder = placeholder;

        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {   
            MessageBoxResult messageBox = System.Windows.MessageBox.Show("Wollen sie diesen Nutzer erfassen ?", "Erfassen?", System.Windows.MessageBoxButton.OKCancel);
            if(messageBox == MessageBoxResult.OK)
            {
                NutzerErstellenLeer nutzerErfasst = new NutzerErstellenLeer(placeholder);
                placeholder.Content = nutzerErfasst;
                MessageBox.Show("Der Nutzer wurde erfasst");
            }
            
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxAbbrechen = System.Windows.MessageBox.Show("Wollen Sie wirklich abbrechen?", "Abbrechen?", System.Windows.MessageBoxButton.YesNo);
            if(messageBoxAbbrechen == MessageBoxResult.Yes)
            {
                NutzerErstellenLeer nutzerErfasstAbbrechen = new NutzerErstellenLeer(placeholder);
                placeholder.Content = nutzerErfasstAbbrechen;
                MessageBox.Show("Vorgangn abgebrochen");
            }

        }
    }
}
