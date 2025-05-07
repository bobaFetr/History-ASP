using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

public class AccountController : Controller
{
    private HistoricalFact db = new HistoricalFact();

    // GET: Register
    public ActionResult Register() => View();

    // POST: Register
    [HttpPost]
    public ActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            db.Users.Add(user);
            //db.SaveChanges();  gives error because db is not a DbContext
            // You need to implement the logic to save the user to the database here
            return RedirectToAction("Login");
        }
        return View(user);
    }

    // GET: Login
    public ActionResult Login() => View();

    // POST: Login
    [HttpPost]
    public ActionResult Login(User user)
    {
        var existingUser = db.Users
            .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        
        if (existingUser != null)
        {
            FormsAuthentication.SetAuthCookie(user.Username, false);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Message = "Invalid login.";
        return View();
    }

    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login");
    }
}
