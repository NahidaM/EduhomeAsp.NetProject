using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Helpers;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Blog> blogs = _db.Blogs.Where(blg => blg.IsDelete == false)
                .Include(blg => blg.BlogDetail).OrderByDescending(blg => blg.CreatedTime).ToList();
            return View(blogs);
        }

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            Blog blog = await _db.Blogs.Include(blg => blg.BlogDetail).FirstOrDefaultAsync(blg => blg.Id == id);
            return View(blog);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (blog == null) return RedirectToAction("Error", "Home");

            if (!ModelState.IsValid) return RedirectToAction("Error", "Home");

            Blog blogs = new Blog();
            Blog blogDetail = new Blog();
            bool isExist = _db.Blogs.Where(cr => cr.IsDelete == false)
               .Any(cr => cr.Title == blog.Title);
            if (isExist)
            {
                ModelState.AddModelError("Blogs.Title", "This name already exist");
                return View();
            }
            #region Images
            //if (!blog.Photo.IsImage())
            //{
            //    ModelState.AddModelError("Photos", $"{blog.Photo.FileName} - not image type");
            //    return View(blogs);
            //}

            //string folder = Path.Combine("img", "blog");
            //string fileName = await blog.Photo.SaveImg(_env.WebRootPath, folder);
            //if (fileName == null)
            //{
            //    return Content("Error");
            //}
            //blogs.Image = fileName;
            #endregion

            blogs.Title = blog.Title;
            blogs.Author = blog.Author;
            blogs.WriteTime = blog.WriteTime;
            blog.CreatedTime = DateTime.Now;
            blogs.CreatedTime = blog.CreatedTime;
            await _db.Blogs.AddAsync(blogs);
            await _db.SaveChangesAsync();

            blogDetail.BlogDetail = blog.BlogDetail;
            blogDetail.Id = blogs.Id;
            await _db.Blogs.AddAsync(blogDetail);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            ViewBag.Categ = _db.Categories.ToList();

            Blog blogs = _db.Blogs.Include(blg => blg.BlogDetail).FirstOrDefault(blg => blg.Id == id);
            return View(blogs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            ViewBag.Categ = _db.Categories.ToList();
            if (id == null) return NotFound();


            Blog DBblog = await _db.Blogs.Include(c => c.BlogDetail).FirstOrDefaultAsync(c => c.Id == id);
            Blog isExist = _db.Blogs.Where(cr => cr.IsDelete == false).FirstOrDefault(cr => cr.Id == id);
            bool exist = _db.Blogs.Where(cr => cr.IsDelete == false).Any(cr => cr.Title == blog.Title);

            if (exist)
            {
                if (isExist.Title != blog.Title)
                {
                    ModelState.AddModelError("Title", "Bu adda artiq var zehmet olmasa bashqa adda yaradin");
                    return View(DBblog);
                }
            }

            //if (blog.Photo != null)
            //{
            //    if (!blog.Photo.IsImage())
            //    {
            //        ModelState.AddModelError("Photo", $"{blog.Photo.FileName} - not image type");
            //        return View(blogOld);
            //    }

            //    string folder = Path.Combine("img", "blog");
            //    string fileName = await blog.Photo.SaveImg(_env.WebRootPath, folder);
            //    if (fileName == null)
            //    {
            //        return Content("Error");
            //    }

            //    Helper.DeleteImage(_env.WebRootPath, folder, blogOld.Image);
            //    blogOld.Image = fileName;
            //}

            DBblog.Title = blog.Title;
            DBblog.BlogDetail = blog.BlogDetail; 
            DBblog.Author = blog.Author;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return RedirectToAction("Error", "Home"); ;
            Blog blog = _db.Blogs.FirstOrDefault(c => c.Id == id);
            if (blog == null) return RedirectToAction("Error", "Home"); ;

            if (!blog.IsDelete)
            {
                blog.IsDelete = true;
            }
            else
                blog.IsDelete = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion 

    }
}
