namespace InveonCourseApp.Backend.API.Extensions
{
    public static class ServiceRegistiration
    {
        public static WebApplicationBuilder AddApiLoggingWebApplicationBuilder(this WebApplicationBuilder builder)
        {
            builder.Logging
                .AddConfiguration(builder.Configuration.GetSection("Logging"))
                .ClearProviders()
                .AddConsole()
                .AddDebug();

            return builder;
        }

        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}