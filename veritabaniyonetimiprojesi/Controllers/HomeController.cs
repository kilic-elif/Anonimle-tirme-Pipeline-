using veritabaniyonetimiprojesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Controllers;
using veritabaniyonetimiprojesi.Data;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UygulamaDbContext _context;

        public HomeController(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            ViewBag.ToplamKullanici = await _context.Kullanicilar.CountAsync();
            ViewBag.ToplamAnonimKullanici = await _context.AnonimKullanicilar.CountAsync();
            ViewBag.ToplamIslem = await _context.IslemKayitlari.CountAsync();
            ViewBag.ToplamErisimKaydi = await _context.ErisimKayitlari.CountAsync();

            var sonIslem = await _context.IslemKayitlari
                .OrderByDescending(x => x.IslemID)
                .FirstOrDefaultAsync();

            var sonBesIslem = await _context.IslemKayitlari
                .OrderByDescending(x => x.IslemID)
                .Take(5)
                .ToListAsync();

            ViewBag.SonIslemDurumu = sonIslem?.Durum ?? "Kayýt yok";
            ViewBag.SonIslemTarihi = sonIslem?.BaslamaZamani.ToString("dd.MM.yyyy HH:mm") ?? "-";
            ViewBag.SonBesIslem = sonBesIslem;

            return View();
        }
    }
}