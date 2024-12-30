namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface ITrainerRepository :
        IAsyncAddableRepository<Trainer>, IAsyncDeletableRepository<Trainer>, IAsyncUpdatableRepository<Trainer>,
        IAsyncQueryableRepository<Trainer>, IAsyncOrderableRepository<Trainer> { }
}