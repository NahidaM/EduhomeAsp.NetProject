using HomeEduBackendFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<NoticeLeftInfo> NoticeLeftInfos { get; set; }
        public List<NoticeRightInfo> NoticeRightInfos { get; set; }
        public WhyUs WhyUs { get; set; } 
        public List<UpCommingEvent> UpComingEvents { get; set; }
        public Testimonial Testimonial { get; set; } 

    }
}
