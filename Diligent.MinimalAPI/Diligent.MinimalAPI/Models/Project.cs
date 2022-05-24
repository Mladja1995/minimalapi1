using System.ComponentModel.DataAnnotations;

namespace Diligent.MinimalAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ProfesorId { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        public string? Technology { get; set; }

    }
}
