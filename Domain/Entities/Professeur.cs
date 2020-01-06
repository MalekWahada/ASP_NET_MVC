using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Professeur:Adherant
    {
        public string Departement { get; set; }

        [DataType(DataType.Currency)]
        public int Salaire { get; set; }
        public string Grade { get; set; }
        public DateTime DateDePriseDeFonction { get; set; }
    }
}
