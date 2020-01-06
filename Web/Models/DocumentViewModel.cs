using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public enum Etat
    {
        Disponible, Emprunte
    }
    public class DocumentViewModel
    {
        public int DocumentID { get; set; }
        public Etat Etat { get; set; }

        public string Titre { get; set; }
        public string Categorie { get; set; }
        public int BibliothequeFK { get; set; }

        public BibliothequeViewModel Bibliotheque { get; set; }
    }
}