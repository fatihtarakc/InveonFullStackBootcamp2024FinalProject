namespace InveonCourseApp.Backend.Queue.Services.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions emailOptions;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<EmailService> logger;
        public EmailService(IOptions<EmailOptions> emailOptions, IStringLocalizer<MessageResources> stringLocalizer, ILogger<EmailService> logger)
        {
            this.emailOptions = emailOptions.Value;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        private async Task<MimeMessage> CreateEmailContentAsync(EmailDto emailDto, EmailOptions emailOptions)
        {
            MailboxAddress mailboxAddressFrom = new(emailOptions.From, emailOptions.EmailFrom);
            MailboxAddress mailboxAddressTo = new(emailDto.To, emailDto.EmailTo);

            BodyBuilder bodyBuilder = new();
            bodyBuilder.HtmlBody = $"<h4>{emailDto.Title}</h4><p>{emailDto.Content}</p>";

            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject = emailDto.Subject;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            return await Task.FromResult(mimeMessage);
        }

        private async Task<IResult> SendAsync(EmailDto emailDto)
        {
            var mimeMessage = await CreateEmailContentAsync(emailDto, emailOptions);

            using SmtpClient smtpClient = new();
            try
            {
                await smtpClient.ConnectAsync(emailOptions.SmtpServer, emailOptions.Port, SecureSocketOptions.SslOnConnect);
                await smtpClient.AuthenticateAsync(emailOptions.Username, emailOptions.Password);
                await smtpClient.SendAsync(mimeMessage);
                await smtpClient.DisconnectAsync(true);

                return new SuccessResult(stringLocalizer[Message.Email_SendingProcess_Was_Successful]);
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);
                return new ErrorResult($"{stringLocalizer[Message.Email_SendingProcess_Was_Failed]} : {exception.Message}");
            }
        }

        public async Task<IResult> SendingEmailForNewStudentAsync(EmailForNewUserDto emailForNewUserDto)
        {
            var result = await SendAsync(new EmailDto(emailForNewUserDto.To, emailForNewUserDto.EmailTo, $"{stringLocalizer[Message.EmailTitle_Has_Been_Sent_For_NewStudent]} {emailForNewUserDto.To},", stringLocalizer[Message.EmailSubject_Has_Been_Sent_For_NewStudent], $"{stringLocalizer[Message.EmailContent_Has_Been_Sent_For_NewStudent]}\n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"));
            if (result.IsSuccess) return new SuccessResult(result.Message);
            return new ErrorResult(result.Message);
        }

        public async Task<IResult> SendingEmailForNewTrainerAsync(EmailForNewUserDto emailForNewUserDto)
        {
            var result = await SendAsync(new EmailDto(emailForNewUserDto.To, emailForNewUserDto.EmailTo, $"{stringLocalizer[Message.EmailTitle_Has_Been_Sent_For_NewTrainer]} {emailForNewUserDto.To},", stringLocalizer[Message.EmailSubject_Has_Been_Sent_For_NewTrainer], $"{stringLocalizer[Message.EmailContent_Has_Been_Sent_For_NewTrainer]}\n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"));
            if (result.IsSuccess) return new SuccessResult(result.Message);
            return new ErrorResult(result.Message);
        }

        public async Task<IResult> SendingEmailForActivateAccountAsync(EmailForVerificationDto emailForVerificationDto)
        {
            var result = await SendAsync(new EmailDto(emailForVerificationDto.To, emailForVerificationDto.EmailTo, $"{stringLocalizer[Message.EmailTitle_Has_Been_Sent_For_ActivateAccount]} {emailForVerificationDto.To},", stringLocalizer[Message.EmailSubject_Has_Been_Sent_For_ActivateAccount], $"{stringLocalizer[Message.EmailContent_Has_Been_Sent_For_ActivateAccount]}: {emailForVerificationDto.VerificationCode}\n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"));
            if (result.IsSuccess) return new SuccessResult(result.Message);
            return new ErrorResult(result.Message);
        }

        public async Task<IResult> SendingEmailForConfirmEmailAsync(EmailForVerificationDto emailForVerificationDto)
        {
            var result = await SendAsync(new EmailDto(emailForVerificationDto.To, emailForVerificationDto.EmailTo, $"{stringLocalizer[Message.EmailTitle_Has_Been_Sent_For_ConfirmEmail]} {emailForVerificationDto.To},", stringLocalizer[Message.EmailSubject_Has_Been_Sent_For_ConfirmEmail], $"{stringLocalizer[Message.EmailContent_Has_Been_Sent_For_ConfirmEmail]}: {emailForVerificationDto.VerificationCode}\n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"));
            if (result.IsSuccess) return new SuccessResult(result.Message);
            return new ErrorResult(result.Message);
        }

        public async Task<IResult> SendingEmailForResetPasswordAsync(EmailForVerificationDto emailForVerificationDto)
        {
            var result = await SendAsync(new EmailDto(emailForVerificationDto.To, emailForVerificationDto.EmailTo, $"{stringLocalizer[Message.EmailTitle_Has_Been_Sent_For_ResetPassword]} {emailForVerificationDto.To},", stringLocalizer[Message.EmailSubject_Has_Been_Sent_For_ResetPassword], $"{stringLocalizer[Message.EmailContent_Has_Been_Sent_For_ResetPassword]}: {emailForVerificationDto.VerificationCode}\n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"));
            if (result.IsSuccess) return new SuccessResult(result.Message);
            return new ErrorResult(result.Message);
        }
    }
}