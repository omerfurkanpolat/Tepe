using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Business.Abstract;
using Tepe.Dal.Abstract;
using Tepe.Entities.Concrete;

namespace Tepe.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public void Add(Lesson lesson)
        {
            _lessonDal.Add(lesson);
        }

        public void Delete(int lessonId)
        {
            _lessonDal.Delete(new Lesson { LessonId = lessonId });
        }

        public Lesson GetLessonById(int lessonId)
        {
            return _lessonDal.Get(x => x.LessonId == lessonId);
        }

        public void Update(Lesson lesson)
        {
            _lessonDal.Update(lesson);
        }
    }
}
