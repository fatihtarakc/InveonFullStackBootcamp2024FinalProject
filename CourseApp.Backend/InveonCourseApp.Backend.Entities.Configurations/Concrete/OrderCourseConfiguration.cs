namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class OrderCourseConfiguration : AuditableBaseEntityConfiguration<OrderCourse>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<OrderCourse> builder)
        {
            base.Configure(builder);

            builder.HasOne(orderCourse => orderCourse.Order).WithMany(order => order.OrderCourses).HasForeignKey(orderCourse => orderCourse.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(orderCourse => orderCourse.Course).WithMany(course => course.OrderCourses).HasForeignKey(orderCourse => orderCourse.CourseId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}