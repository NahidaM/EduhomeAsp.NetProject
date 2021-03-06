﻿using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WhyUsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public WhyUsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public IActionResult Index()
        {
            WhyUs whyUs = _db.WhyUs.FirstOrDefault();
            return View(whyUs);
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            WhyUs whyUs = _db.WhyUs.FirstOrDefault(p => p.Id == id);
            if (whyUs == null) return NotFound();
            return View(whyUs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, WhyUs whyus)
        {
            if (id == null) return NotFound();
            WhyUs dbWhyus = await _db.WhyUs.FindAsync(id);
            if (dbWhyus == null) return NotFound();
            dbWhyus.Answer = whyus.Answer;
            dbWhyus.Question = whyus.Question;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
