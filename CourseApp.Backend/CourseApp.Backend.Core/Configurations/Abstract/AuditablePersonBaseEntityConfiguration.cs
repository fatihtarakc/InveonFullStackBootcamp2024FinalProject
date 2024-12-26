namespace CourseApp.Backend.Core.Configurations.Abstract
{
    public abstract class AuditablePersonBaseEntityConfiguration<T> : AuditableBaseEntityConfiguration<T> where T : AuditablePersonBaseEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.Name).HasMaxLength(25);
            builder.ToTable(auditablePersonBaseEntity => auditablePersonBaseEntity.HasCheckConstraint("Name_MinLength_Control", "Len(Name) >= 2"));

            builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.Surname).HasMaxLength(25);
            builder.ToTable(auditablePersonBaseEntity => auditablePersonBaseEntity.HasCheckConstraint("Surname_MinLength_Control", "Len(Surname) >= 2"));

            builder.HasIndex(auditablePersonBaseEntity => auditablePersonBaseEntity.Email).IsUnique();
            builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.ToTable(auditablePersonBaseEntity => auditablePersonBaseEntity.HasCheckConstraint("Email_MinLength_Control", "Len(Email) >= 5"));

            builder.HasIndex(auditablePersonBaseEntity => auditablePersonBaseEntity.IdentityId).IsUnique();
            builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.IdentityId).HasColumnType("varchar");
            builder.ToTable(auditablePersonBaseEntity => auditablePersonBaseEntity.HasCheckConstraint("IdentityId_Length_Control", "Len(IdentityId) = 36"));

            //builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.VerificationCode).HasDefaultValue(HelperVerification.CodeGenerator());
            //builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.AccountStatus).HasDefaultValue(AccountStatus.Passive);
        }
    }
}