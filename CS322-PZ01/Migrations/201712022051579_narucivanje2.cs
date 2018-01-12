namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class narucivanje2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Narudzbina", "KategorijaID", c => c.Int(nullable: false));
            AddColumn("dbo.Narudzbina", "AutoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Narudzbina", "KategorijaID");
            CreateIndex("dbo.Narudzbina", "AutoID");
            AddForeignKey("dbo.Narudzbina", "AutoID", "dbo.Automobil", "AutoID", cascadeDelete: true);
            AddForeignKey("dbo.Narudzbina", "KategorijaID", "dbo.Kategorija", "KategorijaID", cascadeDelete: true);
            DropColumn("dbo.Narudzbina", "Auto");
            DropColumn("dbo.Narudzbina", "Kategorija");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Narudzbina", "Kategorija", c => c.String());
            AddColumn("dbo.Narudzbina", "Auto", c => c.String());
            DropForeignKey("dbo.Narudzbina", "KategorijaID", "dbo.Kategorija");
            DropForeignKey("dbo.Narudzbina", "AutoID", "dbo.Automobil");
            DropIndex("dbo.Narudzbina", new[] { "AutoID" });
            DropIndex("dbo.Narudzbina", new[] { "KategorijaID" });
            DropColumn("dbo.Narudzbina", "AutoID");
            DropColumn("dbo.Narudzbina", "KategorijaID");
        }
    }
}
