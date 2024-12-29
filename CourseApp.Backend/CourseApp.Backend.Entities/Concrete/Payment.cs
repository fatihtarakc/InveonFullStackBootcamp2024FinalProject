namespace CourseApp.Backend.Entities.Concrete
{
    public class Payment : AuditableBaseEntity
    {
        public int TotalCourseAmount { get; set; }
        public decimal TotalCoursePrice { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public Guid StudentId { get; init; }
        public Guid OrderId { get; init; }
    }
}