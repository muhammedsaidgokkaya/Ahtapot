using Ahtapot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ahtapot.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        Context c = new Context();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit(User form)
        {
            c.Users.Add(form);
            c.SaveChanges();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Hakkimizda()
        {
            Context c = new Context();
            var list = c.Hakkimizdas.FirstOrDefault();
            ViewBag.Title = list.Title.ToString();
            ViewBag.Description = list.Description.ToString();
            ViewBag.MisyonumuzBaslik = list.MisyonumuzBaslik.ToString();
            ViewBag.MisyonumuzDescription = list.MisyonumuzDescription.ToString();
            ViewBag.VizyonBaslik = list.VizyonBaslik.ToString();
            ViewBag.VizyonDescription = list.VizyonDescription.ToString();
            ViewBag.NedenBizBaslik = list.NedenBizBaslik.ToString();
            ViewBag.NedenBizDescription = list.NedenBizDescription.ToString();
            ViewBag.BizKimizBaslik = list.BizKimizBaslik.ToString();
            ViewBag.BizKimizDescription = list.BizKimizDescription.ToString();
            ViewBag.EkibimizBaslik = list.EkibimizBaslik.ToString();
            ViewBag.EkibimizDescription = list.EkibimizDescription.ToString();
            return View();
        }

        public IActionResult Iletisim()
        {
            Context c = new Context();
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.Address = list.Address.ToString();
            ViewBag.Mail = list.Mail.ToString();
            ViewBag.Number = list.Number.ToString();
            ViewBag.Faks = list.Faks.ToString();
            ViewBag.Saatler = list.Saatler.ToString();
            //var iletisimlistesi = iletisimmanager.GetList();
            //return View(iletisimlistesi);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}