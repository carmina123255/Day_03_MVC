using LinkDev.IKEA.DAL.Contacts;
using LinkDev.IKEA.DAL.Contracts;
using LinkDev.IKEA.DAL.Entities.Identity;
using LinkDev.IKEA.DAL.Persistance.Data;
using LinkDev.IKEA.DAL.Persistance.Data.DbInitializer;
using LinkDev.IKEA.DAL.Persistance.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.IKEA.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresistanceServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            // Add DbContext
            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add Unit of Work and DbInitializer
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IDbInitializer, DbInitializer>();

            

            return Services;
        }
    }
}