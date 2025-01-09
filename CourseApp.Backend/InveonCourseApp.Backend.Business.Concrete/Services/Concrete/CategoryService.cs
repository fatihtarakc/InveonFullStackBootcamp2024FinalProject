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
    }
}