namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class PaymentConfiguration : AuditableBaseEntityConfiguration<Payment>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);
            
            builder.Property(payment => payment.Price).HasColumnType("decimal(10,2)");
            builder.ToTable(payment => payment.HasCheckConstraint("Payment_Price_Min_Control", "Price >= 0"));

            builder.HasIndex(payment => payment.OrderId).IsUnique();
        }
    }
}