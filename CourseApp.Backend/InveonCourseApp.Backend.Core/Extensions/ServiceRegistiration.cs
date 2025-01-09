namespace InveonCourseApp.Backend.Core.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionOptions>
                (configuration.GetSection(ConnectionOptions.ConnectionConfiguration));

            services.Configure<EmailOptions>
                (configuration.GetSection(EmailOptions.EmailConfiguraiton));

            services.Configure<Options.TokenOptions>
                (configuration.GetSection(Options.TokenOptions.TokenConfiguration));

            return services;
        }
    }
}