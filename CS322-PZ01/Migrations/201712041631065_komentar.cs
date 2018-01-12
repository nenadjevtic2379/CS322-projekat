namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class komentar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Komentari",
                c => new
                    {
                        KomentarID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.KomentarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Komentari");
        }
    }
}
