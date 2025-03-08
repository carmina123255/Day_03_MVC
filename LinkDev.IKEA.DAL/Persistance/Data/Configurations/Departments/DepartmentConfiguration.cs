using LinkDev.IKEA.DAL.Common.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Data.Configurations.Departments
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Code).HasColumnType("varchar(10)");
            builder.Property(D => D.Name).HasColumnType("varchar(100)");
            builder.Property(D => D.Description).HasColumnType("varchar(100)");


          ///  builder.Property(E => E.CreatedBy).HasColumnType("varchar(50)");
          ///  builder.Property(E => E.LastModifiedBy).HasColumnType("varchar(50)");
          ///  builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETUTCDate()");
          ///  builder.Property(E => E.LastModifiedOn).HasComputedColumnSql("GETUTCDate()");
            
        }
    }
}
