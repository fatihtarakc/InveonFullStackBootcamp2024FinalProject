namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface ITrainerRepository :
        IAsyncAddableRepository<Trainer>, IAsyncDeletableRepository<Trainer>, IAsyncUpdatableRepository<Trainer>,
        IAsyncQueryableRepository<Trainer>, IAsyncOrderableRepository<Trainer>
    {
        Task<Trainer> GetByIdentityIdAsync(Guid identityId);

        Task<Trainer> IncludeGetFirstOrDefaultAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, bool tracking = true);
        Task<Trainer> IncludeGetFirstOrDefaultAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true);

        Task<ICollection<Trainer>> IncludeGetAllWhereAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, Expression<Func<Trainer, object>> orderby, bool tracking = true);
        Task<ICollection<Trainer>> IncludeGetAllWhereAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Trainer, object>> orderby, bool tracking = true);
    }
}