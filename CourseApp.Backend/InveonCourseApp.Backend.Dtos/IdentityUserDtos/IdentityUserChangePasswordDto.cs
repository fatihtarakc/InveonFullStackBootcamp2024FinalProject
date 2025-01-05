namespace InveonCourseApp.Backend.Dtos.IdentityUserDtos
{
    public class IdentityUserChangePasswordDto
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string VerificationCode { get; set; }
    }
}