namespace InveonCourseApp.Backend.API.Validators.CategoryValidators
{
    public class CategoryUpdateValidator : AbstractBaseValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator(IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage(stringLocalizer[Message.Category_Please_Enter_Name])
                .Must(HelperCharacter.DigitNotInclude).WithMessage(stringLocalizer[Message.Category_Digits_ForName_Cannot_Be_Used])
                .Must(HelperCharacter.SymbolNotInclude).WithMessage(stringLocalizer[Message.Category_Symbols_ForName_Cannot_Be_Used])
                .MinimumLength(2).WithMessage(stringLocalizer[Message.Category_Name_Cannot_Be_LessThan_2Characters])
                .MaximumLength(100).WithMessage(stringLocalizer[Message.Category_Name_Cannot_Be_GreaterThan_50Characters]);
        }
    }
}