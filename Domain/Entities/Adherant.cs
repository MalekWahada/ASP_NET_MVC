using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Adherant
    {
        public int AdherantCode { get; set; }

        //public int CIN { get; set; }
        //public string Nom { get; set; }
        //public string Prenom { get; set; }
        public NomComplet NomComplet { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        [Required(ErrorMessage = "Image is Required")]
        public string Image { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string MotDePasse { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("MotDePasse")]
        public string ConfirmMotDePasse { get; set; }

        public int NbrAvertissement { get; set; }

        //prop de navigation
        public Adresse Adr { get; set; }
        public virtual ICollection<Emprunt> ListEmprunt { get; set; }
        public virtual ICollection<Document> ListDocComment { get; set; }
        public virtual ICollection<Document> ListDocNote { get; set; }
    }
}
