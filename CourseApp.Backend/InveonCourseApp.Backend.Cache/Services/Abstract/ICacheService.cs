namespace InveonCourseApp.Backend.Cache.Services.Abstract
{
    public interface ICacheService<Entity> where Entity : AuditableBaseEntity
    {
        Task<IResult> AddAsync(string cacheKey, Entity entity, TimeSpan expiration);

        Task<IResult> DeleteAsync(string cacheKey);

        Task<IDataResult<Entity>> GetByAsync(string cacheKey);
    }
}