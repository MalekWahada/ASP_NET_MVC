using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Bibliotheque
    {
        public int BibliothequeCode { get; set; }
        public int NbrDocument { get; set; }

        //prop de navigation
        public virtual ICollection<Document> ListDoc { get; set; }
    }
}
