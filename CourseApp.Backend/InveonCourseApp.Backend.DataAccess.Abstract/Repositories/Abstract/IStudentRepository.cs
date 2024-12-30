namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface IStudentRepository :
        IAsyncAddableRepository<Student>, IAsyncDeletableRepository<Student>, IAsyncUpdatableRepository<Student>,
        IAsyncQueryableRepository<Student>, IAsyncOrderableRepository<Student>
    {
        Task<Student> IncludeGetFirstOrDefaultAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, bool tracking = true);
        Task<Student> IncludeGetFirstOrDefaultAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<Student>> IncludeGetAllWhereAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, Expression<Func<Student, object>> orderby, bool tracking = true);
        Task<ICollection<Student>> IncludeGetAllWhereAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Student, object>> orderby, bool tracking = true);
    }
}