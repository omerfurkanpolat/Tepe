using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tepe.Core.Entities;

namespace Tepe.Entities.Concrete
{
    public class Lesson:IEntity
    {

        public int LessonId { get; set; }
        
        public string LessonName { get; set; }
        public List<Student> Students { get; set; }
        public List<Note> Notes { get; set; }



    }
}
