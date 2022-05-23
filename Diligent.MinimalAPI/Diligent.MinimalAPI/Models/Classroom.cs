using Diligent.MinimalAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace Diligent.MinimalAPI.Models
{
    public class Classroom
    {
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
        public ClassroomType Type { get; set; }
    }
}
