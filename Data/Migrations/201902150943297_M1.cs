namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdresseId = c.Int(nullable: false),
                        CodePostale = c.Int(nullable: false),
                        Rue = c.String(),
                        Ville = c.String(),
                    })
                .PrimaryKey(t => t.AdresseId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        Etat = c.Int(nullable: false),
                        Titre = c.String(),
                        Categorie = c.String(maxLength: 50),
                        BibliothequeFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Bibliotheques", t => t.BibliothequeFK, cascadeDelete: true)
                .Index(t => t.BibliothequeFK);
            
            CreateTable(
                "dbo.Bibliotheques",
                c => new
                    {
                        BibliothequeCode = c.Int(nullable: false, identity: true),
                        NbrDocument = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BibliothequeCode);
            
            CreateTable(
                "dbo.Auteurs",
                c => new
                    {
                        AuteurCode = c.Int(nullable: false, identity: true),
                        NomComplet_Nom = c.String(),
                        NomComplet_Prenom = c.String(),
                    })
                .PrimaryKey(t => t.AuteurCode);
            
            CreateTable(
                "dbo.EmpruntLivre",
                c => new
                    {
                        DateEmprunt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AdherantCode = c.Int(nullable: false),
                        DocumentCode = c.Int(nullable: false),
                        Document_DocumentID = c.Int(),
                    })
                .PrimaryKey(t => new { t.DateEmprunt, t.AdherantCode, t.DocumentCode })
                .ForeignKey("dbo.Documents", t => t.Document_DocumentID)
                .Index(t => t.Document_DocumentID);
            
            CreateTable(
                "dbo.DocAuth",
                c => new
                    {
                        AuteurFK = c.Int(nullable: false),
                        DocumentFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuteurFK, t.DocumentFK })
                .ForeignKey("dbo.Documents", t => t.AuteurFK, cascadeDelete: true)
                .ForeignKey("dbo.Auteurs", t => t.DocumentFK, cascadeDelete: true)
                .Index(t => t.AuteurFK)
                .Index(t => t.DocumentFK);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        DocumentCode = c.Int(nullable: false),
                        AdherantCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentCode, t.AdherantCode })
                .ForeignKey("dbo.Documents", t => t.AdherantCode, cascadeDelete: true)
                .Index(t => t.AdherantCode);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        DocumentCode = c.Int(nullable: false),
                        AdherantCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentCode, t.AdherantCode })
                .ForeignKey("dbo.Documents", t => t.AdherantCode, cascadeDelete: true)
                .Index(t => t.AdherantCode);
            
            CreateTable(
                "dbo.CD",
                c => new
                    {
                        DocumentID = c.Int(nullable: false),
                        Duree = c.Time(nullable: false, precision: 7),
                        NbrDePlage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Documents", t => t.DocumentID)
                .Index(t => t.DocumentID);
            
            CreateTable(
                "dbo.Livre",
                c => new
                    {
                        DocumentID = c.Int(nullable: false),
                        NbrDePage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Documents", t => t.DocumentID)
                .Index(t => t.DocumentID);
            
            CreateTable(
                "dbo.Etudianat",
                c => new
                    {
                        AdherantCode = c.Int(nullable: false),
                        NomComplet_Nom = c.String(),
                        NomComplet_Prenom = c.String(),
                        Image = c.String(nullable: false),
                        Email = c.String(),
                        MotDePasse = c.String(nullable: false),
                        NbrAvertissement = c.Int(nullable: false),
                        Filiere = c.String(),
                    })
                .PrimaryKey(t => t.AdherantCode);
            
            CreateTable(
                "dbo.Professeur",
                c => new
                    {
                        AdherantCode = c.Int(nullable: false),
                        NomComplet_Nom = c.String(),
                        NomComplet_Prenom = c.String(),
                        Image = c.String(nullable: false),
                        Email = c.String(),
                        MotDePasse = c.String(nullable: false),
                        NbrAvertissement = c.Int(nullable: false),
                        Departement = c.String(),
                        Salaire = c.Int(nullable: false),
                        Grade = c.String(),
                        DateDePriseDeFonction = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.AdherantCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livre", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.CD", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Notes", "AdherantCode", "dbo.Documents");
            DropForeignKey("dbo.Comments", "AdherantCode", "dbo.Documents");
            DropForeignKey("dbo.EmpruntLivre", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.DocAuth", "DocumentFK", "dbo.Auteurs");
            DropForeignKey("dbo.DocAuth", "AuteurFK", "dbo.Documents");
            DropForeignKey("dbo.Documents", "BibliothequeFK", "dbo.Bibliotheques");
            DropIndex("dbo.Livre", new[] { "DocumentID" });
            DropIndex("dbo.CD", new[] { "DocumentID" });
            DropIndex("dbo.Notes", new[] { "AdherantCode" });
            DropIndex("dbo.Comments", new[] { "AdherantCode" });
            DropIndex("dbo.DocAuth", new[] { "DocumentFK" });
            DropIndex("dbo.DocAuth", new[] { "AuteurFK" });
            DropIndex("dbo.EmpruntLivre", new[] { "Document_DocumentID" });
            DropIndex("dbo.Documents", new[] { "BibliothequeFK" });
            DropTable("dbo.Professeur");
            DropTable("dbo.Etudianat");
            DropTable("dbo.Livre");
            DropTable("dbo.CD");
            DropTable("dbo.Notes");
            DropTable("dbo.Comments");
            DropTable("dbo.DocAuth");
            DropTable("dbo.EmpruntLivre");
            DropTable("dbo.Auteurs");
            DropTable("dbo.Bibliotheques");
            DropTable("dbo.Documents");
            DropTable("dbo.Adresses");
        }
    }
}
