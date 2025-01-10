namespace InveonCourseApp.Backend.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController, Area("Admin"), Authorize(Roles = "Admin")]
    public class AdminControllerBase : ControllerBase 
    {
        protected readonly IStringLocalizer<MessageResources> stringLocalizer;
        public AdminControllerBase(IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
        }
    }
}