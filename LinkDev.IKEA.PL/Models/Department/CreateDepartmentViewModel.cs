using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA.PL.Models.Department
{
    public class CreateDepartmentViewModel
    {

        [Required(ErrorMessage ="Code is required Ya Hamada")]
        public required string Code { get; set; }
        public required string Name { get; set; }
        public  string? Description { get; set; }
        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
