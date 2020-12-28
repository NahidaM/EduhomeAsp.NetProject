using HomeEduBackendFinal.DAL;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        } 
    }
}
