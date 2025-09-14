using LinkDev.IKEA.DAL.Entities.Identity;
using LinkDev.IKEA.DAL.Persistance.Data;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace LinkDev.IKEA.PL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = true;//"!@#$%^&*(){}"
                    options.Password.RequireDigit = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredUniqueChars = 1;


                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "ABCDEFGHIGKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()}{";

                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;

                    ///options.SignIn.RequireConfirmedAccount = true;
                    ///options.SignIn.RequireConfirmedEmail = true;
                    ///options.SignIn.RequireConfirmedPhoneNumber = true;
                }
                ).AddEntityFrameworkStores<ApplicationDbContext>();
            
            return services;
        }
    }
}
