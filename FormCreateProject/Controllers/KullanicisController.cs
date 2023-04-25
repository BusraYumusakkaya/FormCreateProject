using FormCreateProject.Models;
using FormCreateProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FormCreateProject.Controllers
{
    public class KullanicisController : Controller
    {
        private readonly IKullaniciRepository kullaniciRepository;

        public KullanicisController(IKullaniciRepository kullaniciRepository)
        {
            this.kullaniciRepository = kullaniciRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BeLogin(LogInVM logInVm)
        {
            var user = kullaniciRepository.GetByUsernameAndPassword(logInVm.Name, logInVm.Sifre);
            if (user == null)
            {
                TempData["Message"] = "Giriş bilgileri hatalı";
                return View();
            }
            HttpContext.Session.SetString("Name", user.Name);
            TempData["Message"] = "Hoşgeldin " + user.Name;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Name");
            TempData["Message"] = "Güle Güle";
            return RedirectToAction("Index", "Home");
        }
    }
}
