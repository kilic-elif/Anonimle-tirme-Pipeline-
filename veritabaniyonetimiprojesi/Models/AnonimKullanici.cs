using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veritabaniyonetimiprojesi.Models
{
    [Table("AnonimKullanicilar")]
    public class AnonimKullanici
    {
        [Key]
        public int AnonimKayitID { get; set; }

        public int KullaniciID { get; set; }

        public string TakmaKullaniciKodu { get; set; }

        public string AdSoyadMaske { get; set; }

        public string TCKimlikMaske { get; set; }

        public string TelefonMaske { get; set; }

        public string EpostaMaske { get; set; }

        public string YasAraligi { get; set; }

        public string Sehir { get; set; }

        public string AdresMaske { get; set; }

        public string TCKimlikHash { get; set; }

        public string TelefonHash { get; set; }

        public DateTime IslemTarihi { get; set; }
    }
}