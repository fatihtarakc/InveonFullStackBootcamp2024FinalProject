namespace CourseApp.Backend.Entities.Concrete
{
    public class CourseOrder : AuditableBaseEntity
    {
        // Relations
        public Guid CourseId { get; init; }
        public virtual Course? Course { get; set; }
        public Guid OrderId { get; init; }
        public virtual Order? Order { get; set; }
    }
}