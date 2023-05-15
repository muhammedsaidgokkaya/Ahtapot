using Ahtapot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ahtapot.ViewComponents.AdminMailListele
{
    public class AdminMailListele : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userid = HttpContext.Session.GetInt32("userid");
            var userbilgi = c.Users.Where(x => x.Id == userid).FirstOrDefault();
            return View(userbilgi);
        }
    }
}
