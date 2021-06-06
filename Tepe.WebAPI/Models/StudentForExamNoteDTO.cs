using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tepe.WebAPI.Models
{
    public class StudentForExamNoteDTO
    {
       
        [Required]
        public int LessonId { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public int LessonNote { get; set; }
        [Required]
        public int NoteNumber { get; set; }
    }
}
