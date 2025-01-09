namespace InveonCourseApp.Backend.BackgroundJobs.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddBackgroundJobsServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            var connectionOptions = serviceProvider.GetRequiredService<IOptions<ConnectionOptions>>().Value;
            services.AddHangfire(configuration =>
            {
                var option = new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true,
                    QueuePollInterval = TimeSpan.FromMinutes(5),
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true,
                };
                configuration.UseSqlServerStorage(connectionOptions.Hangfire, option).WithJobExpirationTimeout(TimeSpan.FromHours(6));
            });
            services.AddHangfireServer();

            services.AddScoped<IJobSchedulerService, JobSchedulerService>();

            return services;
        }

        public static IApplicationBuilder AddBackgroundJobsUseHangfireDashboardWithPathApplicationBuilder(this IApplicationBuilder applicationBuilder, string pathMatch = "/hangfire")
        {
            applicationBuilder.UseHangfireDashboard(pathMatch, new DashboardOptions
            {
                DashboardTitle = "Library Hangfire DashBoard",
                Authorization = new[] { new HangfireAuthorizationFilter() },
            });

            FireAndForgetJobs.SendEmailJob();
            return applicationBuilder;
        }
    }
}