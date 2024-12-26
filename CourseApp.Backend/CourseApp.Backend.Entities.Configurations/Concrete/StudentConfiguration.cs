namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class StudentConfiguration : AuditablePersonBaseEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
        }
    }
}