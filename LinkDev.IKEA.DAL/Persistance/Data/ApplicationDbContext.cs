using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Entities.Employees;
using LinkDev.IKEA.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        
        }

       ///        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       ///        {
       ///            optionsBuilder
       ///                .UseSqlServer("Server =.;Database =IKEA;Trusted_Connection =True ; Encrypt =True;TrustServerCertificate =true");
       ///        }
       ///
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Employee>Employees { get; set; }

         /// public DbSet<ApplicationUser>Users { get; set; }
         /// public DbSet<IdentityRole>Roles { get; set; }

    }
}
