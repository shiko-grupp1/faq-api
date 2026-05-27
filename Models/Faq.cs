namespace FAQ_API.Models
{
    public class Faq
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}