using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_DnevnikWebApplication.Models
{
    public class Ucenik
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String jmbg { get; set; }
        public DateTime datumRodenja { get; set; }
        public String napomena { get; set; }
    }
}
