namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly ICacheService<Course> cacheService;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICourseRepository courseRepository;
        private readonly ITrainerRepository trainerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<CourseService> logger;
        public CourseService(ICacheService<Course> cacheService, ICategoryRepository categoryRepository, ICourseRepository courseRepository, ITrainerRepository trainerRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<CourseService> logger)
        {
            this.cacheService = cacheService;
            this.categoryRepository = categoryRepository;
            this.courseRepository = courseRepository;
            this.trainerRepository = trainerRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IDataResult<CourseDto>> AddAsync(CourseAddDto courseAddDto)
        {
            if (!(await trainerRepository.AnyAsync(trainer => trainer.Id == courseAddDto.TrainerId)))
                return new ErrorDataResult<CourseDto>(stringLocalizer[Message.Trainer_Was_Not_Found_ById]);

            if (!(await categoryRepository.AnyAsync(category => category.Id == courseAddDto.CategoryId)))
                return new ErrorDataResult<CourseDto>(stringLocalizer[Message.Category_Was_Not_Found_ById]);

            IDataResult<CourseDto> dataResult = new ErrorDataResult<CourseDto>();
            var strategy = await unitOfWork.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await unitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var course = courseAddDto.Adapt<Course>();
                    await courseRepository.AddAsync(course);
                    await unitOfWork.SaveChangesAsync();

                    dataResult = new SuccessDataResult<CourseDto>(course.Adapt<CourseDto>(), $"{stringLocalizer[Message.Course_Was_Added_Successfully]}");
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    logger.LogError($"{stringLocalizer[Message.Course_Could_Not_Be_Added]} : {exception.Message}");
                    dataResult = new ErrorDataResult<CourseDto>(stringLocalizer[Message.Course_Could_Not_Be_Added]);
                    transactionScope.Rollback();
                }
                finally
                {
                    await transactionScope.DisposeAsync();
                }
            });

            return dataResult;
        }

        public async Task<IDataResult<CourseDto>> GetByIdAsync(Guid courseId)
        {
            try
            {
                var result = await cacheService.GetByAsync($"Course_{courseId}");
                if (result.Data is not null) return new SuccessDataResult<CourseDto>(result.Data.Adapt<CourseDto>(), stringLocalizer[Message.Course_Was_Got_Successfully]);

                var course = await courseRepository.GetByIdAsync(courseId);
                if (course is null) return new ErrorDataResult<CourseDto>(stringLocalizer[Message.Course_Could_Not_Be_Got]);

                await cacheService.AddAsync($"Course_{courseId}", course, TimeSpan.FromDays(1));
                return new SuccessDataResult<CourseDto>(course.Adapt<CourseDto>(), stringLocalizer[Message.Course_Was_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Course_Could_Not_Be_Got]}\n{exception.Message}");
                return new ErrorDataResult<CourseDto>(stringLocalizer[Message.Course_Could_Not_Be_Got]);
            }
        }

        public async Task<IDataResult<List<CourseListDto>>> GetAllWhereAsync(Expression<Func<Course, bool>> expression)
        {
            try
            {
                var courseListDtos = (await courseRepository.GetAllWhereAsync(expression)).Adapt<List<CourseListDto>>() ?? new List<CourseListDto>();
                if (courseListDtos.Count() is 0) return new ErrorDataResult<List<CourseListDto>>(courseListDtos, stringLocalizer[Message.Course_List_Has_Been_Empty]);

                return new SuccessDataResult<List<CourseListDto>>(courseListDtos, stringLocalizer[Message.Course_WantedCourses_Were_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Course_WantedCourses_Getting_Process_Was_Failed]}\n{exception.Message}");
                return new ErrorDataResult<List<CourseListDto>>(stringLocalizer[Message.Course_WantedCourses_Getting_Process_Was_Failed]);
            }
        }

        public async Task<IDataResult<List<CourseListDto>>> GetAllAsync()
        {
            try
            {
                var courseListDtos = (await courseRepository.GetAllAsync()).Adapt<List<CourseListDto>>() ?? new List<CourseListDto>();
                if (courseListDtos.Count() is 0) return new ErrorDataResult<List<CourseListDto>>(courseListDtos, stringLocalizer[Message.Course_List_Has_Been_Empty]);

                return new SuccessDataResult<List<CourseListDto>>(courseListDtos, stringLocalizer[Message.Course_AllCourses_Were_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Course_AllCourses_Getting_Process_Was_Failed]}\n{exception.Message}");
                return new ErrorDataResult<List<CourseListDto>>(stringLocalizer[Message.Course_AllCourses_Getting_Process_Was_Failed]);
            }
        }

        //public async Task<IDataResult<List<CourseDto>>> IncludeStudetsGetAll()
        //{
        //}
    }
}