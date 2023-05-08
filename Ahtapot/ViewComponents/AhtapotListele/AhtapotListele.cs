using Ahtapot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ahtapot.ViewComponents.AhtapotListele
{
    public class AhtapotListele : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var d = c.Wikis.ToList();
            return View(d);
        }
    }
}
