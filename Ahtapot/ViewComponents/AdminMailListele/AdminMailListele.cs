using Ahtapot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ahtapot.ViewComponents.AdminMailListele
{
    public class AdminMailListele : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == usermail).Select(y => y.Id).FirstOrDefault();

            ViewBag.kullaniciMail = usermail;
            return View();
        }
    }
}
