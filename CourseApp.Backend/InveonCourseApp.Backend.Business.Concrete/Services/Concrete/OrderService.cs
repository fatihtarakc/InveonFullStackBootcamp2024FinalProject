namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly ICacheService<Order> cacheService;
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<OrderService> logger;
        public OrderService(ICacheService<Order> cacheService, IOrderRepository orderRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<OrderService> logger)
        {
            this.cacheService = cacheService;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }
    }
}