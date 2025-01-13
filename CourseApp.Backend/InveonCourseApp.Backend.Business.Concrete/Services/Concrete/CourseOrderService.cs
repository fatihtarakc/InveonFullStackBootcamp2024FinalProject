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

        public async Task<IDataResult<CourseOrderDto>> AddAsync(CourseOrderAddDto courseOrderAddDto)
        {
            try
            {
                var courseOrderListByOrderId = await courseOrderRepository.GetAllWhereAsync(courseOrderList => courseOrderList.OrderId == courseOrderAddDto.OrderId);
                if (courseOrderListByOrderId.Any(courseOrder => courseOrder.CourseId == courseOrderAddDto.CourseId))
                    return new ErrorDataResult<CourseOrderDto>(stringLocalizer[Message.CourseOrder_Course_Has_Already_Existed]);

                var courseOrder = courseOrderAddDto.Adapt<CourseOrder>();
                await courseOrderRepository.AddAsync(courseOrder);
                await unitOfWork.SaveChangesAsync();

                return new SuccessDataResult<CourseOrderDto>(courseOrder.Adapt<CourseOrderDto>(), stringLocalizer[Message.CourseOrder_Was_Added_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.CourseOrder_Could_Not_Be_Added]} : {exception.Message}");
                return new ErrorDataResult<CourseOrderDto>(stringLocalizer[Message.CourseOrder_Could_Not_Be_Added]);
            }
        }
    }
}