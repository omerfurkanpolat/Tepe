using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tepe.WebAPI.Models
{
    public class NoteForReurnDTO
    {
        
        public int NoteId { get; set; }

        public int LessonId { get; set; }
     
        public string Id { get; set; }

        public int LessonNote { get; set; }

        public int NoteNumber { get; set; }
        public string LessonName { get; set; }
    }
}
