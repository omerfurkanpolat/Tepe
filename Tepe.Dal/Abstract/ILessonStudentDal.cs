using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Core.DataAccess;
using Tepe.Entities.Concrete;

namespace Tepe.Dal.Abstract
{
    public interface ILessonStudentDal: IEntityRepository<StudentLesson>
    {
    }
}
