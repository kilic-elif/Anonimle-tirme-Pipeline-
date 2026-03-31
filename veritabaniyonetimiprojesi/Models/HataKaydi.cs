using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veritabaniyonetimiprojesi.Models
{
    [Table("HataKayitlari")]
    public class HataKaydi
    {
        [Key]
        public int HataID { get; set; }

        public int? IslemID { get; set; }

        public string HataMesaji { get; set; }

        public int? HataSatiri { get; set; }

        public DateTime HataTarihi { get; set; }
    }
}