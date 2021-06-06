using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tepe.Core.Entities;

namespace Tepe.Entities.Concrete
{
    public class Note:IEntity
    {
        [Key]
        public int NoteId { get; set; }

        [ForeignKey("LessonId")]
        public int LessonId { get; set; }
        public Lesson Lessons { get; set; }
        [ForeignKey("StudentId")]
        public string Id { get; set; }
       

        public int LessonNote { get; set; }

        public int NoteNumber { get; set; }
    }
}
