namespace InveonCourseApp.Backend.Entities.Concrete
{
    public class Order : AuditableBaseEntity
    {
        public Order()
        {
            CourseOrders = new HashSet<CourseOrder>();
        }

        public int TotalCourseAmount { get; set; }
        public decimal TotalCoursePrice { get; set; }
        public Currency Currency { get; set; }
        public ShoppingStatus ShoppingStatus { get; set; }

        // Relations
        public Guid StudentId { get; init; }
        public virtual ICollection<CourseOrder> CourseOrders { get; set; }
    }
}