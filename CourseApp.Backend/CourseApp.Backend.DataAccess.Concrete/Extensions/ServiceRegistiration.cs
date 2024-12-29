namespace CourseApp.Backend.DataAccess.Concrete.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddDataAccessConcreteServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICourseOrderRepository, CourseOrderRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //var serviceProvider = services.BuildServiceProvider();
            //var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            //var iOptionsConnectionOptions = serviceProvider.GetRequiredService<IOptions<ConnectionOptions>>();
            //DataSeeder.AddAsync(userManager, iOptionsConnectionOptions).GetAwaiter().GetResult();

            return services;
        }
    }
}