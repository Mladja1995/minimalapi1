using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Diligent.MinimalAPI.Models
{
    public class Course
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int Semestar { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int ProfesorId { get; set; }
    }
}
