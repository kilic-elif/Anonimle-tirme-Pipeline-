using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veritabaniyonetimiprojesi.Models
{
    [Table("IslemKayitlari")]
    public class IslemKaydi
    {
        [Key]
        public int IslemID { get; set; }

        public string? IslemAdi { get; set; }

        public DateTime BaslamaZamani { get; set; }

        public DateTime? BitisZamani { get; set; }

        public string? Durum { get; set; }

        public int? EtkilenenKayitSayisi { get; set; }

        public string? Aciklama { get; set; }
    }
}