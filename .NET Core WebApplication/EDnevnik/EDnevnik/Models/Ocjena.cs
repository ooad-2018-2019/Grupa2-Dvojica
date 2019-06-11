using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Ocjena
    {
        public int ocjena { get; set; }
        public DateTime datumUnosa { get; set; }
        public int idUcenika { get; set; }

    }
}
