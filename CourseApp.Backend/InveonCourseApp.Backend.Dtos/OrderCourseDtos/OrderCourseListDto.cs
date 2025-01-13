namespace InveonCourseApp.Backend.Dtos.OrderCourseDtos
{
    public class OrderCourseListDto
    {
        public Guid Id { get; set; }

        // Relations
        public Guid OrderId { get; set; }
        public Guid CourseId { get; set; }
    }
}