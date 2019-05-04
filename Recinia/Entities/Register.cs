using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Entities
{
    public class Register
    {
        [Key]
        public Guid RegistreID { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

    }
}
