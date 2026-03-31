using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veritabaniyonetimiprojesi.Models
{
    [Table("ErisimKayitlari")]
    public class ErisimKaydi
    {
        [Key]
        public int ErisimID { get; set; }

        public int SistemKullaniciID { get; set; }

        public string? IslemTipi { get; set; }

        public string? HedefTablo { get; set; }

        public string? Aciklama { get; set; }

        public DateTime IslemTarihi { get; set; }
    }
}