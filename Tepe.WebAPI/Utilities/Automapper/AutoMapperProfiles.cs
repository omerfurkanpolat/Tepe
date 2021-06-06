using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tepe.Entities.Concrete;
using Tepe.WebAPI.Models;

namespace Tepe.WebAPI.Utilities.Automapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentForReturnDTO>();
        }
    }
}
