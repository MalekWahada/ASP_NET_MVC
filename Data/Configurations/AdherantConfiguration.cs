using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
   public class AdherantConfiguration : EntityTypeConfiguration<Adherant>
    {
        public AdherantConfiguration()
        {
            HasRequired<Adresse>(a => a.Adr).WithRequiredPrincipal(a => a.Adh);

            HasMany<Document>(p => p.ListDocComment).WithMany(o => o.ListAdherantComment).Map(r => { r.ToTable("Comments"); r.MapLeftKey("DocumentCode"); r.MapRightKey("AdherantCode"); });
            HasMany<Document>(p => p.ListDocNote).WithMany(o => o.ListAdherantNote).Map(r => { r.ToTable("Notes"); r.MapLeftKey("DocumentCode"); r.MapRightKey("AdherantCode"); });
            //Map<Professeur>(c =>
            //{
            //    c.Requires("Type").HasValue(1);
            //});
            //////Type is the descreminator             
            //Map<Etudiant>(c =>
            //{
            //    c.Requires("Type").HasValue(0);
            //});

        }
    }
}
