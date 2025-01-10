namespace InveonCourseApp.Backend.Queue.Services.Abstract
{
    public interface IRabbitmqConsumerService
    {
        void StartSendingEmailForNewStudent();

        void StartSendingEmailForNewTrainer();

        void StartSendingEmailForActivateAccount();

        void StartSendingEmailForConfirmEmail();

        void StartSendingEmailForResetPassword();
    }
}