namespace InveonCourseApp.Backend.API.Areas.Student.Controllers
{
    public class HomeController : StudentControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("student");
        }
    }
}