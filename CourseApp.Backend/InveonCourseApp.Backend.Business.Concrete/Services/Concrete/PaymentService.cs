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

        public async Task<IDataResult<PaymentDto>> GetFirstOrDefaultAsync(Expression<Func<Payment, bool>> expression)
        {
            try
            {
                var payment = await paymentRepository.GetFirstOrDefaultAsync(expression);
                if (payment is null) return new ErrorDataResult<PaymentDto>(stringLocalizer[Message.Payment_Could_Not_Be_Got]);

                return new SuccessDataResult<PaymentDto>(payment.Adapt<PaymentDto>(), stringLocalizer[Message.Payment_Was_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Payment_Could_Not_Be_Got]}\n{exception.Message}");
                return new ErrorDataResult<PaymentDto>(stringLocalizer[Message.Payment_Could_Not_Be_Got]);
            }
        }

        public async Task<IDataResult<List<PaymentDto>>> GetAllWhereAsync(Expression<Func<Payment, bool>> expression)
        {
            try
            {
                var paymentDtos = (await paymentRepository.GetAllWhereAsync(expression)).Adapt<List<PaymentDto>>() ?? new List<PaymentDto>();
                if (paymentDtos.Count() is 0) return new ErrorDataResult<List<PaymentDto>>(paymentDtos, stringLocalizer[Message.Payment_List_Has_Been_Empty]);

                return new SuccessDataResult<List<PaymentDto>>(paymentDtos, stringLocalizer[Message.Payment_WantedPayments_Were_Got_Successfully]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Payment_WantedPayments_Getting_Process_Was_Failed]}\n{exception.Message}");
                return new ErrorDataResult<List<PaymentDto>>(stringLocalizer[Message.Payment_WantedPayments_Getting_Process_Was_Failed]);
            }
        }
    }
}