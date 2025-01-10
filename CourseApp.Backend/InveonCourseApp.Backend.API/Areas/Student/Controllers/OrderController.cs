namespace InveonCourseApp.Backend.API.Areas.Student.Controllers
{
    public class OrderController : StudentControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.orderService = orderService;
        }

        [HttpGet("{studentId : guid}")]
        public async Task<IActionResult> CompletedOrders(Guid studentId)
        {
            var orderDtosDataResult = await orderService.GetAllWhereAsync(order => order.StudentId == studentId);
            if (!orderDtosDataResult.IsSuccess) return BadRequest(orderDtosDataResult.Message);

            return Ok(orderDtosDataResult.Data);
        }
    }
}