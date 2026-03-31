using veritabaniyonetimiprojesi.Models;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Models;

namespace veritabaniyonetimiprojesi.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<AnonimKullanici> AnonimKullanicilar { get; set; }
        public DbSet<IslemKaydi> IslemKayitlari { get; set; }
        public DbSet<ErisimKaydi> ErisimKayitlari { get; set; }
        public DbSet<SistemKullanici> SistemKullanicilari { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<HataKaydi> HataKayitlari { get; set; }
    }
}