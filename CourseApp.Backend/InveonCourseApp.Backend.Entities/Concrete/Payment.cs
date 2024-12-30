namespace InveonCourseApp.Backend.Entities.Concrete
{
    public class Payment : AuditableBaseEntity
    {
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public Guid StudentId { get; init; }
        public Guid OrderId { get; init; }
    }
}