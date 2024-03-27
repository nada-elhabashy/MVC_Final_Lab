using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
       ITIDbContext db;
        public LoginController(ITIDbContext _db)
        {
            db = _db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginData userData)
        {
            if (!ModelState.IsValid)
            {
                return View(userData);
            }

            var user = db.Users.FirstOrDefault(a => a.Email == userData.Email && a.Password == userData.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }

            List<Claim> claims = new List<Claim>();
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            Claim claim1 = new Claim(ClaimTypes.Email, user.Email);

            ClaimsIdentity claimsIdentity1 = new
           ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            claimsIdentity1.AddClaim(claim1);
            claimsIdentity1.AddClaims(claims);

            ClaimsPrincipal claimsPrincipal1 = new ClaimsPrincipal();
            claimsPrincipal1.AddIdentity(claimsIdentity1);

            await HttpContext.SignInAsync(claimsPrincipal1);

            return RedirectToAction("Index", "Home");

        }
        public IActionResult AccessError()
        {
            return View();
        }
    }
}
