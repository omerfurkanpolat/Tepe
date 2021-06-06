using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Core.DataAccess.EntityFramework;
using Tepe.Dal.Abstract;
using Tepe.Entities.Concrete;

namespace Tepe.Dal.Concrete.EntityFramework
{
    public class EfNoteDal : EfEntityRepositoryBase<Note, TepeContext>, INoteDal
    {
        public List<Note> GetStudentNoteByLessonId(string studentId, int lessonId)
        {
            using (var _context = new TepeContext())
            {
              
            }
            throw new NotImplementedException();
        }
    }
}
