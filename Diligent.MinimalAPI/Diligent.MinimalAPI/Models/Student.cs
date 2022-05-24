using System.ComponentModel.DataAnnotations;

namespace Diligent.MinimalAPI.Models
{
    public class Student
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int IndexNum { get; set; }
        
    }
}
