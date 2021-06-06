using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Business.Abstract;
using Tepe.Dal.Abstract;
using Tepe.Entities.Concrete;

namespace Tepe.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public void CreateNote(Note note)
        {
            _noteDal.Add(note);
        }

        public List<Note> GetUserNoteByLessonId(string studentId, int lessonId)
        {
            return _noteDal.GetStudentNoteByLessonId(studentId, lessonId);
        }
    }
}
