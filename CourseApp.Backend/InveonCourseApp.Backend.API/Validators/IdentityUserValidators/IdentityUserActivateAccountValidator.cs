namespace InveonCourseApp.Backend.API.Validators.IdentityUserValidators
{
    public class IdentityUserActivateAccountValidator : AbstractBaseValidator<IdentityUserActivateAccountDto>
    {
        public IdentityUserActivateAccountValidator(IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(identityUser => identityUser.Email)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email])
                .EmailAddress().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email_With_Correct_Format])
                .MaximumLength(50).WithMessage(stringLocalizer[Message.Account_Email_Cannot_Be_GreaterThan_50Characters]);

            RuleFor(identityUser => identityUser.VerificationCode)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_VerificationCode])
                .MaximumLength(50).WithMessage(stringLocalizer[Message.Account_VerificationCode_Cannot_Be_GreaterThan_50Characters]);

            RuleFor(identityUser => identityUser.VerificationType)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Select_Your_VerificationType])
                .Equal(VerificationType.ActivateAccount).WithMessage(stringLocalizer[Message.Account_Please_Select_Correct_VerificationType]);
        }
    }
}