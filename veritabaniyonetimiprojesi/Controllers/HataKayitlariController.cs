using veritabaniyonetimiprojesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Controllers;
using veritabaniyonetimiprojesi.Data;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class HataKayitlariController : BaseController
    {
        private readonly UygulamaDbContext _context;

        public HataKayitlariController(UygulamaDbContext context)
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
            var toplamKayit = await _context.HataKayitlari.CountAsync();

            var liste = await _context.HataKayitlari
                .OrderByDescending(x => x.HataID)
                .Skip((sayfa - 1) * sayfaBoyutu)
                .Take(sayfaBoyutu)
                .ToListAsync();

            ViewBag.Sayfa = sayfa;
            ViewBag.ToplamSayfa = (int)Math.Ceiling((double)toplamKayit / sayfaBoyutu);

            return View(liste);
        }
    }
}