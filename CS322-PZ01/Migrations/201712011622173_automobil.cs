namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class automobil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automobil",
                c => new
                    {
                        AutoID = c.Int(nullable: false, identity: true),
                        AutoNaziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AutoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Automobil");
        }
    }
}
