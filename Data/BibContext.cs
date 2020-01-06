using Data.Configurations;
using Data.Conventions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class BibContext:DbContext
    {
        public BibContext():base("name=BibDB")
        {

        }
        public DbSet<Bibliotheque> Bibliotheques { get; set; }
        public DbSet<Adherant> Adherants { get; set; }
        public DbSet<Document> Documents { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             //Convention
             modelBuilder.Conventions.Add(new KeyConvention());
             modelBuilder.Conventions.Add(new DatetimeConvention());
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Fluent API
            modelBuilder.Configurations.Add(new DocConfiguration());
             modelBuilder.Configurations.Add(new EmpruntConfiguration());
            modelBuilder.Configurations.Add(new AdherantConfiguration());

            //TPT
            modelBuilder.Entity<CD>().ToTable("CD");
             modelBuilder.Entity<Livre>().ToTable("Livre");
             //TPC
             modelBuilder.Entity<Etudiant>().Map(m => { m.MapInheritedProperties(); m.ToTable("Etudiant"); });
             modelBuilder.Entity<Professeur>().Map(m => { m.MapInheritedProperties(); m.ToTable("Professeur"); });

         }
    }
}
