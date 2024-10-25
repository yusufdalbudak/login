using Microsoft.AspNetCore.Mvc;
using LoginWebsites.Data;
using LoginWebsites.Models;

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
                return RedirectToAction("Index", "Account");  
            }
            else
            {
                ViewBag.Error = "gecersiz kullanici adi sifre.";
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
            return View();
        }
    }
}
