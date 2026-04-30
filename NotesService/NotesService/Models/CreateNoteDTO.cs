namespace NotesService.Models
{
    public class CreateNoteDto
    {
        public int? Id { get; set; }

        public int Id_User { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Color { get; set; }

        public string Priority { get; set; }

        public string UpdatedAt { get; set; }

        public string CreatedAt { get; set; }
    }
}
