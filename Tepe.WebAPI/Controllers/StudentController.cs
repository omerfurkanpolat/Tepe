using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tepe.Business.Abstract;
using Tepe.Core.Constant;
using Tepe.Entities.Concrete;
using Tepe.WebAPI.Models;

namespace Tepe.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UserManager<Student> _usermanager;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;


        public StudentController(UserManager<Student> usermanager, IMapper mapper, INoteService noteService)
        {
            _usermanager = usermanager;
            _mapper = mapper;
            _noteService = noteService;
        }

        [HttpGet("get-user")]
        public async Task<ActionResult> GetUser()
        {
      
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!string.IsNullOrEmpty(studentId))
            {
                var student = await _usermanager.FindByIdAsync(studentId);
                if (student!=null)
                {
                    var result = _mapper.Map<StudentForReturnDTO>(student);
                    return Ok(result);
                }
            }
            return BadRequest(Messages.StudentNotFound);
        }
        [HttpPost("get-all-notes")]
        public ActionResult GetAllExamNote()
        {
            return Ok();
        }
        [HttpPost("get-lesson-notes/{id}")]
        public ActionResult GetNoteByLessonId(int id)
        {
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var note = _noteService.GetUserNoteByLessonId(studentId, id).OrderBy(x=>x.NoteNumber);
            
            return Ok();
        }
    }
}
