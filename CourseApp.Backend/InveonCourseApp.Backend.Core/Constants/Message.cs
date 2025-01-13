namespace InveonCourseApp.Backend.Core.Constants
{
    public class Message
    {
        #region Account
        public const string Account_SignIn_Failed = "Account_SignIn_Failed";
        public const string Account_SignIn_Successful = "Account_SignIn_Successful";

        public const string Account_ActivateAccount_Failed = "Account_ActivateAccount_Failed";
        public const string Account_ActivateAccount_Successful = "Account_ActivateAccount_Successful";

        public const string Account_ConfirmEmail_Failed = "Account_ConfirmEmail_Failed";
        public const string Account_ConfirmEmail_Successful = "Account_ConfirmEmail_Successful";

        public const string Account_ResetPassword_Failed = "Account_ResetPassword_Failed";
        public const string Account_ResetPassword_Successful = "Account_ResetPassword_Successful";

        public const string Account_Was_Not_Found = "Account_Was_Not_Found";
        public const string Account_Was_Found = "Account_Was_Found";

        public const string Please_Activate_Your_Account_Again = "Please_Activate_Your_Account_Again";
        public const string Account_Has_Already_Been_Activated = "Account_Has_Already_Been_Activated";
        public const string Account_Has_Not_Activated = "Account_Has_Not_Activated";
        public const string Account_Was_Activated = "Account_Was_Activated";

        public const string Account_Email_Has_Already_Been_Confirmed = "Account_Email_Has_Already_Been_Confirmed";
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

        public const string Account_Please_Take_New_VerificationCode = "Account_Please_Take_New_VerificationCode";
        public const string Account_Please_Enter_Your_VerificationCode = "Account_Please_Enter_Your_VerificationCode";
        public const string Account_VerificationCode_Is_Invalid = "Account_VerificationCode_Is_Invalid";
        public const string Account_VerificationCode_Cannot_Be_GreaterThan_50Characters = "Account_VerificationCode_Cannot_Be_GreaterThan_50Characters";

        public const string Account_Please_Select_Your_VerificationType = "Account_Please_Select_Your_VerificationType";
        public const string Account_Please_Select_Correct_VerificationType = "Account_Please_Select_Correct_VerificationType";

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

        public const string Admin_Was_Not_Found_ByUsername = "Admin_Was_Not_Found_ByUsername";
        public const string Admin_Was_Found_ByUsername = "Admin_Was_Found_ByUsername";
        #endregion

        #region Student
        public const string Student_Trainer_Role_Could_Not_Be_Added = "Student_Trainer_Role_Could_Not_Be_Added";
        public const string Student_Trainer_Role_Was_Added_Successfully = "Student_Trainer_Role_Was_Added_Successfully";

        public const string Student_Can_Not_Be_Trainer = "Student_Can_Not_Be_Trainer";
        public const string Student_Can_Be_Trainer = "Student_Can_Be_Trainer";

        public const string Student_Was_Not_Found_ById = "Student_Was_Not_Found_ById";
        public const string Student_Was_Found_ById = "Student_Was_Found_ById";

        public const string Student_Was_Not_Found_ByEmail = "Student_Was_Not_Found_ByEmail";
        public const string Student_Was_Found_ByEmail = "Student_Was_Found_ByEmail";

        public const string Student_Was_Not_Found_ByIdentityId = "Student_Was_Not_Found_ByIdentityId";
        public const string Student_Was_Found_ByIdentityId = "Student_Was_Found_ByIdentityId";

        public const string Student_Was_Not_Found_ByUsername = "Student_Was_Not_Found_ByUsername";
        public const string Student_Was_Found_ByUsername = "Student_Was_Found_ByUsername";

        public const string Student_Could_Not_Added = "Student_Could_Not_Added";
        public const string Student_Was_Added_Successfully = "Student_Was_Added_Successfully";
        #endregion

        #region Trainer
        public const string Trainer_Has_Already_Been_Existed = "Trainer_Has_Already_Been_Existed";

        public const string Trainer_Was_Not_Found_ById = "Trainer_Was_Not_Found_ById";
        public const string Trainer_Was_Found_ById = "Trainer_Was_Found_ById";

        public const string Trainer_Was_Not_Found_ByEmail = "Trainer_Was_Not_Found_ByEmail";
        public const string Trainer_Was_Found_ByEmail = "Trainer_Was_Found_ByEmail";

        public const string Trainer_Was_Not_Found_ByIdentityId = "Trainer_Was_Not_Found_ByIdentityId";
        public const string Trainer_Was_Found_ByIdentityId = "Trainer_Was_Found_ByIdentityId";

        public const string Trainer_Was_Not_Found_ByUsername = "Trainer_Was_Not_Found_ByUsername";
        public const string Trainer_Was_Found_ByUsername = "Trainer_Was_Found_ByUsername";

        public const string Trainer_Could_Not_Added = "Trainer_Could_Not_Added";
        public const string Trainer_Was_Added_Successfully = "Trainer_Was_Added_Successfully";
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

        public const string EmailTitle_Has_Been_Sent_For_ResetPassword = "EmailTitle_Has_Been_Sent_For_ResetPassword";
        public const string EmailSubject_Has_Been_Sent_For_ResetPassword = "EmailSubject_Has_Been_Sent_For_ResetPassword";
        public const string EmailContent_Has_Been_Sent_For_ResetPassword = "EmailContent_Has_Been_Sent_For_ResetPassword";

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

        #region Category
        public const string Category_Was_Added_Successfully = "Category_Was_Added_Successfully";
        public const string Category_Could_Not_Be_Added = "Category_Could_Not_Be_Added";
        
        public const string Category_Was_Deleted_Successfully = "Category_Was_Deleted_Successfully";
        public const string Category_Could_Not_Be_Deleted = "Category_Could_Not_Be_Deleted";
        
        public const string Category_Was_Updated_Successfully = "Category_Was_Updated_Successfully";
        public const string Category_Could_Not_Be_Updated = "Category_Could_Not_Be_Updated";
        
        public const string Category_Was_Not_Found_ById = "Category_Was_Not_Found_ById";

        public const string Category_List_Has_Been_Empty = "Category_List_Has_Been_Empty";
        public const string Category_AllCategories_Were_Got_Successfully = "Category_AllCategories_Were_Got_Successfully";
        public const string Category_AllCategories_Getting_Process_Was_Failed = "Category_AllCategories_Getting_Process_Was_Failed";

        public const string Category_Was_Got_Successfully = "Category_Was_Got_Successfully";
        public const string Category_Could_Not_Be_Got = "Category_Could_Not_Be_Got";
        
        public const string Category_Name_Has_Already_Existed = "Category_Name_Has_Already_Existed";

        public const string Category_Please_Enter_Name = "Category_Please_Enter_Name";
        public const string Category_Digits_ForName_Cannot_Be_Used = "Category_Digits_ForName_Cannot_Be_Used";
        public const string Category_Symbols_ForName_Cannot_Be_Used = "Category_Symbols_ForName_Cannot_Be_Used";
        public const string Category_Name_Cannot_Be_LessThan_2Characters = "Category_Name_Cannot_Be_LessThan_2Characters";
        public const string Category_Name_Cannot_Be_GreaterThan_50Characters = "Category_Name_Cannot_Be_GreaterThan_50Characters";
        #endregion

        #region Course
        public const string Course_Was_Added_Successfully = "Course_Was_Added_Successfully";
        public const string Course_Could_Not_Be_Added = "Course_Could_Not_Be_Added";

        public const string Course_List_Has_Been_Empty = "Course_List_Has_Been_Empty";
        public const string Course_AllCourses_Were_Got_Successfully = "Course_AllCourses_Were_Got_Successfully";
        public const string Course_AllCourses_Getting_Process_Was_Failed = "Course_AllCourses_Getting_Process_Was_Failed";

        public const string Course_WantedCourses_Were_Got_Successfully = "Course_WantedCourses_Were_Got_Successfully";
        public const string Course_WantedCourses_Getting_Process_Was_Failed = "Course_WantedCourses_Getting_Process_Was_Failed";

        public const string Course_Was_Got_Successfully = "Course_Was_Got_Successfully";
        public const string Course_Could_Not_Be_Got = "Course_Could_Not_Be_Got";

        public const string Course_Please_Enter_Name = "Course_Please_Enter_Name";
        public const string Course_Digits_ForName_Cannot_Be_Used = "Course_Digits_ForName_Cannot_Be_Used";
        public const string Course_Symbols_ForName_Cannot_Be_Used = "Course_Symbols_ForName_Cannot_Be_Used";
        public const string Course_Name_Cannot_Be_LessThan_2Characters = "Course_Name_Cannot_Be_LessThan_2Characters";
        public const string Course_Name_Cannot_Be_GreaterThan_100Characters = "Course_Name_Cannot_Be_GreaterThan_100Characters";

        public const string Course_Please_Enter_ImageUrl = "Course_Please_Enter_ImageUrl";
        public const string Course_ImageUrl_Cannot_Be_LessThan_5Characters = "Course_ImageUrl_Cannot_Be_LessThan_5Characters";
        public const string Course_ImageUrl_Cannot_Be_GreaterThan_250Characters = "Course_ImageUrl_Cannot_Be_GreaterThan_250Characters";

        public const string Course_Please_Enter_Description = "Course_Please_Enter_Description";
        public const string Course_Digits_ForDescription_Cannot_Be_Used = "Course_Digits_ForDescription_Cannot_Be_Used";
        public const string Course_Symbols_ForDescription_Cannot_Be_Used = "Course_Symbols_ForDescription_Cannot_Be_Used";
        public const string Course_Description_Cannot_Be_LessThan_5Characters = "Course_Description_Cannot_Be_LessThan_5Characters";
        public const string Course_Description_Cannot_Be_GreaterThan_450Characters = "Course_Description_Cannot_Be_GreaterThan_450Characters";

        public const string Course_Please_Enter_Price = "Course_Please_Enter_Price";
        public const string Course_Price_Must_Be_Min_0 = "Course_Price_Must_Be_Min_0";

        public const string Course_Please_Enter_Currency = "Course_Please_Enter_Currency";

        public const string Course_Please_Enter_CategoryId = "Course_Please_Enter_CategoryId";

        public const string Course_Please_Enter_TrainerId = "Course_Please_Enter_TrainerId";
        #endregion

        #region CourseOrder
        public const string CourseOrder_Course_Has_Already_Existed = "CourseOrder_Course_Has_Already_Existed";
        
        public const string CourseOrder_Was_Added_Successfully = "CourseOrder_Was_Added_Successfully";
        public const string CourseOrder_Could_Not_Be_Added = "CourseOrder_Could_Not_Be_Added";
        #endregion

        #region Order
        public const string Order_List_Has_Been_Empty = "Order_List_Has_Been_Empty";
        public const string Order_WantedOrders_Were_Got_Successfully = "Order_WantedOrders_Were_Got_Successfully";
        public const string Order_WantedOrder_Getting_Process_Was_Failed = "Order_WantedOrder_Getting_Process_Was_Failed";
        #endregion

        #region Payment
        public const string Payment_List_Has_Been_Empty = "Payment_List_Has_Been_Empty";
        public const string Payment_WantedPayments_Were_Got_Successfully = "Payment_WantedPayments_Were_Got_Successfully";
        public const string Payment_WantedPayments_Getting_Process_Was_Failed = "Payment_WantedPayments_Getting_Process_Was_Failed";

        public const string Payment_Could_Not_Be_Got = "Payment_Could_Not_Be_Got";
        public const string Payment_Was_Got_Successfully = "Payment_Was_Got_Successfully";
        #endregion
    }
}