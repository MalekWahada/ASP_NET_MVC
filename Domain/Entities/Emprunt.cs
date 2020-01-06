using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("EmpruntLivre")]
    public class Emprunt
    {
        //public int EmpruntID { get; set; }
        [Key, Column(Order = 1)]
        public DateTime DateEmprunt { get; set; }

        [Key, Column(Order = 2)]
        public int AdherantCode { get; set; }

        [Key, Column(Order = 3)]
        public int DocumentCode { get; set; }

        //prop de navigation
        public Document Document { get; set; }
        public Adherant Adherant { get; set; }

    }
}
