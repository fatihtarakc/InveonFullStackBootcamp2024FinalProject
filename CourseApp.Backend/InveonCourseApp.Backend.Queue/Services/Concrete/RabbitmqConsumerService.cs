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
            var emailForNewUserDto = objectConvertFormatService.ToObjectFromJson<EmailForNewUserDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForNewStudentAsync(emailForNewUserDto);

            Console.WriteLine($"New Student - {emailForNewUserDto.To} : It was sent email to  {emailForNewUserDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"New Student - {emailForNewUserDto.To} : It was sent email to  {emailForNewUserDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForNewTrainer() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForNewTrainer!, queueName: QueueName.NewTrainer);
        private void ConsumerReceivedEmailForNewTrainer(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForNewUserDto = objectConvertFormatService.ToObjectFromJson<EmailForNewUserDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForNewTrainerAsync(emailForNewUserDto);

            Console.WriteLine($"New Trainer - {emailForNewUserDto.To} : It was sent email to  {emailForNewUserDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"New Trainer - {emailForNewUserDto.To} : It was sent email to  {emailForNewUserDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForActivateAccount() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForActivateAccount!, queueName: QueueName.ActivateAccount);
        private void ConsumerReceivedEmailForActivateAccount(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForVerificationDto = objectConvertFormatService.ToObjectFromJson<EmailForVerificationDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForActivateAccountAsync(emailForVerificationDto);

            Console.WriteLine($"Activate account - {emailForVerificationDto.To} : {emailForVerificationDto.VerificationCode} verification code for account activation was sent email to {emailForVerificationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"Activate account - {emailForVerificationDto.To} : {emailForVerificationDto.VerificationCode} verification code for account activation was sent email to {emailForVerificationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForConfirmEmail() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForConfirmEmail!, queueName: QueueName.ConfirmEmail);
        private void ConsumerReceivedEmailForConfirmEmail(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForVerificationDto = objectConvertFormatService.ToObjectFromJson<EmailForVerificationDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForConfirmEmailAsync(emailForVerificationDto);

            Console.WriteLine($"Confirm email - {emailForVerificationDto.To} : {emailForVerificationDto.VerificationCode} verification code for email verification was sent email to {emailForVerificationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"Confirm email - {emailForVerificationDto.To} : {emailForVerificationDto.VerificationCode} verification code for email verification was sent email to {emailForVerificationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }

        public void StartSendingEmailForResetPassword() =>
            StartSendingEmail(basicDeliverEventHandler: ConsumerReceivedEmailForResetPassword!, queueName: QueueName.ResetPassword);
        private void ConsumerReceivedEmailForResetPassword(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            var emailForVerificationDto = objectConvertFormatService.ToObjectFromJson<EmailForVerificationDto>(Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()));
            emailService.SendingEmailForResetPasswordAsync(emailForVerificationDto);

            Console.WriteLine($"Reset password - {emailForVerificationDto.To} : {emailForVerificationDto.VerificationCode} verification code for reset was sent email to {emailForVerificationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            logger.LogInformation($"Reset password - {emailForVerificationDto.To} : {emailForVerificationDto.VerificationCode} verification code for reset was sent email to {emailForVerificationDto.EmailTo} ! \n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
        }
    }
}