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
            var tokenOptions = configuration.GetSection(TokenOptions.TokenConfiguration).Get<TokenOptions>()!;
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;

                options.TokenValidationParameters = new()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = tokenOptions.Audience,
                    ValidIssuer = tokenOptions.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.IssuerSigningSymmetricSecurityKey))
                };
            });

            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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