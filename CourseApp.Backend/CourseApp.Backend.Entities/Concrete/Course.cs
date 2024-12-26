namespace CourseApp.Backend.Entities.Concrete
{
    public class Course : AuditableBaseEntity
    {
        public Course()
        {
            CourseOrders = new HashSet<CourseOrder>();
            StudentCourses = new HashSet<StudentCourse>();
        }

        public string PhotoUri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Relations
        public Guid CategoryId { get; set; }
        public Guid TrainerId { get; set; }
        public virtual ICollection<CourseOrder> CourseOrders { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}