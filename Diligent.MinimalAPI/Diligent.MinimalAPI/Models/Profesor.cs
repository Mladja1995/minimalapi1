using System.ComponentModel.DataAnnotations;

namespace Diligent.MinimalAPI.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int CourseId { get; set; }
        public int BookId { get; set; }
    }
}
