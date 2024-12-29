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
        public Currency Currency { get; set; }

        // Relations
        public Guid CategoryId { get; init; }
        public Guid TrainerId { get; init; }
        public virtual ICollection<CourseOrder> CourseOrders { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}