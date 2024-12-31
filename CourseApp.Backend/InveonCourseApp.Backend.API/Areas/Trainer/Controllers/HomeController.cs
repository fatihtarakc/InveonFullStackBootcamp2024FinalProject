namespace InveonCourseApp.Backend.API.Areas.Trainer.Controllers
{
    public class HomeController : TrainerControllerBase 
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("trainer");
        }
    }
}