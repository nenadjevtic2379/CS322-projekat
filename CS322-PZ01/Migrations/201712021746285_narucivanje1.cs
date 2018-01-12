namespace CS322_PZ01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class narucivanje1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Narudzbina", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Narudzbina", "Status");
        }
    }
}
