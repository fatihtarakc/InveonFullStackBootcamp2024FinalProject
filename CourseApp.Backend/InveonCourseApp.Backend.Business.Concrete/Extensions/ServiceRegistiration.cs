namespace InveonCourseApp.Backend.Business.Concrete.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddBusinessConcreteServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseOrderService, CourseOrderService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IStudentCourseService, StudentCourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITrainerService, TrainerService>();

            return services;
        }
    }
}