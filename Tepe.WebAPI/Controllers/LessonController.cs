using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tepe.Business.Abstract;
using Tepe.Core.Constant;
using Tepe.Entities.Concrete;
using Tepe.WebAPI.Models;

namespace Tepe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        /// <summary>
        /// Bu alanı Rol bazlı şekilde admin veya öğretmen tipi kullanıcıların not girip  yönetimsel işlerin yapılacağı bir yapıda  kurmak istiyorum
        // ama haftasonu da çalıştığım için yeterli vaktim olmadı.
        /// </summary>
       
        private readonly ILessonService _lessonService;
        private readonly ILessonStudentService _lessonStudentService;
        private readonly INoteService _noteService;

        public LessonController(ILessonService lessonService, ILessonStudentService lessonStudentService, INoteService noteService)
        {
            _lessonService = lessonService;
            _lessonStudentService = lessonStudentService;
            _noteService = noteService;
        }

        [HttpPost("create-lesson")]
        public ActionResult CreateLesson(LessonForCreateDTO lessonForCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Lesson lesson = new Lesson()
            {
                LessonName = lessonForCreateDTO.LessonName
            };

            _lessonService.Add(lesson);
            return Ok();
        }
        [HttpPost("update-lesson")]
        public ActionResult UpdateLesson(LessonForUpdateDTO lessonForUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Lesson lesson = _lessonService.GetLessonById(lessonForUpdateDTO.LessonId);
            if (lesson==null)
            {
                return BadRequest(Messages.LessonNotFound);
            }
            lesson.LessonName = lessonForUpdateDTO.LessonName;
            _lessonService.Update(lesson);
            return Ok();
        }
        [HttpDelete("delete-lesson/{id}")]
        public ActionResult DeleteLesson(int id)
        {
            _lessonService.Delete(id);
            return Ok();
        }

        [HttpPost("assign-student-to-lesson")]
        public ActionResult AssignStudentToLesson(StudentForAssignDTO studentForAssignDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            StudentLesson studentLesson = new StudentLesson()
            {
                LessonId = studentForAssignDTO.LessonId,
                Id = studentForAssignDTO.StudentId
            };
            _lessonStudentService.AssignStudentToLesson(studentLesson);
            return Ok();
        }

        [HttpPost("enter-exam-note")]
        public ActionResult EnterExamNote(StudentForExamNoteDTO studentForExamDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Note note = new Note()
            {
                LessonId = studentForExamDTO.LessonId,
                Id = studentForExamDTO.Id,
                LessonNote = studentForExamDTO.LessonNote,
                NoteNumber = studentForExamDTO.NoteNumber
            };
            _noteService.CreateNote(note);
            return Ok();
        }


    }
}
