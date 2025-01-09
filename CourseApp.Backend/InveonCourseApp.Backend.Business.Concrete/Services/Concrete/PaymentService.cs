namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly ICacheService<Payment> cacheService;
        private readonly IPaymentRepository paymentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<PaymentService> logger;
        public PaymentService(ICacheService<Payment> cacheService, IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<PaymentService> logger)
        {
            this.cacheService = cacheService;
            this.paymentRepository = paymentRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }
    }
}