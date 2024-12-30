namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.Property(identityRole => identityRole.Id).HasColumnType("varchar").HasMaxLength(36);
            builder.ToTable(identityRole => identityRole.HasCheckConstraint("IdentityRole_Id_Length_Control", "Len(Id) = 36"));

            builder.HasIndex(identityRole => identityRole.Name).IsUnique();
            builder.Property(identityRole => identityRole.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.ToTable(identityRole => identityRole.HasCheckConstraint("IdentityRole_Name_MinLength_Control", "Len(Name) >= 2"));

            builder.HasIndex(identityRole => identityRole.NormalizedName).IsUnique();
            builder.Property(identityRole => identityRole.NormalizedName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.ToTable(identityRole => identityRole.HasCheckConstraint("IdentityRole_NormalizedName_MinLength_Control", "Len(NormalizedName) >= 2"));
        }
    }
}