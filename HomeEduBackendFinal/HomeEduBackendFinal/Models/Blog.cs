using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Models
{
    public class Blog 
    {
        internal bool isDelete;

        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime WriteTime { get; set; }
        public int CommentCount { get; set; }
        public bool IsDelete { get; internal set; }
        public object BlogDetail { get; internal set; }
        public object CreatedTime { get; internal set; }
        public object Photo { get; internal set; }
    }
}
