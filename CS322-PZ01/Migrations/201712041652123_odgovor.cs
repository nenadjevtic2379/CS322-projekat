namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class odgovor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Odgovor",
                c => new
                    {
                        OdgovorID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Odgovor = c.String(),
                        KomentarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OdgovorID)
                .ForeignKey("dbo.Komentari", t => t.KomentarID, cascadeDelete: true)
                .Index(t => t.KomentarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Odgovor", "KomentarID", "dbo.Komentari");
            DropIndex("dbo.Odgovor", new[] { "KomentarID" });
            DropTable("dbo.Odgovor");
        }
    }
}
