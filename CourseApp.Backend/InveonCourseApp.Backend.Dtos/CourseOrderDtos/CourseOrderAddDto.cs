namespace InveonCourseApp.Backend.Dtos.CourseOrderDtos
{
    public class CourseOrderAddDto
    {
        // Relations
        public Guid CourseId { get; set; }
        public Guid OrderId { get; set; }
    }
}