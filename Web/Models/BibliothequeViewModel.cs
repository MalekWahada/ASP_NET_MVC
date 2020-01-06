using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class BibliothequeViewModel
    {
        public int BibliothequeCode { get; set; }
        public int NbrDocument { get; set; }
        public ICollection<DocumentViewModel> Documents { get; set; }
    }
}