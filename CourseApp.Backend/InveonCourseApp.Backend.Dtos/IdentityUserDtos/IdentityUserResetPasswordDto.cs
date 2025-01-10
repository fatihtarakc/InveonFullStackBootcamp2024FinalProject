namespace InveonCourseApp.Backend.Dtos.IdentityUserDtos
{
    public class IdentityUserResetPasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
        public VerificationType VerificationType => VerificationType.ResetPassword;
    }
}