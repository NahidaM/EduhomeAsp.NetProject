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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        public TeacherController(AppDbContext db)
        {
            _db = db;

        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString,int? page)
        {
            ViewData["GetTeachers"] = searchString;
            var teacherQuery = from x in _db.Teachers select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                teacherQuery = teacherQuery.Where(x => x.FullName.Contains(searchString) && x.IsDeleted == false);
                return View(await teacherQuery.AsNoTracking().ToListAsync());
            }
            else
            {
                ViewBag.PageCount = Math.Ceiling((decimal)_db.Teachers.Count() / 3);
                ViewBag.Page = page;
                if (page == null)
                {
                    return View(_db.Teachers.OrderByDescending(p => p.Id).Take(3).ToList());
                }
                else
                {
                    return View(_db.Teachers.OrderByDescending(p => p.Id).Skip(((int)page - 1) * 3).Take(3).ToList());
                }
            }

        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _db.Teachers.FirstOrDefault(p => p.Id == id);
            return View(teacher);
        }
    }
}
