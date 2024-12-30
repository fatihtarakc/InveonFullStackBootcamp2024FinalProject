namespace InveonCourseApp.Backend.Cache.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped((typeof(ICacheService<>)), typeof(CacheService<>));

            var serviceProvider = services.BuildServiceProvider();
            var connectionOptions = serviceProvider.GetRequiredService<IOptions<ConnectionOptions>>().Value;
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString(connectionOptions.Redis);
                options.InstanceName = "RedisInstance";
            });

            return services;
        }
    }
}