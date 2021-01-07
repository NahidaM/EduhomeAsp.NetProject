using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        #region Search

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["GetCourses"] = searchString;
            var courseQuery = from x in _db.Courses select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                courseQuery = courseQuery.Where(x => x.Title.Contains(searchString) && x.IsDeleted == false);
                return View(await courseQuery.AsNoTracking().ToListAsync());
            }

            List<Course> events = _db.Courses.Where(c=>c.IsDeleted==false).OrderByDescending(p => p.Id).ToList();

            return View(events);
        }
        #endregion

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Course course = _db.Courses.FirstOrDefault(c => c.Id == id); 
            return View(course);
        }
    }
}
