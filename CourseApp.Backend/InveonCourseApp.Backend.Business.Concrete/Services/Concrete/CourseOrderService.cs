namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class CourseOrderService : ICourseOrderService
    {
        private readonly ICacheService<CourseOrder> cacheService;
        private readonly ICourseOrderRepository courseOrderRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<CourseOrderService> logger;
        public CourseOrderService(ICacheService<CourseOrder> cacheService, ICourseOrderRepository courseOrderRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<CourseOrderService> logger)
        {
            this.cacheService = cacheService;
            this.courseOrderRepository = courseOrderRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }
    }
}