namespace CourseApp.Backend.Entities.Configurations.Concrete
{
    public class StudentCourseConfiguration : AuditableBaseEntityConfiguration<StudentCourse>
    {
        public override void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            base.Configure(builder);

            builder.Property(studentCourse => studentCourse.StudentId).HasColumnType("varchar");
            builder.ToTable(studentCourse => studentCourse.HasCheckConstraint("StudentId_Length_Control", "Len(StudentId) = 36"));

            builder.Property(studentCourse => studentCourse.CourseId).HasColumnType("varchar");
            builder.ToTable(studentCourse => studentCourse.HasCheckConstraint("CourseId_Length_Control", "Len(CourseId) = 36"));

            builder.HasOne(studentCourse => studentCourse.Student).WithMany(student => student.StudentCourses).HasForeignKey(studentCourse => studentCourse.StudentId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(studentCourse => studentCourse.Course).WithMany(course => course.StudentCourses).HasForeignKey(studentCourse => studentCourse.CourseId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}