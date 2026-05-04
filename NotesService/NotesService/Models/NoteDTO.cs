using System.ComponentModel.DataAnnotations;

namespace NotesService.Models
{
    public class NoteDto
    {
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Content { get; set; }
        [Required]
        public required string Color { get; set; }
    }
}
