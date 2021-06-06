
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tepe.Core.Entities;

namespace Tepe.Entities.Concrete
{
    public class Student: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string IdentityNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Lesson> Lessons { get; set; }
       


    }
}
