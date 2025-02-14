﻿namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class StudentConfiguration : AuditablePersonBaseEntityConfiguration<Student>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.Property(student => student.Birthdate).HasColumnType("date");
            builder.ToTable(student => student.HasCheckConstraint("Student_Birthdate_MinAge_Control", "Year(BirthDate) <= (Year(GetDate()) - 7)"));
        }
    }
}