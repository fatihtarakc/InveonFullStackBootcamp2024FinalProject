namespace InveonCourseApp.Backend.API.Validators.IdentityUserValidators
{
    public class IdentityUserSignInValidator : AbstractBaseValidator<IdentityUserSignInDto>
    {
        public IdentityUserSignInValidator(IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(identityUser => identityUser.Email)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email])
                .EmailAddress().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email_With_Correct_Format]);

            RuleFor(identityUser => identityUser.Password)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Password]);
        }
    }
}