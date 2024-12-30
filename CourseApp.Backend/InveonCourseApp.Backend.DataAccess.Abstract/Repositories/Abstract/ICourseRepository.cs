namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface ICourseRepository :
        IAsyncAddableRepository<Course>, IAsyncDeletableRepository<Course>, IAsyncUpdatableRepository<Course>,
        IAsyncQueryableRepository<Course>, IAsyncOrderableRepository<Course>
    {
        Task<Course> IncludeGetFirstOrDefaultAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, bool tracking = true);
        Task<Course> IncludeGetFirstOrDefaultAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<Course>> IncludeGetAllWhereAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, Expression<Func<Course, object>> orderby, bool tracking = true);
        Task<ICollection<Course>> IncludeGetAllWhereAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Course, object>> orderby, bool tracking = true);
    }
}