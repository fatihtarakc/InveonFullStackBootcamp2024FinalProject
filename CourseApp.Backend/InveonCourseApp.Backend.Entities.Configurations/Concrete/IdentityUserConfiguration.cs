namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.Property(identityUser => identityUser.Id).HasColumnType("varchar").HasMaxLength(36);
            builder.ToTable(identityUser => identityUser.HasCheckConstraint("IdentityUser_Id_Length_Control", "Len(Id) = 36"));

            builder.HasIndex(identityUser => identityUser.Email).IsUnique();
            builder.Property(identityUser => identityUser.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.ToTable(identityUser => identityUser.HasCheckConstraint("IdentityUser_Email_MinLength_Control", "Len(Email) >= 10"));

            builder.HasIndex(identityUser => identityUser.UserName).IsUnique();
            builder.Property(identityUser => identityUser.UserName).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.ToTable(identityUser => identityUser.HasCheckConstraint("IdentityUser_UserName_MinLength_Control", "Len(UserName) >= 5"));

            builder.HasIndex(identityUser => identityUser.NormalizedEmail).IsUnique();
            builder.Property(identityUser => identityUser.NormalizedEmail).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.ToTable(identityUser => identityUser.HasCheckConstraint("IdentityUser_NormalizedEmail_MinLength_Control", "Len(NormalizedEmail) >= 10"));

            builder.HasIndex(identityUser => identityUser.NormalizedUserName).IsUnique();
            builder.Property(identityUser => identityUser.NormalizedUserName).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.ToTable(identityUser => identityUser.HasCheckConstraint("IdentityUser_NormalizedUserName_MinLength_Control", "Len(NormalizedUserName) >= 5"));
        }
    }
}