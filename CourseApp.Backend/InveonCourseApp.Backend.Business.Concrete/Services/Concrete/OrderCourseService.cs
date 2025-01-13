namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class OrderCourseService : IOrderCourseService
    {
        private readonly ICacheService<OrderCourse> cacheService;
        private readonly IOrderCourseRepository orderCourseRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<OrderCourseService> logger;
        public OrderCourseService(ICacheService<OrderCourse> cacheService, IOrderCourseRepository orderCourseRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<OrderCourseService> logger)
        {
            this.cacheService = cacheService;
            this.orderCourseRepository = orderCourseRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IResult> AddAsync(OrderCourseAddDto orderCourseAddDto)
        {
            try
            {
                var orderCourseListByOrderId = await orderCourseRepository.GetAllWhereAsync(orderCourseList => orderCourseList.OrderId == orderCourseAddDto.OrderId);
                if (orderCourseListByOrderId.Any(orderCourse => orderCourse.CourseId == orderCourseAddDto.CourseId))
                    return new ErrorResult(stringLocalizer[Message.OrderCourse_Course_Has_Already_Existed]);

                var orderCourse = orderCourseAddDto.Adapt<OrderCourse>();
                await orderCourseRepository.AddAsync(orderCourse);
                await unitOfWork.SaveChangesAsync();

                return new SuccessResult(stringLocalizer[Message.OrderCourse_Was_Added_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.OrderCourse_Could_Not_Be_Added]} : {exception.Message}");
                return new ErrorResult(stringLocalizer[Message.OrderCourse_Could_Not_Be_Added]);
            }
        }
    }
}