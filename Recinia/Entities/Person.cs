using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Entities
{
    public class Person
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        [ConcurrencyCheck]
        public String LastName { get; set; }
        public String Numéro { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
        public String Display { get; set; }
        //Navigation properties
        [NotMapped]
        public List<Adress> Adresses { get; set; }
    }
}
