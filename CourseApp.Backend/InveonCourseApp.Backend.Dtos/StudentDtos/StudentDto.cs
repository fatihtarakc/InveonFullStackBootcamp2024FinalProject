namespace InveonCourseApp.Backend.Dtos.StudentDtos
{
    public class StudentDto : AuditablePersonBaseEntityDto
    {
        public DateTime Birthdate { get; set; }
    }
}