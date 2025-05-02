using LinkDev.IKEA.DAL.Contacts;
using LinkDev.IKEA.DAL.Contracts;
using LinkDev.IKEA.DAL.Persistance.Data;
using LinkDev.IKEA.DAL.Persistance.Data.DbInitializer;
using LinkDev.IKEA.DAL.Persistance.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL
{
   public static  class DependencyInjection
    {
        public static IServiceCollection AddPresistanceServices(this IServiceCollection Services,IConfiguration Configuration)
        {
           Services.AddDbContext<ApplicationDbContext>(
               optionsAction: (OptionBuilder) =>
               {
                   OptionBuilder.UseSqlServer(connectionString:Configuration.GetConnectionString("DefaultConnection"));
               }
               /// contextLifetime: ServiceLifetime.Scoped,
               /// optionsLifetime: ServiceLifetime.Scoped
               );
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IDbInitializer, DbInitializer>();
          /// Services.AddScoped<IDbInitializer, DbInitializer>((ServiceProvider) =>
          /// {
          ///     var dbContext = ServiceProvider.GetRequiredService<ApplicationDbContext>();
          ///     return new DbInitializer(dbContext);
          /// });
           
            return Services;

        }
    }
}
