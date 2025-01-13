namespace InveonCourseApp.Backend.Dtos.OrderCourseDtos
{
    public class OrderCourseAddDto
    {
        // Relations
        public Guid OrderId { get; set; }
        public Guid CourseId { get; set; }
    }
}