using Microsoft.AspNetCore.Mvc;
using LoginWebsites.Data;  // Data namespace'ini doðru eklediðinizden emin olun
using LoginWebsites.Models;  // Models namespace'ini ekleyin

namespace LoginWebsites.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Baþarýlý login iþlemi ve kullanýcýyý yusufdalbudak.com adresine yönlendirme
                return Redirect("https://www.yusufdalbudak.com");
            }
            else
            {
                ViewBag.Error = "Geçersiz kullanýcý adý veya þifre.";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

    }
}
