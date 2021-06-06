using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tepe.WebAPI.Models
{
    public class LessonForUpdateDTO
    {
        [Required]
        public int LessonId { get; set; }
        [Required]
        public string  LessonName { get; set; }
    }
}
