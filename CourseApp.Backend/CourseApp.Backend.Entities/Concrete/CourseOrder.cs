namespace CourseApp.Backend.Entities.Concrete
{
    public class CourseOrder : AuditableBaseEntity
    {
        // Relations
        public Guid CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}