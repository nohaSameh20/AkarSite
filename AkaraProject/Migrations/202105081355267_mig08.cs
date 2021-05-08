namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig08 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Advertising", "UnitStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advertising", "UnitStatus", c => c.Int(nullable: false));
        }
    }
}
