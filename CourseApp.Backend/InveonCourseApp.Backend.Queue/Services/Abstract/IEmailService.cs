namespace InveonCourseApp.Backend.Queue.Services.Abstract
{
    public interface IEmailService
    {
        Task<IResult> SendingEmailForNewStudentAsync(EmailForNewStudentDto emailForNewStudentDto);

        Task<IResult> SendingEmailForNewTrainerAsync(EmailForNewTrainerDto emailForNewTrainerDto);

        Task<IResult> SendingEmailForActivateAccountAsync(EmailForActivateAccountDto emailForActivateAccountDto);

        Task<IResult> SendingEmailForConfirmEmailAsync(EmailForConfirmEmailDto emailForConfirmEmailDto);

        Task<IResult> SendingEmailForChangePasswordAsync(EmailForChangePasswordDto emailForChangePasswordDto);

        Task<IResult> SendingEmailForTwoFactorAuthenticationAsync(EmailForTwoFactorAuthenticationDto emailForTwoFactorAuthenticationDto);
    }
}