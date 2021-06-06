using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
               return _context.Notes.Where(x => x.LessonId == lessonId && x.Id == studentId).Include(x => x.Lessons).OrderBy(x => x.NoteNumber).ToList();
            }
        
        }
    }
}
