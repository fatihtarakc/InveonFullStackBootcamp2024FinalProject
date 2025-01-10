namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface IPaymentService
    {
        Task<IDataResult<PaymentDto>> GetFirstOrDefaultAsync(Expression<Func<Payment, bool>> expression);

        Task<IDataResult<List<PaymentDto>>> GetAllWhereAsync(Expression<Func<Payment, bool>> expression);
    }
}