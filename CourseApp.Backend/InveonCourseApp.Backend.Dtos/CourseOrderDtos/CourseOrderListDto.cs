namespace InveonCourseApp.Backend.Dtos.CourseOrderDtos
{
    public class CourseOrderListDto
    {
        public Guid Id { get; set; }

        // Relations
        public Guid CourseId { get; set; }
        public Guid OrderId { get; set; }
    }
}