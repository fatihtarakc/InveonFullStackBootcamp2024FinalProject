namespace InveonCourseApp.Backend.Core.Repositories.Abstract.Interfaces
{
    public interface IAsyncOrderableRepository<Entity> where Entity : AuditableBaseEntity
    {
        Task<IEnumerable<Entity>> GetAllWhereOrderByAsync<TKey>(Expression<Func<Entity, TKey>> orderby, bool orderDesc = false, bool tracking = true);

        Task<IEnumerable<Entity>> GetAllWhereOrderByAsync<TKey>(Expression<Func<Entity, bool>> expression, Expression<Func<Entity, TKey>> orderby, bool orderDesc = false, bool tracking = true);
    }
}