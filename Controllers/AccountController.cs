using Microsoft.AspNetCore.Mvc;
using LoginWebsites.Data;  // Data namespace'ini do�ru ekledi�inizden emin olun
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
                // Ba�ar�l� login i�lemi ve kullan�c�y� yusufdalbudak.com adresine y�nlendirme
                return Redirect("https://www.yusufdalbudak.com");
            }
            else
            {
                ViewBag.Error = "Ge�ersiz kullan�c� ad� veya �ifre.";
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
