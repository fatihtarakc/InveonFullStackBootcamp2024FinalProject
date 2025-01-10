namespace InveonCourseApp.Backend.Core.Enums
{
    public enum VerificationType
    {
        [Display(Name = "Activate Account")]
        ActivateAccount = 1,
        [Display(Name = "Confirm Email")]
        ConfirmEmail,
        [Display(Name = "Reset Password")]
        ResetPassword
    }
}