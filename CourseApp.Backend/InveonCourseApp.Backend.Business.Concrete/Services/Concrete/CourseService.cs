namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly ICacheService<Course> cacheService;
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<CourseService> logger;
        public CourseService(ICacheService<Course> cacheService, ICourseRepository courseRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<CourseService> logger)
        {
            this.cacheService = cacheService;
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }
    }
}