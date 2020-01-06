namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Etudianat", newName: "Etudiant");
            RenameTable(name: "dbo.Adresses", newName: "Adresse");
            RenameTable(name: "dbo.Documents", newName: "Document");
            RenameTable(name: "dbo.Bibliotheques", newName: "Bibliotheque");
            RenameTable(name: "dbo.Auteurs", newName: "Auteur");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Auteur", newName: "Auteurs");
            RenameTable(name: "dbo.Bibliotheque", newName: "Bibliotheques");
            RenameTable(name: "dbo.Document", newName: "Documents");
            RenameTable(name: "dbo.Adresse", newName: "Adresses");
            RenameTable(name: "dbo.Etudiant", newName: "Etudianat");
        }
    }
}
