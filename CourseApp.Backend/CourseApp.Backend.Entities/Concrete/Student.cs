namespace CourseApp.Backend.Entities.Concrete
{
    public class Student : AuditablePersonBaseEntity
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public DateTime Birthdate { get; set; }

        // Relations
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}