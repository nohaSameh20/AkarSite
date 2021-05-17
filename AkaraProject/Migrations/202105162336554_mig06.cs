namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig06 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertising", "CommentId", "dbo.Comment");
            DropIndex("dbo.Advertising", new[] { "CommentId" });
            AddColumn("dbo.Comment", "AdvertisingId", c => c.Guid());
            CreateIndex("dbo.Comment", "AdvertisingId");
            AddForeignKey("dbo.Comment", "AdvertisingId", "dbo.Advertising", "Id");
            DropColumn("dbo.Advertising", "CommentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advertising", "CommentId", c => c.Guid());
            DropForeignKey("dbo.Comment", "AdvertisingId", "dbo.Advertising");
            DropIndex("dbo.Comment", new[] { "AdvertisingId" });
            DropColumn("dbo.Comment", "AdvertisingId");
            CreateIndex("dbo.Advertising", "CommentId");
            AddForeignKey("dbo.Advertising", "CommentId", "dbo.Comment", "Id");
        }
    }
}
