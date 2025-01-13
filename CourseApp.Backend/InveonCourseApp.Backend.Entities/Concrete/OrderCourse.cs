namespace InveonCourseApp.Backend.Entities.Concrete
{
    public class OrderCourse : AuditableBaseEntity
    {
        // Relations
        public Guid OrderId { get; init; }
        public virtual Order? Order { get; set; }
        public Guid CourseId { get; init; }
        public virtual Course? Course { get; set; }
    }
}