using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Diligent.MinimalAPI.Models
{
    public class Classroom
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
