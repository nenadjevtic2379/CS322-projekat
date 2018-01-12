namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class narucivanje : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Narudzbina",
                c => new
                    {
                        NarudzbinaID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ProizvodiModel = c.String(),
                        Cena = c.String(),
                        Auto = c.String(),
                        Kategorija = c.String(),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NarudzbinaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Narudzbina");
        }
    }
}
