using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Core.DataAccess;
using Tepe.Entities.Concrete;

namespace Tepe.Dal.Abstract
{
    public interface INoteDal: IEntityRepository<Note>
    {
        List<Note> GetStudentNoteByLessonId(string studentId, int lessonId);
    }
}
