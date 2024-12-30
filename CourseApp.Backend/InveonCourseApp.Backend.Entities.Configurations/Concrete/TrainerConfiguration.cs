namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class TrainerConfiguration : AuditablePersonBaseEntityConfiguration<Trainer>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);

            builder.Property(trainer => trainer.Birthdate).HasColumnType("date");
            builder.ToTable(trainer => trainer.HasCheckConstraint("Trainer_Birthdate_MinAge_Control", "Year(BirthDate) <= (Year(GetDate()) - 18)"));
        }
    }
}