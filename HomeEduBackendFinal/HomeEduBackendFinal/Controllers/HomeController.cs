using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using HomeEduBackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        { 
            HomeVM homeVM = new HomeVM
            {
                Sliders = _db.Sliders.ToList(),
                NoticeLeftInfos = _db.NoticeLeftInfos.ToList(),
                NoticeRightInfos = _db.NoticeRightInfos.ToList(),
                WhyUs = _db.WhyUs.FirstOrDefault(),
                UpComingEvents = _db.UpComingEvents.ToList(),
                Testimonial = _db.Testimonials.FirstOrDefault() 
            };


            return View(homeVM);
        } 
    }
}
