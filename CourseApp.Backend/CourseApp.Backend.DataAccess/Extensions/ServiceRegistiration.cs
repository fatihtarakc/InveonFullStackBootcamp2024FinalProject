﻿namespace CourseApp.Backend.DataAccess.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionOptions>
                (configuration.GetSection(ConnectionOptions.Connections));

            var connectionOptions = configuration.GetSection(ConnectionOptions.Connections).Get<ConnectionOptions>();
            services.AddDbContext<CourseAppDbContext>(dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder.UseLazyLoadingProxies();
                dbContextOptionsBuilder.UseSqlServer(connectionOptions!.MssqlServer,
                    sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(10), null));
            });

            services.AddIdentity<IdentityUser, IdentityRole>(identityOptions =>
            {
                identityOptions.SignIn.RequireConfirmedEmail = true;

                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequiredUniqueChars = 4;
                identityOptions.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<CourseAppDbContext>().AddErrorDescriber<CustomIdentityErrorDescriber>().AddDefaultTokenProviders();

            return services;
        }
    }

    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Password must have been {length} characters at least !"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Password must have been min one alphanumeric character !"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Password must have been min one digit character !"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Password must have been min one lower character !"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Password must have been min one upper character !"
            };
        }
    }
}