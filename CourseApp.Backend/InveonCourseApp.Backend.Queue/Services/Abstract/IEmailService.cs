namespace InveonCourseApp.Backend.Queue.Services.Abstract
{
    public interface IEmailService
    {
        Task<IResult> SendingEmailForNewStudentAsync(EmailForNewUserDto emailForNewUserDto);

        Task<IResult> SendingEmailForNewTrainerAsync(EmailForNewUserDto emailForNewUserDto);

        Task<IResult> SendingEmailForActivateAccountAsync(EmailForVerificationDto emailForVerificationDto);

        Task<IResult> SendingEmailForConfirmEmailAsync(EmailForVerificationDto emailForVerificationDto);

        Task<IResult> SendingEmailForResetPasswordAsync(EmailForVerificationDto emailForVerificationDto);
    }
}