namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class AdminConfiguration : AuditablePersonBaseEntityConfiguration<Admin>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            base.Configure(builder);
        }
    }
}