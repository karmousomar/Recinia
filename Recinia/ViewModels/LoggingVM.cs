using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.ViewModels
{
    public class LoggingVM
    {
        [Required(ErrorMessage ="UserName is Require")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password Is Require !")]
        [DataType(DataType.Password)]
        [StringLength(25,ErrorMessage ="Mot de passe Invalide",MinimumLength =5 )]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
