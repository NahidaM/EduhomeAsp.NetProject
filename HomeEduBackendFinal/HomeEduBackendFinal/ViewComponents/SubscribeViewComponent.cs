using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.ViewComponents
{
    public class SubscribeViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public SubscribeViewComponent(AppDbContext db)
        {
            _db = db; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SubscribeVM subscribe = new SubscribeVM()
            {
                Subscribe = _db.Subscribes.FirstOrDefault() 
            };
            return View(await Task.FromResult(subscribe));
        } 
    }
}
