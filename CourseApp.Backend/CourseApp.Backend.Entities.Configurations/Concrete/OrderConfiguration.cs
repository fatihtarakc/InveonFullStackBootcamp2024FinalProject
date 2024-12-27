namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class OrderConfiguration : AuditableBaseEntityConfiguration<Order>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
        }
    }
}