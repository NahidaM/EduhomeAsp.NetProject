using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db) 
        {
            _db = db;
        } 

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Course course = _db.Courses.FirstOrDefault(c => c.Id == id);
            return View(course);
        } 
    }
}
