namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface IOrderService
    {
        Task<IDataResult<List<OrderDto>>> GetAllWhereAsync(Expression<Func<Order, bool>> expression);
    }
}