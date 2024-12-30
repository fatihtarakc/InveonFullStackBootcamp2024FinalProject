namespace InveonCourseApp.Backend.Core.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionOptions>
                (configuration.GetSection(ConnectionOptions.Connections));

            services.Configure<EmailOptions>
                (configuration.GetSection(EmailOptions.EmailConfiguraiton));

            return services;
        }
    }
}