namespace InveonCourseApp.Backend.Dtos.StudentCourseDtos
{
    public class StudentCourseDto
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Relations
        public Guid StudentId { get; set; }
        public Guid OrderId { get; set; }
    }
}