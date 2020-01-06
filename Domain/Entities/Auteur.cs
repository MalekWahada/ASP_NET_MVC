using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Auteur
    {
        public int AuteurCode { get; set; }
        //public int CIN { get; set; }

        //public string Nom { get; set; }
        //public string Prenom { get; set; }
        public NomComplet NomComplet { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        [Required(ErrorMessage = "Image is Required")]
        public string Imageurl { get; set; }

        //prop de navigation
        public virtual ICollection<Document> ListDoc { get; set; }
    }
}
