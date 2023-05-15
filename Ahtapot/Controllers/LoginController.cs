using Ahtapot.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kategori.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(User ad)
        {
            var bilgiler = c.Users.FirstOrDefault(x => x.UserMail == ad.UserMail && x.UserPassword == ad.UserPassword);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,ad.UserMail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                HttpContext.Session.SetInt32("userid", bilgiler.Id);
                return RedirectToAction("Home", "Admin");

            }
            else
            {
                return View();
            }
        }
    }
}