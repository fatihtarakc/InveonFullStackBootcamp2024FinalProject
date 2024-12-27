namespace CourseApp.Backend.Core.UnitOfWorks.Abstract
{
    public interface IAsyncTransactionUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task<IExecutionStrategy> CreateExecutionStrategy();
    }
}