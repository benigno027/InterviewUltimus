using EntrevistaUltimus.Models;
using EntrevistaUltimus.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using EntrevistaUltimus.ViewModels;

namespace EntrevistaUltimus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(User model)
        {

            if (ModelState.IsValid)
            {
                var nuevoUsuario = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Telephone = model.Telephone,
                    Email = model.Email,
                    NationalityId = model.NationalityId,
                    Residency = model.Residency,
                };

                _db.Users.Add(nuevoUsuario);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
