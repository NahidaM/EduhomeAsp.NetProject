﻿using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Extentions;
using HomeEduBackendFinal.Helpers;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] 
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AboutController(AppDbContext db, IWebHostEnvironment env) 
        {
            _db = db;
            _env = env;
        }


        #region Index
        //HomeEduBackendFinal/Admin/AboutController/Index 
        public IActionResult Index()
        {
            About about = _db.Abouts.FirstOrDefault();
            return View(about);
        }
        #endregion


        #region Update
        //GET: HomeEduBackendFinal/Admin/AboutController/Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            About about = await _db.Abouts.FindAsync(id);
            if (about == null) return NotFound();
            return View(about);
        }
        //POST: HomeEduBackendFinal/Admin/AboutController/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, About about)
        {
            if (id == null) return NotFound();
            About dbabout = await _db.Abouts.FindAsync(id);
            if (dbabout == null) return NotFound();
            if (about.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!about.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (about.Photo.MaxLength(200))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }

                string path = Path.Combine("img", "about");
                Helper.DeleteImage(_env.WebRootPath, path, dbabout.Image);
                string fileName = await about.Photo.SaveImg(_env.WebRootPath, path);
                dbabout.Image = fileName;
            }
            dbabout.Description = about.Description;
            dbabout.Title = about.Title;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
