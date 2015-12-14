using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesStatistics.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Field Email is required.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "It is not Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Field Email is required.")]
        [EmailAddress(ErrorMessage = "It is not Email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field UserName is required.")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Field Password is required.")]
        [StringLength(18, ErrorMessage = "Not less 6 symbols and not more 18.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Password can inclide only a-z, 0-9 and _.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and its confirm not equals.")]
        public string ConfirmPassword { get; set; }
    }
}
