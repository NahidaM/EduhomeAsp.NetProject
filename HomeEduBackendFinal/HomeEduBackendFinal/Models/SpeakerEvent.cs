using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal.Models
{
    public class SpeakerEvent
    {
        public int Id { get; set; }
        public int UpComingEventId { get; set; }
        public UpCommingEvent UpComingEvent { get; set; } 
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; } 
    }
}
