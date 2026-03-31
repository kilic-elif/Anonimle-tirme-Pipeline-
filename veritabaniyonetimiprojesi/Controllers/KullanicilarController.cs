using veritabaniyonetimiprojesi.Data;
using veritabaniyonetimiprojesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Controllers;
using veritabaniyonetimiprojesi.Data;
using veritabaniyonetimiprojesi.Models;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class KullanicilarController : BaseController
    {
        private readonly UygulamaDbContext _context;

        public KullanicilarController(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? arama, int sayfa = 1)
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolAdmin())
                return YetkiYok();

            int sayfaBoyutu = 50;

            var query = _context.Kullanicilar.AsQueryable();

            if (!string.IsNullOrWhiteSpace(arama))
            {
                query = query.Where(x =>
                    x.Ad.Contains(arama) ||
                    x.Soyad.Contains(arama) ||
                    x.Sehir.Contains(arama));
            }

            var toplamKayit = await query.CountAsync();

            var liste = await query
                .OrderBy(x => x.KullaniciID)
                .Skip((sayfa - 1) * sayfaBoyutu)
                .Take(sayfaBoyutu)
                .ToListAsync();

            ViewBag.Arama = arama;
            ViewBag.Sayfa = sayfa;
            ViewBag.ToplamSayfa = (int)Math.Ceiling((double)toplamKayit / sayfaBoyutu);

            return View(liste);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolAdmin())
                return YetkiYok();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Kullanici model)
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolAdmin())
                return YetkiYok();

            if (!ModelState.IsValid)
                return View(model);

            model.KayitDurumu = "Bekliyor";
            model.KayitTarihi = DateTime.Now;

            _context.Kullanicilar.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Duzenle(int id)
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolAdmin())
                return YetkiYok();

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
                return NotFound();

            return View(kullanici);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(Kullanici model)
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolAdmin())
                return YetkiYok();

            if (!ModelState.IsValid)
                return View(model);

            _context.Kullanicilar.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Sil(int id)
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolAdmin())
                return YetkiYok();

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}