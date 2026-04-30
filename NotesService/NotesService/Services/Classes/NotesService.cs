using NotesService.Models;
using NotesService.Services.Interfaces;

namespace NotesService.Services.Classes
{
    public class NoteService : INotesService
    {
        public Note Create(Note note)
        {
            throw new NotImplementedException();
        }

        public void Delete(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAll(int userId)
        {
            throw new NotImplementedException();
        }

        public Note GetById(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public Note Update(int userId, int noteId, UpdateNoteDto updatedNote)
        {
            throw new NotImplementedException();
        }
    }
}
