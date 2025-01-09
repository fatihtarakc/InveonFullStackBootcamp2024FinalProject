namespace InveonCourseApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IAdminService adminService;
        private readonly IStudentService studentService;
        private readonly ITokenService tokenService;
        private readonly ITrainerService trainerService;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        public HomeController(IAccountService accountService, IAdminService adminService, IStudentService studentService, ITokenService tokenService, ITrainerService trainerService, IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.accountService = accountService;
            this.adminService = adminService;
            this.studentService = studentService;
            this.tokenService = tokenService;
            this.trainerService = trainerService;
            this.stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("adsadsa");
        }
    }
}