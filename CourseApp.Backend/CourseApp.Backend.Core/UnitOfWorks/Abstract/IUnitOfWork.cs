namespace CourseApp.Backend.Core.UnitOfWorks.Abstract
{
    public interface IUnitOfWork :
        IAsyncSaveChangesUnitOfWork, IAsyncTransactionUnitOfWork,
        IDisposable, IAsyncDisposable { }
}