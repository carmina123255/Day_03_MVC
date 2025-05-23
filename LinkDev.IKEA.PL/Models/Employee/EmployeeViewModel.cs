using LinkDev.IKEA.DAL.Common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA.PL.Models.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        public int? Age { get; set; }
        [Display(Name ="Hiring Date")]
        public string? FormatteingHireDate { get; set; }

        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name="Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType  EmployeeType { get; set; }
    
       public String? Department { get;set; }
       

        #region Administration
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        #endregion


    }
}
