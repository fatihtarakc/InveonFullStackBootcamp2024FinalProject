using Microsoft.AspNetCore.Localization;
using System.Globalization;

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
            services.AddLocalization();
            return services;
        }

        public static IApplicationBuilder AddApiUseRequestLocalizationApplicationBuilder(this IApplicationBuilder applicationBuilder)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"), new CultureInfo("tr-TR")
            };

            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                ApplyCurrentCultureToResponseHeaders = true,
                DefaultRequestCulture = new RequestCulture("tr-TR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            applicationBuilder.UseRequestLocalization(requestLocalizationOptions);

            return applicationBuilder;
        }
    }
}