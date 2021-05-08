namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertising", "UnitStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertising", "UnitStatus");
        }
    }
}
