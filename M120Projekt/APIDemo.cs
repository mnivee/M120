using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA
            Data.Bibliothek klasseA1 = new Data.Bibliothek();
            klasseA1.Geschlecht = false;
            klasseA1.Vorname = "Niveditha";
            klasseA1.Nachname = "Muneeswaran";
            klasseA1.Strasse = "Tiefenaustrasse";
            klasseA1.Hausnummer = 84;
            klasseA1.Postleitzahl = 3004;
            klasseA1.Ort = "Bern";
            klasseA1.Buecherliste = "Maze Runner";
            
            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.Bibliothek klasseA2 = new Data.Bibliothek { TextAttribut = "Artikel 2", BooleanAttribut = true, DatumAttribut = DateTime.Today };
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Bibliothek klasseA in Data.Bibliothek.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.KlasseAId + " Name:" + klasseA.TextAttribut);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Bibliothek klasseA1 = Data.Bibliothek.LesenID(1);
            klasseA1.TextAttribut = "Artikel 1 nach Update";
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Bibliothek.LesenID(2).Loeschen();
            Debug.Print("Artikel mit Id 2 gelöscht");
        }
        #endregion
    }
}
