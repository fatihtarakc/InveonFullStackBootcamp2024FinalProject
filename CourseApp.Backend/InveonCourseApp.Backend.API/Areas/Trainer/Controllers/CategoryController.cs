namespace InveonCourseApp.Backend.API.Areas.Trainer.Controllers
{
    public class CategoryController : TrainerControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categoryListDtosDataResult = await categoryService.GetAllAsync();
            if (!categoryListDtosDataResult.IsSuccess) return BadRequest(categoryListDtosDataResult.Message);

            return Ok(categoryListDtosDataResult.Data);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetBy(Guid categoryId)
        {
            var categoryDtoDataResult = await categoryService.GetByIdAsync(categoryId);
            if (!categoryDtoDataResult.IsSuccess) return BadRequest(categoryDtoDataResult.Message);

            return Ok(categoryDtoDataResult.Data);
        }
    }
}