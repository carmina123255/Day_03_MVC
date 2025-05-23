using LinkDev.IKEA.BLL.Mapping.Profiles;
using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.BLL.Services.Employees;
using LinkDev.IKEA.DAL.Contacts;
using LinkDev.IKEA.DAL.Persistance.Data;
using LinkDev.IKEA.DAL.Persistance.Data.DbInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL
{
   public static  class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection Services)
        {
            Services.AddScoped<IDepartmentService, DepartmentService>();
            Services.AddScoped<IEmployeeService, EmployeeService>();
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());
           
            Services.AddAutoMapper(M => M.AddProfiles(new[] { new EmployeeProfile() }));
            Services.AddAutoMapper(typeof(AssemblyInforamtion).Assembly);
            Services.AddAutoMapper(typeof(EmployeeProfile));
            return Services;

        }
    }
}
