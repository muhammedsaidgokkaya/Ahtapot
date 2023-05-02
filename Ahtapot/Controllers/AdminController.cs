using Ahtapot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace Ahtapot.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IWebHostEnvironment _webHost;

        Context c = new Context();

        public AdminController(ILogger<AdminController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult HakkimizdaDuzenle()
        {
            var hakkimizda = c.Hakkimizdas.FirstOrDefault();
            Hakkimizda dto = new Hakkimizda
            {
                Id = hakkimizda.Id,
                Title = hakkimizda.Title,
                Description = hakkimizda.Description,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult HakkimizdaDuzenle(Hakkimizda dto)
        {
            Hakkimizda hakkimizda = new Hakkimizda
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
            };
            c.Hakkimizdas.Update(hakkimizda);
            c.SaveChanges();
            return RedirectToAction("Home", "Admin");
        }

        public IActionResult IletisimDuzenle()
        {
            var iletisim = c.Iletisims.FirstOrDefault();
            Iletisim dto = new Iletisim
            {
                Id = iletisim.Id,
                Mail = iletisim.Mail,
                Number = iletisim.Number,
                Address = iletisim.Address,
                Faks = iletisim.Faks,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult IletisimDuzenle(Iletisim dto)
        {
            Iletisim iletisim = new Iletisim
            {
                Id = dto.Id,
                Mail = dto.Mail,
                Number = dto.Number,
                Address = dto.Address,
                Faks = dto.Faks,
            };
            c.Iletisims.Update(iletisim);
            c.SaveChanges();
            return RedirectToAction("Home", "Admin");
        }

        public IActionResult KategoriEkle() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult KategoriEkle(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("KategoriEkle", "Admin");
        }

        public IActionResult KategoriDuzenle(int id)
        {
            var guncelle = c.Categories.Find(id);
            return View(guncelle);
        }

        [HttpPost]
        public IActionResult KategoriDuzenle(Category category)
        {
            c.Categories.Update(category);
            c.SaveChanges();
            return RedirectToAction("KategoriEkle", "Admin");
        }

        public IActionResult KategoriSil(int id)
        {
            var sil = c.Categories.Find(id);
            c.Categories.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("KategoriEkle", "Admin");
        }

        public IActionResult IcerikEkle()
        {
            var value = c.Categories.ToList();
            List<SelectListItem> CategoryList = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.Category = CategoryList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IcerikEkle(Models.Ahtapot ahtapot)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(ahtapot.File.FileName);
                string extension = Path.GetExtension(ahtapot.File.FileName);
                ahtapot.FilePath = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Resimler/Blog/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await ahtapot.File.CopyToAsync(filestream);
                }
                c.Ahtapots.Add(ahtapot);
                c.SaveChanges();
            }
            return RedirectToAction("IcerikEkle", "Admin");
        }

        public IActionResult IcerikDuzenle(int id)
        {
            var value = c.Categories.ToList();
            List<SelectListItem> CategoryList = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.Category = CategoryList;
            var guncelle = c.Ahtapots.Find(id);
            return View(guncelle);
        }
        [HttpPost]
        public async Task<IActionResult> IcerikDuzenle(Models.Ahtapot ahtapot)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(ahtapot.File.FileName);
                string extension = Path.GetExtension(ahtapot.File.FileName);
                ahtapot.FilePath = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Resimler/Blog/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await ahtapot.File.CopyToAsync(filestream);
                }
                c.Ahtapots.Update(ahtapot);
                c.SaveChanges();
            }
            return RedirectToAction("IcerikEkle", "Admin");
        }

        public IActionResult IcerikSil(int id)
        {
            var sil = c.Ahtapots.Find(id);
            c.Ahtapots.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("IcerikEkle", "Admin");
        }

        public IActionResult Profilim() 
        { 
            return View();
        }
    }
}
