namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class CourseOrderConfiguration : AuditableBaseEntityConfiguration<CourseOrder>
    {
        public override void Configure(EntityTypeBuilder<CourseOrder> builder)
        {
            base.Configure(builder);

            builder.Property(courseOrder => courseOrder.CourseId).HasColumnType("varchar");
            builder.ToTable(courseOrder => courseOrder.HasCheckConstraint("CourseId_Length_Control", "Len(CourseId) = 36"));

            builder.Property(courseOrder => courseOrder.OrderId).HasColumnType("varchar");
            builder.ToTable(courseOrder => courseOrder.HasCheckConstraint("OrderId_Length_Control", "Len(OrderId) = 36"));

            builder.HasOne(courseOrder => courseOrder.Course).WithMany(course => course.CourseOrders).HasForeignKey(courseOrder => courseOrder.CourseId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(courseOrder => courseOrder.Order).WithMany(order => order.CourseOrders).HasForeignKey(courseOrder => courseOrder.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}