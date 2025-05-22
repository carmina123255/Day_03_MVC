using LinkDev.IKEA.DAL.Contacts;

namespace LinkDev.IKEA.PL.Extenstions
{
    public static class InitializerExtensions
    {

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var Scope = app.ApplicationServices.CreateScope();
            var Services = Scope.ServiceProvider;

            var DbInitialize = Services.GetRequiredService<IDbInitializer>();
            DbInitialize.initialize();
            DbInitialize.Seed();

        }
    }
}
