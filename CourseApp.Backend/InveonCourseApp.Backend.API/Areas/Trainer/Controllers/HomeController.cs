namespace InveonCourseApp.Backend.API.Areas.Trainer.Controllers
{
    public class HomeController : TrainerControllerBase
    {
        private readonly ITrainerService trainerService;
        public HomeController(ITrainerService trainerService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.trainerService = trainerService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetBy(string email)
        {
            var trainerDtoDataResult = await trainerService.GetByEmailAsync(email);
            if (!trainerDtoDataResult.IsSuccess) return BadRequest($"{trainerDtoDataResult.Message} : {stringLocalizer[Message.Student_Was_Not_Found_ByEmail]}");

            return Ok(trainerDtoDataResult.Data);
        }
    }
}