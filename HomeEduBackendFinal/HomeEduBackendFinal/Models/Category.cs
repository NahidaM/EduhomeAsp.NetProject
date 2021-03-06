﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        
        public virtual ICollection<UpCommingEvent> UpComingEvents { get; set; } 
        public virtual ICollection<Teacher> Teachers { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CourseCategory> CourseCategories { get; set; }
    }
}
