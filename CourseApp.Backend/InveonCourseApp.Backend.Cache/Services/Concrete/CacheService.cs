namespace InveonCourseApp.Backend.Cache.Services.Concrete
{
    public class CacheService<Entity> : ICacheService<Entity> where Entity : AuditableBaseEntity
    {
        private readonly IDistributedCache distributedCache;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<CacheService<Entity>> logger;
        public CacheService(IDistributedCache distributedCache, IStringLocalizer<MessageResources> stringLocalizer, ILogger<CacheService<Entity>> logger)
        {
            this.distributedCache = distributedCache;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IResult> AddAsync(string cacheKey, Entity entity, TimeSpan expiration)
        {
            var options = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration };

            try
            {
                await distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(entity), options);
                return new SuccessResult(stringLocalizer[Message.Redis_Cache_Entity_Was_Added]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Redis_Cache_Entity_Could_Not_Be_Added]} : {exception.Message}");
                return new ErrorResult($"{stringLocalizer[Message.Redis_Cache_Entity_Could_Not_Be_Added]} : {exception.Message}");
            }
        }

        public async Task<IResult> DeleteAsync(string cacheKey)
        {
            try
            {
                await distributedCache.RemoveAsync(cacheKey);

                return new SuccessResult(stringLocalizer[Message.Redis_Cache_Entity_Was_Deleted]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Redis_Cache_Entity_Could_Not_Be_Deleted]} : {exception.Message}");
                return new ErrorResult($"{stringLocalizer[Message.Redis_Cache_Entity_Could_Not_Be_Deleted]} : {exception.Message}");
            }
        }

        public async Task<IDataResult<Entity>> GetByAsync(string cacheKey)
        {
            try
            {
                var jsonData = await distributedCache.GetStringAsync(cacheKey);
                if (jsonData is null) return new ErrorDataResult<Entity>(stringLocalizer[Message.Redis_Cache_Entity_Was_Not_Found]);

                return new SuccessDataResult<Entity>(JsonSerializer.Deserialize<Entity>(jsonData), stringLocalizer[Message.Redis_Cache_Entity_Was_Found]);
            }
            catch (Exception exception)
            {
                logger.LogError($"{stringLocalizer[Message.Redis_Cache_Entity_Was_Not_Found]} : {exception.Message}");
                return new ErrorDataResult<Entity>($"{stringLocalizer[Message.Redis_Cache_Entity_Was_Not_Found]} : {exception.Message}");
            }
        }
    }
}