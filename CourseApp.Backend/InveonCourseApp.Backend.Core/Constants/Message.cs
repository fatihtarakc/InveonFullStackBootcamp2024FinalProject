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
        public const string Account_Was_Activated = "Account_Was_Activated";

        public const string Account_Email_Has_Not_Confirmed = "Account_Email_Has_Not_Confirmed";
        public const string Account_Email_Was_Confirmed = "Account_Email_Was_Confirmed";

        public const string Account_Email_Has_Already_Existed = "Account_Email_Has_Already_Existed";
        public const string Account_Email_Is_Invalid = "Account_Email_Is_Invalid";

        public const string Account_Username_Has_Already_Existed = "Account_Username_Has_Already_Existed";

        public const string Account_Role_Was_Not_Found_For_IdentityUser = "Account_Role_Was_Not_Found_For_IdentityUser";

        public const string Account_Please_Enter_Your_Name = "Account_Please_Enter_Your_Name";
        public const string Account_Digits_ForName_Cannot_Be_Used = "Account_Digits_ForName_Cannot_Be_Used";
        public const string Account_Symbols_ForName_Cannot_Be_Used = "Account_Symbols_ForName_Cannot_Be_Used";
        public const string Account_Name_Cannot_Be_LessThan_2Characters = "Account_Name_Cannot_Be_LessThan_2Characters";
        public const string Account_Name_Cannot_Be_GreaterThan_25Characters = "Account_Name_Cannot_Be_GreaterThan_25Characters";

        public const string Account_Please_Enter_Your_Surname = "Account_Please_Enter_Your_Surname";
        public const string Account_Digits_ForSurname_Cannot_Be_Used = "Account_Digits_ForSurname_Cannot_Be_Used";
        public const string Account_Symbols_ForSurname_Cannot_Be_Used = "Account_Symbols_ForSurname_Cannot_Be_Used";
        public const string Account_Surname_Cannot_Be_LessThan_2Characters = "Account_Surname_Cannot_Be_LessThan_2Characters";
        public const string Account_Surname_Cannot_Be_GreaterThan_25Characters = "Account_Surname_Cannot_Be_GreaterThan_25Characters";

        public const string Account_Please_Enter_Your_Username = "Account_Please_Enter_Your_Username";
        public const string Account_TurkishCharacters_ForUsername_Cannot_Be_Used = "Account_TurkishCharacters_ForUsername_Cannot_Be_Used";
        public const string Account_UpperLetters_ForUsername_Cannot_Be_Used = "Account_UpperLetters_ForUsername_Cannot_Be_Used";
        public const string Account_Digits_ForUsername_Cannot_Be_Used = "Account_Digits_ForUsername_Cannot_Be_Used";
        public const string Account_Symbols_ForUsername_Cannot_Be_Used = "Account_Symbols_ForUsername_Cannot_Be_Used";
        public const string Account_Username_Cannot_Be_LessThan_5Characters = "Account_Username_Cannot_Be_LessThan_5Characters";
        public const string Account_Username_Cannot_Be_GreaterThan_20Characters = "Account_Username_Cannot_Be_GreaterThan_20Characters";

        public const string Account_Please_Enter_Your_Email = "Account_Please_Enter_Your_Email";
        public const string Account_Please_Enter_Your_Email_With_Correct_Format = "Account_Please_Enter_Your_Email_With_Correct_Format";
        public const string Account_TurkishCharacters_ForEmail_Cannot_Be_Used = "Account_TurkishCharacters_ForEmail_Cannot_Be_Used";
        public const string Account_Email_Cannot_Be_LessThan_10Characters = "Account_Email_Cannot_Be_LessThan_10Characters";
        public const string Account_Email_Cannot_Be_GreaterThan_50Characters = "Account_Email_Cannot_Be_GreaterThan_50Characters";

        public const string Account_Please_Enter_Your_Password = "Account_Please_Enter_Your_Password";
        public const string Account_Password_Must_Include_1UpperLetter_AtLeast = "Account_Password_Must_Include_1UpperLetter_AtLeast";
        public const string Account_Password_Must_Include_1LowerLetter_AtLeast = "Account_Password_Must_Include_1LowerLetter_AtLeast";
        public const string Account_Password_Must_Include_1Digit_AtLeast = "Account_Password_Must_Include_1Digit_AtLeast";
        public const string Account_Password_Must_Include_1Symbol_AtLeast = "Account_Password_Must_Include_1Symbol_AtLeast";
        public const string Account_Password_Cannot_Be_LessThan_8Characters = "Account_Password_Cannot_Be_LessThan_8Characters";
        public const string Account_Password_Cannot_Be_GreaterThan_25Characters = "Account_Password_Cannot_Be_GreaterThan_25Characters";

        public const string Account_Please_Enter_Your_Birthdate = "Account_Please_Enter_Your_Birthdate";
        public const string Account_Birthdate_Age_Cannot_Be_LessThan_7YearsOld = "Account_Birthdate_Age_Cannot_Be_LessThan_7YearsOld";

        #endregion

        #region Token
        public const string Token_Could_Not_Generated = "Token_Could_Not_Generated";
        public const string Token_Was_Generated_Successfully = "Token_Was_Generated_Successfully";
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

        public const string Student_Could_Not_Added = "Student_Could_Not_Added";
        public const string Student_Was_Added_Successfully = "Student_Was_Added_Successfully";
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

        public const string EmailTitle_Has_Been_Sent_For_NewStudent = "EmailTitle_Has_Been_Sent_For_NewStudent";
        public const string EmailSubject_Has_Been_Sent_For_NewStudent = "EmailSubject_Has_Been_Sent_For_NewStudent";
        public const string EmailContent_Has_Been_Sent_For_NewStudent = "EmailContent_Has_Been_Sent_For_NewStudent";

        public const string EmailTitle_Has_Been_Sent_For_NewTrainer = "EmailTitle_Has_Been_Sent_For_NewTrainer";
        public const string EmailSubject_Has_Been_Sent_For_NewTrainer = "EmailSubject_Has_Been_Sent_For_NewTrainer";
        public const string EmailContent_Has_Been_Sent_For_NewTrainer = "EmailContent_Has_Been_Sent_For_NewTrainer";

        public const string EmailTitle_Has_Been_Sent_For_ActivateAccount = "EmailTitle_Has_Been_Sent_For_ActivateAccount";
        public const string EmailSubject_Has_Been_Sent_For_ActivateAccount = "EmailSubject_Has_Been_Sent_For_ActivateAccount";
        public const string EmailContent_Has_Been_Sent_For_ActivateAccount = "EmailContent_Has_Been_Sent_For_ActivateAccount";

        public const string EmailTitle_Has_Been_Sent_For_ConfirmEmail = "EmailTitle_Has_Been_Sent_For_ConfirmEmail";
        public const string EmailSubject_Has_Been_Sent_For_ConfirmEmail = "EmailSubject_Has_Been_Sent_For_ConfirmEmail";
        public const string EmailContent_Has_Been_Sent_For_ConfirmEmail = "EmailContent_Has_Been_Sent_For_ConfirmEmail";

        public const string EmailTitle_Has_Been_Sent_For_ChangePassword = "EmailTitle_Has_Been_Sent_For_ChangePassword";
        public const string EmailSubject_Has_Been_Sent_For_ChangePassword = "EmailSubject_Has_Been_Sent_For_ChangePassword";
        public const string EmailContent_Has_Been_Sent_For_ChangePassword = "EmailContent_Has_Been_Sent_For_ChangePassword";

        public const string EmailTitle_Has_Been_Sent_For_TwoFactorAuthentication = "EmailTitle_Has_Been_Sent_For_TwoFactorAuthentication";
        public const string EmailSubject_Has_Been_Sent_For_TwoFactorAuthentication = "EmailSubject_Has_Been_Sent_For_TwoFactorAuthentication";
        public const string EmailContent_Has_Been_Sent_For_TwoFactorAuthentication = "EmailContent_Has_Been_Sent_For_TwoFactorAuthentication";
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