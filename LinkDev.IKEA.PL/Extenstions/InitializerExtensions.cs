using LinkDev.IKEA.DAL.Contacts;
using LinkDev.IKEA.DAL.Entities.Identity;
using LinkDev.IKEA.DAL.Persistance.Data.DbInitializer;
using Microsoft.AspNetCore.Identity;

namespace LinkDev.IKEA.PL.Extenstions
{
    public static class InitializerExtensions
    {

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var Scope = app.ApplicationServices.CreateScope();
            var Services = Scope.ServiceProvider;

            var dbInitializer = Services.GetRequiredService<IDbInitializer>();
            dbInitializer.initialize();
            dbInitializer.Seed();

           /// var userManager = Services.GetRequiredService<UserManager<ApplicationUser>>();
           /// var roleManager = Services.GetRequiredService <RoleManager < IdentityRole >> ();
           ///
           /// dbInitializer.SeedUserAsync(userManager, roleManager);


        }
    }
}
