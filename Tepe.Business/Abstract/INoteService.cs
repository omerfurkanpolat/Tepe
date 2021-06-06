using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Entities.Concrete;

namespace Tepe.Business.Abstract
{
    public interface INoteService
    {
        void CreateNote(Note note);

        List<Note> GetUserNoteByLessonId(string studentId, int lessonId);
        
    }
}
