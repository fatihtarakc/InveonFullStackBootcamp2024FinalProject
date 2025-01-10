namespace InveonCourseApp.Backend.API.Areas.Student.Controllers
{
    public class CourseController : StudentControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> AllCourses()
        {
            var courseDtosDataResult = await courseService.GetAllAsync();
            if (!courseDtosDataResult.IsSuccess) return BadRequest(courseDtosDataResult.Message);

            return Ok(courseDtosDataResult.Data);
        }
    }
}