using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class EmpruntConfiguration : EntityTypeConfiguration<Emprunt>
     
    {
        public EmpruntConfiguration()
        {
           HasKey(e => new { e.AdherantCode, e.DocumentCode, e.DateEmprunt });
        }
    }
}
