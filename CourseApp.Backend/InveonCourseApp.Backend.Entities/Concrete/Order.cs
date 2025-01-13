namespace InveonCourseApp.Backend.Entities.Concrete
{
    public class Order : AuditableBaseEntity
    {
        public Order()
        {
            OrderCourses = new HashSet<OrderCourse>();
        }

        public int TotalCourseAmount { get; set; }
        public decimal TotalCoursePrice { get; set; }
        public Currency Currency { get; set; }
        public ShoppingStatus ShoppingStatus { get; set; }

        // Relations
        public Guid StudentId { get; init; }
        public virtual ICollection<OrderCourse> OrderCourses { get; set; }
    }
}