namespace InveonCourseApp.Backend.API.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("admin");
        }
    }
}