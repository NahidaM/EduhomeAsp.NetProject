using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Models
{
    public class Course
    {
        public int Id { get; set; } 
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Starts { get; set; } 
        public int Duration { get; set; }
        public string ClassDuration { get; set; }
        public string SkilLevel { get; set; }
        public string Language { get; set; }
        public int StudentsCount { get; set; }
        public string Assesments { get; set; }
        public int CourseFee { get; set; } 
        public string AboutCourse { get; set; }
        public string HowToApply { get; set; }
        public string Certification { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CourseCategory> CourseCategories { get; set; } 

    }
}
