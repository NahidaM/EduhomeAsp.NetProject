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
    public class TestimonialController : Controller
    {

        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public TestimonialController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public IActionResult Index()
        {
            return View(_db.Testimonials.ToList());
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Testimonial testimonial = _db.Testimonials.FirstOrDefault(p => p.Id == id);
            if (testimonial == null) return NotFound();
            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Testimonial testimonial)
        {
            if (!ModelState.IsValid) return View();
            if (id == null) return NotFound();
            Testimonial dbtestimonial = await _db.Testimonials.FindAsync(id);
            if (dbtestimonial == null) return NotFound();
            if (testimonial.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!testimonial.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (testimonial.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 2mg ola biler");
                    return View();
                }
                string path = Path.Combine("img", "testimonial");
                Helper.DeleteImage(_env.WebRootPath, path, dbtestimonial.Image);
                string fileName = await testimonial.Photo.SaveImg(_env.WebRootPath, path);
                dbtestimonial.Image = fileName;
            }
            dbtestimonial.Name = testimonial.Name;
            dbtestimonial.Title = testimonial.Title;
            dbtestimonial.Position = testimonial.Position;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonial testimonial)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!testimonial.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (testimonial.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }

            string path = Path.Combine("img", "testimonial");

            string fileName = await testimonial.Photo.SaveImg(_env.WebRootPath, path);
            Testimonial newTestimonal = new Testimonial();
            newTestimonal.Name = testimonial.Name;
            newTestimonal.Title = testimonial.Title;
            newTestimonal.Image = fileName;
            newTestimonal.Position = testimonial.Position;
            await _db.Testimonials.AddAsync(newTestimonal);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Testimonial testimonial = _db.Testimonials.Find(id);
            if (id == null) return NotFound();
            return View(testimonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteTestimonial(int? id)
        {
            if (id == null) return NotFound();
            Testimonial testimonial = _db.Testimonials.Find(id);
            if (testimonial == null) return NotFound();
            string path = Path.Combine("img", "testimonial");
            Helper.DeleteImage(_env.WebRootPath, path, testimonial.Image);
            _db.Testimonials.Remove(testimonial);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Testimonial");
        }
        #endregion
    }
}
