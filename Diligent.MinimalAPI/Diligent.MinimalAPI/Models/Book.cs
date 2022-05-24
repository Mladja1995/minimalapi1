using System.ComponentModel.DataAnnotations;

namespace Diligent.MinimalAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public int? PageNumber { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
    }
}
