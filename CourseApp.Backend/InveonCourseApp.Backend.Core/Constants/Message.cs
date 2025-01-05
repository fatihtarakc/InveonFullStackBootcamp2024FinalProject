namespace InveonCourseApp.Backend.Core.Constants
{
    public class Message
    {
        #region Account
        public const string Account_SignIn_Failed = "Account_SignIn_Failed";
        public const string Account_SignIn_Successful = "Account_SignIn_Successful";

        public const string Account_Was_Not_Found = "Account_Was_Not_Found";
        public const string Account_Was_Found = "Account_Was_Found";

        public const string Account_Has_Not_Activated = "Account_Has_Not_Activated";
        public const string Account_Was_Activated= "Account_Was_Activated";

        public const string Account_Email_Has_Not_Confirmed = "Account_Email_Has_Not_Confirmed";
        public const string Account_Email_Was_Confirmed = "Account_Email_Was_Confirmed";

        public const string Account_Email_Has_Already_Existed = "Account_Email_Has_Already_Existed";
        public const string Account_Username_Has_Already_Existed = "Account_Username_Has_Already_Existed";

        public const string Account_Please_Enter_Your_Email = "Account_Please_Enter_Your_Email";
        public const string Account_Please_Enter_Your_Password = "Account_Please_Enter_Your_Password";
        public const string Account_Please_Enter_Your_Email_With_Correct_Format = "Account_Please_Enter_Your_Email_With_Correct_Format";
        #endregion

        #region Admin
        public const string Admin_Was_Not_Found_ById = "Admin_Was_Not_Found_ById";
        public const string Admin_Was_Found_ById = "Admin_Was_Found_ById";

        public const string Admin_Was_Not_Found_ByEmail = "Admin_Was_Not_Found_ByEmail";
        public const string Admin_Was_Found_ByEmail = "Admin_Was_Found_ByEmail";

        public const string Admin_Was_Not_Found_ByIdentityId = "Admin_Was_Not_Found_ByIdentityId";
        public const string Admin_Was_Found_ByIdentityId = "Admin_Was_Found_ByIdentityId";
        #endregion

        #region Student
        public const string Student_Was_Not_Found_ById = "Student_Was_Not_Found_ById";
        public const string Student_Was_Found_ById = "Student_Was_Found_ById";

        public const string Student_Was_Not_Found_ByEmail = "Student_Was_Not_Found_ByEmail";
        public const string Student_Was_Found_ByEmail = "Student_Was_Found_ByEmail";

        public const string Student_Was_Not_Found_ByIdentityId = "Student_Was_Not_Found_ByIdentityId";
        public const string Student_Was_Found_ByIdentityId = "Student_Was_Found_ByIdentityId";
        #endregion

        #region Trainer
        public const string Trainer_Was_Not_Found_ById = "Trainer_Was_Not_Found_ById";
        public const string Trainer_Was_Found_ById = "Trainer_Was_Found_ById";

        public const string Trainer_Was_Not_Found_ByEmail = "Trainer_Was_Not_Found_ByEmail";
        public const string Trainer_Was_Found_ByEmail = "Trainer_Was_Found_ByEmail";

        public const string Trainer_Was_Not_Found_ByIdentityId = "Trainer_Was_Not_Found_ByIdentityId";
        public const string Trainer_Was_Found_ByIdentityId = "Trainer_Was_Found_ByIdentityId";
        #endregion

        #region Email
        public const string Email_SendingProcess_Was_Failed = "Email_SendingProcess_Was_Failed";
        public const string Email_SendingProcess_Was_Successful = "Email_SendingProcess_Was_Successful";

        public const string EmailTitle_Has_Been_Sent_For_EmailVerificationCode = "EmailTitle_Has_Been_Sent_For_EmailVerificationCode";
        public const string EmailSubject_Has_Been_Sent_For_EmailVerificationCode = "EmailSubject_Has_Been_Sent_For_EmailVerificationCode";
        public const string EmailContent_Has_Been_Sent_For_EmailVerificationCode = "EmailContent_Has_Been_Sent_For_EmailVerificationCode";

        public const string EmailTitle_Has_Been_Sent_For_PasswordChangeVerificationCode = "EmailTitle_Has_Been_Sent_For_PasswordChangeVerificationCode";
        public const string EmailSubject_Has_Been_Sent_For_PasswordChangeVerificationCode = "EmailSubject_Has_Been_Sent_For_PasswordChangeVerificationCode";
        public const string EmailContent_Has_Been_Sent_For_PasswordChangeVerificationCode = "EmailContent_Has_Been_Sent_For_PasswordChangeVerificationCode";

        public const string EmailTitle_Has_Been_Sent_For_TwoFactorAuthenticationVerificationCode = "EmailTitle_Has_Been_Sent_For_TwoFactorAuthenticationVerificationCode";
        public const string EmailSubject_Has_Been_Sent_For_TwoFactorAuthenticationVerificationCode = "EmailSubject_Has_Been_Sent_For_TwoFactorAuthenticationVerificationCode";
        public const string EmailContent_Has_Been_Sent_For_TwoFactorAuthenticationVerificationCode = "EmailContent_Has_Been_Sent_For_TwoFactorAuthenticationVerificationCode";

        public const string EmailTitle_Has_Been_Sent_For_NewAppUser = "EmailTitle_Has_Been_Sent_For_NewAppUser";
        public const string EmailSubject_Has_Been_Sent_For_NewAppUser = "EmailSubject_Has_Been_Sent_For_NewAppUser";
        public const string EmailContent_Has_Been_Sent_For_NewAppUser = "EmailContent_Has_Been_Sent_For_NewAppUser";
        #endregion

        #region Redis
        public const string Redis_Cache_Entity_Was_Added = "Redis_Cache_Entity_Was_Added";
        public const string Redis_Cache_Entity_Was_Found = "Redis_Cache_Entity_Was_Found";
        public const string Redis_Cache_Entity_Was_Not_Added = "Redis_Cache_Entity_Was_Not_Added";
        public const string Redis_Cache_Entity_Was_Not_Found = "Redis_Cache_Entity_Was_Not_Found";
        #endregion

        #region Rabbitmq
        public const string Rabbitmq_StartSendingEmailProcess_Was_Failed = "Rabbitmq_StartSendingEmailProcess_Was_Failed";
        public const string Rabbitmq_StartSendingEmailProcess_Was_Successful = "Rabbitmq_StartSendingEmailProcess_Was_Successful";

        public const string Rabbitmq_EnqueueModelProcess_Was_Failed = "Rabbitmq_EnqueueModelProcess_Was_Failed";
        public const string Rabbitmq_EnqueueModelProcess_Was_Successful = "Rabbitmq_EnqueueModelProcess_Was_Successful";
        public const string Rabbitmq_EnqueueModelsProcess_Were_Failed = "Rabbitmq_EnqueueModelsProcess_Were_Failed";
        public const string Rabbitmq_EnqueueModelsProcess_Were_Successful = "Rabbitmq_EnqueueModelsProcess_Were_Successful";
        #endregion
    }
}