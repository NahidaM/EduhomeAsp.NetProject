using HomeEduBackendFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.ViewModels
{
    public class AboutVM
    {
        public About About { get; set; }
        public Testimonial Testimonial { get; set; }
        public VideoTour VideoTour { get; set; }
        public List<NoticeLeftInfo> NoticeLeftInfos { get; set; } 
    }
}
