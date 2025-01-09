namespace InveonCourseApp.Backend.Dtos.EmailDtos
{
    public class EmailForChangePasswordDto
    {
        public string To { get; set; }
        public string EmailTo { get; set; }
        public string VerificationCode { get; set; }
    }
}