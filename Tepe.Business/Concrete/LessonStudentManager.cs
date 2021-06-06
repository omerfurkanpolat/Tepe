using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Business.Abstract;
using Tepe.Dal.Abstract;
using Tepe.Entities.Concrete;

namespace Tepe.Business.Concrete
{
    public class LessonStudentManager : ILessonStudentService
    {
        private readonly ILessonStudentDal _lessonStudentDal;

        public LessonStudentManager(ILessonStudentDal lessonStudentDal)
        {
            _lessonStudentDal = lessonStudentDal;
        }

        public void AssignStudentToLesson(StudentLesson studentLesson)
        {
            _lessonStudentDal.Add(studentLesson);
        }
    }
}
