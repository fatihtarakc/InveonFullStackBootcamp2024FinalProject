namespace CourseApp.Backend.Entities.Concrete
{
    public class Student : AuditablePersonBaseEntity
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        // Relations
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}