using Microsoft.AspNetCore.Mvc;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class BaseController : Controller
    {
        protected bool OturumVarMi()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("KullaniciAdi"));
        }

        protected string? AktifRol()
        {
            return HttpContext.Session.GetString("Rol");
        }

        protected bool RolAdmin()
        {
            return AktifRol() == "Admin";
        }

        protected bool RolAnalist()
        {
            return AktifRol() == "Analist";
        }

        protected bool RolDenetci()
        {
            return AktifRol() == "Denetci";
        }

        protected bool RolVar(params string[] roller)
        {
            var rol = AktifRol();
            return !string.IsNullOrEmpty(rol) && roller.Contains(rol);
        }

        protected IActionResult GirisYoksaLogin()
        {
            return RedirectToAction("Login", "Auth");
        }

        protected IActionResult YetkiYok()
        {
            TempData["Hata"] = "Bu sayfaya erişim yetkiniz yok.";
            return RedirectToAction("Index", "Home");
        }
    }
}