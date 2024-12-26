namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class PaymentConfiguration : AuditableBaseEntityConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.ToTable(payment => payment.HasCheckConstraint("TotalCourseAmount_Min_Control", "TotalCourseAmount > 0"));
            builder.ToTable(payment => payment.HasCheckConstraint("TotalCoursePrice_Min_Control", "TotalCoursePrice >= 0"));

            builder.Property(payment => payment.StudentId).HasColumnType("varchar");
            builder.ToTable(payment => payment.HasCheckConstraint("StudentId_Length_Control", "Len(StudentId) = 36"));

            builder.Property(payment => payment.OrderId).HasColumnType("varchar");
            builder.ToTable(payment => payment.HasCheckConstraint("OrderId_Length_Control", "Len(OrderId) = 36"));
        }
    }
}