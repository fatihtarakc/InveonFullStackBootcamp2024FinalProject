namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class TrainerConfiguration : AuditablePersonBaseEntityConfiguration<Trainer>
    {
        public override void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);

            builder.Property(trainer => trainer.Birthdate).HasColumnType("date");
            builder.ToTable(trainer => trainer.HasCheckConstraint("Birthdate_MinAge_Control", "Year(BirthDate) <= (Year(GetDate()) - 18)"));
        }
    }
}