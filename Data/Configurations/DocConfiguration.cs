using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class DocConfiguration :EntityTypeConfiguration<Document>
    {
        public DocConfiguration()
        {
            // HasMany<Adherant>(e => e.ListAdherantNote).WithMany(e => e.ListDocNote).Map(e => e.ToTable("Notes"));
            //HasMany<Adherant>(e => e.ListAdherantComment).WithMany(e => e.ListDocComment).Map(e => e.ToTable("Comments"));
            HasRequired<Bibliotheque>(e => e.Biblio).WithMany(e => e.ListDoc).HasForeignKey(e => e.BibliothequeFK).WillCascadeOnDelete();
            HasMany<Auteur>(e => e.ListAuteur).WithMany(e => e.ListDoc).Map(r => { r.ToTable("DocAuth"); r.MapLeftKey("AuteurFK"); r.MapRightKey("DocumentFK"); });
        }
    }
}
