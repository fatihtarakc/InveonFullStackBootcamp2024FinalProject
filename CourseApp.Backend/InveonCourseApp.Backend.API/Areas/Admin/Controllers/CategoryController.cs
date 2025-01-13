namespace InveonCourseApp.Backend.API.Areas.Admin.Controllers
{
    public class CategoryController : AdminControllerBase
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

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var categoryAddResult = await categoryService.AddAsync(categoryAddDto);
            if (!categoryAddResult.IsSuccess) return BadRequest(categoryAddResult.Message);

            return Ok(categoryAddResult.Message);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var deleteStatus = await categoryService.DeleteAsync(categoryId);
            if (!deleteStatus.IsSuccess) return BadRequest(deleteStatus.Message);

            return Ok(deleteStatus.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var categoryUpdateResult = await categoryService.UpdateAsync(categoryUpdateDto);
            if (!categoryUpdateResult.IsSuccess) return BadRequest(categoryUpdateResult.Message);

            return Ok(categoryUpdateResult.Message);
        }
    }
}