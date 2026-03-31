using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veritabaniyonetimiprojesi.Models
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }

        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        public string TCKimlikNo { get; set; }

        [Required]
        public string Telefon { get; set; }

        [Required]
        public string Eposta { get; set; }

        public DateTime DogumTarihi { get; set; }

        [Required]
        public string Sehir { get; set; }

        [Required]
        public string Adres { get; set; }

        public string KayitDurumu { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}