using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Bibliothek
    {
        #region Datenbankschicht
        [Key]
        public Int64 BibliothekID { get; set; }
        [Required]
        public Boolean Geschlecht { get; set; }
        [Required]
        public String Vorname { get; set; }
        [Required]
        public String Nachname { get; set; }
        [Required]
        public String Strasse { get; set; }
        [Required]
        public Int64 Hausnummer { get; set; }
        [Required]
        public Int64 Postleitzahl { get; set; }
        [Required]
        public String Ort { get; set; }
        [Required]
        public DateTime Ausleihedatum { get; set; }
        [Required]
        public String Buecherliste { get; set; }
        #endregion
        #region Applikationsschicht
        public Bibliothek() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Bibliothek> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.Bibliothek select record).ToList();
            }
        }
        public static Bibliothek LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.Bibliothek where record.BibliothekID == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Bibliothek> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Bibliothek where record.Nachname == suchbegriff select record).ToList();
            }
        }
        public static List<Bibliothek> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Bibliothek where record.Nachname.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Nachname == null || this.Nachname == "") this.Nachname = "leer";
            if (this.Ausleihedatum == null) this.Ausleihedatum = DateTime.MinValue;
            using (var db = new Context())
            {
                db.Bibliothek.Add(this);
                db.SaveChanges();
                return this.BibliothekID;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.BibliothekID;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return BibliothekID.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
