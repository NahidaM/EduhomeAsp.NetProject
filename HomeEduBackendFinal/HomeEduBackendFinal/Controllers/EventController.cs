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
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        public EventController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["GetUpComingEvents"] = searchString;
            var eventQuery = from x in _db.UpComingEvents select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                eventQuery = eventQuery.Where(x => x.Title.Contains(searchString));
                return View(await eventQuery.AsNoTracking().ToListAsync());
            }
            List<UpCommingEvent> events = _db.UpComingEvents.Take(8).OrderByDescending(p => p.Id).ToList();
            return View(events);
        }
        public IActionResult Detail(int? id)
        {
            UpCommingEvent UpComingEvent = _db.UpComingEvents.Include(c => c.SpeakerEvents).ThenInclude(p => p.Speaker).FirstOrDefault(p => p.Id == id);
            return View(UpComingEvent);
        }

    }
}
