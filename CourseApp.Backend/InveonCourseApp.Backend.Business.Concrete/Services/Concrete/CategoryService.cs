namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICacheService<Category> cacheService;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<CategoryService> logger;
        public CategoryService(ICacheService<Category> cacheService, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<CategoryService> logger)
        {
            this.cacheService = cacheService;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto)
        {
            try
            {
                if (await categoryRepository.AnyAsync(category => category.Name == categoryAddDto.Name))
                    return new ErrorResult(stringLocalizer[Message.Category_Name_Has_Already_Existed]);

                var category = categoryAddDto.Adapt<Category>();
                await categoryRepository.AddAsync(category);
                await unitOfWork.SaveChangesAsync();

                await cacheService.AddAsync($"CategoryDto_{category.Id}", category, TimeSpan.FromDays(1));
                return new SuccessResult(stringLocalizer[Message.Category_Was_Added_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Category_Could_Not_Be_Added]} : {exception.Message}");
                return new ErrorResult(stringLocalizer[Message.Category_Could_Not_Be_Added]);
            }
        }

        public async Task<IResult> DeleteAsync(Guid categoryId)
        {
            try
            {
                var category = await categoryRepository.GetByIdAsync(categoryId);
                if (category is null) return new ErrorResult(stringLocalizer[Message.Category_Was_Not_Found_ById]);

                await categoryRepository.DeleteAsync(category);
                await unitOfWork.SaveChangesAsync();

                await cacheService.DeleteAsync($"CategoryDto_{category.Id}");
                return new SuccessResult(stringLocalizer[Message.Category_Was_Deleted_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Category_Could_Not_Be_Deleted]} : {exception.Message}");
                return new ErrorResult(stringLocalizer[Message.Category_Could_Not_Be_Deleted]);
            }
        }

        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                if (await categoryRepository.AnyAsync(category => category.Name == categoryUpdateDto.Name))
                    return new ErrorResult(stringLocalizer[Message.Category_Name_Has_Already_Existed]);

                var category = await categoryRepository.GetByIdAsync(categoryUpdateDto.Id);
                if (category is null) return new ErrorResult(stringLocalizer[Message.Category_Was_Not_Found_ById]);

                category.Name = categoryUpdateDto.Name;
                await categoryRepository.UpdateAsync(category);
                await unitOfWork.SaveChangesAsync();

                await cacheService.DeleteAsync($"CategoryDto_{category.Id}");
                await cacheService.AddAsync($"CategoryDto_{category.Id}", category, TimeSpan.FromDays(1));
                return new SuccessResult(stringLocalizer[Message.Category_Was_Updated_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Category_Could_Not_Be_Updated]} : {exception.Message}");
                return new ErrorResult(stringLocalizer[Message.Category_Could_Not_Be_Updated]);
            }
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid categoryId)
        {
            try
            {
                var dto = await cacheService.GetByAsync($"CategoryDto_{categoryId}");
                if (dto.Data is not null) return new SuccessDataResult<CategoryDto>(dto.Data.Adapt<CategoryDto>(), stringLocalizer[Message.Category_Was_Got_Successfully]);

                var category = await categoryRepository.GetByIdAsync(categoryId);
                if (category is null) return new ErrorDataResult<CategoryDto>(stringLocalizer[Message.Category_Could_Not_Be_Got]);

                await cacheService.AddAsync($"CategoryDto_{categoryId}", category, TimeSpan.FromDays(1));
                return new SuccessDataResult<CategoryDto>(category.Adapt<CategoryDto>(), stringLocalizer[Message.Category_Was_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Category_Could_Not_Be_Got]}\n{exception.Message}");
                return new ErrorDataResult<CategoryDto>(stringLocalizer[Message.Category_Could_Not_Be_Got]);
            }
        }

        public async Task<IDataResult<CategoryDto>> GetByNameAsync(string categoryName)
        {
            try
            {
                var dto = await cacheService.GetByAsync($"CategoryDto_{categoryName}");
                if (dto.Data is not null) return new SuccessDataResult<CategoryDto>(dto.Data.Adapt<CategoryDto>(), stringLocalizer[Message.Category_Was_Got_Successfully]);

                var category = await categoryRepository.GetFirstOrDefaultAsync(category => category.Name == categoryName);
                if (category is null) return new ErrorDataResult<CategoryDto>(stringLocalizer[Message.Category_Could_Not_Be_Got]);

                await cacheService.AddAsync($"CategoryDto_{categoryName}", category, TimeSpan.FromDays(1));
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