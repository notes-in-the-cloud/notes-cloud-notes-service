namespace NotesService.Models
{
    public class Note
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Color { get; set; }

        public Priority Priority { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public enum Priority
    {
        Urgent,
        High,
        Medium,
        Low,
        None
    }
}