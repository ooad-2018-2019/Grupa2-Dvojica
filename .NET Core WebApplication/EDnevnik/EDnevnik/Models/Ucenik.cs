using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Ucenik
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public String Ime { get; set; }
        [Required]
        public String Prezime { get; set; }
        [Required]
        public String jmbg { get; set; }
        [Required]
        public DateTime datumRodenja { get; set; }
        public String napomena { get; set; }
    }
}
