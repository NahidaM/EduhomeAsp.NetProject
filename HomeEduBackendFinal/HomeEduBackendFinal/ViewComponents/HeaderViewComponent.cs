﻿using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public HeaderViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio model = _db.Bios.FirstOrDefault();
            return View(await Task.FromResult(model)); 
        }
    }
}
