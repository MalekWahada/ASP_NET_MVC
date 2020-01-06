using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Etat
    {
       Disponible, Emprunte
    }
 public class Document
    {
        public int DocumentID { get; set; }

        public Etat Etat { get; set; }

        [DataType(DataType.MultilineText)]
        public string Titre { get; set; }

        [Display(Name = "CategorieDoc")]
        [StringLength(50)]
        public string Categorie { get; set; }


        //clé etrangère
        public int BibliothequeFK { get; set; }

        //prop de navigation
        public Bibliotheque Biblio { get; set; }
        public virtual ICollection<Auteur>ListAuteur { get; set; }
        public virtual ICollection<Emprunt> ListEmprunt { get; set; }
        public virtual ICollection<Adherant> ListAdherantComment { get; set; }
        public virtual ICollection<Adherant> ListAdherantNote { get; set; }


    }
}
