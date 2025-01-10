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

        public async Task<IDataResult<List<OrderDto>>> GetAllWhereAsync(Expression<Func<Order, bool>> expression)
        {
            try
            {
                var orderDtos = (await orderRepository.GetAllWhereAsync(expression)).Adapt<List<OrderDto>>() ?? new List<OrderDto>();
                if (orderDtos.Count() is 0) return new ErrorDataResult<List<OrderDto>>(orderDtos, stringLocalizer[Message.Order_List_Has_Been_Empty]);

                return new SuccessDataResult<List<OrderDto>>(orderDtos, stringLocalizer[Message.Order_WantedOrders_Were_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Order_WantedOrder_Getting_Process_Was_Failed]}\n{exception.Message}");
                return new ErrorDataResult<List<OrderDto>>(stringLocalizer[Message.Order_WantedOrder_Getting_Process_Was_Failed]);
            }
        }
    }
}