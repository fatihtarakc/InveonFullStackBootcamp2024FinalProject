namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class CourseConfiguration : AuditableBaseEntityConfiguration<Course>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(course => course.ImageUrl).HasMaxLength(250);
            builder.ToTable(course => course.HasCheckConstraint("Course_ImageUrl_MinLength_Control", "Len(ImageUrl) >= 5"));

            builder.Property(course => course.Name).HasColumnType("nvarchar").HasMaxLength(100);
            builder.ToTable(course => course.HasCheckConstraint("Course_Name_MinLength_Control", "Len(Name) >= 2"));

            builder.Property(course => course.Description).HasColumnType("nvarchar").HasMaxLength(450);
            builder.ToTable(course => course.HasCheckConstraint("Course_Description_MinLength_Control", "Len(Description) >= 5"));

            builder.Property(course => course.Price).HasColumnType("decimal(10,2)");
            builder.ToTable(course => course.HasCheckConstraint("Course_Price_Min_Control", "Price >= 0"));
        }
    }
}