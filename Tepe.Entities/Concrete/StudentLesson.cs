using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tepe.Core.Entities;

namespace Tepe.Entities.Concrete
{
    public class StudentLesson:IEntity
    {
        [Key]
        public int StudentLessonId { get; set; }

        [ForeignKey("LessonId")]
        public int LessonId { get; set; }
        public Lesson Lessons { get; set; }

        [ForeignKey("Id")]
        public string Id { get; set; }
        public Student Students { get; set; }

    }
}
