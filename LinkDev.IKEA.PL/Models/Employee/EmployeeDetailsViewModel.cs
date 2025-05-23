using LinkDev.IKEA.DAL.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace LinkDev.IKEA.PL.Models.Employee
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName => $"{FirstName} {LastName}";
        public string? Email { get; set; }

        [Display(Name = "Phone Number ")]
        public string? PhoneNumber { get; set; }

        public Gender Gender { get; set; }
        [Display(Name = "Gender")]
        public string? GenderName => Gender.ToString();

        public string? Address { get; set; }
        public int? Age { get; set; }
        [Display(Name = "Hire Date")]
        public string? ForamttedHireDate { get; set; }

        [Display(Name = "Years Of Service")]
        public int YearsOfServic { get; set; }
        public string? Position { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public EmployeeType EmployeeType { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        public string Status => IsActive ? "Active" : "InActive";

        //Department Information 
        [Display(Name = "Department Id ")]
        public int? DepartmentId { get; set; }
        [Display(Name = "Department Name ")]
        public string? DepartmentName { get; set; }
        [Display(Name = "Department Code")]
        public string? DepartmentCode { get; set; }
        [Display(Name = "Manager Id ")]
        public int? ManagerDepartmentId  { get; set; }
        [Display(Name = "Manager Name ")]
        public  string? ManagerDepartmentName { get; set; }
        public  string? DepartmentDescription { get; set; }
        [Display(Name = "Created By ")]
        public string? CreatedBy { get; set; }
        [Display(Name = "Created On ")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Last Modified By ")]
        public string? LastModifiedBy { get; set; }
        [Display(Name = "Last MOdified Date ")]
        public DateTime LastModifiedOn { get; set; }

    }
}
