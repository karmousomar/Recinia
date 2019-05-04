using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.ViewModels
{
    public class ResetPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="must be between 6 and 60 caractere",MinimumLength =6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Mot de pass")]
        [Compare("Password",ErrorMessage ="Password and Confirmation MotPass must mutch")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
}
