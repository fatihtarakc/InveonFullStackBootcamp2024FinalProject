namespace InveonCourseApp.Backend.Dtos.StudentDtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Guid IdentityId { get; init; }
        public AccountStatus AccountStatus { get; set; }
        public DateTime Birthdate { get; set; }
    }
}