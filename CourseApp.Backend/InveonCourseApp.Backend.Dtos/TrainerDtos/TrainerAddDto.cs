namespace InveonCourseApp.Backend.Dtos.TrainerDtos
{
    public class TrainerAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
    }
}