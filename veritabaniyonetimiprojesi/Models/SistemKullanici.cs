using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veritabaniyonetimiprojesi.Models
{
    [Table("SistemKullanicilari")]
    public class SistemKullanici
    {
        [Key]
        public int SistemKullaniciID { get; set; }

        public string? KullaniciAdi { get; set; }

        public string? Sifre { get; set; }

        public string? AdSoyad { get; set; }

        public int RolID { get; set; }

        public bool AktifMi { get; set; }

        public DateTime OlusturmaTarihi { get; set; }
    }
}