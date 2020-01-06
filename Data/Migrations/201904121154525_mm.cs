namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auteur", "Imageurl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auteur", "Imageurl");
        }
    }
}
