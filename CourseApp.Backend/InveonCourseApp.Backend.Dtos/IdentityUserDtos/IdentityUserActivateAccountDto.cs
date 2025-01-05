namespace InveonCourseApp.Backend.Dtos.IdentityUserDtos
{
    public class IdentityUserActivateAccountDto
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}