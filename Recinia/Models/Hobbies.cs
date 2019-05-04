using Recinia.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Models
{
    public class Hobbies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public Guid HobbieID { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public int Rating { get; set; }
        [ForeignKey("AspNetUsersId")]
        public ApplicationUser User { get; set; }
        public string AspNetUserId { get; set; }
    }
}
