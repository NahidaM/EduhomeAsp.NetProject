using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Extentions;
using HomeEduBackendFinal.Helpers;
using HomeEduBackendFinal.Models;
using HomeEduBackendFinal.ViewModels.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        #region Index
        public IActionResult Index()
        {
            return View(_db.Teachers.Where(t => t.IsDeleted == false).Include(c => c.Category).ToList());
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(_db.Categories.Where(c => c.IsDeleted == false).ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateVM teacherCreateVm, int CategoryId)
        {
            ViewBag.Category = new SelectList(_db.Categories.Where(c => c.IsDeleted == false).ToList(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            if (!teacherCreateVm.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (teacherCreateVm.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }
            Teacher newTeacher = new Teacher
            {
                FullName = teacherCreateVm.FullName,
                Position = teacherCreateVm.Position,
                Facebook = teacherCreateVm.Facebook,
                Pinterest = teacherCreateVm.Pinterest,
                VContact = teacherCreateVm.VContact,
                Image = await teacherCreateVm.Photo.SaveImg(_env.WebRootPath, "img/teacher"),
                Twitter = teacherCreateVm.Twitter,
                CategoryId = CategoryId,
                PhoneNumber = teacherCreateVm.PhoneNumber,
                Degree = teacherCreateVm.Degree,
                Hobby = teacherCreateVm.Hobby,
                Faculty = teacherCreateVm.Faculty,
                Skype = teacherCreateVm.Skype,
                Mail = teacherCreateVm.Mail,
                Experience = teacherCreateVm.Experience,
                AboutMe = teacherCreateVm.AboutMe
            };
            await _db.AddAsync(newTeacher);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return View();
            Teacher dbteacher = _db.Teachers.Include(c => c.Category).FirstOrDefault(p => p.Id == id);
            return View(dbteacher);
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            ViewBag.Category = new SelectList(_db.Categories.Where(c => c.IsDeleted == false).ToList(), "Id", "Name");
            if (id == null) return View();
            Teacher teacher = _db.Teachers.Include(c => c.Category).FirstOrDefault(p => p.Id == id);
            if (teacher == null) return View();
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TeacherEditVM teacherEditVM)
        {
            if (!ModelState.IsValid) return View();
            Teacher dbTeacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == teacherEditVM.Id);
            if (dbTeacher == null) return NotFound();
            dbTeacher.FullName = teacherEditVM.FullName;
            dbTeacher.Position = teacherEditVM.Position;
            dbTeacher.Facebook = teacherEditVM.Facebook;
            dbTeacher.Twitter = teacherEditVM.Twitter;
            dbTeacher.VContact = teacherEditVM.VContact;
            dbTeacher.Pinterest = teacherEditVM.Pinterest;
            dbTeacher.CategoryId = teacherEditVM.CategoryId;
            dbTeacher.AboutMe = teacherEditVM.AboutMe;
            dbTeacher.Degree = teacherEditVM.Degree;
            dbTeacher.Faculty = teacherEditVM.Faculty;
            dbTeacher.Hobby = teacherEditVM.Hobby;
            dbTeacher.Mail = teacherEditVM.Mail;
            dbTeacher.Skype = teacherEditVM.Skype;
            dbTeacher.PhoneNumber = teacherEditVM.PhoneNumber;
            dbTeacher.Experience = teacherEditVM.Experience;
            if (teacherEditVM.Photo != null)
            {
                Helper.DeleteImage(_env.WebRootPath, "img/teacher", dbTeacher.Image);
                dbTeacher.Image = await teacherEditVM.Photo.SaveImg(_env.WebRootPath, "img/teacher");

            }
            await _db.SaveChangesAsync();
            await Task.Delay(1000);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Teacher dbTeacher = _db.Teachers.Include(t => t.Category).FirstOrDefault(t => t.Id == id);
            if (dbTeacher == null) return NotFound();
            return View(dbTeacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteTeacher(int? id)
        {
            if (id == null) return NotFound();
            Teacher dbTeacher = _db.Teachers.Include(t => t.Category).FirstOrDefault(t => t.Id == id);
            if (dbTeacher == null) return NotFound();
            dbTeacher.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
