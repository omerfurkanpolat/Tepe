using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Entities.Concrete;

namespace Tepe.Business.Abstract
{
    public interface ILessonStudentService
    {
        void AssignStudentToLesson(StudentLesson studentLesson);
    }
}
