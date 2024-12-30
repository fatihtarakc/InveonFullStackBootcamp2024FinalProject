namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class OrderConfiguration : AuditableBaseEntityConfiguration<Order>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable(order => order.HasCheckConstraint("Order_TotalCourseAmount_Min_Control", "TotalCourseAmount > 0"));

            builder.Property(order => order.TotalCoursePrice).HasColumnType("decimal(10,2)");
            builder.ToTable(order => order.HasCheckConstraint("Order_TotalCoursePrice_Min_Control", "TotalCoursePrice >= 0"));
        }
    }
}