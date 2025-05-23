using LinkDev.IKEA.DAL.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LinkDev.IKEA.PL.Models.Employee
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [MinLength(5, ErrorMessage = "Min Length for first Name is 5 char")]
        [MaxLength(50, ErrorMessage = "Max Length for first Name is 50 char")]
        public string? FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [MinLength(5, ErrorMessage = "Min Length for first Name is 5 char")]
        [MaxLength(50, ErrorMessage = "Max Length for first Name is 50 char")]
        public string? LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000000, ErrorMessage = "Salary must be between 0.01 and 1000_000")]
        public decimal Salary { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
                     ErrorMessage = "Address must be in format: 123-Street-City-Country")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Phone Number ")]
        public string? PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public bool IsActive { get; set; }


        [Display(Name = "Department Id ")]
        public int? DepartmentId { get; set; }

        //for drop down 
        public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();

    }

}
