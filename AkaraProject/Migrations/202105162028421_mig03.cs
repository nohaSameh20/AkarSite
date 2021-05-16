namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig03 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advertising", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Advertising", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Advertising", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Advertising", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advertising", "Location", c => c.String());
            AlterColumn("dbo.Advertising", "Image", c => c.String());
            AlterColumn("dbo.Advertising", "Description", c => c.String());
            AlterColumn("dbo.Advertising", "Title", c => c.String());
        }
    }
}
