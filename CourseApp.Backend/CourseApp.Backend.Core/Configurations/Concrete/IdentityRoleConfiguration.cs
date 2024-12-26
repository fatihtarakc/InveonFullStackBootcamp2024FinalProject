namespace CourseApp.Backend.Core.Configurations.Concrete
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasIndex(identityRole => identityRole.Name).IsUnique();
            builder.Property(identityRole => identityRole.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.ToTable(identityRole => identityRole.HasCheckConstraint("Name_MinLength_Control", "Len(Name) >= 2"));

            builder.HasIndex(identityRole => identityRole.NormalizedName).IsUnique();
            builder.Property(identityRole => identityRole.NormalizedName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.ToTable(identityRole => identityRole.HasCheckConstraint("NormalizedName_MinLength_Control", "Len(NormalizedName) >= 2"));
        }
    }
}