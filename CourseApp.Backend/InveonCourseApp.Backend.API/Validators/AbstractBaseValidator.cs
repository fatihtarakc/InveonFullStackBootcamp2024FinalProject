namespace InveonCourseApp.Backend.API.Validators
{
    public abstract class AbstractBaseValidator<Dto> : AbstractValidator<Dto> where Dto : class
    {
        protected readonly IStringLocalizer<MessageResources> stringLocalizer;
        public AbstractBaseValidator(IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
        }
    }
}