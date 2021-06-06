using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Entities.Concrete;

namespace Tepe.Business.Abstract
{
    public interface ILessonService
    {
        void Add(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(int lessonId);
        Lesson GetLessonById(int lessonId);
    }
}
