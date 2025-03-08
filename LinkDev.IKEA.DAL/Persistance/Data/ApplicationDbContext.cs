using LinkDev.IKEA.DAL.Common.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Data
{
    class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server =.;Database =Company;Trusted_Connection =True ; Encrypt =True;TrustServerCertificate =true");
        }
        public DbSet<Department>Departments { get; set; }
    }
}
