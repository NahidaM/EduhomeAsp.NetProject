using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using HomeEduBackendFinal.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Areas.Admin.Controllers
{
    public class SpeakController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;

        public SpeakController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;

        }
        public IActionResult Index()
        {
            return View(_db.Speakers.Where(t => t.IsDeleted == false).ToList());
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpeakerCreateVM speakerCreateVM)
        {


            if (!ModelState.IsValid) return View();
            //if (!speakerCreateVM.Photo.IsImage())
            //{
            //    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
            //    return View();
            //}

            //if (speakerCreateVM.Photo.MaxLength(2000))
            //{
            //    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
            //    return View();
            //}

            Speaker newSpeaker = new Speaker
            {
                Name = speakerCreateVM.Name,
                Position = speakerCreateVM.Position,
                //Image = await speakerCreateVM.Photo.SaveImg(_env.WebRootPath, "img/teacher"),
            };
            await _db.AddAsync(newSpeaker);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }

      
    }
}
