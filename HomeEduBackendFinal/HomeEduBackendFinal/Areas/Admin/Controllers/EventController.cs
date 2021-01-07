using AutoMapper;
using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Extentions;
using HomeEduBackendFinal.Helpers;
using HomeEduBackendFinal.Models;
using HomeEduBackendFinal.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] 
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public EventController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        #region Index
        public IActionResult Index()
        {
            return View(_db.UpComingEvents.Include(c => c.Category).Where(c => c.Category.IsDeleted == false).
                Include(e => e.SpeakerEvents).ThenInclude(c => c.Speaker).ToList());
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.Speaker = _db.Speakers.Where(s => s.IsDeleted == false).ToList();
            ViewBag.Category = new SelectList(_db.Categories.Where(c => c.IsDeleted == false).ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UpComingEventCreateVM upComingEventCreateVM, int speakerId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!upComingEventCreateVM.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return BadRequest(ModelState);
            }

            if (upComingEventCreateVM.Photo.MaxLength(200))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return BadRequest(ModelState);
            }

            string path = Path.Combine("img", "event");
            UpCommingEvent upComingEvent = new UpCommingEvent
            {
                Id = upComingEventCreateVM.Id,
                Title = upComingEventCreateVM.Title,
                Image = await upComingEventCreateVM.Photo.SaveImg(_env.WebRootPath, path),
                Month = upComingEventCreateVM.Month,
                Day = upComingEventCreateVM.Day,
                Location = upComingEventCreateVM.Location,
                StartTime = upComingEventCreateVM.StartTime,
                EndTime = upComingEventCreateVM.EndTime,
                Description = upComingEventCreateVM.Description,
                CategoryId = upComingEventCreateVM.CategoryId
            };
            await _db.UpComingEvents.AddAsync(upComingEvent);
            await _db.SaveChangesAsync();

            #region SubscribedEmail
            List<SubscribedEmail> emails = _db.SubscribedEmails.Where(e => e.HasDeleted == false).ToList();
            foreach (SubscribedEmail email in emails)
            {
                SendEmail(email.Email, "Yeni bir event yaradildi.", "<h1>Yeni bir event yaradildi</h1>");
            }
            #endregion

            var speaker = _db.Speakers.Include(p => p.SpeakerEvents).ThenInclude(p => p.UpComingEvent).
                    FirstOrDefault(p => p.Id == speakerId);

            SpeakerEvent speakerEvent = new SpeakerEvent
            {
                SpeakerId = speakerId,
                UpComingEventId = upComingEvent.Id
            };
            _db.SpeakerEvents.Add(speakerEvent);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion 

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return View();
            UpCommingEvent upComingEvent = _db.UpComingEvents.Include(c => c.Category).Include(c => c.SpeakerEvents).
                ThenInclude(c => c.Speaker).FirstOrDefault(p => p.Id == id);

            return View(upComingEvent);
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        { 
            ViewBag.Category = new SelectList(_db.Categories.ToList(), "Id", "Name");
            ViewBag.Speaker = _db.Speakers.ToList();
            if (id == null) return View();
            UpCommingEvent upComingEvent = _db.UpComingEvents.Include(c => c.SpeakerEvents).
                ThenInclude(c => c.Speaker).FirstOrDefault(p => p.Id == id);
            return View(upComingEvent);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpComingEventCreateVM upComingEventEdit)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var upComing = await _db.UpComingEvents.FirstOrDefaultAsync(x => x.Id == upComingEventEdit.Id);
            if (upComing == null) return NotFound();
            upComing.Location = upComingEventEdit.Location;
            upComing.Title = upComingEventEdit.Title;
            upComing.StartTime = upComingEventEdit.StartTime;
            upComing.Month = upComingEventEdit.Month;
            upComing.EndTime = upComingEventEdit.EndTime;
            upComing.Description = upComingEventEdit.Description;
            upComing.Day = upComingEventEdit.Day;
            upComing.CategoryId = upComingEventEdit.CategoryId;
            if (upComingEventEdit.Photo != null)
            {
                Helper.DeleteImage(_env.WebRootPath, "img/event", upComing.Image);
                upComing.Image = await upComingEventEdit.Photo.SaveImg(_env.WebRootPath, "img/event");
            }
            var speakerEvents = _db.SpeakerEvents.Where(x => x.UpComingEventId == upComing.Id);
            foreach (var item in speakerEvents)
            {
                upComing.SpeakerEvents.Remove(item);
            }
            await _db.SaveChangesAsync();
            //upComing.SpeakerEvents = upComingEventEdit.SpeakersId
           //.Select(x => new SpeakerEvent { SpeakerId = x }).ToList();
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            ViewBag.Speaker = _db.Speakers.ToList();
            if (id == null) return View();
            UpCommingEvent upComingEvent = _db.UpComingEvents.Include(c => c.SpeakerEvents).ThenInclude(c => c.Speaker).FirstOrDefault(p => p.Id == id);
            if (upComingEvent == null) return View();
            return View(upComingEvent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteEvent(int? id)
        {
            ViewBag.Speaker = _db.Speakers.ToList();
            if (id == null) return View();
            UpCommingEvent upComingEvent = _db.UpComingEvents.Include(c => c.SpeakerEvents).ThenInclude(c => c.Speaker).FirstOrDefault(p => p.Id == id);
            if (upComingEvent == null) return View();
            _db.UpComingEvents.Remove(upComingEvent);

            foreach (var item in upComingEvent.SpeakerEvents)
            {
                _db.SpeakerEvents.Remove(item);

            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region SendEmail
        public void SendEmail(string email, string subject, string htmlMessage)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                
                Credentials = new NetworkCredential()
                {
                    UserName = "nahidanm22@gmail.com",
                    Password = "nahida1999"
                }
            };
            MailAddress fromEmail = new MailAddress("nahidanm22@gmail.com", "Nahida");
            MailAddress toEmail = new MailAddress(email, "Nahida");
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = subject,
                Body = htmlMessage
            };
            message.To.Add(toEmail);
            client.Send(message);
        }
        #endregion
    }
}
