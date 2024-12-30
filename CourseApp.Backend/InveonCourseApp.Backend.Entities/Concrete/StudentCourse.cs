namespace InveonCourseApp.Backend.Entities.Concrete
{
    public class StudentCourse : AuditableBaseEntity
    {
        // Relations
        public Guid StudentId { get; init; }
        public virtual Student? Student { get; set; }
        public Guid CourseId { get; init; }
        public virtual Course? Course { get; set; }
    }
}