namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertising", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertising", "IsDeleted");
        }
    }
}
