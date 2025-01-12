namespace InveonCourseApp.Backend.Dtos.StudentCourseDtos
{
    public class StudentCourseListDto
    {
        public Guid Id { get; set; }

        // Relations
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}