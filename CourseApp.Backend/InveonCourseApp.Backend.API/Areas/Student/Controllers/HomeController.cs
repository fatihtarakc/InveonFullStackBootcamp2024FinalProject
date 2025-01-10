namespace InveonCourseApp.Backend.API.Areas.Student.Controllers
{
    public class HomeController : StudentControllerBase
    {
        private readonly IStudentService studentService;
        private readonly ITrainerService trainerService;
        public HomeController(IStudentService studentService, ITrainerService trainerService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.studentService = studentService;
            this.trainerService = trainerService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetBy(string email)
        {
            var studentDtoDataResult = await studentService.GetByEmailAsync(email);
            if (!studentDtoDataResult.IsSuccess) return BadRequest($"{stringLocalizer[Message.Student_Was_Not_Found_ByEmail]}\n{studentDtoDataResult.Message}");

            return Ok(studentDtoDataResult.Data);
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> WantToBeTrainer(string email)
        {
            var studentDtoDataResult = await studentService.GetByEmailAsync(email);
            if (!studentDtoDataResult.IsSuccess) return BadRequest($"{stringLocalizer[Message.Student_Was_Not_Found_ByEmail]}\n{studentDtoDataResult.Message}");

            var trainerDtoDataResult = await trainerService.AddAsync(studentDtoDataResult.Data.Adapt<TrainerAddDto>());
            if (!trainerDtoDataResult.IsSuccess) return BadRequest($"{stringLocalizer[Message.Student_Trainer_Role_Could_Not_Be_Added]}\n{studentDtoDataResult.Message}");

            return Ok(trainerDtoDataResult.Data);
        }
    }
}