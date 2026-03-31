using System.ComponentModel.DataAnnotations;

namespace veritabaniyonetimiprojesi.Models
{
    public class GirisViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}