namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class CourseConfiguration : AuditableBaseEntityConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(course => course.Name).HasMaxLength(50);
            builder.ToTable(course => course.HasCheckConstraint("Name_MinLength_Control", "Len(Name) >= 2"));

            builder.Property(course => course.Description).HasMaxLength(250);
            builder.ToTable(course => course.HasCheckConstraint("Description_MinLength_Control", "Len(Description) >= 5"));

            builder.ToTable(course => course.HasCheckConstraint("Price_Min_Control", "Price >= 0"));

            builder.Property(course => course.CategoryId).HasColumnType("varchar");
            builder.ToTable(course => course.HasCheckConstraint("CategoryId_Length_Control", "Len(CategoryId) = 36"));

            builder.Property(course => course.TrainerId).HasColumnType("varchar");
            builder.ToTable(course => course.HasCheckConstraint("TrainerId_Length_Control", "Len(TrainerId) = 36"));
        }
    }
}