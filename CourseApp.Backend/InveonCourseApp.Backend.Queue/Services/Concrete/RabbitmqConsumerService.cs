namespace InveonCourseApp.Backend.Queue.Services.Concrete
{
    public class RabbitmqConsumerService : IRabbitmqConsumerService
    {
        private readonly IRabbitmqService rabbitmqService;
        private readonly IEmailService emailService;
        private readonly IObjectConvertFormatService objectConvertFormatService;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<RabbitmqConsumerService> logger;
        public RabbitmqConsumerService(IRabbitmqService rabbitmqService, IEmailService emailService, IObjectConvertFormatService objectConvertFormatService, IStringLocalizer<MessageResources> stringLocalizer, ILogger<RabbitmqConsumerService> logger)
        {
            this.rabbitmqService = rabbitmqService;
            this.emailService = emailService;
            this.objectConvertFormatService = objectConvertFormatService;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }
        private void StartSendingEmail(EventHandler<BasicDeliverEventArgs> basicDeliverEventHandler, string queueName)
        {
            try
            {
                var connection = rabbitmqService.CreateConnection();

                var channel = rabbitmqService.CreateModel(connection);

                channel.QueueDeclare(queue: queueName,
                        durable: true, exclusive: false, autoDelete: false, arguments: null);

                var eventingBasicConsumer = new EventingBasicConsumer(channel);
                eventingBasicConsumer.Received += basicDeliverEventHandler;
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: eventingBasicConsumer);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Rabbitmq_StartSendingEmailProcess_Was_Failed]} : {exception.Message}");
            }
        }

        public void StartSendingEmailForNewStudent() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForNewStudent!, queueName: QueueName.NewStudent);
        private void ConsumerReceivedEmailForNewStudent(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForNewStudentDto = objectConvertFormatService.ToObjectFromJson<EmailForNewStudentDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForNewStudentAsync(emailForNewStudentDto);

            Console.WriteLine($"New Student - {emailForNewStudentDto.To} : It was sent email to  {emailForNewStudentDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"New Student - {emailForNewStudentDto.To} : It was sent email to  {emailForNewStudentDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForNewTrainer() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForNewTrainer!, queueName: QueueName.NewTrainer);
        private void ConsumerReceivedEmailForNewTrainer(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForNewTrainerDto = objectConvertFormatService.ToObjectFromJson<EmailForNewTrainerDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForNewTrainerAsync(emailForNewTrainerDto);

            Console.WriteLine($"New Trainer - {emailForNewTrainerDto.To} : It was sent email to  {emailForNewTrainerDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"New Trainer - {emailForNewTrainerDto.To} : It was sent email to  {emailForNewTrainerDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForActivateAccount() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForActivateAccount!, queueName: QueueName.ActivateAccount);
        private void ConsumerReceivedEmailForActivateAccount(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForActivateAccountDto = objectConvertFormatService.ToObjectFromJson<EmailForActivateAccountDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForActivateAccountAsync(emailForActivateAccountDto);

            Console.WriteLine($"Activate account - {emailForActivateAccountDto.To} : {emailForActivateAccountDto.VerificationCode} verification code for account activation was sent email to {emailForActivateAccountDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"Activate account - {emailForActivateAccountDto.To} : {emailForActivateAccountDto.VerificationCode} verification code for account activation was sent email to {emailForActivateAccountDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForConfirmEmail() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForConfirmEmail!, queueName: QueueName.ConfirmEmail);
        private void ConsumerReceivedEmailForConfirmEmail(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForConfirmEmailDto = objectConvertFormatService.ToObjectFromJson<EmailForConfirmEmailDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForConfirmEmailAsync(emailForConfirmEmailDto);

            Console.WriteLine($"Confirm email - {emailForConfirmEmailDto.To} : {emailForConfirmEmailDto.VerificationCode} verification code for email verification was sent email to {emailForConfirmEmailDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"Confirm email - {emailForConfirmEmailDto.To} : {emailForConfirmEmailDto.VerificationCode} verification code for email verification was sent email to {emailForConfirmEmailDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForChangePassword() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForChangePassword!, queueName: QueueName.ChangePassword);
        private void ConsumerReceivedEmailForChangePassword(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForChangePasswordDto = objectConvertFormatService.ToObjectFromJson<EmailForChangePasswordDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForChangePasswordAsync(emailForChangePasswordDto);

            Console.WriteLine($"Change password - {emailForChangePasswordDto.To} : {emailForChangePasswordDto.VerificationCode} verification code for password change was sent email to {emailForChangePasswordDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"Change password - {emailForChangePasswordDto.To} : {emailForChangePasswordDto.VerificationCode} verification code for password change was sent email to {emailForChangePasswordDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForTwoFactorAuthentication() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForTwoFactorAuthentication!, queueName: QueueName.TwoFactorAuthentication);
        private void ConsumerReceivedEmailForTwoFactorAuthentication(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForTwoFactorAuthenticationDto = objectConvertFormatService.ToObjectFromJson<EmailForTwoFactorAuthenticationDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForTwoFactorAuthenticationAsync(emailForTwoFactorAuthenticationDto);

            Console.WriteLine($"Two factor authentication - {emailForTwoFactorAuthenticationDto.To} : {emailForTwoFactorAuthenticationDto.VerificationCode} verification code for two factor authentication was sent email to {emailForTwoFactorAuthenticationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"Two factor authentication - {emailForTwoFactorAuthenticationDto.To} : {emailForTwoFactorAuthenticationDto.VerificationCode} verification code for two factor authentication was sent email to {emailForTwoFactorAuthenticationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }
    }
}