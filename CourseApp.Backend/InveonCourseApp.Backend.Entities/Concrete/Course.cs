namespace InveonCourseApp.Backend.Entities.Concrete
{
    public class Course : AuditableBaseEntity
    {
        public Course()
        {
            CourseOrders = new HashSet<CourseOrder>();
            StudentCourses = new HashSet<StudentCourse>();
        }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public Guid CategoryId { get; set; }
        public Guid TrainerId { get; set; }
        public virtual ICollection<CourseOrder> CourseOrders { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}