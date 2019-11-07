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
        private string status;
        private Int32 currentId;
        private Boolean isChanged = false;

        public NutzerErstellen(ScrollViewer placeholder, string status, Int32 id = 1)
        {
            InitializeComponent();
            this.placeholder = placeholder;
            this.status = status;
            currentId = id;

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

        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            Save.IsEnabled = true;
            isChanged = true;
        }

        private void DatePicker_SelectedDateChanged(object sender, TextChangedEventArgs args)
        {
            Save.IsEnabled = true;
            isChanged = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Save.IsEnabled = true;
            isChanged = true;
        }

        private void DatenHolen(Int32 id)
        {
            Data.Bibliothek nutzer = Data.Bibliothek.LesenID(id);
            vornameBox.Text = nutzer.Vorname;
            nachnameBox.Text = nutzer.Nachname;
            strasseBox.Text = nutzer.Strasse;
            hausnummerBox.Text = nutzer.Hausnummer.ToString();
            postleitzahlBox.Text = nutzer.Postleitzahl.ToString();
            ortBox.Text = nutzer.Ort;
            ausleihedatumBox.Text = nutzer.Ausleihedatum.ToString();
            Bücherauswahl.Text = nutzer.Buecherliste;

        }
        private void saveDataIntoDatabase(bool geschlecht, string vorname, string nachname, string strasse, long hausnummer, long postleitzahl, string ort, DateTime ausleihedatum, string buecherliste)
        {
            if(this.status == "new")
            {
                Data.Bibliothek nutzer = new Data.Bibliothek();
                nutzer.Geschlecht = geschlecht;
                nutzer.Vorname = vorname;
                nutzer.Nachname = nachname;
                nutzer.Strasse = strasse;
                nutzer.Hausnummer = hausnummer;
                nutzer.Postleitzahl = postleitzahl;
                nutzer.Ort = ort;
                nutzer.Ausleihedatum = ausleihedatum;
                nutzer.Buecherliste = buecherliste;
            }
            else
            {
                Data.Bibliothek nutzer = Data.Bibliothek.LesenID(currentId);
                nutzer.Geschlecht = geschlecht;
                nutzer.Vorname = vorname;
                nutzer.Nachname = nachname;
                nutzer.Strasse = strasse;
                nutzer.Hausnummer = hausnummer;
                nutzer.Postleitzahl = postleitzahl;
                nutzer.Ort = ort;
                nutzer.Ausleihedatum = ausleihedatum;
                nutzer.Buecherliste = buecherliste;
                Int64 id = nutzer.Aktualisieren();
            }


        }
    }
}
