namespace InveonCourseApp.Backend.Core.Configurations.Abstract
{
    public abstract class AuditablePersonBaseEntityConfiguration<T> : AuditableBaseEntityConfiguration<T> where T : AuditablePersonBaseEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.Name).HasMaxLength(25);
            builder.ToTable(auditablePersonBaseEntity => auditablePersonBaseEntity.HasCheckConstraint($"{typeof(T).Name}_Name_MinLength_Control", "Len(Name) >= 2"));

            builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.Surname).HasMaxLength(25);
            builder.ToTable(auditablePersonBaseEntity => auditablePersonBaseEntity.HasCheckConstraint($"{typeof(T).Name}_Surname_MinLength_Control", "Len(Surname) >= 2"));

            builder.HasIndex(auditablePersonBaseEntity => auditablePersonBaseEntity.Email).IsUnique();
            builder.Property(auditablePersonBaseEntity => auditablePersonBaseEntity.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.ToTable(auditablePersonBaseEntity => auditablePersonBaseEntity.HasCheckConstraint($"{typeof(T).Name}_Email_MinLength_Control", "Len(Email) >= 5"));

            builder.HasIndex(auditablePersonBaseEntity => auditablePersonBaseEntity.IdentityId).IsUnique();
        }
    }
}