using Ahtapot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ahtapot.ViewComponents.IletisimListele
{
    public class IletisimListele : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Iletisims.ToList();
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.Address = list.Address.ToString();
            ViewBag.Mail = list.Mail.ToString();
            ViewBag.Number = list.Number.ToString();
            ViewBag.Saatler = list.Saatler.ToString();
            return View(liste);
        }
    }
}
