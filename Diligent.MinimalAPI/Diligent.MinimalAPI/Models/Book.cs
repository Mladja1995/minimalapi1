namespace Diligent.MinimalAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int? PageNumber { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
