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
                return (from record in db.KlasseA select record).ToList();
            }
        }
        public static Bibliothek LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.KlasseAId == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Bibliothek> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.TextAttribut == suchbegriff select record).ToList();
            }
        }
        public static List<Bibliothek> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.KlasseA where record.TextAttribut.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.TextAttribut == null || this.TextAttribut == "") this.TextAttribut = "leer";
            if (this.DatumAttribut == null) this.DatumAttribut = DateTime.MinValue;
            using (var db = new Context())
            {
                db.KlasseA.Add(this);
                db.SaveChanges();
                return this.KlasseAId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.KlasseAId;
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
            return KlasseAId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
