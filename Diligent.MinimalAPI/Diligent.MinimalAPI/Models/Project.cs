namespace Diligent.MinimalAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int ProfesorId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Technology { get; set; }

    }
}
