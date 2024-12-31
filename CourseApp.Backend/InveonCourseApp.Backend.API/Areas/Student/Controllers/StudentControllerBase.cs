namespace InveonCourseApp.Backend.API.Areas.Student.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController, Area("Student"), AllowAnonymous/*Authorize(Roles = "Student")*/]
    public class StudentControllerBase : ControllerBase { }
}