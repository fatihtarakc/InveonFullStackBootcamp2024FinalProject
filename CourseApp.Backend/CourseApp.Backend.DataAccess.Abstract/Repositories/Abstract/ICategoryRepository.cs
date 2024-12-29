namespace CourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface ICategoryRepository :
        IAsyncAddableRepository<Category>, IAsyncDeletableRepository<Category>, IAsyncUpdatableRepository<Category>,
        IAsyncQueryableRepository<Category>, IAsyncOrderableRepository<Category> { }
}