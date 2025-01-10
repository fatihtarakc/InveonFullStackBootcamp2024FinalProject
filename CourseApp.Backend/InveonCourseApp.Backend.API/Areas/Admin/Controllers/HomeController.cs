namespace InveonCourseApp.Backend.API.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase
    {
        private readonly IAdminService adminService;
        public HomeController(IAdminService adminService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.adminService = adminService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetBy(string email)
        {
            var adminDtoDataResult = await adminService.GetByEmailAsync(email);
            if (!adminDtoDataResult.IsSuccess) return BadRequest($"{adminDtoDataResult.Message} : {stringLocalizer[Message.Student_Was_Not_Found_ByEmail]}");

            return Ok(adminDtoDataResult.Data);
        }
    }
}