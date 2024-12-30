namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface IOrderRepository :
        IAsyncAddableRepository<Order>, IAsyncDeletableRepository<Order>, IAsyncUpdatableRepository<Order>,
        IAsyncQueryableRepository<Order>, IAsyncOrderableRepository<Order>
    {
        Task<Order> IncludeGetFirstOrDefaultAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, bool tracking = true);
        Task<Order> IncludeGetFirstOrDefaultAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<Order>> IncludeGetAllWhereAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, Expression<Func<Order, object>> orderby, bool tracking = true);
        Task<ICollection<Order>> IncludeGetAllWhereAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Order, object>> orderby, bool tracking = true);
    }
}