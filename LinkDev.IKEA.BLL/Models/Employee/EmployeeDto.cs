using LinkDev.IKEA.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Employee
{
   public  record EmployeeDto(int Id, string FirstName, 
       string LastName,int? Age, string? Email, string? phoneNumber,
       string? Address, decimal Salary, bool IsActive,
       DateOnly HireDate, Gender Gender, EmployeeType EmployeeType,
       int? DepartmentId, string? CreatedBy, DateTime CreatedOn
       , string? LastModifiedBy, DateTime LastModifiedOn)

    {
        public string FullName => $"{FirstName} {LastName}";
        public string FromattedHireDate => HireDate.ToString("MMMM d,yyyy");

    };
}
