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
            
        }

        public IActionResult Index()
        {
            return View(_db.UpComingEvents.Include(c => c.Category).Where(c => c.Category.IsDeleted == false).
                Include(e => e.SpeakerEvents).ThenInclude(c => c.Speaker).ToList());

        }


        public IActionResult Create()
        {
            ViewBag.Speaker = _db.Speakers.Where(s => s.IsDeleted == false).ToList();
            ViewBag.Category = new SelectList(_db.Categories.Where(c => c.IsDeleted == false).ToList(), "Id", "Name");
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create([FromForm] UpComingEventCreateVM upComingEventCreateVM)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!upComingEventCreateVM.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return BadRequest(ModelState);
            }

            if (upComingEventCreateVM.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return BadRequest(ModelState);
            }
            if (upComingEventCreateVM.SpeakerEventsId == null)
            {
                ModelState.AddModelError("", "Speaker Secmelisiniz!");
                return BadRequest(ModelState);
            }
            string path = Path.Combine("img", "event");
            UpCommingEvent upComingEvent = new UpCommingEvent
            {
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
            foreach (var speakerId in upComingEventCreateVM.SpeakerEventsId)
            {
                var speaker = _db.Speakers.Include(p => p.SpeakerEvents).ThenInclude(p => p.UpComingEvent).
                    FirstOrDefault(p => p.Id == speakerId);
                foreach (var se in speaker.SpeakerEvents)
                {
                    if (upComingEvent.StartTime > se.UpComingEvent.StartTime && upComingEvent.EndTime < se.UpComingEvent.EndTime)
                    {
                        ModelState.AddModelError("", "Busy");
                        return BadRequest(ModelState);

                    }

                }

                SpeakerEvent speakerEvent = new SpeakerEvent
                {
                    SpeakerId = speakerId,
                    UpComingEventId = upComingEvent.Id

                };
                _db.SpeakerEvents.Add(speakerEvent);

                await _db.SaveChangesAsync();
            }
          

            return Ok($"{upComingEvent.Id} li element yaradildi");


        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return View();
            UpCommingEvent upComingEvent = _db.UpComingEvents.Include(c => c.Category).Include(c => c.SpeakerEvents).
                ThenInclude(c => c.Speaker).FirstOrDefault(p => p.Id == id);

            return View(upComingEvent);
        }

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

        public async Task<IActionResult> Update([FromForm] UpComingEventEditVM upComingEventEdit)
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
            if (upComingEventEdit.SpeakersId == null)
            {
                ModelState.AddModelError("", "Speaker Secmelisiniz!");
                return BadRequest(ModelState);
            }

            var speakerEvents = _db.SpeakerEvents.Where(x => x.UpComingEventId == upComing.Id);


            foreach (var item in speakerEvents)
            {
                upComing.SpeakerEvents.Remove(item);
            }
            await _db.SaveChangesAsync();

            upComing.SpeakerEvents = upComingEventEdit.SpeakersId
           .Select(x => new SpeakerEvent { SpeakerId = x }).ToList();




            await _db.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }


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
    }
}
