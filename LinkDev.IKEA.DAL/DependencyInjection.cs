using LinkDev.IKEA.DAL.Persistance.Data;
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
            return Services;

        }
    }
}
