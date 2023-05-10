using Ahtapot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ahtapot.ViewComponents.MenuCategory
{
    public class MenuCategory : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var d = c.Categories.ToList();
            return View(d);
        }
    }
}
