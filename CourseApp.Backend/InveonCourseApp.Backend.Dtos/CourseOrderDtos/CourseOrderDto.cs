namespace InveonCourseApp.Backend.Dtos.CourseOrderDtos
{
    public class CourseOrderDto
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Relations
        public Guid CourseId { get; set; }
        public Guid OrderId { get; set; }
    }
}