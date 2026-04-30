using NotesService.Models;

namespace NotesService.Services.Interfaces
{
    public interface INotesService
    {
        List<Note> GetAll(Guid userId);
        Note GetById(Guid userId, Guid id);
        Note Create(Note note);
        void Delete(Guid userId, Guid id);

        Note Update(Guid userId, Guid noteId, UpdateNoteDto updatedNote);
    }
}
