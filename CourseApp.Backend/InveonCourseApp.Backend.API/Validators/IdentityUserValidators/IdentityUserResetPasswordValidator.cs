namespace InveonCourseApp.Backend.API.Validators.IdentityUserValidators
{
    public class IdentityUserResetPasswordValidator : AbstractBaseValidator<IdentityUserResetPasswordDto>
    {
        public IdentityUserResetPasswordValidator(IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(identityUser => identityUser.Email)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email])
                .EmailAddress().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email_With_Correct_Format])
                .MaximumLength(50).WithMessage(stringLocalizer[Message.Account_Email_Cannot_Be_GreaterThan_50Characters]);

            RuleFor(identityUser => identityUser.Password)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Password])
                .Must(HelperCharacter.UpperCharacterInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1UpperLetter_AtLeast])
                .Must(HelperCharacter.LowerCharacterInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1LowerLetter_AtLeast])
                .Must(HelperCharacter.DigitInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1Digit_AtLeast])
                .Must(HelperCharacter.SymbolInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1Symbol_AtLeast])
                .MinimumLength(8).WithMessage(stringLocalizer[Message.Account_Password_Cannot_Be_LessThan_8Characters])
                .MaximumLength(25).WithMessage(stringLocalizer[Message.Account_Password_Cannot_Be_GreaterThan_25Characters]);

            RuleFor(identityUser => identityUser.VerificationCode)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_VerificationCode])
                .MaximumLength(50).WithMessage(stringLocalizer[Message.Account_VerificationCode_Cannot_Be_GreaterThan_50Characters]); ;

            RuleFor(identityUser => identityUser.VerificationType)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Select_Your_VerificationType])
                .Equal(VerificationType.ResetPassword).WithMessage(stringLocalizer[Message.Account_Please_Select_Correct_VerificationType]);
        }
    }
}