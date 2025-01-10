namespace InveonCourseApp.Backend.API.Areas.Student.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController, Area("Student"), Authorize(Roles = "Student")]
    public class StudentControllerBase : ControllerBase 
    {
        protected readonly IStringLocalizer<MessageResources> stringLocalizer;
        public StudentControllerBase(IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
        }
    }
}