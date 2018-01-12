namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategorija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategorija",
                c => new
                    {
                        KategorijaID = c.Int(nullable: false, identity: true),
                        KategorijaNaziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KategorijaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kategorija");
        }
    }
}
