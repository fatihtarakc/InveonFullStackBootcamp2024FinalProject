namespace InveonCourseApp.Backend.Entities.Configurations.Concrete
{
    public class StudentCourseConfiguration : AuditableBaseEntityConfiguration<StudentCourse>, IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            base.Configure(builder);

            builder.HasOne(studentCourse => studentCourse.Student).WithMany(student => student.StudentCourses).HasForeignKey(studentCourse => studentCourse.StudentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(studentCourse => studentCourse.Course).WithMany(course => course.StudentCourses).HasForeignKey(studentCourse => studentCourse.CourseId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}