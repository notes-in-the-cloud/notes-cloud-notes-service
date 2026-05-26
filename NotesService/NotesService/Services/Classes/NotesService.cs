using Dapper;
using NotesService.Models;
using NotesService.Services.Interfaces;
using Npgsql;

namespace NotesService.Services.Classes
{
    public class NoteService : INotesService
    {
        private readonly string connectionString;

        public NoteService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection is not configured.");
        }

        private NpgsqlConnection CreateConnection() => new NpgsqlConnection(connectionString);
        public Note Create(Guid userId, NoteDto note)
        {
            using var connection = CreateConnection();
            var id = Guid.NewGuid();
            var now = DateTime.UtcNow;

            connection.Execute(
                @"INSERT INTO notes (id, user_id, title, content, color, created_at, updated_at) 
                  VALUES (@Id, @UserId, @Title, @Content, @Color, @CreatedAt, @UpdatedAt)",
                new { Id = id, UserId = userId, note.Title, note.Content, note.Color, CreatedAt = now, UpdatedAt = now }
                );

            return new Note
            {
                Id = id,
                UserId = userId,
                Title = note.Title,
                Content = note.Content,
                Color = note.Color,
                CreatedAt = now,
                UpdateAt = now,
            };
        }

        public void Delete(Guid userId, Guid id)
        {
            using var connection = CreateConnection();
            connection.Execute(
                "DELETE FROM notes WHERE id = @Id AND user_id = @UserId",
                new { Id = id, UserId = userId });
        }

        public List<Note> GetAll(Guid userId)
        {
            using var connection = CreateConnection();
            var notes = connection.Query<Note>(
                "SELECT id, user_id AS UserId, title, content, color, created_at AS CreatedAt, updated_at AS UpdatedAt FROM notes WHERE user_id = @UserId",
                new { UserId = userId });
            return notes.ToList();
        }

        public Note? GetById(Guid userId, Guid id)
        {
            using var connection = CreateConnection();
            return connection.QueryFirstOrDefault<Note>(
                "SELECT id, user_id AS UserId, title, content, color, created_at AS CreatedAt, updated_at AS UpdatedAt FROM notes WHERE id = @Id AND user_id = @UserId",
                new { Id = id, UserId = userId });
        }

        public Note? Update(Guid userId, Guid noteId, NoteDto updatedNote)
        {
            using var connection = CreateConnection();
            var now = DateTime.UtcNow;

            connection.Execute(
                @"UPDATE notes SET title = @Title, content = @Content, color = @Color, updated_at = @UpdatedAt 
                  WHERE id = @Id AND user_id = @UserId",
                new { updatedNote.Title, updatedNote.Content, updatedNote.Color, UpdatedAt = now, Id = noteId, UserId = userId });
            return GetById(userId, noteId);
        }
    }
}
