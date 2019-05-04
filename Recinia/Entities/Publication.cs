using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Entities
{
    public class Publication
    {
        [Key]
        //il faut de provide this Value on typing
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PubID { get; set; }
        public string contenu { get; set; }
        public string Image { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string TimePost { get; set; }
        [ForeignKey("AspNetUsersId")]
        public ApplicationUser User { get; set; }
        public string AspNetUserId { get; set; }
    }
}
