namespace InveonCourseApp.Backend.API.Areas.Trainer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController, Area("Trainer"), AllowAnonymous/*Authorize(Roles = "Trainer")*/]
    public class TrainerControllerBase : ControllerBase { }
}