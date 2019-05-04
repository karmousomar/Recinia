using Recinia.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Models
{
    public class Organization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrganizationID { get; set; }
        [StringLength(20)]
        [Required]
        public string BusinessName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Profession { get; set; }
        [ForeignKey("AspNetUsersId")]
        public ApplicationUser User { get; set; }
        public string AspNetUserId { get; set; }
    }
}
