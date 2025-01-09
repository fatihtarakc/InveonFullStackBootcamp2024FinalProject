namespace InveonCourseApp.Backend.API.Validators.StudentValidators
{
    public class StudentAddValidator : AbstractBaseValidator<StudentAddDto>
    {
        public StudentAddValidator(IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(student => student.Name)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Name])
                .Must(HelperCharacter.DigitNotInclude).WithMessage(stringLocalizer[Message.Account_Digits_ForName_Cannot_Be_Used])
                .Must(HelperCharacter.SymbolNotInclude).WithMessage(stringLocalizer[Message.Account_Symbols_ForName_Cannot_Be_Used])
                .MinimumLength(2).WithMessage(stringLocalizer[Message.Account_Name_Cannot_Be_LessThan_2Characters])
                .MaximumLength(25).WithMessage(stringLocalizer[Message.Account_Name_Cannot_Be_GreaterThan_25Characters]);

            RuleFor(student => student.Surname)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Surname])
                .Must(HelperCharacter.DigitNotInclude).WithMessage(stringLocalizer[Message.Account_Digits_ForSurname_Cannot_Be_Used])
                .Must(HelperCharacter.SymbolNotInclude).WithMessage(stringLocalizer[Message.Account_Symbols_ForSurname_Cannot_Be_Used])
                .MinimumLength(2).WithMessage(stringLocalizer[Message.Account_Surname_Cannot_Be_LessThan_2Characters])
                .MaximumLength(25).WithMessage(stringLocalizer[Message.Account_Surname_Cannot_Be_GreaterThan_25Characters]);

            RuleFor(student => student.Username)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Username])
                .Must(HelperCharacter.TRCharacterNotInclude).WithMessage(stringLocalizer[Message.Account_TurkishCharacters_ForUsername_Cannot_Be_Used])
                .Must(HelperCharacter.UpperCharacterNotInclude).WithMessage(stringLocalizer[Message.Account_UpperLetters_ForUsername_Cannot_Be_Used])
                .Must(HelperCharacter.DigitNotInclude).WithMessage(stringLocalizer[Message.Account_Digits_ForUsername_Cannot_Be_Used])
                .Must(HelperCharacter.SymbolNotInclude).WithMessage(stringLocalizer[Message.Account_Symbols_ForUsername_Cannot_Be_Used])
                .MinimumLength(5).WithMessage(stringLocalizer[Message.Account_Username_Cannot_Be_LessThan_5Characters])
                .MaximumLength(20).WithMessage(stringLocalizer[Message.Account_Username_Cannot_Be_GreaterThan_20Characters]);

            RuleFor(student => student.Email)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email])
                .EmailAddress().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Email_With_Correct_Format])
                .Must(HelperCharacter.TRCharacterNotInclude).WithMessage(stringLocalizer[Message.Account_TurkishCharacters_ForEmail_Cannot_Be_Used])
                .MinimumLength(10).WithMessage(stringLocalizer[Message.Account_Email_Cannot_Be_LessThan_10Characters])
                .MaximumLength(50).WithMessage(stringLocalizer[Message.Account_Email_Cannot_Be_GreaterThan_50Characters]);

            RuleFor(student => student.Password)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Password])
                .Must(HelperCharacter.UpperCharacterInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1UpperLetter_AtLeast])
                .Must(HelperCharacter.LowerCharacterInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1LowerLetter_AtLeast])
                .Must(HelperCharacter.DigitInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1Digit_AtLeast])
                .Must(HelperCharacter.SymbolInclude).WithMessage(stringLocalizer[Message.Account_Password_Must_Include_1Symbol_AtLeast])
                .MinimumLength(8).WithMessage(stringLocalizer[Message.Account_Password_Cannot_Be_LessThan_8Characters])
                .MaximumLength(25).WithMessage(stringLocalizer[Message.Account_Password_Cannot_Be_GreaterThan_25Characters]);

            RuleFor(student => student.Birthdate)
                .NotEmpty().WithMessage(stringLocalizer[Message.Account_Please_Enter_Your_Birthdate])
                .Must(HelperAge.StudentControl).WithMessage(stringLocalizer[Message.Account_Birthdate_Age_Cannot_Be_LessThan_7YearsOld]);
        }
    }
}