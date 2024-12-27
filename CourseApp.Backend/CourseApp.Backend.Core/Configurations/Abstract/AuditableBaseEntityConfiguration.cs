namespace CourseApp.Backend.Core.Configurations.Abstract
{
    public abstract class AuditableBaseEntityConfiguration<T> : BaseEntityConfiguration<T> where T : AuditableBaseEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(auditableBaseEntity => auditableBaseEntity.CreatedBy).HasMaxLength(36);
            builder.ToTable(auditableBaseEntity => auditableBaseEntity.HasCheckConstraint($"{typeof(T).Name}_CreatedBy_MinLength_Control", "Len(CreatedBy) >= 1"));

            builder.Property(auditableBaseEntity => auditableBaseEntity.DeletedBy).HasMaxLength(36);

            builder.Property(auditableBaseEntity => auditableBaseEntity.ModifiedBy).HasMaxLength(36);
        }
    }
}