using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tepe.WebAPI.Models
{
    public class StudentForAssignDTO
    {
        [Required]
        public int LessonId { get; set; }
        [Required]
        public string StudentId { get; set; }
    }
}
