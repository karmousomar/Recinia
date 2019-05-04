using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.ViewModels
{
    public class ELCVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
