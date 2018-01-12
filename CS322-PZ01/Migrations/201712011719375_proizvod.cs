namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proizvod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proizvodi",
                c => new
                    {
                        ProizvodiID = c.Int(nullable: false, identity: true),
                        ProizvodiModel = c.String(),
                        DatumProizvodnje = c.DateTime(nullable: false),
                        Cena = c.String(),
                        KategorijaID = c.Int(nullable: false),
                        AutoID = c.Int(nullable: false),
                        Slika = c.Binary(),
                    })
                .PrimaryKey(t => t.ProizvodiID)
                .ForeignKey("dbo.Automobil", t => t.AutoID, cascadeDelete: true)
                .ForeignKey("dbo.Kategorija", t => t.KategorijaID, cascadeDelete: true)
                .Index(t => t.KategorijaID)
                .Index(t => t.AutoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proizvodi", "KategorijaID", "dbo.Kategorija");
            DropForeignKey("dbo.Proizvodi", "AutoID", "dbo.Automobil");
            DropIndex("dbo.Proizvodi", new[] { "AutoID" });
            DropIndex("dbo.Proizvodi", new[] { "KategorijaID" });
            DropTable("dbo.Proizvodi");
        }
    }
}
