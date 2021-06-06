using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tepe.WebAPI.Models
{
    public class LessonForCreateDTO
    {
        [Required]
        public string LessonName { get; set; }
    }
}
