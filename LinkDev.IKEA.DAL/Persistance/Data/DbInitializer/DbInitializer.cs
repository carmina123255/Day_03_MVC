using LinkDev.IKEA.DAL.Common.Entities.Departments;
using LinkDev.IKEA.DAL.Contacts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            if (!_dbContext.Departments.Any())
            {
                var departmentData = File.ReadAllText(@"D:\Route\MVC\Session03\LinkDev.IKIA\LinkDev.IKEA.DAL\Persistance\Data\Seeds\departments.json");
                var departments = JsonSerializer.Deserialize<List<Department>>(departmentData);
                if (departments?.Count > 0)
                {
                    _dbContext.Departments.AddRange(departments);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
