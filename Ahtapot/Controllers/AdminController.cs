using Microsoft.AspNetCore.Mvc;

namespace Ahtapot.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult HakkimizdaDuzenle()
        {
            return View();
        }
        public IActionResult IletisimDuzenle() 
        { 
            return View(); 
        }
        public IActionResult KategoriEkle() 
        { 
            return View(); 
        }
        public IActionResult IcerikEkle() 
        { 
            return View(); 
        }
        public IActionResult Profilim() 
        { 
            return View(); 
        }
    }
}
