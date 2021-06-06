using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Core.DataAccess.EntityFramework;
using Tepe.Dal.Abstract;
using Tepe.Entities.Concrete;

namespace Tepe.Dal.Concrete.EntityFramework
{
    public class EfLessonStudentDal:  EfEntityRepositoryBase<StudentLesson, TepeContext>, ILessonStudentDal
    {
    }
}
