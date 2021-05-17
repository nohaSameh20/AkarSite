namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "UserId", c => c.Guid());
            CreateIndex("dbo.Comment", "UserId");
            AddForeignKey("dbo.Comment", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropColumn("dbo.Comment", "UserId");
        }
    }
}
