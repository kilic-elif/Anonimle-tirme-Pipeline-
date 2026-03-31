using veritabaniyonetimiprojesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Controllers;
using veritabaniyonetimiprojesi.Data;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class AnonimVerilerController : BaseController
    {
        private readonly UygulamaDbContext _context;

        public AnonimVerilerController(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? arama, int sayfa = 1)
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolVar("Admin", "Analist"))
                return YetkiYok();

            int sayfaBoyutu = 50;

            var query = _context.AnonimKullanicilar.AsQueryable();

            if (!string.IsNullOrWhiteSpace(arama))
            {
                query = query.Where(x =>
                    x.TakmaKullaniciKodu.Contains(arama) ||
                    x.Sehir.Contains(arama) ||
                    x.YasAraligi.Contains(arama));
            }

            var toplamKayit = await query.CountAsync();

            var liste = await query
                .OrderBy(x => x.AnonimKayitID)
                .Skip((sayfa - 1) * sayfaBoyutu)
                .Take(sayfaBoyutu)
                .ToListAsync();

            ViewBag.Arama = arama;
            ViewBag.Sayfa = sayfa;
            ViewBag.ToplamSayfa = (int)Math.Ceiling((double)toplamKayit / sayfaBoyutu);

            return View(liste);
        }
    }
}