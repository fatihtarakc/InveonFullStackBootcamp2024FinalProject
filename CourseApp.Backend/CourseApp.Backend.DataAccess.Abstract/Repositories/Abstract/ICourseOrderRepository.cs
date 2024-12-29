namespace CourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface ICourseOrderRepository :
        IAsyncAddableRepository<CourseOrder>, IAsyncDeletableRepository<CourseOrder>, IAsyncUpdatableRepository<CourseOrder>,
        IAsyncQueryableRepository<CourseOrder>, IAsyncOrderableRepository<CourseOrder>
    {
        Task<CourseOrder> IncludeGetFirstOrDefaultAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, bool tracking = true);
        Task<CourseOrder> IncludeGetFirstOrDefaultAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<CourseOrder>> IncludeGetAllWhereAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, Expression<Func<CourseOrder, object>> orderby, bool tracking = true);
        Task<ICollection<CourseOrder>> IncludeGetAllWhereAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<CourseOrder, object>> orderby, bool tracking = true);
    }
}