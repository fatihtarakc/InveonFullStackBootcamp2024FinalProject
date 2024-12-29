namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class PaymentConfiguration : AuditableBaseEntityConfiguration<Payment>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.ToTable(payment => payment.HasCheckConstraint("Payment_TotalCourseAmount_Min_Control", "TotalCourseAmount > 0"));

            builder.Property(payment => payment.TotalCoursePrice).HasColumnType("decimal(10,2)");
            builder.ToTable(payment => payment.HasCheckConstraint("Payment_TotalCoursePrice_Min_Control", "TotalCoursePrice >= 0"));

            builder.HasIndex(payment => payment.OrderId).IsUnique();
        }
    }
}