namespace InveonCourseApp.Backend.API.Validators.CourseValidators
{
    public class CourseAddValidator : AbstractBaseValidator<CourseAddDto>
    {
        public CourseAddValidator(IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(course => course.ImageUrl)
                .NotEmpty().WithMessage(stringLocalizer[Message.Course_Please_Enter_ImageUrl])
                .MinimumLength(5).WithMessage(stringLocalizer[Message.Course_ImageUrl_Cannot_Be_LessThan_5Characters])
                .MaximumLength(250).WithMessage(stringLocalizer[Message.Course_ImageUrl_Cannot_Be_GreaterThan_250Characters]);

            RuleFor(course => course.Name)
                .NotEmpty().WithMessage(stringLocalizer[Message.Course_Please_Enter_Name])
                .Must(HelperCharacter.DigitNotInclude).WithMessage(stringLocalizer[Message.Course_Digits_ForName_Cannot_Be_Used])
                .Must(HelperCharacter.SymbolNotInclude).WithMessage(stringLocalizer[Message.Course_Symbols_ForName_Cannot_Be_Used])
                .MinimumLength(2).WithMessage(stringLocalizer[Message.Course_Name_Cannot_Be_LessThan_2Characters])
                .MaximumLength(100).WithMessage(stringLocalizer[Message.Course_Name_Cannot_Be_GreaterThan_100Characters]);

            RuleFor(course => course.Description)
                .NotEmpty().WithMessage(stringLocalizer[Message.Course_Please_Enter_Description])
                .Must(HelperCharacter.DigitNotInclude).WithMessage(stringLocalizer[Message.Course_Digits_ForDescription_Cannot_Be_Used])
                .Must(HelperCharacter.SymbolNotInclude).WithMessage(stringLocalizer[Message.Course_Symbols_ForDescription_Cannot_Be_Used])
                .MinimumLength(5).WithMessage(stringLocalizer[Message.Course_Description_Cannot_Be_LessThan_5Characters])
                .MaximumLength(450).WithMessage(stringLocalizer[Message.Course_Description_Cannot_Be_GreaterThan_450Characters]);

            RuleFor(course => course.Price)
                .NotEmpty().WithMessage(stringLocalizer[Message.Course_Please_Enter_Price])
                .GreaterThanOrEqualTo(0).WithMessage(stringLocalizer[Message.Course_Price_Must_Be_Min_0]);

            RuleFor(course => course.Currency)
                .NotEmpty().WithMessage(stringLocalizer[Message.Course_Please_Enter_Currency]);

            RuleFor(course => course.CategoryId)
                .NotEmpty().WithMessage(stringLocalizer[Message.Course_Please_Enter_CategoryId]);

            RuleFor(course => course.TrainerId)
                .NotEmpty().WithMessage(stringLocalizer[Message.Course_Please_Enter_TrainerId]);
        }
    }
}