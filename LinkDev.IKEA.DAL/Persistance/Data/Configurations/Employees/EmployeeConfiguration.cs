using LinkDev.IKEA.DAL.Common.Enums;
using LinkDev.IKEA.DAL.Entities.Employees;
using LinkDev.IKEA.DAL.Persistance.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinkDev.IKEA.DAL.Persistance.Data.Configurations.Employees
{
     class EmployeeConfiguration :BaseAuditableEntityConfigurations<int,Employee> 
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.Property(E => E.Id).UseIdentityColumn(1, 1);
            builder.Property(E => E.FirstName).HasColumnType("varchar(50)");
            builder.Property(E => E.LastName).HasColumnType("varchar(50)");
            builder.Property(E => E.Email).HasColumnType("varchar(100)");
            builder.Property(E => E.Gender).HasConversion(
                (gender) => gender.ToString(),
                (gender) => Enum.Parse<Gender>(gender));

            builder.Property(E => E.EmployeeType).HasConversion
                (
                (EmpType) => EmpType.ToString(),
                (EmpType) => Enum.Parse<EmployeeType>(EmpType)
                );

            builder.HasOne(E => E.Department)
                 .WithMany(D => D.Employees)
                 .HasForeignKey(e => e.DepartmentId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
