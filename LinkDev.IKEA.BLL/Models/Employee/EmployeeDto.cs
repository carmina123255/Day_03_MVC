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
    public record EmployeeDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string? DepartmentName { get; init; }
        public int? Age { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Address { get; init; }
        public decimal Salary { get; init; }
        public bool IsActive { get; init; }
        public DateOnly HireDate { get; init; }
        public Gender Gender { get; init; }
        public EmployeeType EmployeeType { get; init; }
        public int? DepartmentId { get; init; }
        public string? CreatedBy { get; init; }
        public DateTime CreatedOn { get; init; }
        public string? LastModifiedBy { get; init; }
        public DateTime LastModifiedOn { get; init; }
   
        
        public string FullName => $"{FirstName} {LastName}";
        public string FormattedHireDate => HireDate.ToString("MMMM d, yyyy");
    
    }
}
