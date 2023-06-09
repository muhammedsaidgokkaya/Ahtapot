﻿using Ahtapot.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

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
            var userid = HttpContext.Session.GetInt32("userid");
            var userbilgi = c.Users.Where(x => x.Id == userid).FirstOrDefault();
            var telefon = c.Iletisims.FirstOrDefault();
            var userSayisi = c.Users.Count().ToString();

            ViewBag.userSayisi = userSayisi;
            ViewBag.Number = telefon.Number;
            ViewBag.Faks = telefon.Faks;
            return View(userbilgi);

        }

        public IActionResult HakkimizdaDuzenle()
        {
            var hakkimizda = c.Hakkimizdas.FirstOrDefault();
            Hakkimizda dto = new Hakkimizda
            {
                Id = hakkimizda.Id,
                Title = hakkimizda.Title,
                Description = hakkimizda.Description,
                MisyonumuzBaslik = hakkimizda.MisyonumuzBaslik,
                MisyonumuzDescription = hakkimizda.MisyonumuzDescription,
                VizyonBaslik = hakkimizda.VizyonBaslik,
                VizyonDescription = hakkimizda.VizyonDescription,
                NedenBizBaslik = hakkimizda.NedenBizBaslik,
                NedenBizDescription = hakkimizda.NedenBizDescription,
                BizKimizBaslik = hakkimizda.BizKimizBaslik,
                BizKimizDescription = hakkimizda.BizKimizDescription,
                EkibimizBaslik = hakkimizda.EkibimizBaslik,
                EkibimizDescription = hakkimizda.EkibimizDescription,
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
                MisyonumuzBaslik = dto.MisyonumuzBaslik,
                MisyonumuzDescription = dto.MisyonumuzDescription,
                VizyonBaslik = dto.VizyonBaslik,
                VizyonDescription = dto.VizyonDescription,
                NedenBizBaslik = dto.NedenBizBaslik,
                NedenBizDescription = dto.NedenBizDescription,
                BizKimizBaslik = dto.BizKimizBaslik,
                BizKimizDescription = dto.BizKimizDescription,
                EkibimizBaslik = dto.EkibimizBaslik,
                EkibimizDescription = dto.EkibimizDescription,
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
                Saatler = iletisim.Saatler,
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
                Saatler = dto.Saatler,
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
        public async Task<IActionResult> IcerikEkle(Wiki wiki)
        {
            string wwwRootPath = _webHost.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(wiki.File.FileName);
            string extension = Path.GetExtension(wiki.File.FileName);
            wiki.FilePath = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Resimler/", filename);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await wiki.File.CopyToAsync(filestream);
            }
            c.Wikis.Add(wiki);
            c.SaveChanges();
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
            var guncelle = c.Wikis.Find(id);
            return View(guncelle);
        }

        [HttpPost]
        public async Task<IActionResult> IcerikDuzenle(Wiki wiki)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(wiki.File.FileName);
                string extension = Path.GetExtension(wiki.File.FileName);
                wiki.FilePath = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Resimler/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await wiki.File.CopyToAsync(filestream);
                }
                c.Wikis.Update(wiki);
                c.SaveChanges();
            }
            return RedirectToAction("IcerikEkle", "Admin");
        }

        public IActionResult IcerikSil(int id)
        {
            var sil = c.Wikis.Find(id);
            c.Wikis.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("IcerikEkle", "Admin");
        }

        public IActionResult HomeIcerik()
        {
            var home = c.WikiHomes.FirstOrDefault();
            WikiHome dto = new WikiHome
            {
                Id = home.Id,
                Name = home.Name,
                Description = home.Description,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult HomeIcerik(WikiHome dto)
        {
            WikiHome home = new WikiHome
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
            c.WikiHomes.Update(home);
            c.SaveChanges();
            return RedirectToAction("Home", "Admin");
        }

        public IActionResult Profilim()
        {
           
            var userid = HttpContext.Session.GetInt32("userid");
            var userbilgi = c.Users.Where(x => x.Id == userid).FirstOrDefault();
            return View(userbilgi);
        }
        
        [HttpPost]
        public IActionResult Profilim(User user)
        {
            User us = new User
            {
                Id = user.Id,  
                UserName = user.UserName,
                UserMail = user.UserMail,
                UserPassword = user.UserPassword
            };
            c.Users.Update(us);
            c.SaveChanges();
            return RedirectToAction("Home", "Admin");
           
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
