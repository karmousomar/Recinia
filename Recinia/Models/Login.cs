using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Models
{
    public class Login
    {
        [Key]
        public Guid LoginID { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}
