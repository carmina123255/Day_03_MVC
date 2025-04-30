using LinkDev.IKEA.DAL.Common;
using LinkDev.IKEA.DAL.Common.JsonConverter;
using LinkDev.IKEA.DAL.Contacts;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Data.DbInitializer
{
    public class DbInitializer:IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DbInitializer(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void initialize()
        {
            var pendingMigrations = _dbContext.Database.GetPendingMigrations().ToList();
            if (pendingMigrations.Any())
                _dbContext.Database.Migrate();
        }

        public void Seed()
        {
            var JsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                Converters =
                    {
                        new DataOnlyJsonConverter(),
                        new GenderJsonCoverter(),
                        new EmployeeTypeJsonCoverter()
                    }
            };
            if (!_dbContext.Departments.Any())
            {
                var departmentData = File.ReadAllText(@"D:\Route\MVC\Session03\LinkDev.IKIA\LinkDev.IKEA.DAL\Persistance\Data\Seeds\departments.json");
                var departments = JsonSerializer.Deserialize<List<Department>>(departmentData,JsonSerializerOptions);
                if (departments?.Count > 0)
                {
                    _dbContext.Departments.AddRange(departments);
                    _dbContext.SaveChanges();
                }
            }


            if (!_dbContext.Employees.Any())
            {
             
                var employeedata = File.ReadAllText(@"D:\Route\MVC\Session03\LinkDev.IKIA\LinkDev.IKEA.DAL\Persistance\Data\Seeds\employees.json");
              
                var Employees = JsonSerializer.Deserialize<List<Employee>>(employeedata,JsonSerializerOptions);
                if (Employees?.Count > 0)
                {
                    _dbContext.Employees.AddRange(Employees);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
