using NotesService.Models;

namespace NotesService.Services.Interfaces
{
    public interface INotesService
    {
        List<Note> GetAll(int userId);
        Note GetById(int userId, int id);
        Note Create(Note note);
        void Delete(int userId, int id);

        Note Update(int userId, int noteId, UpdateNoteDto updatedNote);
    }
}
