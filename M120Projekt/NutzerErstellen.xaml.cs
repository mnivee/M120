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

            if(this.status == "edit")
            {
                Delete.IsEnabled = true;
                DatenHolen(currentId);
            }

        }

        // Enable Save Button on change
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            Save.IsEnabled = true;
            isChanged = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Save.IsEnabled = true;
            isChanged = true;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Save.IsEnabled = true;
            isChanged = true;
        }


        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = true;
            isChanged = true;
        }

        private void DatenHolen(Int32 id)
        {
            Data.Bibliothek nutzer = Data.Bibliothek.LesenID(id);
            checkboxHerr.IsChecked = nutzer.Geschlecht;
            checkboxFrau.IsChecked = nutzer.Geschlecht;
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
                nutzer.Erstellen();
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

        // Buttons 
        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            // validation
            string vornameInput = vornameBox.Text;
            string nachnameInput = nachnameBox.Text;
            string strasseInput = strasseBox.Text;
            string hausnummerInput = hausnummerBox.Text.ToString();
            string postleitzahlInput = postleitzahlBox.Text.ToString();
            string ortInput = ortBox.Text;
            DateTime dateInput = Convert.ToDateTime(ausleihedatumBox.Text);
            object buecherlisteInput = Bücherauswahl.SelectedValue;
            string buecherlisteValue = Bücherauswahl.Text;
            bool checkboxInput;
            
            if(checkboxHerr.IsChecked == true)
            {
                checkboxInput = true;
            }
            else if(checkboxFrau.IsChecked == true)
            {
                checkboxInput = true;
            }
            else
            {
                checkboxInput = false;
            }

            // validation correct save in database | else: error message
            if(ValidateVorname(vornameInput) && ValidateNachname (nachnameInput) && ValidateStrasse(strasseInput) && ValidateHausnummer(hausnummerInput) && ValidatePostleitzahl(postleitzahlInput) && ValidateOrt(ortInput) && ValidateDatum(dateInput) && ValidateBuecherauswahl(buecherlisteInput))
            {
                long hausnummer = Convert.ToInt64(hausnummerInput);
                long postleitzahl = Convert.ToInt64(postleitzahlInput);
                // saves into db
                this.saveDataIntoDatabase(checkboxInput,vornameInput, nachnameInput, strasseInput, hausnummer, postleitzahl, ortInput, dateInput, buecherlisteValue);
               NutzerErstellenLeer nutzer = new NutzerErstellenLeer(placeholder);
               placeholder.Content = nutzer;

                MessageBox.Show("Der Nutzer wurde gespeichert.");
            }
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            if (isChanged)
            {
                MessageBoxResult messageBoxAbbrechen = System.Windows.MessageBox.Show("Wollen Sie wirklich abbrechen?", "Abbrechen?", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxAbbrechen == MessageBoxResult.Yes)
                {
                    NutzerErstellenLeer nutzerErfasstAbbrechen = new NutzerErstellenLeer(placeholder);
                    placeholder.Content = nutzerErfasstAbbrechen;
                    MessageBox.Show("Vorgang abgebrochen");
                }
            }
            else
            {
                NutzerErstellen nutzer = new NutzerErstellen(placeholder, "abbruch");
                placeholder.Content = nutzer;
            }

        }

        private void Löschen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Sicher, dass du den Nutzer löschen möchtest?", "Löschen?", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes && this.status == "edit")
            {
                // TODO: Delete function here
                Data.Bibliothek nutzer = Data.Bibliothek.LesenID(currentId);
                nutzer.Loeschen();

                NutzerErstellen mehrerenutzer = new NutzerErstellen(placeholder, "edit");
                placeholder.Content = mehrerenutzer;

                MessageBox.Show("Der Nutzer wurde gelöscht.");
            }
        }


        // Validation here
        private Boolean ValidateVorname(string text)
        {
            vornameBox.Background = Brushes.White;
            // validierung
            System.Text.RegularExpressions.Match match = DefineRegex("Vorname").Match(text);
            if (text.Length > 0 && match.Success)
            {
                return true;
            }
            vornameBox.Background = Brushes.Red;
            return false;
        }

        private Boolean ValidateNachname(string text)
        {
            nachnameBox.Background = Brushes.White;
            // validierung
            System.Text.RegularExpressions.Match match = DefineRegex("Nachname").Match(text);
            if (text.Length > 0 && match.Success)
            {
                return true;
            }
            nachnameBox.Background = Brushes.Red;
            return false;
        }

        private Boolean ValidateStrasse(string text)
        {
            strasseBox.Background = Brushes.White;
            // validierung
            System.Text.RegularExpressions.Match match = DefineRegex("Strasse").Match(text);
            if (text.Length > 0 && match.Success)
            {
                return true;
            }
            strasseBox.Background = Brushes.Red;
            return false;
        }

        private Boolean ValidateHausnummer(string text)
        {
            hausnummerBox.Background = Brushes.White;
            // validierung
            System.Text.RegularExpressions.Match match = DefineRegex("Hausnummer").Match(text);
            if (text.Length > 0 && match.Success)
            {
                return true;
            }
            hausnummerBox.Background = Brushes.Red;
            return false;
        }

        private Boolean ValidatePostleitzahl(string text)
        {
            postleitzahlBox.Background = Brushes.White;
            // validierung
            System.Text.RegularExpressions.Match match = DefineRegex("Postleitzahl").Match(text);
            if (text.Length > 0 && match.Success)
            {
                return true;
            }
            postleitzahlBox.Background = Brushes.Red;
            return false;
        }
        private Boolean ValidateOrt(string text)
        {
            ortBox.Background = Brushes.White;
            // validierung
            System.Text.RegularExpressions.Match match = DefineRegex("Ort").Match(text);
            if (text.Length > 0 && match.Success)
            {
                return true;
            }
            ortBox.Background = Brushes.Red;
            return false;
        }

        private Boolean ValidateDatum(DateTime date)
        {
            ausleihedatumBox.Background = Brushes.White;
            // validierung
            if (date < DateTime.Now)
            {
                return true;
            }
            ausleihedatumBox.Background = Brushes.Red;
            return false;
        }

        private Boolean ValidateBuecherauswahl(object obj)
        {
            Bücherauswahl.BorderThickness = new Thickness(0);
            // validierung
            if (obj != null)
            {
                return true;
            }
            Bücherauswahl.BorderThickness = new Thickness(1);
            return false;
        }

        private System.Text.RegularExpressions.Regex DefineRegex(string inputType)
        {
            // see help here : https://docs.microsoft.com/en-us/windows/communitytoolkit/extensions/textboxregex
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[A-Z][a-z\w0-9]+$");
            switch (inputType)
            {
                case "Vorname":
                    regex = new System.Text.RegularExpressions.Regex(@"^[A-z0-9\s]+$");
                    break;
                case "Nachname":
                    regex = new System.Text.RegularExpressions.Regex(@"^[A-z0-9\s]+$");
                    break;
                case "Strasse":
                    regex = new System.Text.RegularExpressions.Regex(@"^[A-z0-9\s]+$");
                    break;
                case "Hausnummer":
                    regex = new System.Text.RegularExpressions.Regex(@"^[A-z0-9\s]+$");
                    break;
                case "Postleitzahl":
                    regex = new System.Text.RegularExpressions.Regex(@"^[A-z0-9\s]+$");
                    break;
                case "Ort":
                    regex = new System.Text.RegularExpressions.Regex(@"^[A-z0-9\s]+$");
                    break;
            }
            return regex;
        }
    }
}


