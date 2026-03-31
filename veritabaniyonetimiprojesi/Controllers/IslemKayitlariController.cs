using veritabaniyonetimiprojesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Controllers;
using veritabaniyonetimiprojesi.Data;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class IslemKayitlariController : BaseController
    {
        private readonly UygulamaDbContext _context;

        public IslemKayitlariController(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int sayfa = 1)
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolVar("Admin", "Denetci"))
                return YetkiYok();

            int sayfaBoyutu = 50;
            var toplamKayit = await _context.IslemKayitlari.CountAsync();

            var liste = await _context.IslemKayitlari
                .OrderByDescending(x => x.IslemID)
                .Skip((sayfa - 1) * sayfaBoyutu)
                .Take(sayfaBoyutu)
                .ToListAsync();

            ViewBag.Sayfa = sayfa;
            ViewBag.ToplamSayfa = (int)Math.Ceiling((double)toplamKayit / sayfaBoyutu);

            return View(liste);
        }
    }
}