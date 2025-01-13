namespace InveonCourseApp.Backend.API.Areas.Student.Controllers
{
    public class PaymentController : StudentControllerBase
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.paymentService = paymentService;
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> Payments(Guid studentId)
        {
            var paymentDtosDataResult = await paymentService.GetAllWhereAsync(payment => payment.StudentId == studentId);
            if (!paymentDtosDataResult.IsSuccess) return BadRequest(paymentDtosDataResult.Message);

            return Ok(paymentDtosDataResult.Data);
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetBy(Guid studentId)
        {
            var paymentDtoDataResult = await paymentService.GetFirstOrDefaultAsync(payment => payment.StudentId == studentId);
            if (!paymentDtoDataResult.IsSuccess) return BadRequest(paymentDtoDataResult.Message);

            return Ok(paymentDtoDataResult.Data);
        }
    }
}