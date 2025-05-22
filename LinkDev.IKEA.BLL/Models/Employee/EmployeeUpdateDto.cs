using LinkDev.IKEA.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Employee
{
    public record EmployeeUpdateDto(
     int Id,
     string FirstName,
     string LastName,
     string? Address,
     decimal Salary,
     string? Email,
     string? PhoneNumber,
     DateOnly BirthOfDate,
     bool IsActive ,
     Gender Gender,
    EmployeeType EmployeeType,
     int? DepartmentId
        );
}
