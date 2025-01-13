namespace InveonCourseApp.Backend.Dtos.OrderCourseDtos
{
    public class OrderCourseDto
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Relations
        public Guid OrderId { get; set; }
        public Guid CourseId { get; set; }
    }
}