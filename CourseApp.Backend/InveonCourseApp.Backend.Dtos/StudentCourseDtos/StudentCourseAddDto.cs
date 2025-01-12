namespace InveonCourseApp.Backend.Dtos.StudentCourseDtos
{
    public class StudentCourseAddDto
    {
        // Relations
        public Guid StudentId { get; set; }
        public Guid OrderId { get; set; }
    }
}