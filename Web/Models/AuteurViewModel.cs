using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class AuteurViewModel
    {
        public int AuteurCode { get; set; }
        
        public NomCompletViewModel NomComplet { get; set; }
        public string imageURL { get; set; }
    }
}