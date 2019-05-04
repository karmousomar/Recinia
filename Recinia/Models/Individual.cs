using Recinia.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recinia.Models
{
    public class Individual
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid IndividualID { get; set; }
        [Required]
        [StringLength(20)]
        public string FullName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        [ForeignKey("AspNetUsersId")]
        public ApplicationUser User { get; set; }
        public string AspNetUserId { get; set; }
    }
}
