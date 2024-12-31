namespace InveonCourseApp.Backend.Dtos.IdentityUserDtos
{
    public class IdentityUserSignInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPersistant { get; set; }
    }
}