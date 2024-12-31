namespace InveonCourseApp.Backend.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController, Area("Admin"), AllowAnonymous/*Authorize(Roles = "Admin")*/]
    public class AdminControllerBase : ControllerBase { }
}