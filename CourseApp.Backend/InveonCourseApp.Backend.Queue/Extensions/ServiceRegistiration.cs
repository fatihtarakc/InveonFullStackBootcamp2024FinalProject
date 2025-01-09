namespace InveonCourseApp.Backend.Queue.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddQueueServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IObjectConvertFormatService, ObjectConvertFormatService>();
            services.AddScoped<IRabbitmqConsumerService, RabbitmqConsumerService>();
            services.AddScoped<IRabbitmqPublisherService, RabbitmqPublisherService>();
            services.AddScoped<IRabbitmqService, RabbitmqService>();

            return services;
        }
    }
}