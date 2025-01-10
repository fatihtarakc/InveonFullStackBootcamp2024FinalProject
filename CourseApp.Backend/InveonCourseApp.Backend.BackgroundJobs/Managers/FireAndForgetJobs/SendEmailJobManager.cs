namespace InveonCourseApp.Backend.BackgroundJobs.Managers.FireAndForgetJobs
{
    public class SendEmailJobManager
    {
        private readonly IRabbitmqConsumerService rabbitmqConsumerService;
        public SendEmailJobManager(IRabbitmqConsumerService rabbitmqConsumerService)
        {
            this.rabbitmqConsumerService = rabbitmqConsumerService;
        }

        public void Execute()
        {
            rabbitmqConsumerService.StartSendingEmailForNewStudent();
            rabbitmqConsumerService.StartSendingEmailForNewTrainer();
            rabbitmqConsumerService.StartSendingEmailForActivateAccount();
            rabbitmqConsumerService.StartSendingEmailForConfirmEmail();
            rabbitmqConsumerService.StartSendingEmailForResetPassword();
        }
    }
}