using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adresse
    {
        public int CodePostale { get; set; }
        public int AdresseId { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public Adherant Adh { get; set; }
    }
}
