namespace CourseApp.Backend.Entities.Concrete
{
    public class Payment : AuditableBaseEntity
    {
        public int TotalCourseAmount { get; set; }
        public decimal TotalCoursePrice { get; set; }

        // Relations
        public Guid StudentId { get; set; }
        public Guid OrderId { get; set; }
    }
}