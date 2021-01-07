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
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            ViewData["GetBlog"] = searchString;
            var blogQuery = from x in _db.Blogs select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                blogQuery = blogQuery.Where(x => x.Title.Contains(searchString));
                return View(await blogQuery.AsNoTracking().ToListAsync());
            }
            else
            {
                ViewBag.PageCount = Math.Ceiling((decimal)_db.Blogs.Count() / 3);
                ViewBag.Page = page;
                if (page == null)
                {
                    return View(_db.Blogs.OrderByDescending(p => p.Id).Take(3).ToList());
                }
                else
                {
                    return View(_db.Blogs.OrderByDescending(p => p.Id).Skip(((int)page - 1) * 3).Take(3).ToList());
                }
            }

        }

        public IActionResult Detail()
        {
            return View();
        }

    }
}
