using EntrevistaUltimus.Data;
using EntrevistaUltimus.Models;
using EntrevistaUltimus.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace EntrevistaUltimus.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly List<SelectListItem> _nationalities;
        private readonly List<SelectListItem> _generos;

        public UserController(ApplicationDbContext db)
        {
            _db = db;

            _nationalities = new List<SelectListItem>
            {
                new SelectListItem { Value = "-1", Text = "--Seleccione--" },
                new SelectListItem { Value = "1", Text = "Argentina" },
                new SelectListItem { Value = "2", Text = "Panama" },
                new SelectListItem { Value = "3", Text = "Chile" },
                new SelectListItem { Value = "4", Text = "Colombia" },
                new SelectListItem { Value = "5", Text = "Ecuador" },
                new SelectListItem { Value = "6", Text = "Paraguay" },
                new SelectListItem { Value = "7", Text = "Peru" },
                new SelectListItem { Value = "8", Text = "Uruguay" },
                new SelectListItem { Value = "9", Text = "Venezuela" }
            };

            _generos = new List<SelectListItem>
            {
                new SelectListItem { Value = "-1", Text = "--Seleccione--" },
                new SelectListItem { Value = "1", Text = "Hombre" },
                new SelectListItem { Value = "2", Text = "Mujer" }
            };
        }

        // GET: UsuarioController
        public ActionResult Index(int? page)
        {

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var users = _db.Users.ToPagedList(pageNumber, pageSize);
            var viewModel = new UsersViewModel
            {
                Users = users
            };

            ViewBag.Nationalities = _nationalities;
            ViewBag.Generos = _generos;

            return View(viewModel);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            ViewBag.Nationalities = _nationalities;
            ViewBag.Generos = _generos;

            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    BirthDate = viewModel.BirthDate,
                    Telephone = viewModel.Telephone,
                    Email = viewModel.Email,
                    NationalityId = viewModel.NationalityId,
                    Residency = viewModel.Residency,
                    Gender = viewModel.Gender
                };

                _db.Users.Add(user);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Nationalities = _nationalities;
            ViewBag.Generos = _generos;

            return View(viewModel);
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {

            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Telephone = user.Telephone,
                Email = user.Email,
                NationalityId = user.NationalityId,
                Residency = user.Residency,
                Gender = user.Gender
            };

            ViewBag.Nationalities = _nationalities;
            ViewBag.Generos = _generos;

            return View(viewModel);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(u => u.Id == viewModel.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.BirthDate = viewModel.BirthDate;
                user.Telephone = viewModel.Telephone;
                user.Email = viewModel.Email;
                user.NationalityId = viewModel.NationalityId;
                user.Residency = viewModel.Residency;
                user.Gender = viewModel.Gender;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nationalities = _nationalities;
            ViewBag.Generos = _generos;
            
            return View(viewModel);
        }

        // Acción para eliminar un usuario
        public IActionResult Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
