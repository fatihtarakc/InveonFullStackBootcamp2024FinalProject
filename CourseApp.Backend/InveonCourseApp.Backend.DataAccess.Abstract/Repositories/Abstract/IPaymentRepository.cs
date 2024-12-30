namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface IPaymentRepository :
        IAsyncAddableRepository<Payment>, IAsyncDeletableRepository<Payment>, IAsyncUpdatableRepository<Payment>,
        IAsyncQueryableRepository<Payment>, IAsyncOrderableRepository<Payment>
    {
        Task<Payment> IncludeGetFirstOrDefaultAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, bool tracking = true);
        Task<Payment> IncludeGetFirstOrDefaultAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<Payment>> IncludeGetAllWhereAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, Expression<Func<Payment, object>> orderby, bool tracking = true);
        Task<ICollection<Payment>> IncludeGetAllWhereAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Payment, object>> orderby, bool tracking = true);
    }
}