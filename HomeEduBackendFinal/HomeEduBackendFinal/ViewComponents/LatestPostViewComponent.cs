﻿using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.ViewComponents
{
    public class LatestPostViewComponent: ViewComponent
    {
        private readonly AppDbContext _db;
        public LatestPostViewComponent(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<Blog> model = _db.Blogs.Take(take).OrderByDescending(b => b.Id).ToList();
            return View(await Task.FromResult(model));

        }
    }
}
