using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Entities
{
    [Table("adr", Schema = "Adress")]

    public class Adress
    {
        public int AddId { get; set; }
        [Column("Street",TypeName ="varchar(20)")]
        public String StreetName { get; set; }
        [MaxLength(20)]
        public String City { get; set; }
        public String State { get; set; }
        //Here or in AppDbContext
        [Required]
        public String ZipCode { get; set; }
        public int PersonId { get; set; }
        //Navigation properties
        [NotMapped]
        public Person MyPerson { get; set; }
    }
}
