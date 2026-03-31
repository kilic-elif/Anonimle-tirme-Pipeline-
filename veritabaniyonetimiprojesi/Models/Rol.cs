using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veritabaniyonetimiprojesi.Models
{
    [Table("Roller")]
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        public string? RolAdi { get; set; }

        public string? Aciklama { get; set; }
    }
}