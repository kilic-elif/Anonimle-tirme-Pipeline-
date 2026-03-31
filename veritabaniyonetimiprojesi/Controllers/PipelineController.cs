using veritabaniyonetimiprojesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veritabaniyonetimiprojesi.Controllers;
using veritabaniyonetimiprojesi.Data;

namespace veritabaniyonetimiprojesi.Controllers
{
    public class PipelineController : BaseController
    {
        private readonly UygulamaDbContext _context;

        public PipelineController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Calistir()
        {
            if (!OturumVarMi())
                return GirisYoksaLogin();

            if (!RolVar("Admin", "Analist"))
                return YetkiYok();

            _context.Database.ExecuteSqlRaw("EXEC sp_AnonimlestirmePipelineCalistir");
            TempData["Basari"] = "Pipeline başarıyla çalıştırıldı.";

            return RedirectToAction("Index", "Home");
        }
    }
}