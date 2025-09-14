using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA.PL.Models.Identity
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name is Required ")]
        [Display(Name ="First Name ")]
        public required string  FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is Required ")]
        [Display(Name ="Last Name ")]
        public required string  LastName { get; set; }

        [Required(ErrorMessage ="User Name is Required ")]
        public required string UserName { get; set; }
        [Required(ErrorMessage ="Email is requird")]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirmed Password ")]
        [Compare(nameof(Password),ErrorMessage ="The Password and Confirmatin are not the same ")]
        public required string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
