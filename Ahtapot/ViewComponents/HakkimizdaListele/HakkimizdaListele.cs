using Ahtapot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ahtapot.ViewComponents.HakkimizdaListele
{
    public class HakkimizdaListele : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Hakkimizdas.ToList();
            var list = c.Hakkimizdas.FirstOrDefault();
            ViewBag.Title = list.Title.ToString();
            ViewBag.Description = list.Description.ToString();
            return View(liste);
        }
    }
}
