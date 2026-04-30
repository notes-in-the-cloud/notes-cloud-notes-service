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

        public void Delete(Guid userId, Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Note GetById(Guid userId, Guid id)
        {
            throw new NotImplementedException();
        }

        public Note Update(Guid userId, Guid noteId, UpdateNoteDto updatedNote)
        {
            throw new NotImplementedException();
        }
    }
}
