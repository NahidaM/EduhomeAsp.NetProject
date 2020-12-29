using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM
            {
               About = _db.Abouts.FirstOrDefault(),
               Testimonial = _db.Testimonials.FirstOrDefault(),
               VideoTour = _db.VideoTours.FirstOrDefault(),
               NoticeLeftInfos = _db.NoticeLeftInfos.ToList()  
            };
            return View(aboutVM);
        }
    }
}
