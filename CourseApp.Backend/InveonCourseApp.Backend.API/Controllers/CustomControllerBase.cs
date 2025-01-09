namespace InveonCourseApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController, AllowAnonymous]
    public class CustomControllerBase : ControllerBase
    {
        protected readonly IStringLocalizer<MessageResources> stringLocalizer;
        public CustomControllerBase(IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
        }
    }
}