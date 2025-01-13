namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface IOrderCourseRepository :
        IAsyncAddableRepository<OrderCourse>, IAsyncDeletableRepository<OrderCourse>, IAsyncUpdatableRepository<OrderCourse>,
        IAsyncQueryableRepository<OrderCourse>, IAsyncOrderableRepository<OrderCourse>
    {
        Task<OrderCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, bool tracking = true);
        Task<OrderCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<OrderCourse>> IncludeGetAllWhereAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, Expression<Func<OrderCourse, object>> orderby, bool tracking = true);
        Task<ICollection<OrderCourse>> IncludeGetAllWhereAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<OrderCourse, object>> orderby, bool tracking = true);
    }
}