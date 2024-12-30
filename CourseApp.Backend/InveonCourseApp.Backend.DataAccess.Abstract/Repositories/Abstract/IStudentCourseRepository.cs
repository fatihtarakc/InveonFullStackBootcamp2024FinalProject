namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface IStudentCourseRepository :
        IAsyncAddableRepository<StudentCourse>, IAsyncDeletableRepository<StudentCourse>, IAsyncUpdatableRepository<StudentCourse>,
        IAsyncQueryableRepository<StudentCourse>, IAsyncOrderableRepository<StudentCourse>
    {
        Task<StudentCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, bool tracking = true);
        Task<StudentCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<StudentCourse>> IncludeGetAllWhereAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, Expression<Func<StudentCourse, object>> orderby, bool tracking = true);
        Task<ICollection<StudentCourse>> IncludeGetAllWhereAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<StudentCourse, object>> orderby, bool tracking = true);
    }
}