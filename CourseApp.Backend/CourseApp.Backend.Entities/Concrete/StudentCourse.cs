namespace CourseApp.Backend.Entities.Concrete
{
    public class StudentCourse : AuditableBaseEntity
    {
        // Relations
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course? Course { get; set; }
    }
}