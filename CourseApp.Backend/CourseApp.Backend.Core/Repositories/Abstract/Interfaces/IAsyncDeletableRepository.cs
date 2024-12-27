namespace CourseApp.Backend.Core.Repositories.Abstract.Interfaces
{
    public interface IAsyncDeletableRepository<Entity> where Entity : AuditableBaseEntity
    {
        ValueTask DeleteAsync(Entity entity);
    }
}