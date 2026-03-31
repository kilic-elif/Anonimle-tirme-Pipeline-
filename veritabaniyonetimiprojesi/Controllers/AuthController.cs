using veritabaniyonetimiprojesi.Data;
using veritabaniyonetimiprojesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Data;
using veritabaniyonetimiprojesi.Models;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class AuthController : Controller
    {
        private readonly UygulamaDbContext _context;

        public AuthController(UygulamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("KullaniciAdi")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(GirisViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var kullanici = await _context.SistemKullanicilari
                .FirstOrDefaultAsync(x =>
                    x.KullaniciAdi == model.KullaniciAdi &&
                    x.Sifre == model.Sifre &&
                    x.AktifMi);

            if (kullanici == null)
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı.";
                return View(model);
            }

            var rol = await _context.Roller
                .FirstOrDefaultAsync(r => r.RolID == kullanici.RolID);

            HttpContext.Session.SetInt32("SistemKullaniciID", kullanici.SistemKullaniciID);
            HttpContext.Session.SetString("KullaniciAdi", kullanici.KullaniciAdi ?? "");
            HttpContext.Session.SetString("AdSoyad", kullanici.AdSoyad ?? "");
            HttpContext.Session.SetString("Rol", rol?.RolAdi ?? "");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}