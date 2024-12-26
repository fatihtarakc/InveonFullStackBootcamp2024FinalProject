namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class OrderConfiguration : AuditableBaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property(order => order.StudentId).HasColumnType("varchar");
            builder.ToTable(order => order.HasCheckConstraint("StudentId_Length_Control", "Len(StudentId) = 36"));
        }
    }
}