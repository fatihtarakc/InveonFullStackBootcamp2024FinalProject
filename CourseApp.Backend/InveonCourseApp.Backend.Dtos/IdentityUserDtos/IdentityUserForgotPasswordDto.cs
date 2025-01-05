namespace InveonCourseApp.Backend.Dtos.IdentityUserDtos
{
    public class IdentityUserForgotPasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string VerificationCode { get; set; }
    }
}