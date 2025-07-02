using Microsoft.AspNetCore.Mvc;
using SchoolTracker.DAL;
using SchoolTracker.Model;
using SchoolTracker.Models.ViewModels;

namespace SchoolTracker.Controllers;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Traži korisnika po emailu i lozinci
        AppUser? user = _context.Profesors.FirstOrDefault(p => p.Email == model.Email && p.Password == model.Password);

        if (user == null)
        {
            user = _context.Students.FirstOrDefault(s => s.Email == model.Email && s.Password == model.Password);
        }

        if (user == null)
        {
            ModelState.AddModelError("", "Neispravan email ili lozinka.");
            return View(model);
        }

        // Spremi podatke u session
        HttpContext.Session.SetString("UserID", user.ID.ToString());
        HttpContext.Session.SetString("UserType", user is Profesor ? "Profesor" : "Student");

        // Redirect na početnu stranicu
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
