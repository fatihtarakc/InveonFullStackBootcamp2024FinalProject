namespace CourseApp.Backend.Core.UnitOfWorks.Abstract
{
    public interface IAsyncSaveChangesUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}