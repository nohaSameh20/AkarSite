namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        CommentId = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CommentId })
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Advertising", "Comment_Id", c => c.Guid());
            AddColumn("dbo.User", "Comment_Id", c => c.Guid());
            CreateIndex("dbo.Advertising", "Comment_Id");
            CreateIndex("dbo.User", "Comment_Id");
            AddForeignKey("dbo.Advertising", "Comment_Id", "dbo.Comment", "Id");
            AddForeignKey("dbo.User", "Comment_Id", "dbo.Comment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComments", "UserId", "dbo.User");
            DropForeignKey("dbo.UserComments", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.User", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.Advertising", "Comment_Id", "dbo.Comment");
            DropIndex("dbo.UserComments", new[] { "CommentId" });
            DropIndex("dbo.UserComments", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "Comment_Id" });
            DropIndex("dbo.Advertising", new[] { "Comment_Id" });
            DropColumn("dbo.User", "Comment_Id");
            DropColumn("dbo.Advertising", "Comment_Id");
            DropTable("dbo.Comment");
            DropTable("dbo.UserComments");
        }
    }
}
