using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CD:Document
    {
        public TimeSpan Duree { get; set; }
        public int NbrDePlage { get; set; }

    }
}
