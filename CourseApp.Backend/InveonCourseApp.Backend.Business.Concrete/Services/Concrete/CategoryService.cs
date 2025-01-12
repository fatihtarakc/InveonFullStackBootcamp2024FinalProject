namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICacheService<Category> cacheService;
        private readonly ICategoryRepository categoryRepository;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<CategoryService> logger;
        public CategoryService(ICacheService<Category> cacheService, ICategoryRepository categoryRepository, IStringLocalizer<MessageResources> stringLocalizer, ILogger<CategoryService> logger)
        {
            this.cacheService = cacheService;
            this.categoryRepository = categoryRepository;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid categoryId)
        {
            try
            {
                var result = await cacheService.GetCacheAsync($"Category_{categoryId}");
                if (result.Data is not null) return new SuccessDataResult<CategoryDto>(result.Data.Adapt<CategoryDto>(), stringLocalizer[Message.Category_Was_Got_Successfully]);

                var category = await categoryRepository.GetByIdAsync(categoryId);
                if (category is null) return new ErrorDataResult<CategoryDto>(stringLocalizer[Message.Category_Could_Not_Be_Got]);

                await cacheService.SetCacheAsync($"Category_{categoryId}", category, TimeSpan.FromDays(1));
                return new SuccessDataResult<CategoryDto>(category.Adapt<CategoryDto>(), stringLocalizer[Message.Category_Was_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Category_Could_Not_Be_Got]}\n{exception.Message}");
                return new ErrorDataResult<CategoryDto>(stringLocalizer[Message.Category_Could_Not_Be_Got]);
            }
        }

        public async Task<IDataResult<List<CategoryListDto>>> GetAllAsync()
        {
            try
            {
                var categoryListDtos = (await categoryRepository.GetAllAsync()).Adapt<List<CategoryListDto>>() ?? new List<CategoryListDto>();
                if (categoryListDtos.Count() is 0) return new ErrorDataResult<List<CategoryListDto>>(categoryListDtos, stringLocalizer[Message.Category_List_Has_Been_Empty]);

                return new SuccessDataResult<List<CategoryListDto>>(categoryListDtos, stringLocalizer[Message.Category_AllCategories_Were_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Category_AllCategories_Getting_Process_Was_Failed]}\n{exception.Message}");
                return new ErrorDataResult<List<CategoryListDto>>(stringLocalizer[Message.Category_AllCategories_Getting_Process_Was_Failed]);
            }
        }
    }
}