namespace CourseApp.Backend.Entities.Concrete
{
    public class Order : AuditableBaseEntity
    {
        public Order()
        {
            CourseOrders = new HashSet<CourseOrder>();
        }

        public ShoppingStatus ShoppingStatus { get; set; }

        // Relations
        public Guid StudentId { get; init; }
        public virtual ICollection<CourseOrder> CourseOrders { get; set; }
    }
}