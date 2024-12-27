namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class CourseOrderConfiguration : AuditableBaseEntityConfiguration<CourseOrder>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<CourseOrder> builder)
        {
            base.Configure(builder);

            builder.HasOne(courseOrder => courseOrder.Course).WithMany(course => course.CourseOrders).HasForeignKey(courseOrder => courseOrder.CourseId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(courseOrder => courseOrder.Order).WithMany(order => order.CourseOrders).HasForeignKey(courseOrder => courseOrder.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}