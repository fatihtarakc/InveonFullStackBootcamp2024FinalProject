namespace InveonCourseApp.Backend.API.Areas.Trainer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController, Area("Trainer"), Authorize(Roles = "Trainer")]
    public class TrainerControllerBase : ControllerBase 
    {
        protected readonly IStringLocalizer<MessageResources> stringLocalizer;
        public TrainerControllerBase(IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
        }
    }
}