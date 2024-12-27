namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class CategoryConfiguration : AuditableBaseEntityConfiguration<Category>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.HasIndex(category => category.Name).IsUnique();
            builder.Property(category => category.Name).HasMaxLength(50);
            builder.ToTable(category => category.HasCheckConstraint("Category_Name_MinLength_Control", "Len(Name) >= 2"));
        }
    }
}