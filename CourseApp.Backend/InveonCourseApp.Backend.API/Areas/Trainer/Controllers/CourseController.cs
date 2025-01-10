namespace InveonCourseApp.Backend.API.Areas.Trainer.Controllers
{
    public class CourseController : TrainerControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.courseService = courseService;
        }

        [HttpGet("{trainerId : guid}")]
        public async Task<IActionResult> PublishedCourses(Guid trainerId)
        {
            var courseDtosDataResult = await courseService.GetAllWhereAsync(course => course.TrainerId == trainerId);
            if (!courseDtosDataResult.IsSuccess) return BadRequest(courseDtosDataResult.Message);

            return Ok(courseDtosDataResult.Data);
        }

        [HttpGet("{courseId :guid}")]
        public async Task<IActionResult> GetBy(Guid courseId)
        {
            var courseDtoDataResult = await courseService.GetByIdAsync(courseId);
            if (!courseDtoDataResult.IsSuccess) return BadRequest(courseDtoDataResult.Message);

            return Ok(courseDtoDataResult.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseAddDto courseAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var courseDtoDataResult = await courseService.AddAsync(courseAddDto);
            if (!courseDtoDataResult.IsSuccess) return BadRequest(courseDtoDataResult.Message);

            return Ok(courseDtoDataResult.Data);
        }
    }
}